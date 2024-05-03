using System;
using IKProjesi.UI.Models.Enums;

namespace IKProjesi.UI.Models.VMs.PersonelVMs
{
	public class CreateDaysOffVm
	{
        public int EmployeeId { get; set; }
        public ApprovalType? ApprovalType { get; set; }
        public DateTime? RequestTime { get; set; }
        public DateTime? DayOffStartTime { get; set; }
        public DateTime? DayOffEndTime { get; set; }
        public int? DayNumber { get; set; }
        public DateTime? ResponseTime { get; set; }
        public DayOffType? DayOffType { get; set; }
        public int? DaysOffNumber { get; set; }
        public string Description { get; set; }

    }
}

