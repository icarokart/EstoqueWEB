using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstoqueWEB.Models;

namespace EstoqueWEB.Controllers
{
    public class SaidasEstoquesController : Controller
    {
        private readonly Controle_EstoqueContext _context;

        public SaidasEstoquesController(Controle_EstoqueContext context)
        {
            _context = context;
        }


        // GET: SaidasEstoques
        public async Task<IActionResult> Index()
        {
            var controle_EstoqueContext = _context.SaidasEstoques.Include(s => s.IdProdutoNavigation);
            return View(await controle_EstoqueContext.ToListAsync());
        }

        //GET: SaidasEstoques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SaidasEstoques == null)
            {
                return NotFound();
            }

            var saidasEstoque = await _context.SaidasEstoques
                .Include(s => s.IdProdutoNavigation)
                .FirstOrDefaultAsync(m => m.IdSaida == id);
            if (saidasEstoque == null)
            {
                return NotFound();
            }

            return View(saidasEstoque);
        }

        // GET: SaidasEstoques/Create
        public IActionResult Create()
        {
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto");
            return View();
        }

        // POST: SaidasEstoques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSaida,IdProduto,DtSaida,NomeProduto,QtdSaida,PrecoVendaUn")] SaidasEstoque saidasEstoque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saidasEstoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto", saidasEstoque.IdProduto);
            return View(saidasEstoque);
        }

        // GET: SaidasEstoques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SaidasEstoques == null)
            {
                return NotFound();
            }

            var saidasEstoque = await _context.SaidasEstoques.FindAsync(id);
            if (saidasEstoque == null)
            {
                return NotFound();
            }
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto", saidasEstoque.IdProduto);
            return View(saidasEstoque);
        }

        // POST: SaidasEstoques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSaida,IdProduto,DtSaida,NomeProduto,QtdSaida,PrecoVendaUn")] SaidasEstoque saidasEstoque)
        {
            if (id != saidasEstoque.IdSaida)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saidasEstoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaidasEstoqueExists(saidasEstoque.IdSaida))
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
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto", saidasEstoque.IdProduto);
            return View(saidasEstoque);
        }

        // GET: SaidasEstoques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SaidasEstoques == null)
            {
                return NotFound();
            }

            var saidasEstoque = await _context.SaidasEstoques
                .Include(s => s.IdProdutoNavigation)
                .FirstOrDefaultAsync(m => m.IdSaida == id);
            if (saidasEstoque == null)
            {
                return NotFound();
            }

            return View(saidasEstoque);
        }

        // POST: SaidasEstoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SaidasEstoques == null)
            {
                return Problem("Entity set 'Controle_EstoqueContext.SaidasEstoques'  is null.");
            }
            var saidasEstoque = await _context.SaidasEstoques.FindAsync(id);
            if (saidasEstoque != null)
            {
                _context.SaidasEstoques.Remove(saidasEstoque);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaidasEstoqueExists(int id)
        {
          return _context.SaidasEstoques.Any(e => e.IdSaida == id);
        }
    }
}
