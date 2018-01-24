// -----------------------------------------------------------------------
// <copyright file="Authenticate.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace BusinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Objects;
    using System.Linq;
    using System.Web;
    using DataLayer;

    /// <summary>
    /// Authenticate class.
    /// </summary>
    public class Authenticate
    {
        /// <summary>
        /// AuthenticateUser used for authenticating an user.
        /// </summary>
        /// <param name="userName">User name provided by user.</param>
        /// <param name="password">Password provide by user.</param>
        /// <returns>Authentication status.</returns>
        public int AuthenticateUser(string userName, string password)
        {
            GI_InnovationsEntities dataContext = new GI_InnovationsEntities();
            return (from status in dataContext.GI_User
                    where status.UserName.Equals(userName) && status.Password.Equals(password)
                    select status.UserId).FirstOrDefault();
        }
    }
}