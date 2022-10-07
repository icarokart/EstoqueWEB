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
    public class BaixasEstoquesController : Controller
    {
        private readonly Controle_EstoqueContext _context;

        public BaixasEstoquesController(Controle_EstoqueContext context)
        {
            _context = context;
        }

        // GET: BaixasEstoques
        public async Task<IActionResult> Index()
        {
            var controle_EstoqueContext = _context.BaixasEstoques.Include(b => b.IdProdutoNavigation);
            return View(await controle_EstoqueContext.ToListAsync());
        }

        // GET: BaixasEstoques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BaixasEstoques == null)
            {
                return NotFound();
            }

            var baixasEstoque = await _context.BaixasEstoques
                .Include(b => b.IdProdutoNavigation)
                .FirstOrDefaultAsync(m => m.IdBaixa == id);
            if (baixasEstoque == null)
            {
                return NotFound();
            }

            return View(baixasEstoque);
        }

        // GET: BaixasEstoques/Create
        public IActionResult Create()
        {
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto");
            return View();
        }

        // POST: BaixasEstoques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBaixa,IdProduto,DtBaixa,QtdProduto,Lote,ValorPerda")] BaixasEstoque baixasEstoque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baixasEstoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto", baixasEstoque.IdProduto);
            return View(baixasEstoque);
        }

        // GET: BaixasEstoques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BaixasEstoques == null)
            {
                return NotFound();
            }

            var baixasEstoque = await _context.BaixasEstoques.FindAsync(id);
            if (baixasEstoque == null)
            {
                return NotFound();
            }
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto", baixasEstoque.IdProduto);
            return View(baixasEstoque);
        }

        // POST: BaixasEstoques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBaixa,IdProduto,DtBaixa,QtdProduto,Lote,ValorPerda")] BaixasEstoque baixasEstoque)
        {
            if (id != baixasEstoque.IdBaixa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baixasEstoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaixasEstoqueExists(baixasEstoque.IdBaixa))
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
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto", baixasEstoque.IdProduto);
            return View(baixasEstoque);
        }

        // GET: BaixasEstoques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BaixasEstoques == null)
            {
                return NotFound();
            }

            var baixasEstoque = await _context.BaixasEstoques
                .Include(b => b.IdProdutoNavigation)
                .FirstOrDefaultAsync(m => m.IdBaixa == id);
            if (baixasEstoque == null)
            {
                return NotFound();
            }

            return View(baixasEstoque);
        }

        // POST: BaixasEstoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BaixasEstoques == null)
            {
                return Problem("Entity set 'Controle_EstoqueContext.BaixasEstoques'  is null.");
            }
            var baixasEstoque = await _context.BaixasEstoques.FindAsync(id);
            if (baixasEstoque != null)
            {
                _context.BaixasEstoques.Remove(baixasEstoque);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaixasEstoqueExists(int id)
        {
          return _context.BaixasEstoques.Any(e => e.IdBaixa == id);
        }
    }
}
