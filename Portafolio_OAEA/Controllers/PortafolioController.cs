using Microsoft.AspNetCore.Mvc;
using Portafolio_OAEA.Datos;
using Portafolio_OAEA.Models;

namespace Portafolio_OAEA.Controllers
{
    public class PortafolioController : Controller
    {
        PortafolioDatos portafolioDatos = new PortafolioDatos();
        public IActionResult ListarP()
        {
            var lista = portafolioDatos.Listar();
            return View(lista);
        }


        


    }

  
}

