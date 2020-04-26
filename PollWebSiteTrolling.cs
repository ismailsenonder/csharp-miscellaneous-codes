/**
 * This Windows Forms application was written for trolling a website which allows users to create and vote polls.
 * It basically finds the poll in the page, and votes for the specified option repeatedly.
 * I'm uploading this code here because it contains examples for injecting and running javascript code 
 * in a web page using a windows web browser and c#
 **/

using mshtml;
using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creating a web browser
            WebBrowser wb1 = new WebBrowser();

            //Place the wb on the form
            wb1.Location = new System.Drawing.Point(400, 50);
            wb1.Width = 1000;
            wb1.Height = 600;
            this.Controls.Add(wb1);
           
            //Navigate to urş
            wb1.Navigate("http://navigatetothisurl.com/10");

            wb1.AllowNavigation = true;
            //wb1.ScriptErrorsSuppressed = true; //This is for ignoring the javascript errors

            //Run LogIn method after loading the page
            wb1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(LogIn);
    
        }

        public void LogIn(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //if (i == 1000)
            //    MessageBox.Show("1000 iteration completed.");


            var webBrowser = sender as WebBrowser;
            //Remove the method from documentcompleted event. Will be added again after login action is completed.
            webBrowser.DocumentCompleted -= new WebBrowserDocumentCompletedEventHandler(LogIn);

            //Injecting javascript to head section of te page. Or writing it to the url.
            //Whichever works...
            webBrowser.Navigate("javascript:$('#someOptions').attr('value', '28');");
            HtmlElement head = webBrowser.Document.GetElementsByTagName("head")[0];
            HtmlElement scriptEl = webBrowser.Document.CreateElement("script");
            scriptEl.SetAttribute("type", "text/javascript");
            IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
            //element.text = "function changeit() { $('#someOptions').attr('value', '28'); alert('hello'); }";
            element.text = "function changeit() { $('#someOptions').attr('value', '28'); }";     
            head.AppendChild(scriptEl);
            webBrowser.Document.InvokeScript("changeit");
            //Thread.Sleep(3000);
 
            //get all the divs in the page
            HtmlElementCollection c1 = webBrowser.Document.GetElementsByTagName("div");

            foreach (HtmlElement e2 in c1)
            {
                //if the div contains "VoteThis"
                if (e2.InnerHtml.Contains("VoteThis"))
                {
                    //change the voted property of that div to true
                    e2.SetAttribute("voted", "true");
                }
            }

            //get all the buttons in the page
            HtmlElementCollection c2 = webBrowser.Document.GetElementsByTagName("button");

            foreach (HtmlElement e3 in c2)
            {
                //if the class property of the button equals this
                if (e3.GetAttribute("className").Contains("btn btn-success pull-right"))
                {
                    //and the button text contains this
                    if (e3.InnerHtml.Contains("Vote"))
                    {
                        //click the button
                        e3.InvokeMember("click");
                    }

                }
            }

            //wait for 1 second before doing anything else... just in case
            Thread.Sleep(1000);
            
            //i++;
            //add LogIn method to documentcompleted action again and navigate to the same url to do the same job.
            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(LogIn);
            webBrowser.Navigate("http://navigatetothisurl.com/10");
        }

        
    }
}
