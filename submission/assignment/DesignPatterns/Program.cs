using PatternsLab.Problems.Builder;
using PatternsLab.Problems.Prototype;
using PatternsLab.Problems.Singleton;

class Program
{
    static void Main(string[] args)
    {
        //var database = new DatabaseService();
        //var ui = new UiService();

        //database.Config.Theme = "Dark";

        //database.Connect();
        //ui.Render();

        //Console.WriteLine(
        //    $"Same instance: {ReferenceEquals(database.Config, ui.Config)}"
        //);

        //Console.WriteLine(
        //    $"Load count: {AppConfig.LoadCount}"
        //);



        //Enemy prototype = new Orc();


        //Enemy copy = prototype.Clone();


        //Console.WriteLine($"Prototype ModelId: {prototype.ModelId}");
        //Console.WriteLine($"Copy ModelId:      {copy.ModelId}");

        //Console.WriteLine(
        //    $"Same Object: {ReferenceEquals(prototype, copy)}"
        //);


        //copy.Weapon.Damage = 100;
        //copy.Abilities.Add("Fireball");

        //Console.WriteLine($"Original Weapon Damage: {prototype.Weapon.Damage}");
        //Console.WriteLine($"Copy Weapon Damage:     {copy.Weapon.Damage}");


        //Console.WriteLine(
        //    $"Original Abilities: {string.Join(", ", prototype.Abilities)}"
        //);

        //Console.WriteLine(
        //    $"Copy Abilities:     {string.Join(", ", copy.Abilities)}"
        //);



        var liveRegistration = new CourseRegistration.Builder()
            .ForStudent("Kerolos")
            .ForCourse("C# Advanced")
            .AsLiveGroup("CSHARP-01")
            .Build();

        var videosRegistration = new CourseRegistration.Builder()
            .ForStudent("Ahmed")
            .ForCourse("Design Patterns")
            .AsVideosOnly()
            .Build();

        Console.WriteLine("Live Group Registration");
        Console.WriteLine($"Student: {liveRegistration.StudentName}");
        Console.WriteLine($"Course: {liveRegistration.CourseName}");
        Console.WriteLine($"Type: {liveRegistration.RegistrationType}");
        Console.WriteLine($"Group Code: {liveRegistration.GroupCode}");

        Console.WriteLine();

        Console.WriteLine("Videos Only Registration");
        Console.WriteLine($"Student: {videosRegistration.StudentName}");
        Console.WriteLine($"Course: {videosRegistration.CourseName}");
        Console.WriteLine($"Type: {videosRegistration.RegistrationType}");
        Console.WriteLine($"Group Code: {videosRegistration.GroupCode}");
    }
}