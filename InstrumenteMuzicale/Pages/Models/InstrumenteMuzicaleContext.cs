using Microsoft.EntityFrameworkCore;

namespace InstrumenteMuzicale.Models
{
    public class InstrumenteMuzicaleContext : DbContext
    {
        public InstrumenteMuzicaleContext(DbContextOptions<InstrumenteMuzicaleContext> options)
            : base(options)
        {
        }

        public DbSet<Instrument> Instrumente { get; set; }
        public DbSet<Comanda> Comenzi { get; set; }
    }
}
