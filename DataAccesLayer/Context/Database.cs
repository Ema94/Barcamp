using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccesLayer
{
    public class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;" +
                "                       Initial Catalog=BarcampDb;" +
                "                       Integrated Security=True;" +
                "                       Connect Timeout=30;" +
                "                       Encrypt=False;" +
                "                       TrustServerCertificate=False;" +
                "                       ApplicationIntent=ReadWrite;" +
                "                       MultiSubnetFailover=False");

        }
        public DbSet<DataEntityPerson> Persons { get; set; }
    }
}
