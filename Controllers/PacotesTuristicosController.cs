using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using destinocerto.Models;
using Microsoft.AspNetCore.Mvc;

namespace destinocerto.Controllers
{
    public class PacotesTuristicosController : Controller
    {
        public IActionResult CadPacote(){
            return View();
        }
         
         [HttpPost]
         public IActionResult CadPacote(decpacote pacote){
            Pacote pac = new Pacote();
            pac.cadastrar(pacote);
            ViewBag.msg = "Pacote cadsatrado com sucesso";
            return View();
        }
          public IActionResult DeletePacote(){
          
             
            return View();
        }
        [HttpPost]
        public IActionResult DeletePacote(decpacote pacote){
            Pacote pac = new Pacote();
             pac.Delete(pacote);
             ViewBag.msg  ="Deletado com sucesso";
            return View();
        }
        public IActionResult EditPacote(){
          
             
            return View();
        }

        [HttpPost]
        public IActionResult EditPacote(decpacote pacote){
          
               Pacote pac = new Pacote();
             pac.Update(pacote);
             ViewBag.msg  ="Editado com sucesso";
            return View();
        }
         public IActionResult LiPacote(){
        Pacote pac = new Pacote();
             List<decpacote> lista = pac.Ordenar();
             
            return View(lista);
        }
    }
}