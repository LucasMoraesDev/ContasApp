using Microsoft.AspNetCore.Mvc;

namespace ContasApp.Presentation.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Método para abrir a página /Home/Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
