using System.ComponentModel.DataAnnotations;

namespace InstrumenteMuzicale.Models
{
    public class Instrument
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nume Instrument")]
        public string Nume { get; set; } = string.Empty;

        public string? Descriere { get; set; }

        [Required]
        public decimal Pret { get; set; }

        public string? Categorie { get; set; }

        public string? Imagine { get; set; }

        public List<Comanda>? Comenzi { get; set; }
    }
}
