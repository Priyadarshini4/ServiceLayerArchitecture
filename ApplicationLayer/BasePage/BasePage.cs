namespace ApplicationLayer.BasePage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Globalization;
    using Framework.Logging;
    using System.Web.UI.WebControls;
    using System.Web.UI;
    using System.IO;

    /// <summary>
    /// BasePage class.
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {

        public bool CheckForCSRF { get; set; }
        public bool isRedirecting = false;

        /// <summary>
        /// OnInit predefined event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", true);
        }

        /// <summary>
        /// OnPreLoad predefined event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnPreLoad(System.EventArgs e)
        {
            base.OnPreLoad(e);
        }

        /// <summary>
        /// OnLoad predefined event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnLoad(EventArgs e)
        {

        }

        /// <summary>
        /// Move view stat to the bottom of the page : Helpful for future SEO requirement if any.
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            //This is used to move all the view state text at the bottom of the page as per the SEO requirment.
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
            try
            {
                if (this.isRedirecting)
                    return;

                base.Render(htmlWriter);
                string html = stringWriter.ToString();
                int startPoint = html.IndexOf("<input type=\"hidden\" name=\"__VIEWSTATE\""); // finding the view state variable from the page html
                if (startPoint >= 0)
                {
                    int endPoint = html.IndexOf("/>", startPoint) + 2; // finding the closing tag for viewstate from the html
                    string viewstateInput = html.Substring(startPoint, endPoint - startPoint);
                    html = html.Remove(startPoint, endPoint - startPoint);
                    //int formEndStart = html.IndexOf("</form>") - 1;
                    int formEndStart = html.IndexOf("</form>");
                    if (formEndStart >= 0)
                    {
                        html = html.Insert(formEndStart, viewstateInput);
                    }
                }
                writer.Write(html);
            }
            catch (Exception exp)
            {
                string url = "";
                if (HttpContext.Current != null && HttpContext.Current.Request != null)
                {
                    url = HttpContext.Current.Request.RawUrl;
                }

                Logger.Log(exp, "Moving viewstate bootom of the page, URL: " + url, Framework.Enums.Enums.ErrorLevel.ERROR);
                Exception newEx = new Exception("Moving ViewState to the bottom of the page", exp);
                throw newEx;
            }
            finally
            {
                if (htmlWriter != null)
                    htmlWriter.Dispose();
                if (stringWriter != null)
                    stringWriter.Dispose();
            }
        }

        /// <summary>
        /// LogError used for logging various types of information.
        /// </summary>
        /// <param name="ex">Exception occured.</param>
        /// <param name="customException">Custom exception text.</param>
        /// <param name="level">Error level.</param>
        public void LogError(Exception ex, string customException, Framework.Enums.Enums.ErrorLevel level)
        {
            Logger.Log(ex, customException, level);
        }
    }
}