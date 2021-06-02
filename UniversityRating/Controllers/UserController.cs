using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityRating.Models;
using BLL;
using System.IO;
using Common;
using System.Text.RegularExpressions;

namespace UniversityRating.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserLogic userLogic;

        public UserController(IUserLogic userLogic)
        {
            this.userLogic = userLogic;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var res = this.userLogic.GetAllUsers();
                if (this.userLogic.GetAllUsers().Any(u => u.Login == model.Login && u.Password == model.Password))
                {
                    using (FileStream fstream = new FileStream($"user.txt", FileMode.OpenOrCreate))
                    {
                        byte[] array = System.Text.Encoding.Default.GetBytes("autorized");
                        fstream.Write(array, 0, array.Length);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Bad login/password");
                    return this.View(model);
                }
            }

            return this.View(model);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return this.View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterVM model)
        {
            List<string> errors = this.CheckLoginPassword(model.Login, model.Password).ToList();
            if (ModelState.IsValid && !this.userLogic.GetAllUsers().Any(u => u.Login == (model.Login?.ToUpper() ?? string.Empty)))
            {
                if (errors.Count != 0)
                {
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }

                    return this.View(model);
                }
                else
                {
                    this.userLogic.AddUser(new User { Login = model.Login.ToUpper(), Password = model.Password, Role = "User" });
                    using (FileStream fstream = new FileStream($"user.txt", FileMode.OpenOrCreate))
                    {
                        byte[] array = System.Text.Encoding.Default.GetBytes("autorized");
                        fstream.Write(array, 0, array.Length);
                    }

                    return this.RedirectToAction("Index", "Home");
                }
            }

            return this.View(model);
        }

        public ActionResult Logout()
        {
            // запись в файл
            using (FileStream fstream = new FileStream($"note.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes("");
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
            }
            return this.RedirectToAction("Index", "Home");
        }

        private ICollection<string> CheckLoginPassword(string login, string password)
        {
            List<string> errors = new List<string>();
            if (login == null || password == null)
            {
                errors.Add("Invalid login or password");
                return errors;
            }

            if (login.Length == 0 || password.Length == 0)
            {
                errors.Add("Invalid login or password");
                return errors;
            }

            if (!Regex.IsMatch(login, @"(^[A-Za-z]([_]{0,1}[A-Za-z0-9]+)*([_]{0,1}[A-Za-z0-9]+$))|(^[A-Za-z]$)"))
            {
                errors.Add("Login is not corrected!");
                return errors;
            }

            if (!Regex.IsMatch(password, @"(^[A-Za-z]([_]{0,1}[A-Za-z0-9]+)*([_]{0,1}[A-Za-z0-9]+$))|(^[A-Za-z]$)"))
            {
                errors.Add("Password is not corrected!");
                return errors;
            }

            if (password.Contains(login))
            {
                errors.Add("Password is not corrected!");
                return errors;
            }

            return errors;
        }

        //// GET: UserController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: UserController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: UserController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: UserController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UserController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: UserController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UserController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: UserController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
