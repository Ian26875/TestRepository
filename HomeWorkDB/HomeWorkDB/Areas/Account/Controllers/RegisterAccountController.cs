using HomeWorkDB.Areas.Account.Models.ViewModel;
using HomeWorkDB.Areas.Account.Service;
using HomeWorkDB.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace HomeWorkDB.Areas.Account.Controllers
{
    public class RegisterAccountController : Controller
    {
 
        private IUnitOfWork _UnitOfWork;
        private RegisterAccountService serivce;

        public RegisterAccountController()
        {
            _UnitOfWork = new UnitOfWork();
            serivce = new RegisterAccountService(_UnitOfWork);
        }

        // GET: Account/RegisterAccount
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult AccountLists()
        {
            return PartialView("_AccountLists", serivce.GetAllAccountViewModels().OrderBy(x => x.Date));
        }
        [HttpPost]
        public ActionResult Insert(
            [Bind(Include = "Number,Category,Date,Amount,Description")]
        AccountInsertViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                serivce.InsertAccount(viewModel);
                int affectCount=_UnitOfWork.SaveChanges();
                if (affectCount > 0)
                {

                }
            }
            return RedirectToAction("Index");
        }
    }
}