using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Performace_Indicator_Core_Web_App.Business
{
    //The operator infomation.
    public class Operator
    {
        //Operator id
        public int Id { get; set; }

        //Operator name
        public string Name { get; set; }


        //Oprator is permanant indicator.
        public Boolean IsPermanent { get; set; }
    }
}
