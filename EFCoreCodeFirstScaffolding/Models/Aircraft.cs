using System;
using System.Collections.Generic;

namespace EFCoreCodeFirstScaffolding.Models
{
    public partial class Aircraft
    {
        public Aircraft()
        {
            AircraftFlightOrFlightPlan = new HashSet<AircraftFlightOrFlightPlan>();
        }

        public int AircraftId { get; set; }
        public string AircraftName { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? ModifiedLast { get; set; }
        public int? ModifiedById { get; set; }

        public Users CreatedBy { get; set; }
        public Users ModifiedBy { get; set; }
        public ICollection<AircraftFlightOrFlightPlan> AircraftFlightOrFlightPlan { get; set; }
    }
}
