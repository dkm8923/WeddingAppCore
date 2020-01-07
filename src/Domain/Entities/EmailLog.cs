using CleanArchitecture.Domain.Common;
using System;

namespace CleanArchitecture.Domain.Entities
{
    public class EmailLog : AuditableEntity
    {
        public long Id { get; set; }
        public int EmailId { get; set; }
        public DateTime SentDate { get; set; }
        public string SentBy { get; set; }
        //public int GuestDetailId { get; set; }
    }
}
