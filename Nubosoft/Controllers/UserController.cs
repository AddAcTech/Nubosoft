﻿using Nubosoft.Context;
using Nubosoft.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Nubosoft.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            {
                using (AppDbContext context = new AppDbContext())
                {
                    var users = context.Users.ToList();
                    return View(users);
                }
            }
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null || id <= 0)
                return RedirectToAction("Index");

            using (AppDbContext context = new AppDbContext())
            {
                var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
                return View(user);
            }
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            using (AppDbContext context = new AppDbContext())
            {
                // Validación de email duplicado
                var emailExistente = context.Users.Any(u => u.Email == user.Email);
                if (emailExistente)
                {
                    ModelState.AddModelError("Email", "Este correo electrónico ya está registrado.");
                    return View(user);
                }

                if (ModelState.IsValid)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(user);
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
                return RedirectToAction("Index");

            using (AppDbContext context = new AppDbContext())
            {
                var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
                return View(user);
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, User user)
        {
            if (id == null || id <= 0)
                return RedirectToAction("Index");

            using (AppDbContext context = new AppDbContext())
            {
                // Validación de email duplicado (excluyendo el usuario actual)
                var emailExistente = context.Users
                    .Any(u => u.Email == user.Email && u.Id != user.Id);

                if (emailExistente)
                {
                    ModelState.AddModelError("Email", "Este correo electrónico ya está registrado por otro usuario.");
                    return View(user);
                }

                if (ModelState.IsValid)
                {
                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(user);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
                return RedirectToAction("Index");

            using (AppDbContext context = new AppDbContext())
            {
                var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
                return View(user);
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            if (id == null || id <= 0)
                return RedirectToAction("Index");
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    User user = context.Users.Where(u => u.Id == id).FirstOrDefault();
                    if (user != null)
                    {
                        context.Users.Remove(user);
                        context.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
