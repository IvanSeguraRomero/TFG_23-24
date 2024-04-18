
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashGamingHub.Models
{
    public class Studio
    {
        [Key]
        public int StudioID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        public DateTime Fundation { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EmailContact { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Website { get; set; }

        public bool Active { get; set; }
    }
}
