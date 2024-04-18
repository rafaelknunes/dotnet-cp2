using FIAP_MVC.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using FIAP_MVC.Data;

namespace FIAP_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _dataContext;

        public AccountController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = _dataContext.MVC_Users
                    .FirstOrDefault(u => u.UserEmail == model.Email && u.UserPassword == model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("LoginFailed", "E-mail ou senha inválida!");
                    return View(model);
                }

                TempData["UserDetails"] = JsonSerializer.Serialize(user);
                return RedirectToAction("UserProfile");
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult UserProfile()
        {
            if (TempData["UserDetails"] is string serializedUser)
            {
                var user = JsonSerializer.Deserialize<User>(serializedUser);
                if (user != null)
                {
                    return View(user);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult SetEdit(int id, string field)
        {
            ViewBag.EditMode = true;
            ViewBag.EditField = field;
            var user = _dataContext.MVC_Users.Find(id);
            return View("UserProfile", user);
        }

        [HttpPost]
        public IActionResult EditUser(int id, string phone)
        {
            var user = _dataContext.MVC_Users.Find(id);
            if (user != null)
            {
                user.UserPhone = phone;
                _dataContext.SaveChanges();
                TempData["SuccessMessage"] = "Telefone atualizado com sucesso!";
                return RedirectToAction("UserProfile", new { id = user.Id });
            }
            TempData["ErrorMessage"] = "Usuário não encontrado.";
            return RedirectToAction("Index");
        }


    }
}
