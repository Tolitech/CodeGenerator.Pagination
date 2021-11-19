using System;
using System.Collections.Generic;
using Tolitech.CodeGenerator.Pagination.Tests.Models;
using Xunit;

namespace Tolitech.CodeGenerator.Pagination.Tests
{
    public class PaginatedTest
    {
        private IList<Person> people;

        public PaginatedTest()
        {
            people = new List<Person>();

            for (int i = 0; i < 50; i++)
            {
                people.Add(new Person($"Person {i}"));
            }
        }

        [Fact(DisplayName = "Paginated - Default - Valid")]
        public void Paginated_Default_Valid()
        {
            var paginatedList = new PaginatedList<Person>(people, 1, 10);
            var paginated = new Paginated<Person>(paginatedList, 5);
            Assert.True(paginated.PageNumber == 1);
            Assert.True(paginated.PageSize == 10);
            Assert.True(paginated.PageCount == 5);
            Assert.True(paginated.TotalItemCount == 50);
        }

        [Fact(DisplayName = "Paginated - PageNumberOne - Valid")]
        public void Paginated_PageNumberOne_Valid()
        {
            var paginatedList = new PaginatedList<Person>(people, 1, 10);
            var paginated = new Paginated<Person>(paginatedList, 5);
            Assert.True(paginated.HasPreviousPage == false);
            Assert.True(paginated.HasNextPage == true);
            Assert.True(paginated.IsFirstPage == true);
            Assert.True(paginated.IsLastPage == false);
            Assert.True(paginated.FirstItemOnPage == 1);
            Assert.True(paginated.LastItemOnPage == 10);
        }

        [Fact(DisplayName = "Paginated - PageNumberThree - Valid")]
        public void Paginated_PageNumberThree_Valid()
        {
            var paginatedList = new PaginatedList<Person>(people, 3, 10);
            var paginated = new Paginated<Person>(paginatedList, 5);
            Assert.True(paginated.HasPreviousPage == true);
            Assert.True(paginated.HasNextPage == true);
            Assert.True(paginated.IsFirstPage == false);
            Assert.True(paginated.IsLastPage == false);
            Assert.True(paginated.FirstItemOnPage == 21);
            Assert.True(paginated.LastItemOnPage == 30);
        }

        [Fact(DisplayName = "Paginated - PageNumberFive - Valid")]
        public void Paginated_PageNumberFive_Valid()
        {
            var paginatedList = new PaginatedList<Person>(people, 5, 10);
            var paginated = new Paginated<Person>(paginatedList, 5);
            Assert.True(paginated.HasPreviousPage == true);
            Assert.True(paginated.HasNextPage == false);
            Assert.True(paginated.IsFirstPage == false);
            Assert.True(paginated.IsLastPage == true);
            Assert.True(paginated.FirstItemOnPage == 41);
            Assert.True(paginated.LastItemOnPage == 50);
        }
    }
}
