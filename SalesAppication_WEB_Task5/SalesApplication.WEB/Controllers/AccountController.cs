namespace SalesApplication.WEB.Controllers
{
    using System.Web.Mvc;
    using System.Web.Security;
    using BLL.Models;
    using BLL.Services;
    using Constants;
    using Models;

    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController()
        {
            _userService = new UserService("SalesDB");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //Serach User on db
                var user = _userService.GetByEMail(model.Name);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", ErrorMessages.EmailOrPasswordErrorMassage);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetByEMail(model.Name);

                if (user == null)
                {
                    // create user
                    _userService.Add(new UserModel {Email = model.Name, Password = model.Password});
                    user = _userService.GetByEMailAndPassword(model.Name, model.Password);
                    // if user created on db
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError("", ErrorMessages.UserCreationErrorMessage);
                }
                else
                {
                    ModelState.AddModelError("", ErrorMessages.UserAlreadyExistsErrorMessage);
                }
            }

            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}