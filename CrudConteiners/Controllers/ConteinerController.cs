using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudConteiners.Data;
using CrudConteiners.Models;
using CrudConteiners.Interfaces;
using CrudConteiners.Repository;
using static CrudConteiners.Models.Relatorio;

namespace CrudConteiners.Controllers
{
    public class ConteinerController : Controller
    {
        private readonly CrudConteinerContext _context;
        private readonly IConteinerRepository _conteinerRepository;

        public ConteinerController(CrudConteinerContext context, IConteinerRepository repository)
        {
            _context = context;
            _conteinerRepository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var conteiners = await _conteinerRepository.GetAll();
            return View(conteiners);
        }

        public async Task<IActionResult> Details(int id)
        {
            var conteiner = await _conteinerRepository.Get(id);

            if (conteiner == null)
            {
                return NotFound();
            }
            return View(conteiner);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cliente,NumeroConteiner,TipoConteiner,Status,Categoria")] Conteiner conteiner)
        {
            if (ModelState.IsValid)
            {
                await _conteinerRepository.Create(conteiner);
                return RedirectToAction(nameof(Index));
            }
            return View(conteiner);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var conteiner = await _conteinerRepository.Get(id);
            if (conteiner == null)
            {
                return NotFound();
            }

            return View(conteiner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cliente,NumeroConteiner,TipoConteiner,Status,Categoria")] Conteiner conteiner)
        {
            if (id != conteiner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _conteinerRepository.Update(conteiner);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConteinerExists(conteiner.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(conteiner);
        }

        public async Task<IActionResult> Delete(int id)
        {

            var conteiner = await _conteinerRepository.Get(id);

            if (conteiner == null)
            {
                return NotFound();
            }

            return View(conteiner);
        }

        // POST: Conteiner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool removido = await _conteinerRepository.Delete(id);
            if (removido)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }

        private bool ConteinerExists(int id)
        {
            return (_context.Conteiners?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Relatorio()
        {
            var movimentacoesConteiner = await _conteinerRepository.GetMovimentacoesConteiner();

            var detalhes = movimentacoesConteiner
                                                .GroupBy(m => new { m.Conteiner.Cliente, m.Conteiner.Categoria, TipoMovimentacao = m.TipoMovimentacao })
                                                .Select(g => new DetalheRelatorio
                                                {
                                                    Cliente = g.Key.Cliente,
                                                    Categoria = g.Key.Categoria.ToString(),
                                                    TipoMovimentacao = g.Key.TipoMovimentacao.ToString(),
                                                    TotalMovimentacoes = g.Count()
                                                })
                                                .ToList();

            var sumario = movimentacoesConteiner.GroupBy(m => m.Conteiner.Categoria)
                                                .Select (g => new SumarioRelatorio 
                                                {
                                                    Categoria = g.Key.ToString(),   
                                                    TotalMovimentacoes = g.Count()  
                                                }).ToList();

            var viewModel = new RelatorioViewModel
            {
                Detalhes = detalhes,
                Sumario = sumario,
            };

            return View(viewModel);
        }
    }
}
