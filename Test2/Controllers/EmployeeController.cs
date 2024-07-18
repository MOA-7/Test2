using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Test2.Contract;
using Test2.Data;
using Test2.Models;
using Test2.Repository;

namespace Test2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UserManager<Employ> _UserManager;
        private readonly IMapper _mapper;
        private readonly IleaveAllocationRipository ileaveAllocationRipository;
        private readonly IleaveRepository ileaveRepository;



        public EmployeeController(UserManager<Employ> userManager ,IleaveRepository ileaveRepository,IMapper mapper, IleaveAllocationRipository ileaveAllocationRipository )
        
        {
            _UserManager = userManager;
            _mapper = mapper;
           this.ileaveAllocationRipository = ileaveAllocationRipository;
            this.ileaveRepository = ileaveRepository;
        }

        // GET: EmployeeController
        public async Task<IActionResult> Index()
        {
            var employess = await _UserManager.GetUsersInRoleAsync("User");
            var model = _mapper.Map<List<EmployListVM>>(employess);
            return View(model);
        }

        public  async Task<IActionResult> ViewAllocation(string id)
        {

            var model = await ileaveAllocationRipository.GetEmployeAllocations(id);
            return View(model);

        }
  

        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> EditAllocation(int id)
        {
            var model = await ileaveAllocationRipository.GetEmployeAllocation(id);
            if (model == null)
            {
                return NotFound();
            }
          
            return View(model);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAllocation(int id, EdirLeaveAllocationVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await ileaveAllocationRipository.UPDATEEmployeAllocation(model))
                    {
                        return RedirectToAction(nameof(ViewAllocation), new { id = model.Employeeid });
                    }

                    

                } 
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, " Error  Pleace Try Again later");
            }
            model.Employee =  _mapper.Map<EmployListVM>(await _UserManager.FindByIdAsync(model.Employeeid));
            model.LeaveType = _mapper.Map<LeaveTypeVM>(await ileaveRepository.GetAsync(model.LeaveTypeID));
            return View(model);
        }

        // GET: EmployeeController/Delete/5

    }
}
