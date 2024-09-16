using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using HtmlAgilityPack;

namespace Novelscrap
{
    public partial class novelsc : System.Web.UI.Page
    {
        public string websiteName;
        string websiteUrl;
        public string opt;
        string lastchapterlink;
        public string curul;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      
        protected void SinglePage1(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    var web = new HtmlWeb();
                    var doc = web.Load(url);
                    var novelcon = doc.DocumentNode.SelectNodes("//div[@class='chapter-content']/p");
                    var title = doc.DocumentNode.SelectSingleNode("//div[@class='titles']/h2");
                    string x = title.InnerText.ToString();
                    string n="";
                    for(int i = 0; i < x.Length; i++)
                    {
                        if ((x[i] >= 'A' && x[i] <= 'Z') || (x[i] >= 'a' && x[i] <= 'z') || (x[i] >= '0' && x[i] <= '9') || x[i] == ' ')
                        {
                            n += x[i].ToString();
                        }

                    }
                    n += ".txt";
                    
                    string path = @"C:\\Users\\LENOVO\\Downloads\\Novel\\";
                    //Response.Write($"<script>alert('{path}{n}')</script>");
                    FileStream f = new FileStream(Path.Combine(path,n), FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter s = new StreamWriter(f);
                    s.WriteLine($"\n{title.InnerText.ToString()}\n\n\n");
                    foreach (var para in novelcon)
                    {
                        s.WriteLine($"\n{para.InnerText.ToString()}");
        
                    }
                    s.Close();
                    f.Close();
                }
                else
                {
                    Response.Write($"<script>alert('Please Input the url')</script>");
                }
            }
            catch (NullReferenceException)
            {
                //Thread.Sleep(3000);
                SinglePage1(curul);

            }
            catch (Exception ex) {
                SinglePage1(curul);
                Response.Write($"<script>alert('{ex.Message}')</script>");
                
            }
           


        }

        protected void SinglePage2(string url)
        {
            try
            {
                curul = url;
                if (!string.IsNullOrEmpty(url))
                {
                    var web = new HtmlWeb();
                    var doc = web.Load(url);
                    var title = doc.DocumentNode.SelectSingleNode("//div[@class='chapter-title']");
                    var novelcon = doc.DocumentNode.SelectNodes("//div[@class='chp_raw']/p");
                    string x = title.InnerText.ToString();
                    string n = "";
                    for (int i = 0; i < x.Length; i++)
                    {
                        if ((x[i] >= 'A' && x[i] <= 'Z') || (x[i] >= 'a' && x[i] <= 'z') || (x[i] >= '0' && x[i] <= '9') || x[i] == ' ')
                        {
                            n += x[i].ToString();
                        }

                    }
                    n += ".txt";

                    string path = @"C:\\Users\\LENOVO\\Downloads\\Novel\\";
                    FileStream f = new FileStream(Path.Combine(path, n), FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter s = new StreamWriter(f);
                    s.WriteLine($"\n{title.InnerText.ToString()}\n\n\n");
                    foreach (var para in novelcon)
                    {
                        s.WriteLine($"\n{para.InnerText.ToString()}");
                    }
                    s.Close();
                    f.Close();
                }
                else
                {
                    Response.Write($"<script>alert('Please Input the url')</script>");
                }
            }
            catch (Exception ex)
            {
                SinglePage2(curul);
                Response.Write($"<script>alert('{ex.Message}')</script>");

            }

        }

        protected void SinglePage3(string url)
        {
            try
            {
                curul = url;
                if (!string.IsNullOrEmpty(url))
                {
                    var web = new HtmlWeb();
                    var doc = web.Load(url);
                    var title = doc.DocumentNode.SelectSingleNode("//div[@id='article']/h4");
                    var novelcon = doc.DocumentNode.SelectNodes("//div[@id='article']/p");
                    string x = title.InnerText.ToString();
                    string n = "";
                    for (int i = 0; i < x.Length; i++)
                    {
                        if ((x[i] >= 'A' && x[i] <= 'Z') || (x[i] >= 'a' && x[i] <= 'z') || (x[i] >= '0' && x[i] <= '9') || x[i] == ' ')
                        {
                            n += x[i].ToString();
                        }

                    }
                    n += ".txt";

                    string path = @"C:\\Users\\LENOVO\\Downloads\\Novel\\";
                    FileStream f = new FileStream(Path.Combine(path, n), FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter s = new StreamWriter(f);
                    s.WriteLine($"\n{title.InnerText.ToString()}\n\n\n");
                    foreach (var para in novelcon)
                    {
                        s.WriteLine($"\n{para.InnerText.ToString()}");
                    }
                    s.Close();
                    f.Close();
                }
                else
                {
                    Response.Write($"<script>alert('Please Input the url')</script>");
                }
            }
            catch (Exception ex)
            {
                SinglePage2(curul);
                Response.Write($"<script>alert('{ex.Message}')</script>");

            }

        }


        protected void SinglePage4(string url)
        {
            try
            {
                curul = url;
                if (!string.IsNullOrEmpty(url))
                {
                    var web = new HtmlWeb();
                    var doc = web.Load(url);
                    var title = doc.DocumentNode.SelectSingleNode("//div[@class='chr-c']/h3");
                    var novelcon = doc.DocumentNode.SelectNodes("//div[@class='chr-c']/p");
                    string x = title.InnerText.ToString();
                    string n = "";
                    for (int i = 0; i < x.Length; i++)
                    {
                        if ((x[i] >= 'A' && x[i] <= 'Z') || (x[i] >= 'a' && x[i] <= 'z') || (x[i] >= '0' && x[i] <= '9') || x[i] == ' ')
                        {
                            n += x[i].ToString();
                        }

                    }
                    n += ".txt";

                    string path = @"C:\\Users\\LENOVO\\Downloads\\Novel\\";
                    FileStream f = new FileStream(Path.Combine(path, n), FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter s = new StreamWriter(f);
                    s.WriteLine($"\n{title.InnerText.ToString()}\n\n\n");
                    foreach (var para in novelcon)
                    {
                        s.WriteLine($"\n{para.InnerText.ToString()}");
                    }
                    s.Close();
                    f.Close();
                }
                else
                {
                    Response.Write($"<script>alert('Please Input the url')</script>");
                }
            }
            catch (Exception ex)
            {
                SinglePage2(curul);
                Response.Write($"<script>alert('{ex.Message}')</script>");

            }

        }

        protected void FullPage1(string url)
        {
            try
            {
                string webdom = "https://www.fanmtl.com";
                if (!string.IsNullOrEmpty(url))
                {
                    var web = new HtmlWeb();
                    var doc = web.Load(url);
                    var novelast = doc.DocumentNode.SelectSingleNode("//div[@class='intro']/a").Attributes["href"].Value;
                    lastchapterlink = $"{webdom}{novelast}";
                    var novelfirst = doc.DocumentNode.SelectSingleNode("//ul[@class='chapter-list']/li/a").Attributes["href"].Value;
                    string opt = $"{webdom}{novelfirst}";
                    SinglePage1(opt);
                    nextpage(opt);
                }
                else
                {
                    Response.Write($"<script>alert('Please Input the url')</script>");
                }

            }
            catch(Exception ex) { Response.Write($"<script>alert('{ex.Message}')</script>"); }
        }

        protected void nextpage(string url)
        {
            try
            {
                string webdom = "https://www.fanmtl.com";
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var novelnext = doc.DocumentNode.SelectSingleNode("//a[@class=' chnav next']").Attributes["href"].Value;
                curul = $"{webdom}{novelnext}";
                SinglePage1(curul);
                if (lastchapterlink != curul)
                {
                    nextpage(curul);
                }
            }
            catch (NullReferenceException)
            {
               // Thread.Sleep(3000);
                nextpage(curul);

            }
            catch (Exception ex) {
                nextpage(curul);
                Response.Write($"<script>alert('{ex.Message}')</script>");
                
            }

        }

        protected void Button1_Click(object sender, EventArgs e)//single page click
        {
            websiteName= DropDownList1.SelectedValue.ToString();
            websiteUrl= TextBox1.Text.ToString();
            switch (websiteName)
            {
                case "fanmtl.com":
                    SinglePage1(websiteUrl);
                    Response.Write($"<script>alert('novel content downloaded in downloads')</script>");
                    break;
                case "scribblehub.com":
                    SinglePage2(websiteUrl);
                    Response.Write($"<script>alert('novel content downloaded in downloads')</script>");
                    break;
                case "readfree.com":
                    SinglePage3(websiteUrl);
                    Response.Write($"<script>alert('novel content downloaded in downloads')</script>");
                    break;
                case "novelbin.com":
                    SinglePage4(websiteUrl);
                    Response.Write($"<script>alert('novel content downloaded in downloads')</script>");
                    break;
        

                default:
                    break;
            }
            //Response.Write($"<script>alert('{websiteName} {websiteUrl}')</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)// full novel click
        {
            Response.Redirect("Home.aspx");

        }
    }
}