using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_CoreEF.Models;

namespace MVC_CoreEF.Controllers
{
    public class TesteController : Controller
    {
        private AlunoContext _context;
        public TesteController(AlunoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var alunos = _context.Alunos.ToList().OrderBy(a => a.Nome);
            return View(alunos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Nome,Sexo,Email,DataNascimento")]Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Aluno aluno = _context.Alunos.SingleOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nome,Sexo,Email,DataNascimento")]Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    if (!GetAsExists(aluno.Id))
                    {
                        return NotFound();
                    }
                    throw new Exception(e.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }
        private bool GetAsExists(int id)
        {
            return _context.Alunos.Any(a => a.Id == id);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Aluno aluno = _context.Alunos.SingleOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            Aluno aluno = _context.Alunos.SingleOrDefault(a => a.Id == id);
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                NotFound();

            Aluno aluno = _context.Alunos.SingleOrDefault(a => a.Id == id);

            if (aluno == null)
                NotFound();

            return View(aluno);
        }
    }
}