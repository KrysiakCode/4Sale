using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _4Sale.Data;
using _4Sale.Models;
using _4Sale.ViewModels;
using AutoMapper;

namespace _4Sale.Controllers
{
    public class InvoiceContentsController : Controller
    {
        private readonly _4SaleContext _context;
        private readonly IMapper _mapper;

        public InvoiceContentsController(_4SaleContext context, IMapper  mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: InvoiceContents
        public async Task<IActionResult> Index(int? id)
        {
            if (id != null)
            {
                ViewData["InvoiceId"] = id;
                var invoiceNo = await _context.Invoice.FindAsync(id);
                ViewData["InvoiceNo"] = invoiceNo.InvoiceNo;
                var _4SaleContext = _context.InvoiceContent
                    .Where(ic => ic.InvoiceId == id)
                    .Include(i => i.Invoice)
                    .Include(i => i.Item);
                return View(await _4SaleContext.ToListAsync());
            }
            else
            {
                return RedirectToAction("Index", "Invoices");
            }
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

            //Przerobić na ViewModel - wszędzie

            ViewData["InvoiceId"] = invoiceContent.InvoiceId;
            return View(invoiceContent);
        }

        // GET: InvoiceContents/Create
        public async Task<IActionResult> Create(int? id)
        {
            var invoiceNo = await _context.Invoice.FindAsync(id);
            ViewData["InvoiceNo"] = invoiceNo.InvoiceNo;
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Name");
            var cc = new InvoiceContentViewModel();
            cc.InvoiceId = (int)id;
            return View(cc);
        }

        // POST: InvoiceContents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Quantity,Gross,Vat,Net,InvoiceId,ItemId")] InvoiceContentViewModel invoiceContentVM)
        {
            if (ModelState.IsValid)
            {
                var invoiceContent = _mapper.Map<InvoiceContent>(invoiceContentVM);
                _context.Add(invoiceContent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = invoiceContent.InvoiceId });
            }
            
            ViewData["InvoiceId"] = new SelectList(_context.Invoice, "Id", "Id", invoiceContentVM.InvoiceId);
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Id", invoiceContentVM.ItemId);
            return View(invoiceContentVM);
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

            var icVM = _mapper.Map<InvoiceContentViewModel>(invoiceContent);

            ViewData["Invoice"] = new SelectList(_context.Invoice, "Id", "InvoiceNo", icVM.InvoiceId);
            ViewData["Item"] = new SelectList(_context.Item, "Id", "Name", icVM.ItemId);
            return View(icVM);
        }

        // POST: InvoiceContents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,Gross,Vat,Net,InvoiceId,ItemId")] InvoiceContentViewModel invoiceContentVM)
        {
            if (id != invoiceContentVM.Id)
            {
                return NotFound();
            }
            var ic = _mapper.Map<InvoiceContent>(invoiceContentVM);
            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(ic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceContentExists(ic.Id))
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
            ViewData["Invoice"] = new SelectList(_context.Invoice, "Id", "InvoiceNo", invoiceContentVM.InvoiceId);
            ViewData["Item"] = new SelectList(_context.Item, "Id", "Name", invoiceContentVM.ItemId);
            return View(invoiceContentVM);
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
