using Microsoft.AspNetCore.Mvc;
using Crud_Aluno.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Crud_Aluno.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            AlunoBll alunoBll = new AlunoBll();

            List<Aluno> listaAlunos = alunoBll.GetAlunos().ToList();

            return View("Lista", listaAlunos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Aluno aluno)
        {
            //if (string.IsNullOrWhiteSpace(aluno.Nome))
            //    ModelState.AddModelError("Nome", "Campo Obrigatorio");

            //if (string.IsNullOrWhiteSpace(aluno.Sexo))
            //    ModelState.AddModelError("Sexo", "Campo Obrigatorio");

            //if (aluno.DataNascimento <= DateTime.Now.AddYears(-100))
            //    ModelState.AddModelError("DataNascimento", "Campo Invalido");

            if (!ModelState.IsValid)
            {
                return View();
            }

            AlunoBll alunoBll = new AlunoBll();
            alunoBll.IncluirAluno(aluno);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            AlunoBll alunoBll = new AlunoBll();
            Aluno aluno = alunoBll.GetAlunos().Single(X => X.Id == id);

            return View(aluno);
        }
        [HttpPost]
        public IActionResult Edit(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                AlunoBll alunoBll = new AlunoBll();
                alunoBll.AtualizarAluno(aluno);
                return RedirectToAction("Index");
            }

            return View(aluno);
        }
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    AlunoBll alunoBll = new AlunoBll();
        //    Aluno aluno = alunoBll.GetAlunos().Single(a => a.Id == id);

        //    return View(aluno);
        //}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            AlunoBll alunoBll = new AlunoBll();
            alunoBll.DeletarAluno(id);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            AlunoBll alunoBll = new AlunoBll();
            Aluno aluno = alunoBll.GetAlunos().Single(a => a.Id == id);

            return View(aluno);
        }

        public IActionResult Procurar(string ProcurarPor, string criterio)
        {
            switch (ProcurarPor)
            {                
                case "Nome":
                    {
                        Aluno aluno = new AlunoBll().GetAlunos().SingleOrDefault(a => a.Nome == criterio);
                        return View(aluno);
                    }
                case "Email":
                    {
                        Aluno aluno = new AlunoBll().GetAlunos().SingleOrDefault(a => a.Email == criterio);
                        return View(aluno);
                    }
                default:
                    return RedirectToAction("Index");
            }

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
