public namespace Tools.Download{
  
  /// url = "http://feeds.itunes.apple.com/feeds/epf/v3/full/current/itunes20110511.tbz.md5"
  /// downloadLocation = "C:\folder\file.md5"
  public void GetFileFromServer(string url, string downloadLocation, string username, string password){
    using (WebClient client = new WebClient()) {
      client.Credentials = new NetworkCredential(username, password);
      client.DownloadFile(url, downloadLocation);
    }
  }
  
  public HttpResponseMessage Post(string version, string environment,
    string filetype)
{
    var path = @"C:\Temp\test.exe";
    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
    var stream = new FileStream(path, FileMode.Open);
    result.Content = new StreamContent(stream);
    result.Content.Headers.ContentType = 
        new MediaTypeHeaderValue("application/octet-stream");
    return result;
}


}
