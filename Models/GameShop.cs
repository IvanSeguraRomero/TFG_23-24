using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashGamingHub.Models
{
    public class GameShop
    {
        [Key]
        public int StoreID { get; set; }


        [Column(TypeName = "nvarchar(80)")]
        public string Event { get; set; }
        //cuando se cree modifique o elimine un juego el estudio, el stock se actualizara, y lastupdated
        public int Stock { get; set; }

        public int AnnualSales { get; set; }

        public DateTime LastUpdated { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string Origin { get; set; }

        public List<Game> Games { get; set; }

        
    // [Column(TypeName = "nvarchar(100)")]
    // public string Location { get; set; } // Ubicación física de la tienda

    // public int ContactNumber { get; set; } // Número de contacto
    //     [Column(TypeName = "nvarchar(50)")]
    // public string OpeningHours { get; set; } // Horario de apertura

    // [Column(TypeName = "nvarchar(80)")]
    // public string ManagerName { get; set; } // Nombre del gerente

    // [Column(TypeName = "nvarchar(100)")]
    // public string Email { get; set; } // Dirección de correo electrónico
    }
}
