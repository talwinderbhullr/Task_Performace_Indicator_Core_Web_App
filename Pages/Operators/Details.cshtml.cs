using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task_Performace_Indicator_Core_Web_App.Business;
using Task_Performace_Indicator_Core_Web_App.Models;

namespace Task_Performace_Indicator_Core_Web_App.Pages.Operators
{
    //Gets the details of the operator .
    public class DetailsModel : PageModel
    {
        private readonly Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext _context;

        public DetailsModel(Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Holda the operator.
        public Operator Operator { get; set; }

        //Gets the operator details using a lamda
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Operator = _context.Operator.FirstOrDefault(m => m.Id == id);

            if (Operator == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
