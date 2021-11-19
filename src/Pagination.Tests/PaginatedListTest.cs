using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Tolitech.CodeGenerator.Pagination.Tests.Models;

namespace Tolitech.CodeGenerator.Pagination.Tests
{
    public class PaginatedListTest
    {
        private IList<Person> people;

        public PaginatedListTest()
        {
            people = new List<Person>();

            for (int i = 0; i < 50; i++)
            {
                people.Add(new Person($"Person {i}"));
            }
        }

        [Fact(DisplayName = "PaginatedList - ConstructorOne - Valid")]
        public void PaginatedList_ConstructorOne_Valid()
        {
            var items = people.Skip(0).Take(10).ToList();
            var paginated = new PaginatedList<Person>(items, people.Count, 1, 10);
            Assert.True(paginated.Count == 10);
            Assert.True(paginated.TotalItemCount == 50);
        }

        [Theory(DisplayName = "PaginatedList - ConstructorTwo - Valid")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void PaginatedList_ConstructorTwo_Valid(int pageNumber)
        {
            var paginated = new PaginatedList<Person>(people, pageNumber, 10);
            Assert.True(paginated.Count == 10);
            Assert.True(paginated.TotalItemCount == 50);
            Assert.True(paginated.First().Name == $"Person {(pageNumber - 1) * 10}");
        }

        [Fact(DisplayName = "PaginatedList - PageNumberOne - Valid")]
        public void PaginatedList_PageNumberOne_Valid()
        {
            var paginated = new PaginatedList<Person>(people, 1, 10);
            Assert.True(paginated.HasPreviousPage == false);
            Assert.True(paginated.HasNextPage == true);
            Assert.True(paginated.IsFirstPage == true);
            Assert.True(paginated.IsLastPage == false);
        }

        [Fact(DisplayName = "PaginatedList - PageNumberThree - Valid")]
        public void PaginatedList_HasNextPage_Valid()
        {
            var paginated = new PaginatedList<Person>(people, 3, 10);
            Assert.True(paginated.HasPreviousPage == true);
            Assert.True(paginated.HasNextPage == true);
            Assert.True(paginated.IsFirstPage == false);
            Assert.True(paginated.IsLastPage == false);
        }

        [Fact(DisplayName = "PaginatedList - PageNumberFive - Valid")]
        public void PaginatedList_IsFirstPage_Valid()
        {
            var paginated = new PaginatedList<Person>(people, 5, 10);
            Assert.True(paginated.HasPreviousPage == true);
            Assert.True(paginated.HasNextPage == false);
            Assert.True(paginated.IsFirstPage == false);
            Assert.True(paginated.IsLastPage == true);
        }
    }
}
