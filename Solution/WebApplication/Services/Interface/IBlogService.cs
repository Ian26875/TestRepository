using System.Collections.Generic;
using WebApplication.ViewModels;

namespace WebApplication.Services.Interface
{
    public interface IBlogService
    {
        IEnumerable<BlogViewModel> GetAllArticle();
        IEnumerable<BlogViewModel> GetAllArticle(int year, int month);
    }
}