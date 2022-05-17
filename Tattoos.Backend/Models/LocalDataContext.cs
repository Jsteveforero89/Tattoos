

namespace Tattoos.Backend.Models
{
    using Tattoos.Domain.Models;
    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<Tattoos.Common.Models.Tatuajes> Tatuajes { get; set; }
    }
}