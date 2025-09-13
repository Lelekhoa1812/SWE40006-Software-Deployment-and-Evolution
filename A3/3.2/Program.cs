using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace _3._2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // HTML UI for root
            app.MapGet("/", () => Results.Content(@"
            <!doctype html>
            <html>
            <head>
            <meta charset='utf-8'>
            <title>C# Calculator</title>
            </head>
            <body>
            <h1>ASP.NET Core Calculator</h1>
            <form action='/calculate' method='post'>
                <input type='number' step='any' name='a' required placeholder='Enter number A'>
                <select name='op'>
                <option value='add'>+</option>
                <option value='sub'>−</option>
                <option value='mul'>×</option>
                <option value='div'>÷</option>
                </select>
                <input type='number' step='any' name='b' required placeholder='Enter number B'>
                <button type='submit'>=</button>
            </form>
            </body>
            </html>
            ", "text/html"));

            // Handle form submission
            app.MapPost("/calculate", (HttpRequest request) =>
            {
                var form = request.Form;
                double a = double.Parse(form["a"]!);
                double b = double.Parse(form["b"]!);
                string op = form["op"]!;

                double result;
                string output;

                switch (op)
                {
                    case "add":
                        result = a + b;
                        output = $"{a} + {b} = {result}";
                        break;
                    case "sub":
                        result = a - b;
                        output = $"{a} − {b} = {result}";
                        break;
                    case "mul":
                        result = a * b;
                        output = $"{a} × {b} = {result}";
                        break;
                    case "div":
                        if (b == 0) output = "Error: Division by zero!";
                        else output = $"{a} ÷ {b} = {a / b}";
                        break;
                    default:
                        output = "Invalid operation.";
                        break;
                }

                return Results.Content($@"
            <!doctype html>
            <html>
            <head><meta charset='utf-8'><title>Result</title></head>
            <body>
            <h1>Result</h1>
            <p>{output}</p>
            <a href='/'>Back</a>
            </body>
            </html>
            ", "text/html");
            });

            app.Run();
        }

        public record CalcRequest(double a, double b);
    }
}
