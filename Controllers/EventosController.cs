using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExerciciosPadraoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExerciciosPadraoMVC.Controllers
{
    public class EventosController : Controller
    {
        private static List<Evento> _eventos = new()
        {
          new Evento {Id = 1, Nome = "CASE 2026 (Conferência Anual de Startups e Empreendedorismo)", Descricao = "13ª edição organizada pela ABStartups com palestras, painéis, feira de startups, mentorias e networking voltados a inovação e empreendedorismo.", Local = "FEA-USP, São Paulo", DataEvento = new (2026, 11, 26), QuantidadeVagas = 1000, ValorIngresso = 0m},

          new Evento {Id = 2, Nome = "Primavera Sound São Paulo 2026", Descricao = "Festival com quatro palcos e cerca de 40 atrações, incluindo The Strokes, Gorillaz, FKA twigs, Lily Allen, Arca e Gaby Amarantos.", Local = "Av. Sen. Teotônio Vilela, 261 – Jardim Malia I, Interlagos, São Paulo – SP", DataEvento = new (2026, 11, 05), QuantidadeVagas = 1000, ValorIngresso = 483m},
          
          new Evento {Id = 3, Nome = "Mystic Fair", Descricao = "Festival com quatro palcos e cerca de 40 atrações, incluindo The Strokes, Gorillaz, FKA twigs, Lily Allen, Arca e Gaby Amarantos.", Local = "São Paulo Expo (Pavilhão 8), localizado na Rodovia dos Imigrantes, km 1,5, Vila Água Funda, São Paulo - SP", DataEvento = new (2026, 12, 12), QuantidadeVagas = 35, ValorIngresso = 40m}
        };
        
        public IActionResult Index()
        {
            return View(_eventos);
        }

        public IActionResult Detalhes(int id)
        {
            var evento = _eventos.FirstOrDefault(a => a.Id == id);
            if (evento == null)
                return NotFound();

            return View(evento);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Evento evento)
        {
            if (!ModelState.IsValid)
                return View(evento);

            evento.Id = _eventos.Any() ? _eventos.Max(a => a.Id) + 1 : 1;
            _eventos.Add(evento);

            return RedirectToAction("Index");
        }
    }
}