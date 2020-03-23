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
    //Gets the task details.
    public class DetailsModel : PageModel
    {
        private readonly Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext _context;

        public DetailsModel(Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Holds the task.

        public Business.Task Task { get; set; }

        //Gets the task details using a lamda query.
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
    }
}
