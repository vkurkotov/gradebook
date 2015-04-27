﻿using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Gradebook.Business.Interfaces;
using Gradebook.Business.Public_Data_Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Gradebook.Web.Models;

namespace Gradebook.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserService _userService;
        
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return null;
        }


        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var modelDto = new TeacherDto
                    {
                        FirstName = model.FirstName,
                        Email = model.Email,
                        BirthDate = model.BirthDate,
                        IsAdministrator = model.IsAdministrator,
                        LastName = model.LastName,
                        MiddleName = model.MiddleName,
                        Password = model.Password,
                        UserType = model.UserType
                    };

                    _userService.CreateTeacher(modelDto);
                }
            }
            catch (Exception e)
            {
                ViewBag.Exception = e;
            }
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }
    }
}