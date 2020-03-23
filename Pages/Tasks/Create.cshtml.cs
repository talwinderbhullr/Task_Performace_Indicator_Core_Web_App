using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_Performace_Indicator_Core_Web_App.Business;
using Task_Performace_Indicator_Core_Web_App.Models;

namespace Task_Performace_Indicator_Core_Web_App.Pages.Tasks
{
    //Creates the task
    public class CreateModel : PageModel
    {
        private readonly Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext _context;

        public CreateModel(Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Gets the task create form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Binds the task  model.
        [BindProperty]
        public Business.Task Task { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Adds a  task.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Task.Add(Task);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
