using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstScaffolding.Models
{
    public partial class FlightPlan : BaseModel
    {
        public FlightPlan() {}

        public FlightPlan(string flightPlanName, Users createdBy, Users modifiedBy)
            : base(createdBy, modifiedBy)
        {
            FlightPlanName = flightPlanName;
        }

        [Key]
        public int FlightPlanId { get; set; }

        [Column(TypeName = "varchar(128)"), MaxLength(128)]
        public string FlightPlanName { get; set; }
        
        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }
    }
}
