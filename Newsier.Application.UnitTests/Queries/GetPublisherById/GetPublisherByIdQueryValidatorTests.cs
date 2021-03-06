﻿using FluentValidation.Results;
using Newsier.Application.Queries.GetPublisherById;
using Newsier.Application.UnitTests.Common;
using Newsier.Infrastructure;
using Shouldly;
using Xunit;

namespace Newsier.Application.UnitTests.Queries.GetPublisherById
{
    [Collection("QueryTests")]
    public sealed class GetPublisherByIdQueryValidatorTests
    {
        private readonly NewsierContext _context;

        public GetPublisherByIdQueryValidatorTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Theory]
        [InlineData("test-publisher-1")]
        [InlineData("test-publisher-2")]
        public void Validate_GivenCorrectPublisherId_ShouldBeTrue(string publisherId)
        {
            GetPublisherByIdQuery query = new GetPublisherByIdQuery { PublisherId = publisherId };
            GetPublisherByIdQueryValidator validator = new GetPublisherByIdQueryValidator(_context);

            ValidationResult result = validator.Validate(query);

            result.IsValid.ShouldBe(true);
        }

        [Theory]
        [InlineData("test-publisher-723")]
        [InlineData("test-publisher-987")]
        public void Validate_GivenCorrectPublisherId_ShouldBeFalse(string publisherId)
        {
            GetPublisherByIdQuery query = new GetPublisherByIdQuery { PublisherId = publisherId };
            GetPublisherByIdQueryValidator validator = new GetPublisherByIdQueryValidator(_context);

            ValidationResult result = validator.Validate(query);

            result.IsValid.ShouldBe(false);
        }
    }
}
