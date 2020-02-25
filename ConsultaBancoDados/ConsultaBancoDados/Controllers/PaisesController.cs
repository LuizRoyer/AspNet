using ConsultaBancoDados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace ConsultaBancoDados.Controllers
{
    public class PaisesController : Controller
    {
        private readonly AplicacaoContext _context;

        public PaisesController(AplicacaoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Pais> listaPaises = new List<Pais>();

            //----pega dados da tabela
           // listaPaises = (from pais in _context.Paises
             //              select pais).ToList();

            // Inser um item na lista
            listaPaises.Insert(0, new Pais { Id = 0, Nome = "Selecione" });
            listaPaises.Insert(1, new Pais { Id = 1, Nome = "Teste" });
            listaPaises.Insert(2, new Pais { Id = 2, Nome = "Brasil" });
            ViewBag.ListaPaises = listaPaises;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Pais pais)
        {
            if (pais.Id == 0)
            {
                ModelState.AddModelError("", "Selecione um pais");
            }

            ViewBag.ValorSelecionado = pais.Id;

            List<Pais> listaPaises = new List<Pais>();

            //----pega dados da tabela
            //listaPaises = (from p in _context.Paises
            //               select p).ToList();

            // Inser um item na lista
            listaPaises.Insert(0, new Pais { Id = 0, Nome = "Selecione" });
            ViewBag.ListaPaises = listaPaises;
            return View();
        }

    }
}