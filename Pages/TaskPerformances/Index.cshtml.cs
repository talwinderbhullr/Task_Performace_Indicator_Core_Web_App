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
    //Gets all performance 
    public class IndexModel : PageModel
    {
        private readonly Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext _context;

        public IndexModel(Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Performance list.
        public IList<TaskPerformance> TaskPerformance { get;set; }

        //Gets all performance using a lamda
        public void OnGet()
        {
            TaskPerformance =  _context.TaskPerformance
                .Include(t => t.Operator)
                .Include(t => t.Task).ToList();
        }
    }
}
