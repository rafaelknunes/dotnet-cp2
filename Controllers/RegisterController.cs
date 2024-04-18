using FIAP_MVC.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace FIAP_MVC.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly DataContext _dataContext;

        public RegisterController(ILogger<RegisterController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        // Retonar a página Index da View Register
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(RegisterDTO request)
        {
            if (ModelState.IsValid)
            {
                if (_dataContext.MVC_Users.Any(x => x.UserEmail == request.UserEmail))
                {
                    TempData["ErrorMessage"] = "Usuário já existe com este email";
                    TempData["UserData"] = JsonSerializer.Serialize(request); // Serializa o DTO para JSON
                    return RedirectToAction("RegisterError");
                }

                var newUser = new User
                {
                    UserName = request.UserName,
                    UserEmail = request.UserEmail,
                    UserPassword = request.UserPassword,
                    UserPhone = request.UserPhone
                };

                _dataContext.Add(newUser);
                _dataContext.SaveChanges();

                TempData["SuccessMessage"] = "Cadastro efetuado com sucesso!";
                TempData["UserData"] = JsonSerializer.Serialize(request);
                return RedirectToAction("RegisterSuccess");
            }
            return View(request);
        }

        [HttpGet]
        public IActionResult RegisterSuccess()
        {
            if (TempData["UserData"] is string serializedUserData)
            {
                var userData = JsonSerializer.Deserialize<RegisterDTO>(serializedUserData); // Desserializa o JSON de volta para o DTO
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
                return View(userData);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult RegisterError()
        {
            // Tentativa de recuperar e desserializar os dados do usuário
            if (TempData["UserData"] is string serializedUserData)
            {
                var userData = JsonSerializer.Deserialize<RegisterDTO>(serializedUserData);
                if (userData != null)
                {
                    ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;
                    return View(userData);
                }
            }
            // Redireciona para a página de registro se não houver dados válidos ou dados em TempData
            return RedirectToAction("Index");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
