using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstScaffolding.Models
{
    public sealed class Flight : BaseModel
    {
        public Flight() { }

        public Flight(string flightAlias)
        {
            FlightAlias = flightAlias;
        }

        [Key]
        public int FlightId { get; set; }
        [Column(TypeName = "varchar(128)"), MaxLength(128)]
        public string FlightAlias { get; set; }
    }
}
