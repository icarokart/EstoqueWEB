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
    public class EntradasEstoquesController : Controller
    {
        private readonly Controle_EstoqueContext _context;

        public EntradasEstoquesController(Controle_EstoqueContext context)
        {
            _context = context;
        }

        // GET: EntradasEstoques
        public async Task<IActionResult> Index()
        {
            var controle_EstoqueContext = _context.EntradasEstoques.Include(e => e.IdFornecedorNavigation).Include(e => e.IdProdutoNavigation);
            ViewBag.Controle_EstoqueContext = _context.EntradasEstoques.ToListAsync();
            return View(await controle_EstoqueContext.ToListAsync());
        }

        // GET: EntradasEstoques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EntradasEstoques == null)
            {
                return NotFound();
            }

            var entradasEstoque = await _context.EntradasEstoques
                .Include(e => e.IdFornecedorNavigation)
                .Include(e => e.IdProdutoNavigation)
                .FirstOrDefaultAsync(m => m.IdEntrada == id);
            if (entradasEstoque == null)
            {
                return NotFound();
            }

            return View(entradasEstoque);
        }

        // GET: EntradasEstoques/Create
        public IActionResult Create()
        {
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedores, "IdFornecedor", "IdFornecedor");
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto");
            return View();
        }

        // POST: EntradasEstoques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEntrada,IdProduto,NomeProduto,QtdEntrada,DtEntrada,DtUltimaAlteracao,NumItensAtual,PrecoUn,ValorVenda,NumNotaFiscal,Lote,IdFornecedor,Aberto")] EntradasEstoque entradasEstoque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entradasEstoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedores, "IdFornecedor", "IdFornecedor", entradasEstoque.IdFornecedor);
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto", entradasEstoque.IdProduto);
            return View(entradasEstoque);
        }

        // GET: EntradasEstoques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EntradasEstoques == null)
            {
                return NotFound();
            }

            var entradasEstoque = await _context.EntradasEstoques.FindAsync(id);
            if (entradasEstoque == null)
            {
                return NotFound();
            }
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedores, "IdFornecedor", "IdFornecedor", entradasEstoque.IdFornecedor);
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto", entradasEstoque.IdProduto);
            return View(entradasEstoque);
        }

        // POST: EntradasEstoques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEntrada,IdProduto,NomeProduto,QtdEntrada,DtEntrada,DtUltimaAlteracao,NumItensAtual,PrecoUn,ValorVenda,NumNotaFiscal,Lote,IdFornecedor,Aberto")] EntradasEstoque entradasEstoque)
        {
            if (id != entradasEstoque.IdEntrada)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entradasEstoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradasEstoqueExists(entradasEstoque.IdEntrada))
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
            ViewData["IdFornecedor"] = new SelectList(_context.Fornecedores, "IdFornecedor", "IdFornecedor", entradasEstoque.IdFornecedor);
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto", entradasEstoque.IdProduto);
            return View(entradasEstoque);
        }

        // GET: EntradasEstoques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EntradasEstoques == null)
            {
                return NotFound();
            }

            var entradasEstoque = await _context.EntradasEstoques
                .Include(e => e.IdFornecedorNavigation)
                .Include(e => e.IdProdutoNavigation)
                .FirstOrDefaultAsync(m => m.IdEntrada == id);
            if (entradasEstoque == null)
            {
                return NotFound();
            }

            return View(entradasEstoque);
        }

        // POST: EntradasEstoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EntradasEstoques == null)
            {
                return Problem("Entity set 'Controle_EstoqueContext.EntradasEstoques'  is null.");
            }
            var entradasEstoque = await _context.EntradasEstoques.FindAsync(id);
            if (entradasEstoque != null)
            {
                _context.EntradasEstoques.Remove(entradasEstoque);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradasEstoqueExists(int id)
        {
          return _context.EntradasEstoques.Any(e => e.IdEntrada == id);
        }
    }
}
