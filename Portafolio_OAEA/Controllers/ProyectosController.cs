using Microsoft.AspNetCore.Mvc;
using Portafolio_OAEA.Datos;
using Portafolio_OAEA.Models;

namespace Portafolio_OAEA.Controllers
{
    public class ProyectosController : Controller
    {
        ProyectosDatos proyectosDatos = new ProyectosDatos();
        public IActionResult MisProyectos()
        {
            var lista = proyectosDatos.Listar();
            return View(lista);
        }
    }
}
