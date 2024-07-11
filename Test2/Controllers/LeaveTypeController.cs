using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Models;

namespace Test2.Controllers
{
    public class LeaveTypeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LeaveTypeController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: LeaveType
        public async Task<IActionResult> Index()
        {
            var LeaveType = _mapper.Map<List<LeaveTypeVM>>(await _context.leaveTypes.ToListAsync());
            return View(LeaveType);
        }

        // GET: LeaveType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.leaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var LeaveTypeVM = _mapper.Map<LeaveTypeVM>(leaveType);
            return View(LeaveTypeVM);
        }

        // GET: LeaveType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //تمنع الريبلي اتاك
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeVM LeaveTypeVM)
        {
            if (ModelState.IsValid)
            {
                var LeaveType = _mapper.Map<LeaveType>(LeaveTypeVM); 
                _context.Add(LeaveType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(LeaveTypeVM);
        }

        // GET: LeaveType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.leaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var LeaveTypeVM = _mapper.Map<LeaveTypeVM>(leaveType);
            return View(LeaveTypeVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  LeaveTypeVM leaveTypeVM)
        {
            if (id != leaveTypeVM.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = _mapper.Map<LeaveType>(leaveTypeVM);
                    _context.Update(leaveType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeExists(leaveTypeVM.id))
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
            return View(leaveTypeVM);
        }

        // GET: LeaveType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.leaveTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveType = await _context.leaveTypes.FindAsync(id);
            if (leaveType != null)
            {
                _context.leaveTypes.Remove(leaveType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypeExists(int id)
        {
            return _context.leaveTypes.Any(e => e.id == id);
        }
    }
}
