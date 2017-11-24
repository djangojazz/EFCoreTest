using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstScaffolding.Models
{
    public abstract class BaseModel
    {
        public BaseModel() { }

        public BaseModel(Users createdBy, Users modifiedyBy, DateTime? dateCreated = null, DateTime? modifiedLast = null)
        {
            CreatedBy = createdBy;
            ModifiedBy = modifiedyBy;
            DateCreated = (dateCreated == null) ? DateTime.Now : dateCreated;
            ModifiedLast = (modifiedLast == null) ? DateTime.Now : modifiedLast;
        }

        [Column(TypeName = "DateTime"), Required]
        public DateTime? DateCreated { get; set; }

        [ForeignKey("CreatedById"), Required]
        public Users CreatedBy { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime? ModifiedLast { get; set; }

        [ForeignKey("ModifiedById")]
        public Users ModifiedBy { get; set; }
    }
}
