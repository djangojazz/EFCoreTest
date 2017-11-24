using System;
using System.Collections.Generic;

namespace EFCoreCodeFirstScaffolding.Models
{
    public partial class Users
    {
        public Users()
        {
            AircraftCreatedBy = new HashSet<Aircraft>();
            AircraftFlightOrFlightPlanCreatedBy = new HashSet<AircraftFlightOrFlightPlan>();
            AircraftFlightOrFlightPlanModifiedBy = new HashSet<AircraftFlightOrFlightPlan>();
            AircraftModifiedBy = new HashSet<Aircraft>();
            FlightCreatedBy = new HashSet<Flight>();
            FlightModifiedBy = new HashSet<Flight>();
            FlightPlanCreatedBy = new HashSet<FlightPlan>();
            FlightPlanModifiedBy = new HashSet<FlightPlan>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public ICollection<Aircraft> AircraftCreatedBy { get; set; }
        public ICollection<AircraftFlightOrFlightPlan> AircraftFlightOrFlightPlanCreatedBy { get; set; }
        public ICollection<AircraftFlightOrFlightPlan> AircraftFlightOrFlightPlanModifiedBy { get; set; }
        public ICollection<Aircraft> AircraftModifiedBy { get; set; }
        public ICollection<Flight> FlightCreatedBy { get; set; }
        public ICollection<Flight> FlightModifiedBy { get; set; }
        public ICollection<FlightPlan> FlightPlanCreatedBy { get; set; }
        public ICollection<FlightPlan> FlightPlanModifiedBy { get; set; }
    }
}
