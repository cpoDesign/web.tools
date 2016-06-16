/*
[Route("Images/{*imagePath}")]
public IHttpActionResult GetImage(string imagePath)
{
    var serverPath = Path.Combine(_rootPath, imagePath);
    var fileInfo = new FileInfo(serverPath);

    return !fileInfo.Exists
        ? (IHttpActionResult) NotFound()
        : new FileResult(fileInfo.FullName);
}

And here's one way you can tell IIS to ignore requests with an extension so that the request will make it to the controller:

<!-- web.config -->
<system.webServer>
  <modules runAllManagedModulesForAllRequests="true"/>
  
  ref:http://stackoverflow.com/questions/9541351/returning-binary-file-from-controller-in-asp-net-web-api
*/
public class FileResult : IHttpActionResult
{
    private readonly string _filePath;
    private readonly string _contentType;

    public FileResult(string filePath, string contentType = null)
    {
        if (filePath == null) throw new ArgumentNullException("filePath");

        _filePath = filePath;
        _contentType = contentType;
    }

    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(File.OpenRead(_filePath))
        };

        var contentType = _contentType ?? MimeMapping.GetMimeMapping(Path.GetExtension(_filePath));
        response.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

        return Task.FromResult(response);
    }
}
