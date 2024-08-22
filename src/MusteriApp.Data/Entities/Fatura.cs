using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusteriApp.Data.Entities
{
    [Table("musteri_fatura_table")]
    public class Fatura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("Musteri")]
        public int MUSTERI_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime FATURA_TARIHI { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal FATURA_TUTARI { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ODEME_TARIHI { get; set; }

        public Musteri Musteri { get; set; }
    }
}
