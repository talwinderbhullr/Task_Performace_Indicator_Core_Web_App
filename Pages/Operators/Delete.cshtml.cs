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
    //Deletes an operator.
    public class DeleteModel : PageModel
    {
        private readonly Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext _context;

        public DeleteModel(Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds the operator model.
        [BindProperty]
        public Operator Operator { get; set; }

        //Gets the operator for delete using a lamda
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Operator =  _context.Operator.FirstOrDefault(m => m.Id == id);

            if (Operator == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Delets the operator.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Operator =  _context.Operator.Find(id);

            if (Operator != null)
            {
                _context.Operator.Remove(Operator);
               _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
