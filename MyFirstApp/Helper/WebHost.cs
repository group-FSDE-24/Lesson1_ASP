using System.Net;
using System.Text;

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

            if (File.Exists(fileName))
            {
                response.StatusCode = 200;

                response.ContentType = GetContentType(requestPath);

                var bytes = File.ReadAllBytes(fileName);

                response.OutputStream.Write(bytes);
            }
            else
            {
                string notFound = Path.Combine("../../../Views", "NotFound.html");
                response.StatusCode = 404;

                // TODO: Bura baxilacaq
                response.ContentType = GetContentType(requestPath);

                var bytes = File.ReadAllBytes(notFound);
                response.OutputStream.Write(bytes, 0, bytes.Length);
            }



        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            response.OutputStream.Write(Encoding.UTF8.GetBytes(ex.Message));
        }
        finally
        {
            response.Close();
        }

    }

    private string GetContentType(string path)
    {
        string contentType = "text/html";

        switch (Path.GetExtension(path).ToLower())
        {
            case ".css":
                contentType = "text/css";
                break;

            case ".js":
                contentType = "text/javascript";
                break;

            // Şəkillər
            case ".png":
                contentType = "image/png";
                break;

            case ".jpg":
            case ".jpeg":
                contentType = "image/jpeg";
                break;

            case ".gif":
                contentType = "image/gif";
                break;

            case ".svg":
                contentType = "image/svg+xml";
                break;

            case ".webp":
                contentType = "image/webp";
                break;

            // PDF
            case ".pdf":
                contentType = "application/pdf";
                break;
        }

        return contentType;
    }


}
