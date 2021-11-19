using System;

namespace Tolitech.CodeGenerator.Pagination.Tests.Models
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}