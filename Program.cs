using CourseCLI;
using System.Diagnostics;

List <Course> courses = new();

using StreamReader reader = new(@"../../../src/course.txt");
while (!reader.EndOfStream)
    courses.Add(new Course(reader.ReadLine()));

Console.WriteLine("1. Feladat:");
Console.WriteLine(courses.Count());

Console.WriteLine("2. Feladat:");
Console.WriteLine(courses.Average(x => x.Results[3]));

Console.WriteLine("3. Feladat:");
Console.WriteLine(courses.OrderByDescending(x => x.Results.Sum()).First().ToString());

Console.WriteLine("4. Feladat:");
Console.WriteLine(Convert.ToDouble(courses.Count(x => x.Gender)) / courses.Count());

Console.WriteLine("5. Feladat:");
Console.WriteLine(courses.OrderByDescending(x => x.Results[2] + x.Results[3]).Where(x => !x.Gender).First());

Console.WriteLine("6. Feladat:");
foreach (var student in courses)
{
    if(student.Money == 2600)
        Console.WriteLine(student);
}

Console.WriteLine("7. Feladat:");
Console.Write("Adjon meg egy nevet: ");
string name = Console.ReadLine();
var studentByName = courses.FirstOrDefault(x => x.FirstName + " " + x.FamilyName == name);
var indexes = studentByName.Results
    .Select((value, index) => new { value, index })
    .Where(x => x.value < 51)
    .Select(x => x.index)
    .ToList();
foreach (var index in indexes)
{
    switch (index)
    {
        case 0:
            Console.WriteLine("Hálózat bukás");
            break;
        case 1:
            Console.WriteLine("Mobil bukás");
            break;
        case 2:
            Console.WriteLine("Frontend bukás");
            break;
        case 3:
            Console.WriteLine("Backend bukás");
            break;
        default:
            break;
    }
}

Console.WriteLine("8. Feladat:");
var notFailed = courses.Where(x => x.Results[0] >= 51 && x.Results[1] >= 51 && x.Results[2] >= 51 && x.Results[3] >= 51);
Console.WriteLine(notFailed.Count(x => x.Results[0] == 100 || x.Results[1] == 100 || x.Results[2] == 100 || x.Results[3] == 100));

Console.WriteLine("9. Feladat:");
Console.WriteLine("Hálózat: " + courses.Count(x => x.Results[0] < 51));
Console.WriteLine("Mobil: " + courses.Count(x => x.Results[1] < 51));
Console.WriteLine("Frontend: " + courses.Count(x => x.Results[2] < 51));
Console.WriteLine("Backend: " + courses.Count(x => x.Results[3] < 51));

Console.WriteLine("10. Feladat:");
using StreamWriter writer = new(@"../../../src/atlag.txt", false);
List<Course> sorted = courses.OrderBy(x => x.FamilyName).ToList();
foreach (var student in sorted)
{
    writer.WriteLine(student.FirstName + ' ' + student.FamilyName + '-' + student.Results.Average());
}
Console.WriteLine("Sikeres kiírás!");