using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task_Performace_Indicator_Core_Web_App.Business;
using Task_Performace_Indicator_Core_Web_App.Models;

namespace Task_Performace_Indicator_Core_Web_App.Pages.TaskPerformances
{
    //Updates the performance
    public class EditModel : PageModel
    {
        private readonly Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext _context;

        public EditModel(Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds the performance 
        [BindProperty]
        public TaskPerformance TaskPerformance { get; set; }

        //Gets the performance for update using a lamda 
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskPerformance =  _context.TaskPerformance
                .Include(t => t.Operator)
                .Include(t => t.Task).FirstOrDefault(m => m.Id == id);

            if (TaskPerformance == null)
            {
                return NotFound();
            }
           ViewData["OperatorId"] = new SelectList(_context.Operator, "Id", "Name");
           ViewData["TaskId"] = new SelectList(_context.Set<Business.Task>(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Updates the performance.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TaskPerformance).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskPerformanceExists(TaskPerformance.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Checks the availablilty using a lamda 
        private bool TaskPerformanceExists(int id)
        {
            return _context.TaskPerformance.Any(e => e.Id == id);
        }
    }
}
