using DemoApplication.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DemoApplication.WebAPI.DatabaseContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeContacts> EmployeeContacts { get; set; }
        public DbSet<EmployeeGovernmentNumbers> EmployeeGovernmentNumbers { get; set; }


        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return Database.BeginTransactionAsync(cancellationToken);
        }


    }
}



//public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
//{
//    var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity &&
//     (e.State == EntityState.Added || e.State == EntityState.Modified)).Select(x => x.Entity as BaseEntity);

//    await UpdateEntries(entries, DateTime.UtcNow);

//    return await base.SaveChangesAsync(cancellationToken);
//}

//protected async Task UpdateEntries(IEnumerable<BaseEntity> entries, DateTime savedTime)
//{
//    await Task.Delay(10);

//    var username = "system";

//    foreach (var entry in entries)
//    {
//        if (entry.Id == default || string.IsNullOrEmpty(entry.CreatedBy))
//        {
//            entry.CreatedOn = savedTime;
//            entry.CreatedBy = username;
//        }
//        entry.UpdatedOn = savedTime;
//        entry.UpdatedBy = username;               
//    }

//}