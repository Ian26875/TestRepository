using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;
using WebApplication.ViewModels;

namespace WebApplication.Services
{
    public class BlogService
    {
        private MyForumEntities db;

        public BlogService()
        {
            db = new MyForumEntities();
        }

        /// <summary>
        /// 抓取前3個月的所有文章
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BlogViewModel> GetAllArticle()
        {
            DateTime dateTime = DateTime.Now.AddMonths(-3);
            return GetAllArticle(dateTime.Year, dateTime.Month);
        }

        /// <summary>
        /// 抓取指定年月的文章
        /// </summary>
        /// <param name="year">西元年</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public IEnumerable<BlogViewModel> GetAllArticle(int year, int month)
        {
            var viewModels = new HashSet<BlogViewModel>();
            var articles = db.Article.Where(x => x.CreateTime.Year.Equals(year) && x.CreateTime.Month.Equals(month));
            foreach (var article in articles)
            {
                BlogViewModel blog = new BlogViewModel
                {
                    Content = article.Content,
                    CreatTime = article.CreateTime,
                    Kind = article.Tag,
                    Title = article.Title
                };
                viewModels.Add(blog);
            }
            return viewModels;
        }
    }
}