using Nubosoft.Context;
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
        public ActionResult Details(int id)
        {            
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
        public ActionResult Create(User users)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    if (ModelState.IsValid)
                    {
                        context.Users.Add(users);
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
                return View(user);
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User users)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    if (ModelState.IsValid)
                    {
                        context.Entry(users).State = EntityState.Modified;
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
                return View(user);
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
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
