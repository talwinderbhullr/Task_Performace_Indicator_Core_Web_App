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
using Task = Task_Performace_Indicator_Core_Web_App.Business.Task;

namespace Task_Performace_Indicator_Core_Web_App.Pages.Tasks
{
    //Updates a  task
    public class EditModel : PageModel
    {
        private readonly Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext _context;

        public EditModel(Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds  task model
        [BindProperty]
        public Task Task { get; set; }

        //Gets the task for update using a ladma
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Task =  _context.Task.FirstOrDefault(m => m.Id == id);

            if (Task == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Updates the task.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Task).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(Task.Id))
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

        //Check task exists using a lamda.
        private bool TaskExists(int id)
        {
            return _context.Task.Any(e => e.Id == id);
        }
    }
}
