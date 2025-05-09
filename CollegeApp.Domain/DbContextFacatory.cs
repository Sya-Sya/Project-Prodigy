using CollegeApp.Domain.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace CollegeApp.Domain
{
    public class DbContextFacatory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Replace with your actual connection string
            //optionsBuilder.UseSqlServer("Server=localhost;Database=CollegeAppDb;Trusted_Connection=True;TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer("server=172.20.22.12;Database=IME_SWIFT_REMIT_V0;uid=prasant;pwd=ime@1111");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
