using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aula31_Filters.Models;
using Aula31_Filters.Filtros;

namespace Aula31_Filters.Controllers
{
    public class HomeController : Controller
    {[SaudacaoFilter]
        public IActionResult Index()
        {
            ViewData["Menssage"] = "Pagina Index";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Pagina About.";
            throw new Exception("Ocorreu um erro no metódo Action About");
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Pagina Contact";
            throw new Exception("Ocorreu um erro no metódo Action Contact");
            return View();
        }
    
    
    }
}
