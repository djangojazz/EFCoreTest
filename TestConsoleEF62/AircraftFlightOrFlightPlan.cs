//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestConsoleEF62
{
    using System;
    using System.Collections.Generic;
    
    public partial class AircraftFlightOrFlightPlan
    {
        public int AircraftFlightOrFlightPlanId { get; set; }
        public string ReferencedTable { get; set; }
        public Nullable<int> AircraftId { get; set; }
        public Nullable<int> FlightId { get; set; }
        public Nullable<int> FlightPlanId { get; set; }
        public Nullable<int> CreatedById { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> ModifiedById { get; set; }
        public Nullable<System.DateTime> ModifiedLast { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual Aircraft Aircraft { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual FlightPlan FlightPlan { get; set; }
    }
}