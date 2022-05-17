

namespace Tattoos.Domain.Models
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Tattoos.Common.Models.Tatuajes> Tatuajes { get; set; }
    }
}
