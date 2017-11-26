using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstScaffolding.Models
{
    public sealed class Aircraft : BaseModel
    {
        public Aircraft() {}

        public Aircraft(string aircraftName, Users createdBy, Users modifiedBy) 
            : base(createdBy, modifiedBy)
        {
            AircraftName = aircraftName;
        }

        [Key]
        public int AircraftId { get; set; }

        [Column(TypeName = "varchar(128)"), MaxLength(128)]
        public string AircraftName { get; set; }
    }
}
