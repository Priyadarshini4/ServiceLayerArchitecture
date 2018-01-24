namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using BusinessLayer;

    /// <summary>
    /// AuthenticateService class.
    /// </summary>
    public class AuthenticateService : BaseService, IAuthenticateService
    {
        /// <summary>
        /// AuthenticateUser used for authenticating an user.
        /// </summary>
        /// <param name="userName">User name provided by user.</param>
        /// <param name="password">Password provided by user.</param>
        /// <returns></returns>
        public int AuthenticateUser(string userName, string password)
        {
            try
            {
                Authenticate auth = new Authenticate();
                return auth.AuthenticateUser(userName, password);
            }
            catch (Exception ex)
            {
                throw LogWcfError(ex, "Error authenicating an user", Framework.Enums.Enums.ErrorLevel.ERROR,ErrorCodes.ErrorCodes.ErrorAuthenticateUser);
            }
        }
    }
}