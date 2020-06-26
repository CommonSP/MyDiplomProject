using System;
using System.Collections.Generic;

namespace MyDiplomProject
{
    public partial class Schedules
    {
        public int ScheduleId { get; set; }
        public string Event { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public int? GroupId { get; set; }

        public virtual Groups Group { get; set; }
    }
}
