using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authService.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        //[JsonIgnore] // does not need to be included in returned API responses
        public string Password { get; set; }

        public bool Admin { get; set; }

    }
}
