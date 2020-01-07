using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using System;

namespace CleanArchitecture.Application.UsaStates.Queries
{
    public class EmailLogDto : AuditableEntity, IMapFrom<Domain.Entities.UsaState>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AbbreviatedName { get; set; }
    }
}
