using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class RestoranDBContext:IdentityDbContext<User> 
    {
        internal object restaurant;

        public RestoranDBContext(DbContextOptions<RestoranDBContext> options) : base(options) { }
        
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<Owner> owners { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<RestaurantUnit> restaurantUnits { get; set; }
        public DbSet<Shift> shifts { get; set; }
        public DbSet<WorkPlace> workPlaces { get; set; }
        public DbSet<Recipe> recipes { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Meal> meals { get; set; }
        public DbSet<UnitMenu> unitMenus { get; set; }
        public DbSet<SpecialOffer> specialOffers { get; set; }
        public DbSet<Schedule> schedules { get; set; }
        public DbSet<Bill> bills { get; set; }
        public DbSet<BillMeal> billMeals { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<TablePosition> tablePositions { get; set; }
        public DbSet<Table> tables { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>()
                .Property(b => b.GeneralEmployeeNo)
                .HasDefaultValue(0);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Owners)
                .WithOne(o => o.Restaurant)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Country>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<City>()
                .HasIndex(c => c.ZIPCode)
                .IsUnique();

            modelBuilder.Entity<Location>()
                .HasOne(l => l.Country)
                .WithOne(t => t.Location)
                .HasForeignKey<Location>(l => l.CountryFK);

            modelBuilder.Entity<Location>()
                .HasOne(l => l.City)
                .WithOne(t => t.Location)
                .HasForeignKey<Location>(l => l.CityFK);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.RestaurantUnits)
                .WithOne(u => u.Restaurant)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.meals)
                .WithOne(m => m.Category);

            /*modelBuilder.Entity<Meal>()
                .HasMany(m => m.Recipe)
                .WithOne(r => r.Meal)
                .OnDelete(DeleteBehavior.Cascade);*/

            /*modelBuilder.Entity<RestaurantUnit>()
                .HasMany(r => r.UnitMenus)
                .WithOne(u => u.AllRestaurantUnit)
                .HasForeignKey<UnitMenu>(u => u.MealFK);

            modelBuilder.Entity<Meal>()
                .HasMany(m => m.unitMenus)
                .WithOne(u => u.AllMeals);*/

            modelBuilder.Entity<UnitMenu>()
                .HasKey(i => new { i.MealId, i.UnitId });

            /*modelBuilder.Entity<Meal>()
                .HasMany(m => m.specialOffers)
                .WithOne(o => o.Meal)
                .OnDelete(DeleteBehavior.Cascade);*/

            modelBuilder.Entity<Schedule>()
                .Property(b => b.OvertimeHours)
                .HasDefaultValue(0);

            modelBuilder.Entity<RestaurantUnit>()
                .HasMany(u => u.schedules)
                .WithOne(s => s.RestaurantUnit);

            modelBuilder.Entity<Shift>()
                .HasMany(u => u.Schedules)
                .WithOne(s => s.Shift);

            modelBuilder.Entity<WorkPlace>()
                .HasMany(u => u.Schedules)
                .WithOne(s => s.WorkPlace);

            modelBuilder.Entity<RestaurantUnit>()
                .HasMany(r => r.Bills)
                .WithOne(b => b.RestaurantUnit);

            /*modelBuilder.Entity<Bill>()
                .HasMany(b => b.BillMeals)
                .WithOne(x => x.Bill);

            modelBuilder.Entity<Meal>()
                .HasMany(m => m.BillMeals)
                .WithOne(x => x.Meal);*/

            modelBuilder.Entity<BillMeal>()
                .HasKey(bm => new { bm.BillId, bm.MealId });

            modelBuilder.Entity<RestaurantUnit>()
                .HasMany(r => r.Orders)
                .WithOne(b => b.RestaurantUnit);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Bill)
                .WithOne(b => b.Order)
                .HasForeignKey<Order>(o => o.BillFK);

            modelBuilder.Entity<OrderMeal>()
                .HasKey(bm => new { bm.OrderId, bm.MealId });

            modelBuilder.Entity<RestaurantUnit>()
                .HasMany(r => r.Users)
                .WithOne(u => u.RestaurantUnit)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Shift>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Shift);

            modelBuilder.Entity<TablePosition>()
                .HasMany(p => p.Tables)
                .WithOne(t => t.TablePosition);

            modelBuilder.Entity<RestaurantUnit>()
                .HasMany(r => r.Tables)
                .WithOne(t => t.RestaurantUnit);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Tables)
                .WithOne(t => t.User);

            modelBuilder.Entity<Schedule>()
                .HasMany(s => s.Users)
                .WithOne(u => u.Schedule);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Bills)
                .WithOne(b => b.User);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User);

            modelBuilder.Entity<User>(b => {
                b.HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();
                b.HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();
                b.HasMany(e => e.Tokens).WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
                b.HasMany(e => e.UserRoles)
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });

            modelBuilder.Entity<Location>(e => {
                e.HasIndex(e => e.CountryFK)
                 .IsUnique(false);
            });

            modelBuilder.Entity<Location>(e => {
                e.HasIndex(e => e.CityFK)
                 .IsUnique(false);
            });

          
            
        }


        
    }


}
