using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities.Addresses;
using Etar.Domain.Entities.Carts;
using Etar.Domain.Entities.Foods;
using Etar.Domain.Entities.Orders;
using Etar.Domain.Entities.Table;
using Etar.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Presistance.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) 
        { }

        public DbSet<Client> users { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Address> addresses { get ; set; } 
        public DbSet<Food> foods { get; set; }
        public DbSet<FoodCategory> foodCategories { get; set; }
        public DbSet<Table> tables { get; set; }
        public DbSet<AdminCart> adminCarts { get; set; }
        public DbSet<AdminCartItem> adminCartItems { get; set; }
        public DbSet<AdminOrder> adminOrders { get; set; }

    }
}
