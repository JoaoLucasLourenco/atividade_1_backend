using Atividade1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atividade1.Controllers
{
    public class ConvidadoController : Controller
    {
        public static IList<Convidado> convidados = new List<Convidado>()
        {
            new Convidado() { Id = 1,Nome="João Lucas Lourenço", Telefone="35997275693",EMail="jao.lucas@gmail.com",comparecimento=false}
        };


        public IActionResult Index()
        {
            return View(convidados);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Convidado convidado)
        {
            convidado.Id = convidados.Select(conv => conv.Id).Max() + 1;
            convidados.Add(convidado);
            return RedirectToAction("Index");
        }


        public IActionResult Details(long id)
        {
            return View(convidados.Where(conv => conv.Id == id).First());
        }


        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Convidado convidado)
        {
            convidados.Remove(convidados.Where(conv => conv.Id == convidado.Id).First());
            convidados.Add(convidado);
            return RedirectToAction("Index");
        }

        

        public IActionResult Delete(int id)
        {
            return View(convidados.Where(conv => conv.Id == id).First());
        }
        [HttpPost]
        public IActionResult Delete(Convidado convidado)
        {
            convidados.Remove(convidados.Where(conv => conv.Id == convidado.Id).First());
            return RedirectToAction("Index");
        }



        public IActionResult SortByConfirmation()
        {
            return View(convidados.Where(conv => conv.comparecimento == true));
        }

        public IActionResult SortByNotConfirmation()
        {
            return View(convidados.Where(conv => conv.comparecimento == false));
        }
    }
}
