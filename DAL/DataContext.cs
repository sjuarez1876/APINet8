using ApiPersonas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonas.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<tbl_personas> tbl_personas { get; set; }
    }
}
