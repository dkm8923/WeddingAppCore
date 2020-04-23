using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }
        
        DbSet<Domain.Entities.WeddingDescription> WeddingDescriptions { get; set; }
        DbSet<Guest> Guests { get; set; }
        DbSet<Family> Families { get; set; }
        DbSet<Domain.Entities.Email> Emails { get; set; }
        DbSet<EmailLog> EmailLogs { get; set; }
        DbSet<GuestBookEntry> GuestBookEntries { get; set; }
        DbSet<UsaState> UsaStates { get; set; }

        //Ui App Settings
        public DbSet<UiAppSetting> UiAppSettings { get; set; }
        public DbSet<UiAppSettingReferenceType> UiAppSettingReferenceTypes { get; set; }
        public DbSet<UiAppSettingApplication> UiAppSettingApplications { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
