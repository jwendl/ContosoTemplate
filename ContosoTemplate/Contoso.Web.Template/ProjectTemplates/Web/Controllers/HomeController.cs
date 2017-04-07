using $rootprojectname$.Business.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace $safeprojectname$.Controllers
{
    public class HomeController 
        : Controller
    {
        private ICustomerService CustomerService { get; set; }

        public HomeController(ICustomerService customerService)
        {
            CustomerService = customerService;
        }

        public async Task<ActionResult> Index()
        {
            var customers = await CustomerService.FetchCustomerNamesAsync();
            return View(customers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}