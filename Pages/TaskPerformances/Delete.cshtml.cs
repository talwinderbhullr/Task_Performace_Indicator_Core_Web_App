using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task_Performace_Indicator_Core_Web_App.Business;
using Task_Performace_Indicator_Core_Web_App.Models;

namespace Task_Performace_Indicator_Core_Web_App.Pages.TaskPerformances
{
    //Deletes a performance
    public class DeleteModel : PageModel
    {
        private readonly Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext _context;

        public DeleteModel(Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds the task performance property.
        [BindProperty]
        public TaskPerformance TaskPerformance { get; set; }

        //Gets the performance for delete using a lamda 
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
            return Page();
        }

        //Delets the performance .
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskPerformance = (from performance in _context.TaskPerformance
                               where performance.Id == id
                               select performance).FirstOrDefault();

            if (TaskPerformance != null)
            {
                _context.TaskPerformance.Remove(TaskPerformance);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
