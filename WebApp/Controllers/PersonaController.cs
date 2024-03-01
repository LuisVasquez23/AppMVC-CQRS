using Application.Services.Persona;
using Domain.ViewModels.Persona;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PersonaController : Controller
    {
        private IPersonaServices _personaServices;

        public PersonaController(IPersonaServices personaServices) { 
            _personaServices = personaServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ListPersonas = await _personaServices.GetPersonas();

            ViewBag.ListPersonas = ListPersonas;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int IdPersona)
        {
            PersonaViewModel persona = await _personaServices.GetPersonaById(IdPersona);

            ViewBag.Persona = persona;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(PersonaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isUpdateded = await _personaServices.UpdatePersona(model);

            TempData["estado"] = "error";
            TempData["mensaje"] = "No se pudo actualizar";

            if (isUpdateded)
            {
                TempData["estado"] = "success";
                TempData["mensaje"] = "Actualizado correctamente";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Crear() { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(PersonaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isAdded = await _personaServices.CreatePersona(model);

            TempData["estado"] = "error";
            TempData["mensaje"] = "No se pudo crear";

            if (isAdded)
            {
                TempData["estado"] = "success";
                TempData["mensaje"] = "Agregado correctamente";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int IdPersona)
        {
            bool isDeleted = await _personaServices.DeletePersona(IdPersona);

            TempData["estado"] = "error";
            TempData["mensaje"] = "No se pudo eliminar";

            if (isDeleted)
            {
                TempData["estado"] = "success";
                TempData["mensaje"] = "Eliminado correctamente";
            }

            return RedirectToAction("Index");
        }
    }
}
