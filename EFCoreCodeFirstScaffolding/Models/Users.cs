using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstScaffolding.Models
{
    public sealed class Users
    {
        public Users(string userName)
        {
            UserName = userName;
        }

        [Key]
        public int UserId { get; set; }

        public int TestId { get; set; }

        [Column(TypeName = "varchar(128)"), MaxLength(128)]
        public string UserName { get; set; }
    }
}
