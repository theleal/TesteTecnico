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

namespace CrudConteiners.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly CrudConteinerContext _context;
        private readonly IMovimentacoesRepository _movimentacoesRepository;  
        public MovimentacaoController(CrudConteinerContext context, IMovimentacoesRepository repository)
        {
            _context = context;
            _movimentacoesRepository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var movimentacoes = await _movimentacoesRepository.GetAll();

            return View(movimentacoes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movimentacao = await _movimentacoesRepository.Get(id);

            return View(movimentacao);
        }

        public IActionResult Create()
        {
            ViewData["ID_Conteiner"] = new SelectList(_context.Conteiners, "Id", "NumeroConteiner");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoMovimentacao,DataHoraInicio,DataHoraFim,ID_Conteiner")] Movimentacoes movimentacoes)
        {
            if (ModelState.IsValid)
            {
                await _movimentacoesRepository.Create(movimentacoes);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Conteiner"] = new SelectList(_context.Conteiners, "Id", "NumeroConteiner", movimentacoes.ID_Conteiner);
            return View(movimentacoes);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movimentacao = await _movimentacoesRepository.Get(id);
            if (movimentacao == null)
            {
                return NotFound();
            }
            ViewData["ID_Conteiner"] = new SelectList(_context.Conteiners, "Id", "NumeroConteiner", movimentacao.ID_Conteiner);
            return View(movimentacao);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoMovimentacao,DataHoraInicio,DataHoraFim,ID_Conteiner")] Movimentacoes movimentacoes)
        {
            if (id != movimentacoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _movimentacoesRepository.Update(movimentacoes);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentacoesExists(movimentacoes.Id))
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
            ViewData["ID_Conteiner"] = new SelectList(_context.Conteiners, "Id", "NumeroConteiner", movimentacoes.ID_Conteiner);
            return View(movimentacoes);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movimentacao = await _movimentacoesRepository.Get(id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool removido = await _movimentacoesRepository.Delete(id);

            if (removido)
            {
                return RedirectToAction(nameof(Index));
            }
            else 
            {
                return BadRequest();
            }
        }

        private bool MovimentacoesExists(int id)
        {
          return (_context.Movimentacoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
