using AutoMapper;
using CleanArchitecture.Application.EmailLogs.Queries;
using CleanArchitecture.Application.Emails.Queries;
using CleanArchitecture.Application.Families.Queries;
using CleanArchitecture.Application.GuestBookEntries.Queries;
using CleanArchitecture.Application.Guests.Queries;
using CleanArchitecture.Application.TodoLists.Queries.GetTodos;
using CleanArchitecture.Application.UsaStates.Queries;
using CleanArchitecture.Application.WeddingDescriptions.Queries;
using CleanArchitecture.Domain.Entities;
using System;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Common.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
        
        [Theory]
        [InlineData(typeof(TodoList), typeof(TodoListDto))]
        [InlineData(typeof(TodoItem), typeof(TodoItemDto))]
        [InlineData(typeof(WeddingDescription), typeof(WeddingDescriptionDto))]
        [InlineData(typeof(Email), typeof(EmailDto))]
        [InlineData(typeof(EmailLog), typeof(EmailLogDto))]
        [InlineData(typeof(Family), typeof(FamilyDto))]
        [InlineData(typeof(Guest), typeof(GuestDto))]
        [InlineData(typeof(GuestBookEntry), typeof(GuestBookEntryDto))]
        [InlineData(typeof(UsaState), typeof(UsaStateDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}
