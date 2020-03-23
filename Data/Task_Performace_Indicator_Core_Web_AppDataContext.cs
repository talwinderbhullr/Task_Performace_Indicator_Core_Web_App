using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task_Performace_Indicator_Core_Web_App.Business;

namespace Task_Performace_Indicator_Core_Web_App.Models
{
    //Maps the busienss layer classes to the datasbase tables.
    public class Task_Performace_Indicator_Core_Web_AppDataContext : DbContext
    {
        public Task_Performace_Indicator_Core_Web_AppDataContext (DbContextOptions<Task_Performace_Indicator_Core_Web_AppDataContext> options)
            : base(options)
        {
        }

        public DbSet<Task_Performace_Indicator_Core_Web_App.Business.Operator> Operator { get; set; }

        public DbSet<Task_Performace_Indicator_Core_Web_App.Business.TaskPerformance> TaskPerformance { get; set; }

        public DbSet<Task_Performace_Indicator_Core_Web_App.Business.Task> Task { get; set; }
    }
}
