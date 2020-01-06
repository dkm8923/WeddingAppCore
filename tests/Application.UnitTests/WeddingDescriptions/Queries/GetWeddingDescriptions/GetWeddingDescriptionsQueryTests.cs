using AutoMapper;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.WeddingDescriptions.Queries;
using CleanArchitecture.Infrastructure.Persistence;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.WeddingDescriptions.Queries.GetWeddingDescriptions
{
    [Collection("QueryTests")]
    public class GetWeddingDescriptionsQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetWeddingDescriptionsQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectWeddingDescriptionCount()
        {
            var query = new GetWeddingDescriptionQuery();

            var handler = new GetWeddingDescriptionQuery.GetWeddingDescriptionQueryHandler(_context, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<List<WeddingDescriptionDto>>();
            result.Count().ShouldBe(1);
        }
    }
}
