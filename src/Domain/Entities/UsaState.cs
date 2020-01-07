using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class UsaState : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AbbreviatedName { get; set; }
    }
}
