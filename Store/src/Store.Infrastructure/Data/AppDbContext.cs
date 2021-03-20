using Store.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.Core.Entities;
using Store.SharedKernel;
using Ardalis.EFCore.Extensions;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Store.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<StoreUser>
    {
        private readonly IDomainEventDispatcher _dispatcher;

        //public AppDbContext(DbContextOptions options) : base(options)
        //{
        //}

        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Item> Items { set; get; }
        public DbSet<ItemCart> ItemCarts { set; get; }
        public DbSet<ItemUniqueSpec> ItemUniqueSpecs { set; get; }
        public DbSet<OfferItem> OfferItems { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderedItem> OrderedItems { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();

            // alternately this is built-in to EF Core 2.2
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    await _dispatcher.Dispatch(domainEvent).ConfigureAwait(false);
                }
            }

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}