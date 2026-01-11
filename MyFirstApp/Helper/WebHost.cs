using System.Net;

namespace MyFirstApp.Helper;

public class WebHost
{
    private short _port { get; set; }
    private HttpListener _httpListener { get; set; }


    public WebHost(short port)
    {
        _port = port;
    }


    public void Run()
    {
        _httpListener = new HttpListener();

        _httpListener.Prefixes.Add($"http://localhost:{_port}/");

        _httpListener.Start();

        Console.WriteLine($"Httplistener started on {_port}");

        while (true)
        {
            var context = _httpListener.GetContext();

            Task.Run(() =>
            {
                HandlerRequest(context);
            });

        }


    }

    private void HandlerRequest(HttpListenerContext context)
    {
        var request = context.Request;
        var response = context.Response;

        // Rawurl -> /contact
        // http://localhost:27001/contact.html

        var str = request.RawUrl;

        var requestPath = str.Substring(1); // contact

        try
        {
            if (!Path.HasExtension(requestPath))
                requestPath += ".html";


            var fileName = "../../../Views/" + requestPath;

            if(File.Exists(fileName))
            {
                response.StatusCode = 200;






            }
            else
            {

            }



        }
        catch (Exception ex)
        {

        }
        finally
        {

        }





    }


}
