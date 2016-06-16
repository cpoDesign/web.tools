public namespace Tools.Download{
  
  /// url = "http://feeds.itunes.apple.com/feeds/epf/v3/full/current/itunes20110511.tbz.md5"
  /// downloadLocation = "C:\folder\file.md5"
  public void GetFileFromServer(string url, string downloadLocation, string username, string password){
    using (WebClient client = new WebClient()) {
      client.Credentials = new NetworkCredential(username, password);
      client.DownloadFile(url, downloadLocation);
    }
  }
}
