var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!"); // using anonymous function
app.MapGet("/hellous", GetHello);

app.Run();

string GetHello()
{
    var helloFolder = new DirectoryInfo(Directory.GetCurrentDirectory());
    var helloPath = Path.Combine(helloFolder.FullName, "hello.txt");

    // alternative shorter syntax ( same result )

    var helloPath2 = Path.Combine(Directory.GetCurrentDirectory(), "hello.txt");

    // print to console for debugging purposes
    Console.WriteLine($"Reading hello from {helloPath}");

    var message = File.ReadAllText("hello.txt");
    return "Read from FILE:\n\n" + message;
}
