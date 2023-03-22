using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _4Sale.Data;
using _4Sale.Enums;
using _4Sale.Models;
using _4Sale.ViewModels;
using AutoMapper;

namespace _4Sale.Controllers
{
    public class ItemsController : Controller
    {
        private readonly _4SaleContext _context;
        private readonly IMapper _mapper;

        public ItemsController(_4SaleContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            List<ItemViewModel> itemVmList = new List<ItemViewModel>();
            var itemList = await _context.Item.ToListAsync();
            foreach (var item in itemList)
            {
                itemVmList.Add(_mapper.Map<ItemViewModel>(item));
            }

            return _context.Item != null ? 
                          View(itemVmList) :
                          Problem("Entity set '_4SaleContext.Item'  is null.");
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public async Task<IActionResult> Create()
        {
            if (_context != null && _context.Dictionary != null)
            {
                var list = await _context.Dictionary.ToListAsync();
                var itemTypes = list.Where((x => x.Category == CategoryEnum.ItemType)).Select(x => x.Name);
                var itemColors = list.Where((x => x.Category == CategoryEnum.ItemColor)).Select(x => x.Name);
                ViewBag.ItemTypes = new SelectList(itemTypes);
                ViewBag.ItemColors = new SelectList(itemColors);
            }
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Color,ItemType")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var list = await _context.Dictionary.ToListAsync();
            var itemTypes = list.Where((x => x.Category == CategoryEnum.ItemType)).Select(x => x.Name);
            var itemColors = list.Where((x => x.Category == CategoryEnum.ItemColor)).Select(x => x.Name);
            ViewBag.ItemTypes = new SelectList(itemTypes);
            ViewBag.ItemColors = new SelectList(itemColors);

            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Color,ItemType")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
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
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Item == null)
            {
                return Problem("Entity set '_4SaleContext.Item'  is null.");
            }
            var item = await _context.Item.FindAsync(id);
            if (item != null)
            {
                _context.Item.Remove(item);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
          return (_context.Item?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
