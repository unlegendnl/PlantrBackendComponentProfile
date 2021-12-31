using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authService.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("Role")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
