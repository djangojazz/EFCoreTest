using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstScaffolding.Models
{
    public sealed class AircraftFlightOrFlightPlan : BaseModel
    {
        public AircraftFlightOrFlightPlan() {}

        public AircraftFlightOrFlightPlan(string referencedTable, Aircraft aircraft, Flight flight = null, FlightPlan flightPlan = null)
        {
            ReferencedTable = referencedTable;
            Aircraft = aircraft;
            Flight = flight;
            FlightPlan = flightPlan;
        }

        [Key]
        public int Aircraft_FlightOrFlightPlanId { get; set; }
        public string ReferencedTable { get; set; }

        [ForeignKey("AircraftId")]
        public Aircraft Aircraft { get; set; }

        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }

        [ForeignKey("FlightPlanId")]
        public FlightPlan FlightPlan { get; set; }
    }
}
