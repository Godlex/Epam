namespace SalesApplication.WEB.Controllers
{
    using System.Web.Mvc;
    using System.Web.Security;
    using BLL.Models;
    using BLL.Services;
    using DAL.Entities;
    using Models;

    public class AccountController : Controller
    {
        private readonly UserService _userService;
        
        public AccountController(UserService userService)
        {
            _userService = userService;
        }
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
                User user = null;
                
                //Serach User on db

                user = _userService.GetByEMail(model.Name);
                
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The email or password is incorrect");
                }
            }
 
            return View(model);
        }
 
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                User user = null;
                
                user = _userService.GetByEMail(model.Name);
                
                if (user == null)
                {
                    // создаем нового пользователя
                    _userService.Add(model.Name,model.Password);
                    user = _userService.GetByEMailAndPassword(model.Name, model.Password);
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "User creation error");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User with this login already exists");
                }
            }
 
            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}