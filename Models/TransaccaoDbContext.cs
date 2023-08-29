using Microsoft.EntityFrameworkCore;

namespace TransacoesBanco.Models
{
    public class TransaccaoDbContext: DbContext
    {
        public TransaccaoDbContext(DbContextOptions<TransaccaoDbContext>options): base(options) 
        { 

        }
        
        public DbSet<Transaccao> Transaccoes { get; set;}
            
        }
    }

