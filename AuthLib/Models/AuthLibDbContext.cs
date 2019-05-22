using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuthLib.Models
{
    public class AuthLibDbContext : DbContext
    {
        public AuthLibDbContext( DbContextOptions<AuthLibDbContext> options) : base(options)
        {
        }

        public DbSet<IdentityModel> Identities { get; set; }
    }

    public class IdentityModel
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
