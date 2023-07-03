using Microsoft.AspNetCore.Mvc;

namespace ContasApp.Presentation.Controllers
{
    /// <summary>
    /// /classe de controle do Asp.Net MVC
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// Método para abrir a página /Account/Login
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Método para abrir a página /Account/Register
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Método para abrir a página /Account/ForgotPassword
        /// </summary>
        /// <returns></returns>
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
