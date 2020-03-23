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
    //Gets performance details.
    public class DetailsModel : PageModel
    {
        private readonly Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext _context;

        public DetailsModel(Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Task  performance 
        public TaskPerformance TaskPerformance { get; set; }

        //Gets the performance using a lamda.
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
    }
}
