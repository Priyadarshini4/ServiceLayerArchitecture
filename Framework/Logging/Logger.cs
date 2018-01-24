[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Framework.Logging
{
    using System;
    using Framework.Enums;

    /// <summary>
    /// Logger class.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Logger field of Logger class.
        /// </summary>
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Logs info to DB / File based on web.config settings.
        /// </summary>
        /// <param name="ex">Exception object</param>
        /// <param name="customMessage">Custom error message.</param>
        /// <param name="errorLevel">Exception error type.</param>
        public static void Log(Exception ex, string customMessage, Enums.ErrorLevel errorLevel)
        {
            switch (errorLevel)
            {
                case Enums.ErrorLevel.DEBUG:
                    logger.Debug(customMessage, ex);
                    break;
                case Enums.ErrorLevel.ERROR:
                    logger.Error(customMessage, ex);
                    break;
                case Enums.ErrorLevel.FATAL:
                    logger.Fatal(customMessage, ex);
                    break;
                case Enums.ErrorLevel.INFO:
                    logger.Info(customMessage, ex);
                    break;
                case Enums.ErrorLevel.WARN:
                    logger.Warn(customMessage, ex);
                    break;
                default:
                    logger.Error(customMessage, ex);
                    break;
            }
        }
    }
}