using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServerValidation.Models;

namespace ServerValidation.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private static Users users = new Users();
        public ActionResult Index()
        {
            return View(users.userList);
        }
        public ActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserAdd(UserModel userModel)
        {
            users.CreateUser(userModel);
            return View("Index", users.userList);
        }
    }
}