using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _4Sale.Data;
using _4Sale.Models;

namespace _4Sale.Controllers
{
    public class InvoiceContentsController : Controller
    {
        private readonly _4SaleContext _context;

        public InvoiceContentsController(_4SaleContext context)
        {
            _context = context;
        }

        // GET: InvoiceContents
        public async Task<IActionResult> Index()
        {
            var _4SaleContext = _context.InvoiceContent.Include(i => i.Invoice).Include(i => i.Item);
            return View(await _4SaleContext.ToListAsync());
        }

        // GET: InvoiceContents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InvoiceContent == null)
            {
                return NotFound();
            }

            var invoiceContent = await _context.InvoiceContent
                .Include(i => i.Invoice)
                .Include(i => i.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceContent == null)
            {
                return NotFound();
            }

            return View(invoiceContent);
        }

        // GET: InvoiceContents/Create
        public IActionResult Create()
        {
            ViewData["InvoiceId"] = new SelectList(_context.Invoice, "Id", "InvoiceNo");
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Id");
            return View();
        }

        // POST: InvoiceContents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantity,Gross,Vat,Net,InvoiceId,ItemId")] InvoiceContent invoiceContent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoice, "Id", "InvoiceNo", invoiceContent.InvoiceId);
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Id", invoiceContent.ItemId);
            return View(invoiceContent);
        }

        // GET: InvoiceContents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InvoiceContent == null)
            {
                return NotFound();
            }

            var invoiceContent = await _context.InvoiceContent.FindAsync(id);
            if (invoiceContent == null)
            {
                return NotFound();
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoice, "Id", "InvoiceNo", invoiceContent.InvoiceId);
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Id", invoiceContent.ItemId);
            return View(invoiceContent);
        }

        // POST: InvoiceContents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,Gross,Vat,Net,InvoiceId,ItemId")] InvoiceContent invoiceContent)
        {
            if (id != invoiceContent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceContentExists(invoiceContent.Id))
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
            ViewData["InvoiceId"] = new SelectList(_context.Invoice, "Id", "InvoiceNo", invoiceContent.InvoiceId);
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Id", invoiceContent.ItemId);
            return View(invoiceContent);
        }

        // GET: InvoiceContents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InvoiceContent == null)
            {
                return NotFound();
            }

            var invoiceContent = await _context.InvoiceContent
                .Include(i => i.Invoice)
                .Include(i => i.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceContent == null)
            {
                return NotFound();
            }

            return View(invoiceContent);
        }

        // POST: InvoiceContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InvoiceContent == null)
            {
                return Problem("Entity set '_4SaleContext.InvoiceContent'  is null.");
            }
            var invoiceContent = await _context.InvoiceContent.FindAsync(id);
            if (invoiceContent != null)
            {
                _context.InvoiceContent.Remove(invoiceContent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceContentExists(int id)
        {
          return (_context.InvoiceContent?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
