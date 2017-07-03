using HomeWorkDB.Areas.Account.Models.ViewModel;
using HomeWorkDB.Models;
using HomeWorkDB.Repositories;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Web;
using HomeWorkDB.Areas.Account.Models;

namespace HomeWorkDB.Areas.Account.Service
{
    public class RegisterAccountService
    {
        private IUnitOfWork _unitOfWork;

        private IRepository<AccountBook> repository;

        public RegisterAccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            repository = new Repository<AccountBook>(_unitOfWork);
        }

        public IEnumerable<AccountViewModel> GetAllAccountViewModels()
        {
            List<AccountBook> dbModels = repository.GetAll().ToList();
            List<AccountViewModel> viewModels = new List<AccountViewModel>();
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.CreateMap<AccountBook, AccountViewModel>()
                .ForMember(
                    x => x.Category,
                    y => y.MapFrom(s => ChangeCategoryName(s.Categoryyy))
                    )
               .ForMember(
                    x => x.Number,
                    y => y.MapFrom(s => s.Id.ToString())
                    )
               .ForMember(
                    x => x.Amount,
                    y => y.MapFrom(s => s.Amounttt)
                    )
               .ForMember(
                    x => x.Date,
                    y => y.MapFrom(s => s.Dateee)
                    )
                    );

            var mapper = config.CreateMapper();
            viewModels = mapper.Map<List<AccountViewModel>>(dbModels);
            return viewModels;
        }
        private string ChangeCategoryName(int CategoryType)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>()
            {
                {0,"支出" },
                {1,"收入" },
            };
            return dictionary[CategoryType];
        }
        public bool InsertAccount(AccountInsertViewModel viewModel)
        {
            var model = new AccountBook
            {
                Amounttt = viewModel.Amount,
                Categoryyy = (int)viewModel.Category,
                Dateee = viewModel.Date,
                Id = Guid.NewGuid(),
                Remarkkk = viewModel.Description
            };
            repository.Insert(model);
            return true;
        }
    }
}