using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OutputCaching;
using ShoeWebApp.Models;

namespace ShoeWebApp.Controllers
{
    
    public class UserController : Controller
    {
        [Authorize("Admin")]
        [HttpGet]
        [ActionName("getData")]
        public IActionResult List()
        {
            IList<UserViewModel> ulist = new List<UserViewModel>();
            ulist.Add(new UserViewModel {UserFirstName="Kalrav", UserLastName="Pavadia", UserId=1, UserEmail="abc@gmail.com", UserPassword="aaa", UserPhone="123" });

            return View(ulist);
        }

        [OutputCache(Duration =1000)]
        [HttpPost("getListById")]
        public IActionResult List(int id) {

            return View();
        
        }

        public IActionResult Edit()
        {
            UserViewModel user = new UserViewModel();
            user.UserFirstName = "Kalrav";
            user.UserLastName = "Pavadia";
            user.UserId = 1;
            user.UserEmail = "abc@gmail.com";
            user.UserPassword = "aaa";
            user.UserPhone = "123";
            return View();

        }

        public IActionResult Login()
        {
            UserViewModel user = new UserViewModel();
            
            return View(user);
        }

        public IActionResult Register()
        {

            return View();
        }

        [ActionName("save")]
        public IActionResult Save([FromRoute] int id, [FromForm] UserViewModel user)
        {
            if (ModelState.IsValid) { }
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update(IFormCollection user)
        {

            return RedirectToAction("Login");
        }


    }
}
