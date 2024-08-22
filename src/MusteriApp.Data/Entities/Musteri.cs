using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusteriApp.Data.Entities
{
    [Table("musteri_tanim_table")]
    public class Musteri
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string UNVAN { get; set; }
    }
}
