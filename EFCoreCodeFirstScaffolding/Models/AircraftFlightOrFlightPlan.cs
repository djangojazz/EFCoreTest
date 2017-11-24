using System;
using System.Collections.Generic;

namespace EFCoreCodeFirstScaffolding.Models
{
    public partial class AircraftFlightOrFlightPlan
    {
        public int AircraftFlightOrFlightPlanId { get; set; }
        public string ReferencedTable { get; set; }
        public int? AircraftId { get; set; }
        public int? FlightId { get; set; }
        public int? FlightPlanId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? ModifiedLast { get; set; }
        public int? ModifiedById { get; set; }

        public Aircraft Aircraft { get; set; }
        public Users CreatedBy { get; set; }
        public Flight Flight { get; set; }
        public FlightPlan FlightPlan { get; set; }
        public Users ModifiedBy { get; set; }
    }
}
