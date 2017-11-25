using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstScaffolding.Models
{
    public partial class Aircraft //: BaseModel
    {
        public Aircraft() {}

        public Aircraft(string aircraftName, Users createdBy) 
            //: base(createdBy, modifiedBy)
        {
            AircraftName = aircraftName;
            AircraftCreatedBy = createdBy;
        }

        [Key]
        public int AircraftId { get; set; }

        public Users AircraftCreatedBy { get; set; }

        [Column(TypeName = "varchar(128)"), MaxLength(128)]
        public string AircraftName { get; set; }
        
    }
}
