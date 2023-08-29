using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransacoesBanco.Models;

namespace TransacoesBanco.Controllers
{
    public class TransaccaoController : Controller
    {
        private readonly TransaccaoDbContext _context;

        public TransaccaoController(TransaccaoDbContext context)
        {
            _context = context;
        }

        // GET: Transaccao
        public async Task<IActionResult> Index()
        {
              return _context.Transaccoes != null ? 
                          View(await _context.Transaccoes.ToListAsync()) :
                          Problem("Entity set 'TransaccaoDbContext.Transaccoes'  is null.");
        }



        // GET: Transaccao/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Transaccao());
            else
                return View(_context.Transaccoes.Find(id));
        }

        // POST: Transaccao/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("TransaccaoId,NumeroConta,TitularConta,NomeBanco,CodigoSWIFT,Montante,DataTransaccao")] Transaccao transaccao)
        {
            if (ModelState.IsValid)
            {
                if(transaccao.TransaccaoId == 0)
                {
                    transaccao.DataTransaccao = DateTime.Now;
                    _context.Add(transaccao);
                } else
                    _context.Update(transaccao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transaccao);
        }

        // GET: Transaccao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transaccoes == null)
            {
                return NotFound();
            }

            var transaccao = await _context.Transaccoes.FindAsync(id);
            if (transaccao == null)
            {
                return NotFound();
            }
            return View(transaccao);
        }

        // POST: Transaccao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransaccaoId,NumeroConta,TitularConta,NomeBanco,CodigoSWIFT,Montante,DataTransaccao")] Transaccao transaccao)
        {
            if (id != transaccao.TransaccaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaccao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaccaoExists(transaccao.TransaccaoId))
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
            return View(transaccao);
        }


        // POST: Transaccao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transaccoes == null)
            {
                return Problem("Entity set 'TransaccaoDbContext.Transaccoes'  is null.");
            }
            var transaccao = await _context.Transaccoes.FindAsync(id);
            if (transaccao != null)
            {
                _context.Transaccoes.Remove(transaccao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaccaoExists(int id)
        {
          return (_context.Transaccoes?.Any(e => e.TransaccaoId == id)).GetValueOrDefault();
        }
    }
}
