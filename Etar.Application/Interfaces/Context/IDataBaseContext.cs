using Etar.Domain.Entities.Addresses;
using Etar.Domain.Entities.Foods;
using Etar.Domain.Entities.Table;
using Etar.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Interfaces.Context
{
    public interface IDataBaseContext
    {
        DbSet<Client> users { get; set; }
        DbSet<Admin> admins { get; set; }
        DbSet<Address> addresses { get; set; }
        DbSet<FoodCategory> foodCategories { get; set; }
        DbSet<Food> foods { get; set; }
        DbSet<Table> tables { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}

