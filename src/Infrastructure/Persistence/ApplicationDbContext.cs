using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using CleanArchitecture.Infrastructure.Identity;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<TodoList> TodoLists { get; set; }

        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<WeddingDescription> WeddingDescriptions { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<EmailLog> EmailLogs { get; set; }
        public DbSet<GuestBookEntry> GuestBookEntries { get; set; }
        public DbSet<UsaState> UsaStates { get; set; }

        //Ui App Settings
        public DbSet<UiAppSetting> UiAppSettings { get; set; }
        public DbSet<UiAppSettingReferenceType> UiAppSettingReferenceTypes { get; set; }
        public DbSet<UiAppSettingApplication> UiAppSettingApplications { get; set; }
        public DbSet<UiAppSettingFooter> UiAppSettingFooters { get; set; }
        public DbSet<UiAppSettingHeader> UiAppSettingHeaders { get; set; }
        public DbSet<UiAppSettingNavLink> UiAppSettingNavLinks { get; set; }
        public DbSet<UiAppSettingNavLinkSection> UiAppSettingNavLinkSections { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
