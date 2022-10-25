using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using destinocerto.Models;

namespace destinocerto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        decpacote pacote = new decpacote();
        ViewBag.nome = pacote.Nome;
         Pacote pacot = new Pacote();
            List<decpacote> lista = pacot.Ordenar();
        return View(lista);
    }

    public IActionResult Privacy()
    { 
      
        return View();
    }
    [HttpPost]
     public IActionResult CadPacote(Usuariodatabase usuario)
    {   
         Usuario usr = new Usuario();
         usr.cadastrar(usuario);
       return View();
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
