namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Framework.Logging;    

    /// <summary>
    /// BaseService Class.
    /// </summary>
    public abstract class BaseService
    {
        /// <summary>
        /// Used for logging the web service errors.
        /// </summary>
        /// <param name="ex">Exception generated.</param>
        /// <param name="customMessage">Custom message.</param>
        /// <param name="errorLevel">Error level.</param>
        /// <param name="errCode">Error code.</param>
        /// <returns>Fault exception.</returns>
        public System.ServiceModel.FaultException LogWcfError(Exception ex, string customMessage, Framework.Enums.Enums.ErrorLevel errorLevel, string errCode)
        {
            Logger.Log(ex, customMessage, errorLevel);
            return new System.ServiceModel.FaultException(new System.ServiceModel.FaultReason(customMessage), new System.ServiceModel.FaultCode(errCode));
        }
    }
}