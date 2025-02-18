using CourseCLI;

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


Console.WriteLine("8. Feladat:");

Console.WriteLine("9. Feladat:");

Console.WriteLine("10. Feladat:");