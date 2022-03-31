using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Teste.API.Data
{
    public class TesteDbContextFactory : IDesignTimeDbContextFactory<TesteDbContext>
    {
        public TesteDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<TesteDbContext>();
            optionBuilder.UseSqlServer("Server=localhost;Database=teste;user=sa;password=1234");

            return new TesteDbContext(optionBuilder.Options);
        }
    }
}
