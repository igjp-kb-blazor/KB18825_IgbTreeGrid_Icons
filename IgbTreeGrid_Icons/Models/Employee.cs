namespace IgbTreeGrid_Icons.Models;

public record Employee(int Id, int? ParentId, string Name, string Title, string Country, int Age, DateTime HireDate, bool OnPTO);

public static class EmployeeData
{
    public static IReadOnlyList<Employee> Create() =>
    [
        new(1, null, "Johnathan Winchester", "Development Manager", "USA", 55, new DateTime(2008, 3, 20), false),
        new(2, 1, "Ana Sanders", "Senior Software Developer", "USA", 43, new DateTime(2011, 6, 3), false),
        new(3, 2, "Laurence Johnson", "Software Developer", "Canada", 31, new DateTime(2016, 9, 12), true),
        new(4, 2, "Victoria Lincoln", "Software Developer", "UK", 29, new DateTime(2018, 1, 15), false),
        new(5, 1, "Michael Burke", "Senior Software Developer", "Japan", 38, new DateTime(2012, 11, 1), false),
        new(6, 5, "Elizabeth Richards", "QA Engineer", "Japan", 27, new DateTime(2020, 4, 1), true),
        new(7, null, "Casey Houston", "Sales Manager", "UK", 47, new DateTime(2009, 7, 7), false),
        new(8, 7, "Monica Reyes", "Sales Representative", "Germany", 34, new DateTime(2015, 2, 23), false),
        new(9, 7, "Roland Mendel", "Sales Representative", "Austria", 41, new DateTime(2013, 10, 30), true),
        new(10, 9, "Yang Wang", "Sales Associate", "Japan", 25, new DateTime(2022, 5, 16), false),
        new(11, null, "Maria Anders", "Marketing Manager", "Germany", 50, new DateTime(2010, 8, 9), false),
        new(12, 11, "Thomas Hardy", "Marketing Specialist", "UK", 36, new DateTime(2017, 3, 6), false),
        new(13, 11, "Hanna Moos", "Marketing Specialist", "Germany", 30, new DateTime(2019, 12, 2), true),
    ];
}
