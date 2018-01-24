namespace ApplicationLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using ServiceProxies.AuthenticateService;
    using Framework.Logging;

    /// <summary>
    /// Login class.
    /// </summary>
    public partial class Login : ApplicationLayer.BasePage.BasePage
    {
        /// <summary>
        /// OnInit -- csrf handling
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            this.CheckForCSRF = true;
            base.OnInit(e);
        }

        /// <summary>
        /// Page_Load event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// btnLogin_Click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text;
                string password = txtPassword.Text;
                int status = 0;
                if (!string.IsNullOrEmpty(userName) || !string.IsNullOrEmpty(password))
                {
                    AuthenticateServiceClient client = new AuthenticateServiceClient();
                    status = client.AuthenticateUser(userName, password);
                    if (status==1)
                    {
                        Response.Redirect("SuccessfulAuthenticate.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Exception occure in authenticating an user", Framework.Enums.Enums.ErrorLevel.ERROR);
            }
        }
    }
}