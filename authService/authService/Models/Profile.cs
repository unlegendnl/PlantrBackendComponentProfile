using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authService.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("Profile")]
    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string Biography { get; set; }

        public string ProfilePicture { get; set; }

    }
}
