using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Performace_Indicator_Core_Web_App.Business
{
    //Task perforamc information.
    public class TaskPerformance
    {
        //Task id
        public int Id { get; set; }

        //Task actual completion time.
        public int CompletedTime { get; set; }

        //Task id foriegn key
        public int TaskId { get; set; }

        //Operator id foriegn key
        public int OperatorId { get; set; }

        //Operator link
        public Operator Operator { get; set; }

        //Task link

        public Task Task { get; set; }

        //Calculated performance index Divide estimated time in hours from completed 
        //Time in hours

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public decimal PerformanceIndex {

            get {
                return ((decimal) this.Task.EstimatedTime) / ((decimal)CompletedTime);


            }
        }
    }
}
