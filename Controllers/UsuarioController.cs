using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using destinocerto.Models;
using Microsoft.AspNetCore.Mvc;

namespace destinocerto.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Login(){
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuariodatabase usuario){
            Usuario user = new Usuario();
                Usuariodatabase usercon =  user.Validar(usuario);

                if(usercon.Nome != null && usercon.senha != null){
                    ViewBag.msg = "logado";
                     

                   return Redirect("Cadastrar");
                }
                else if(usuario.Nome == "joao" && usuario.senha == "1234"){
                    return Redirect("CadPacote");
                } 
                else{
                    return View();
                    ViewBag.msg = "falha login";
                }
        
        }
         public IActionResult Cadastrar(){
           
            return View();
        }
        [HttpPost]
          public IActionResult Cadastrar(Usuariodatabase usuario){
             Usuario user = new Usuario();
            user.cadastrar(usuario);
            user.Listar();
            ViewBag.msg = "Cadastrado com sucesso";
            return View();
        }
         public IActionResult Editar(){
           
            return View();
        }
        [HttpPost]
        public IActionResult Editar(Usuariodatabase usuario){
            Usuario user = new Usuario();
            user.Editar(usuario);
            ViewBag.msg = "Editado";
            return View();
        }
        public IActionResult Deletar(){
           
            return View();
        }
        [HttpPost]
        public IActionResult Deletar(Usuariodatabase usuario){
            Usuario user = new  Usuario();
            user.Deletar(usuario);
            ViewBag.msg = "deletado";
            return View();
        }
        
        
        public IActionResult Listar(){
             Usuario user = new Usuario();
             List<Usuariodatabase> lista = user.Listar();
             Pacote pacote = new Pacote();
            List<decpacote> decpacotes = pacote.Ordenar();
            return View(lista);
        }
    
        
      
        
    }
}