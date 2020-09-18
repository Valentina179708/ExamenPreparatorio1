namespace admGemio.Models
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<admGemio.Models.gemio> gemios { get; set; }
    }
}