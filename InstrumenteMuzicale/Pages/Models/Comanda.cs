using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstrumenteMuzicale.Models
{
    public class Comanda
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nume Client")]
        public string NumeClient { get; set; } = string.Empty;

        [Required]
        public string AdresaLivrare { get; set; } = string.Empty;

        [Required]
        public string Telefon { get; set; } = string.Empty;

        public DateTime DataComanda { get; set; } = DateTime.Now;

        
        [Required]
        [Display(Name = "Instrument")]
        public int InstrumentID { get; set; }

        [ForeignKey("InstrumentID")]
        public Instrument? Instrument { get; set; }
    }
}
