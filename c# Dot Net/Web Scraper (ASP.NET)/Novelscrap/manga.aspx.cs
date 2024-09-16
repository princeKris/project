using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Novelscrap
{
    public partial class manga : System.Web.UI.Page
    {
        public string websiteName;
        string websiteUrl;
        public string opt;
        string lastchapterlink;
        public string curul;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SinglePage(string url)
        {
            try
            {
                curul = url;
                if (!string.IsNullOrEmpty(url))
                {
                    var web = new HtmlWeb();
                    var doc = web.Load(url);
                    switch (websiteName)
                    {
                        case "mangatop.org":
                            var mangacon = doc.DocumentNode.SelectNodes("//div[@class='page-break no-gaps']/img");
                            foreach (var para in mangacon)
                            {
                                string h = para.Attributes["data-src"].Value;
                                imgd(h);
                            }
                            break;
                        case "asuracomic.net":
                            var mangacon1 = doc.DocumentNode.SelectNodes("//div[@class='w-full mx-auto center']/img");
                            foreach (var para in mangacon1)
                            {
                                string h = para.Attributes["src"].Value;
                                imgd(h);
                            }
                            break;
                        case "kunmanga.com":
                            var mangacon2 = doc.DocumentNode.SelectNodes("//div[@class='page-break no-gaps']/img");
                            foreach (var para in mangacon2)
                            {
                                string h = para.Attributes["src"].Value;
                                imgd(h);
                            }
                            break;
                        case "manhuaus.com":
                            var mangacon3 = doc.DocumentNode.SelectNodes("//div[@class='page-break no-gaps']/img");
                            foreach (var para in mangacon3)
                            {
                                string h = para.Attributes["data-src"].Value;
                                imgd(h);
                            }
                            break;

                        default:
                            break;
                    } 
                }
                else
                {
                    Response.Write($"<script>alert('Please Input the url')</script>");
                }
            }
            catch (Exception ex)
            {
                SinglePage(curul);
                Response.Write($"<script>alert('{ex.Message}')</script>");

            }
        }

        protected void imgd(string url)
        {
            var sp=url.Split('/');
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(url, $@"C:\\Users\\LENOVO\\Downloads\\Novel\\{sp[sp.Length-1]}");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            websiteName = DropDownList1.SelectedValue.ToString();
            websiteUrl = TextBox1.Text.ToString();
            SinglePage(websiteUrl);
            Response.Write($"<script>alert('novel content downloaded in downloads')</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}