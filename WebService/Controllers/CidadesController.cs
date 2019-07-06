using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebService.Models;

namespace WebService.Controllers
{
    public class CidadesController : Controller
    {
        private readonly Context _context;

        public CidadesController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            return View(_context.Cidades.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ConsultarEndereco(Cidade cep)
        {
            
            WebClient client = new WebClient();
            string json = client.DownloadString("https://viacep.com.br/ws/" + cep.Cep + "/json/");
            Cidade cidade = JsonConvert.DeserializeObject<Cidade>(json);

            _context.Cidades.Add(cidade);
            _context.SaveChanges();
            
                //gravar o objeto no banco
            return RedirectToAction("ListCidade");
        }

        public IActionResult btnConsultareCadastrar(Cidade cidade)
        {
            _context.Cidades.Update(cidade);
            _context.SaveChanges();

            return RedirectToAction("ListCidade");
        }

        public IActionResult ListCidade()
        {
            return View(_context.Cidades.ToList());
        }
    }
}