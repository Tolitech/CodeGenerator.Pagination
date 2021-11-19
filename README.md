# Tolitech.CodeGenerator.Pagination
Pagination library used in projects created by the Code Generator tool. 

This project allows simplifying the use and return of paginated lists either by using an ORM as Entity Framework Core, or by simply using lists with LINQ. 

Tolitech Code Generator Tool: [http://www.tolitech.com.br](https://www.tolitech.com.br/)

Examples:

```
public class Person
{
    public Person(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
}
```

```
var people = new List<Person>();

for (int i = 0; i < 50; i++)
{
    people.Add(new Person($"Person {i}"));
}
```

```
var items = people.Skip(0).Take(10).ToList();
var paginated = new PaginatedList<Person>(items, people.Count, 1, 10);
```

```
var paginated = new PaginatedList<Person>(people, 5, 10);
bool b1 = paginated.First().Name == "Person 40"); // this is true 
bool b2 = paginated.Last().Name == "Person 49"); // this is true 
```

```
var paginatedList = new PaginatedList<Person>(people, 5, 10);
var paginated = new Paginated<Person>(paginatedList, 5);
bool b1 = paginated.HasPreviousPage == true; // this is true 
bool b2 = paginated.HasNextPage == false; // this is true 
bool b3 = paginated.IsFirstPage == false; // this is true 
bool b4 = paginated.IsLastPage == true; // this is true 
bool b5 = paginated.FirstItemOnPage == 41; // this is true 
bool b6 = paginated.LastItemOnPage == 50; // this is true 
```

Other Usage Properties:
- HasPreviousPage
- HasNextPage
- IsFirstPage
- IsLastPage 

Check the unit tests to learn about other exposed properties and various possibilities for use. 