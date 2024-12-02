using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Models;

namespace DataLayer.DatabaseAccess
{
    public class DBAccess : DbContext
    {
        public DBAccess(DbContextOptions<DBAccess> options) : base(options)
        { }
        public DbSet<LoginModel> LoginCredentials { get; set; }

    }
}
