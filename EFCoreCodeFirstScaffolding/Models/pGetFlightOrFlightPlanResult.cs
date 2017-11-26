using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstScaffolding.Models
{
    public sealed class pGetFlightOrFlightPlanResult
    {
        [Key]
        public int AircraftFlightOrFlightPlanId { get; set; }
        public int AircraftId { get; set; }
        public string AircraftName { get; set; }
        public int? FlightId { get; set; }
        public string FlightAlias { get; set; }
        public int? FlightPlanId { get; set; }
        public string FlightPlanName { get; set; }
        public int CreatedById { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public int ModifiedById { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedLast { get; set; }
        
    }
}
