using EstoqueWEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EstoqueWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Controle_EstoqueContext _context;

        public HomeController(ILogger<HomeController> logger, Controle_EstoqueContext contexto)
        {
            _logger = logger;
            _context = contexto;
        }

        public IActionResult Index()
        {   
            ViewBag.Home = _context.TotalProdutosEstoques.ToList();
            return View();
        }

        public IActionResult CadastrarProdutos()
        {
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