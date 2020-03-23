using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Performace_Indicator_Core_Web_App.Business
{
    //The task 
    public class Task
    {
        //TASK ID
        public int Id { get; set; }

        //task name
        public string Name { get; set; }

        //Task estimated time.
        public int EstimatedTime { get; set; }

    }
}
