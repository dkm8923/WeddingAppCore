using AutoMapper;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.EmailLogs.Queries;
using CleanArchitecture.Infrastructure.Persistence;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.EmailLogs.Queries.GetEmailLogs
{
    [Collection("QueryTests")]
    public class GetEmailLogsQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEmailLogsQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectEmailLogCount()
        {
            var query = new GetEmailLogQuery();

            var handler = new GetEmailLogQuery.GetEmailLogQueryHandler(_context, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<List<EmailLogDto>>();
            result.Count().ShouldBe(1);
        }
    }
}
