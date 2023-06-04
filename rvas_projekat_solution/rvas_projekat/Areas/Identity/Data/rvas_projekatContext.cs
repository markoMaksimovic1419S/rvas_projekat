using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rvas_projekat.Areas.Identity.Data;
using rvas_projekat.Models;

namespace rvas_projekat.Areas.Identity.Data;

public class rvas_projekatContext : IdentityDbContext<rvas_projekatUser>
{
    public rvas_projekatContext(DbContextOptions<rvas_projekatContext> options)
        : base(options)
    {
    }
    public DbSet<rvas_projekat.Models.ChatSoba> ChatSoba { get; set; }


    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //     base.OnModelCreating(builder);
    // Customize the ASP.NET Identity model and override the defaults if needed.
    // For example, you can rename the ASP.NET Identity table names and more.
    // Add your customizations after calling base.OnModelCreating(builder);
    // }
}
