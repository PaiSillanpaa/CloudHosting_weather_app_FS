
Console.WriteLine(@$"Current Directory: 
{Directory.GetCurrentDirectory()}");

Console.WriteLine(@$"Executing Assembly: 
{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}");

// 1

var builder = WebApplication.CreateBuilder(args);

// 2
//we may need to configure builder before building ( as example, add controllers etc. )

// 3
var app = builder.Build();

//4
// MAP. ENDPOINT <-> metodi()
app.MapGet("/", () => "Hello World!"); // using anonymous function
app.MapGet("/hellous", GetHello);

// 5 after run... program will stop here to wait for GET/POST/UPDATE calls...
app.Run();

Console.WriteLine("this should never happen...");
// we will never get here...

string GetHello()
{
    // look for all assets in the same folder, where the program (dll's etc. ) are
    // usually bin/Debug/net9.0) 
    var helloFolder = new DirectoryInfo(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

    var helloPath = Path.Combine(helloFolder.FullName, "hello.txt");

    // alternative shorter syntax ( same result )

    // var helloPath2 = Path.Combine(Directory.GetCurrentDirectory(), "hello.txt");

    if (!File.Exists(helloPath))
    {
        return @$"Sorry, Can't find anything. Couldn't find {helloPath} . Please copy hello.txt to the folder with the executable.";
    }

    // print to console for debugging purposes
    Console.WriteLine($"FILE FOUND! Yippee!Reading hello from {helloPath}");

    var message = File.ReadAllText("hello.txt");
    return "Read from FILE:\n\n" + message;
}

