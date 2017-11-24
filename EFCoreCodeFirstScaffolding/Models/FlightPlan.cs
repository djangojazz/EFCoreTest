using System;
using System.Collections.Generic;

namespace EFCoreCodeFirstScaffolding.Models
{
    public partial class FlightPlan
    {
        public FlightPlan()
        {
            AircraftFlightOrFlightPlan = new HashSet<AircraftFlightOrFlightPlan>();
        }

        public int FlightPlanId { get; set; }
        public int? FlightId { get; set; }
        public string FlightPlanName { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? ModifiedLast { get; set; }
        public int? ModifiedById { get; set; }

        public Users CreatedBy { get; set; }
        public Flight Flight { get; set; }
        public Users ModifiedBy { get; set; }
        public ICollection<AircraftFlightOrFlightPlan> AircraftFlightOrFlightPlan { get; set; }
    }
}
