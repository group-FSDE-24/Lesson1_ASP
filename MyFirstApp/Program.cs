//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");




using MyFirstApp.Helper;
using System.Net;
using System.Text;

#region Comeback

// HttpListener httpListener = new HttpListener();


// httpListener.Prefixes.Add("http://localhost:27001/");

// httpListener.Start();

// Console.WriteLine("Listening ....");

// while (true)
// {
//     var context = httpListener.GetContext();

//     context.Response.OutputStream.Write(Encoding.UTF8.GetBytes("Hello world!"));
//     context.Response.Close();

//     Console.WriteLine("Response return...");
// }

#endregion


var webhost = new WebHost(27001);

webhost.Run();





