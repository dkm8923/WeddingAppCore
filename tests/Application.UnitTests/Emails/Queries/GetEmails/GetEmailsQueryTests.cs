using AutoMapper;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Emails.Queries;
using CleanArchitecture.Infrastructure.Persistence;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Emails.Queries.GetEmails
{
    [Collection("QueryTests")]
    public class GetEmailsQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEmailsQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectEmailCount()
        {
            var query = new GetEmailQuery();

            var handler = new GetEmailQuery.GetEmailQueryHandler(_context, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<List<EmailDto>>();
            result.Count().ShouldBe(1);
        }
    }
}
