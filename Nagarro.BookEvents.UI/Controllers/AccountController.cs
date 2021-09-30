
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Nagarro.BookEvents.UI;
using Nagarro.BookEvents.Shared;
using Nagarro.BookEvents.EntityDataModel;
using Nagarro.BookEvents.UI.Models;

namespace Nagarro.BookEvents.UI.Controllers
{
 
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
           
            return View("LoginUser");
        }

        public ActionResult CreateUser()
        {
            return View();
        }

  

        [HttpPost]
        public ActionResult CreateUser(RegisterUser model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDTO = new UserDTO();
                EntityConverter.FillDTOFromEntity(model, userDTO);
                if (model.Email == "myadmin@bookevents.com")
                {
                    userDTO.Role = "admin";
                }
                else
                {
                    userDTO.Role = "normal";
                }
                IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
                OperationResult<UserDTO> result = userFacade.CreateUser(userDTO);
                if (result.ResultType == OperationResultType.Failure)
                {
                    ModelState.AddModelError("", result.Message);
                    return View();
                }
            }
            ModelState.Clear();
            return RedirectToAction("LoginUser");
        }
    
        public ActionResult LoginUser()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LoginUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDTO = new UserDTO();
                EntityConverter.FillDTOFromEntity(model, userDTO);
                IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
                OperationResult<UserDTO> result = userFacade.LoginUser(userDTO);
                if (result.ResultType == OperationResultType.Failure)
                {
                    ModelState.AddModelError("", result.Message);
                    return View();
                }
                if (result.IsValid())
                {
                    FormsAuthentication.SetAuthCookie(result.Data.FullName + "|" + result.Data.Id + "|" + result.Data.Role, false);
                    return RedirectToAction("Index", "User");
                }

            }
            ModelState.AddModelError("",Constant.WrongEmailOrPassword);
            return View();
           
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginUser");
        }
    }
}