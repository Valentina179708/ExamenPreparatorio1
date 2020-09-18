

namespace ExamenP1.Models
{
    using System.Data.Entity;
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<ExamenP1.Models.gemio> gemios { get; set; }
    }
}