﻿using System;
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
    public class DictionariesController : Controller
    {
        private readonly _4SaleContext _context;

        public DictionariesController(_4SaleContext context)
        {
            _context = context;
        }

        // GET: Dictionaries
        public async Task<IActionResult> Index()
        {
              return _context.Dictionary != null ? 
                          View(await _context.Dictionary.ToListAsync()) :
                          Problem("Entity set '_4SaleContext.Dictionary'  is null.");
        }

        // GET: Dictionaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dictionary == null)
            {
                return NotFound();
            }

            var dictionary = await _context.Dictionary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictionary == null)
            {
                return NotFound();
            }

            return View(dictionary);
        }

        // GET: Dictionaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dictionaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Category,Name")] Dictionary dictionary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictionary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictionary);
        }

        // GET: Dictionaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dictionary == null)
            {
                return NotFound();
            }

            var dictionary = await _context.Dictionary.FindAsync(id);
            if (dictionary == null)
            {
                return NotFound();
            }
            return View(dictionary);
        }

        // POST: Dictionaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Category,Name")] Dictionary dictionary)
        {
            if (id != dictionary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictionary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictionaryExists(dictionary.Id))
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
            return View(dictionary);
        }

        // GET: Dictionaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dictionary == null)
            {
                return NotFound();
            }

            var dictionary = await _context.Dictionary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictionary == null)
            {
                return NotFound();
            }

            return View(dictionary);
        }

        // POST: Dictionaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dictionary == null)
            {
                return Problem("Entity set '_4SaleContext.Dictionary'  is null.");
            }
            var dictionary = await _context.Dictionary.FindAsync(id);
            if (dictionary != null)
            {
                _context.Dictionary.Remove(dictionary);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictionaryExists(int id)
        {
          return (_context.Dictionary?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
