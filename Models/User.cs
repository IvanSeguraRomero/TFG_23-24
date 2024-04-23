using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlashGamingHub.Models;
public class User
{
        [Key]
        public int UserID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        
        [Column(TypeName = "nvarchar(50)")]
        public string Surname { get; set; }

        
        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; }

        [Column(TypeName = "int")]
        public int? Age { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }

        public bool Active { get; set; }

        [ForeignKey("UserID")]
         public int LibraryGameUserID { get; set; }

         public LibraryGameUser libraryGameUser{ get; set; }

         [ForeignKey("MessageID")]
         public int MessageID { get; set; }

         public Community community{ get; set; }
    
}