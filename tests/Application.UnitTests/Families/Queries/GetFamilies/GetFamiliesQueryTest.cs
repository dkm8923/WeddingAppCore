using AutoMapper;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Families.Queries;
using CleanArchitecture.Infrastructure.Persistence;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Families.Queries.GetFamilies
{
    [Collection("QueryTests")]
    public class GetFamiliesQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetFamiliesQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectFamilyCount()
        {
            var query = new GetFamilyQuery();

            var handler = new GetFamilyQuery.GetFamilyQueryHandler(_context, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<List<FamilyDto>>();
            result.Count().ShouldBe(1);
        }
    }
}
