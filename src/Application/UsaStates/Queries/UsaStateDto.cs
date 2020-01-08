using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UsaStates.Queries
{
    public class UsaStateDto : AuditableEntity, IMapFrom<UsaState>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AbbreviatedName { get; set; }
    }
}
