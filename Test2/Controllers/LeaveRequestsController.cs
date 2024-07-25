using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test2.Contract;
using Test2.Data;
using Test2.Models;
using Test2.Repository;

namespace Test2.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;
        private readonly IleaveRequestReosotory ileaveRequestReosotory;

        public LeaveRequestsController(ApplicationDbContext context,IMapper mapper,IleaveRequestReosotory ileaveRequestReosotory)
        {
            _context = context;
            this.mapper = mapper;
            this.ileaveRequestReosotory = ileaveRequestReosotory;
        }

        // GET: LeaveRequests
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
            var model = await ileaveRequestReosotory.GetAdminLeaveReqquestList();
        //    var applicationDbContext = _context.LeaveRequests.Include(l => l.LeaveType);
            return View(model);
        }


        public async Task<ActionResult> MyLeave()
        {
            var model = await ileaveRequestReosotory.GetMyLeaveDetails();
            return View(model);
        }




        // GET: LeaveRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var model = await ileaveRequestReosotory.GetLeaveRequesatAsync(id);

            if (id == null)
            {
                return NotFound();
            }

         

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveRequest(int id,bool aprroved)
        {
            try
            {
            await ileaveRequestReosotory.changeAprooveStatuse(id, aprroved);

            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancele (int id)
        {
            try
            {
                await ileaveRequestReosotory.CanceleLeaveRequest(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction(nameof(MyLeave));
        }




        // GET: LeaveRequests/Create
        public IActionResult Create()
        {
            var model = new LeaveReqestCreatVM
            {
                LeaveType = new SelectList(_context.leaveTypes, "id", "named")
            }; 
            return View(model);
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveReqestCreatVM model)
        { 
            try
            {
                 if (ModelState.IsValid)
                            {
                                 var isvalidRequest =   await  ileaveRequestReosotory.CreateLeaveRequest(model);
                    if (isvalidRequest)
                    {
                                return RedirectToAction(nameof(MyLeave));

                    }
                    ModelState.AddModelError(string.Empty, " you have Exceeded your allocation with this request");

                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, " Error  Pleace Try Again later");

            }
            model.LeaveType= new SelectList(_context.leaveTypes, "id", "named", model.LeaveTypeid);
            return View(model);
        }


        


        // GET: LeaveRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            ViewData["LeaveTypeid"] = new SelectList(_context.leaveTypes, "id", "id", leaveRequest.LeaveTypeid);
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StartDate,EndDate,LeaveTypeid,DateRequest,RequrstComent,Approve,CDancele,RequestEmployID,id,datecreat,datemodified")] LeaveRequest leaveRequest)
        {
            if (id != leaveRequest.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveRequestExists(leaveRequest.id))
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
            ViewData["LeaveTypeid"] = new SelectList(_context.leaveTypes, "id", "id", leaveRequest.LeaveTypeid);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequests
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(m => m.id == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest != null)
            {
                _context.LeaveRequests.Remove(leaveRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveRequestExists(int id)
        {
            return _context.LeaveRequests.Any(e => e.id == id);
        }
    }
}
