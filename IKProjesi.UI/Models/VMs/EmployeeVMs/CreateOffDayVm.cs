using System;
using IKProjesi.UI.Models.Enums;

namespace IKProjesi.UI.Models.VMs.EmployeeVMs
{
    public class CreateOffDayVM
    {

        public DateTime? DayOffStartTime { get; set; }
        public DateTime? DayOffEndTime { get; set; }
        public int? DayOffType { get; set; }
        public int? RequestOffDayNumber { get; set; }



        //public int? RemainingDaysOffNumber { get; set; }
        //public int? EmployeeId { get; set; }
        //public int? DayNumber { get; set; }
    }
}

