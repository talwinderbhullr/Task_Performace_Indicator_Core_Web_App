using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task_Performace_Indicator_Core_Web_App.Business;
using Task_Performace_Indicator_Core_Web_App.Models;

namespace Task_Performace_Indicator_Core_Web_App.Pages.Tasks
{
    //Removes the task 
    public class DeleteModel : PageModel
    {
        private readonly Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext _context;

        public DeleteModel(Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds the task model.
        [BindProperty]
        public Business.Task Task { get; set; }

        //Gets the task for remove using a lamda query.
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

        //Removes the task
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Task = (from task in _context.Task
                    where task.Id == id
                    select task).FirstOrDefault();

            if (Task != null)
            {
                _context.Task.Remove(Task);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
