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
    var helloFolder = new DirectoryInfo(Directory.GetCurrentDirectory());
    var helloPath = Path.Combine(helloFolder.FullName, "hello.txt");

    // alternative shorter syntax ( same result )

    var helloPath2 = Path.Combine(Directory.GetCurrentDirectory(), "hello.txt");

    // print to console for debugging purposes
    Console.WriteLine($"Reading hello from {helloPath}");

    var message = File.ReadAllText("hello.txt");
    return "Read from FILE:\n\n" + message;
}


// Deploy with:
// az webapp up --name my-very-best-net24s-chapp -g test1 --location westeurope --sku B1 --os-type linux