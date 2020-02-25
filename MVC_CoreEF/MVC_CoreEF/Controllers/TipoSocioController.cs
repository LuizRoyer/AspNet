using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CoreEF.Models;
using System.Linq;

namespace MVC_CoreEF.Controllers
{
    public class TipoSocioController : Controller
    {
        private AlunoContext context;
        public TipoSocioController(AlunoContext _alunoContext)
        {
            context = _alunoContext;
        }
        public IActionResult Index()
        {
            var infoAluno = context.Alunos.Include(tp => tp.TipoSocio);
                return View(infoAluno);
        }
    }
}