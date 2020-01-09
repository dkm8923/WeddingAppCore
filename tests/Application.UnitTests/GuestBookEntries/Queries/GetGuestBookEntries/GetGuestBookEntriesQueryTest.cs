using AutoMapper;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.GuestBookEntries.Queries;
using CleanArchitecture.Infrastructure.Persistence;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.GuestBookEntries.Queries.GetGuestBookEntries
{
    [Collection("QueryTests")]
    public class GetGuestBookEntriesQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGuestBookEntriesQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectGuestBookEntryCount()
        {
            var query = new GetGuestBookEntryQuery();

            var handler = new GetGuestBookEntryQuery.GetGuestBookEntryQueryHandler(_context, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<List<GuestBookEntryDto>>();
            result.Count().ShouldBe(1);
        }
    }
}
