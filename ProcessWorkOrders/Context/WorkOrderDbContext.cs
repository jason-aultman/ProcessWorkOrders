using Microsoft.EntityFrameworkCore;
using ProcessWorkOrders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessWorkOrders.Context
{
    public class WorkOrderDbContext : DbContext
    {
        public WorkOrderDbContext(DbContextOptions<WorkOrderDbContext> options):base(options)
        {

        }
        public DbSet<Roll> Rolls { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
