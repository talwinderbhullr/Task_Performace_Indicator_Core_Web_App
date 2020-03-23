using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_Performace_Indicator_Core_Web_App.Business;
using Task_Performace_Indicator_Core_Web_App.Models;
using Task = Task_Performace_Indicator_Core_Web_App.Business.Task;

namespace Task_Performace_Indicator_Core_Web_App.Pages.TaskPerformances
{
    //Creates a task performane.
    public class CreateModel : PageModel
    {
        private readonly Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext _context;

        public CreateModel(Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Gets a task performance create form.
        public IActionResult OnGet()
        {
        ViewData["OperatorId"] = new SelectList(_context.Operator, "Id", "Name");
        ViewData["TaskId"] = new SelectList(_context.Set<Task>(), "Id", "Name");
            return Page();
        }


        //Binds the performance model.

        [BindProperty]
        public TaskPerformance TaskPerformance { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        //Creates a performance .
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TaskPerformance.Add(TaskPerformance);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
