using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;

namespace AndreTurismoApp.AddressServeceNew.Data
{
    public class AndreTurismoAppAddressServeceNewContext : DbContext
    {
        public AndreTurismoAppAddressServeceNewContext (DbContextOptions<AndreTurismoAppAddressServeceNewContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoApp.Models.Address> Address { get; set; } = default!;
    }
}
