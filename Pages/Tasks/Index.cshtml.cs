using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task_Performace_Indicator_Core_Web_App.Business;
using Task_Performace_Indicator_Core_Web_App.Models;
using Task = Task_Performace_Indicator_Core_Web_App.Business.Task;

namespace Task_Performace_Indicator_Core_Web_App.Pages.Tasks
{
    //Gets all tasks 
    public class IndexModel : PageModel
    {
        private readonly Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext _context;

        public IndexModel(Task_Performace_Indicator_Core_Web_App.Models.Task_Performace_Indicator_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Task list.

        public IList<Task> Task { get;set; }

        //Gets the task list using a linq query.
        public void OnGet()
        {
            Task = (from task in _context.Task select task).ToList();
        }
    }
}
