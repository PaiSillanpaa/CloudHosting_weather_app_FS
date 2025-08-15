var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!"); // using anonymous function
app.MapGet("/hellous", HelloMethod);

app.Run();

string HelloMethod()
{
    var message = File.ReadAllText("hello.txt");

    // soon we add code, which reads the message from code
    return "Read from FILE:\n\n" + message;
}