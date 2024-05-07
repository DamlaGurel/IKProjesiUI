using System;
using IKProjesi.UI.Models.Enums;

namespace IKProjesi.UI.Models.VMs.OffDayVMs
{
    public class ListOffDayVM
    {
        public int? ApprovalType { get; set; }
        public DateTime? RequestTime { get; set; }
        public DateTime? DayOffStartTime { get; set; }
        public DateTime? DayOffEndTime { get; set; }
        public int? RequestOffDayNumber { get; set; }
        public DateTime? ResponseTime { get; set; }
        public int? DayOffType { get; set; }

    }
}

