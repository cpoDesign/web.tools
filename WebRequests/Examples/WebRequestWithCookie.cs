  // SourceForExample http://stackoverflow.com/questions/10263082/how-to-pass-post-parameters-to-asp-net-web-request
  
  string email = "YOUR EMAIL";
  string password = "YOUR PASSWORD";

  string URLAuth = "https://accounts.craigslist.org/login";
  string postString = string.Format("inputEmailHandle={0}&name={1}&inputPassword={2}", email, password);

  const string contentType = "application/x-www-form-urlencoded";
  System.Net.ServicePointManager.Expect100Continue = false;

  CookieContainer cookies = new CookieContainer();
  HttpWebRequest webRequest = WebRequest.Create(URLAuth) as HttpWebRequest;
  webRequest.Method = "POST";
  webRequest.ContentType = contentType;
  webRequest.CookieContainer = cookies;
  webRequest.ContentLength = postString.Length;
  webRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.1) Gecko/2008070208 Firefox/3.0.1";
  webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
  webRequest.Referer = "https://accounts.craigslist.org";

  StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
  requestWriter.Write(postString);
  requestWriter.Close();

  StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
  string responseData = responseReader.ReadToEnd();

  responseReader.Close();
  webRequest.GetResponse().Close();
