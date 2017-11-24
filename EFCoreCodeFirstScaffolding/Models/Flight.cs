using System;
using System.Collections.Generic;

namespace EFCoreCodeFirstScaffolding.Models
{
    public partial class Flight
    {
        public Flight()
        {
            AircraftFlightOrFlightPlan = new HashSet<AircraftFlightOrFlightPlan>();
            FlightPlan = new HashSet<FlightPlan>();
        }

        public int FlightId { get; set; }
        public string FlightAlias { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? ModifiedLast { get; set; }
        public int? ModifiedById { get; set; }

        public Users CreatedBy { get; set; }
        public Users ModifiedBy { get; set; }
        public ICollection<AircraftFlightOrFlightPlan> AircraftFlightOrFlightPlan { get; set; }
        public ICollection<FlightPlan> FlightPlan { get; set; }
    }
}
