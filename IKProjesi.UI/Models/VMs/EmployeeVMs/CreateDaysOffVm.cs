using System;
using IKProjesi.UI.Models.Enums;

namespace IKProjesi.UI.Models.VMs.EmployeeVMs
{
	public class CreateDaysOffVM

	{
        public int? Id { get; set; }
        public int ApprovalType { get; set; }
        public DateTime? RequestTime { get; set; }
        public DateTime? DayOffStartTime { get; set; }
        public DateTime? DayOffEndTime { get; set; }
        public int? DayNumber { get; set; }
        public DateTime? ResponseTime { get; set; }
        public DayOffType? DayOffType { get; set; }
        public int? DaysOffNumber { get; set; }

        public int? EmployeeId { get; set; }
        public int? EmployeeFullName { get; set; }

    }
}

