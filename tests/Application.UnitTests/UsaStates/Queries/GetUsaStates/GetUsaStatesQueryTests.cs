using AutoMapper;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.UsaStates.Queries;
using CleanArchitecture.Infrastructure.Persistence;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.UsaStates.Queries.GetUsaStates
{
    [Collection("QueryTests")]
    public class GetUsaStatesQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUsaStatesQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectUsaStateCount()
        {
            var query = new GetUsaStateQuery();

            var handler = new GetUsaStateQuery.GetUsaStateQueryHandler(_context, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<List<UsaStateDto>>();
            result.Count().ShouldBe(1);
        }
    }
}
