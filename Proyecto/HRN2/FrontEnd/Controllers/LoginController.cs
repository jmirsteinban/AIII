using BackEnd.DAL;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FrontEnd.Controllers
{
    public class LoginController : Controller
    {


        private IUserDAL userDAL;

        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Autherize(UserViewModel userModel)
        {

            userDAL = new UserDALImpl();
            var userDetails = userDAL.getUser(userModel.UserName, userModel.Password);

            if (userDetails == null)
            {
                userModel.LoginErrorMessage = "Nombre de Usuario o Password Incorrectos";
                return View("Index", userModel);
            }
            else
            {

                Session["userID"] = userDetails.userID;
                Session["userName"] = userDetails.usuario;
                Session["userName2"] = userDetails.primer_nombre_user+" "+userDetails.primer_apellido_user;
                var authTicket = new FormsAuthenticationTicket(userDetails.usuario, true, 100000);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                            FormsAuthentication.Encrypt(authTicket));
                Response.Cookies.Add(cookie);
                var name = User.Identity.Name; // line 4
                return RedirectToAction("Index", "Sales");
            }
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Clear();
            Session.Abandon();



            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);
            return RedirectToAction("Index", "Login");
        }
    }
}