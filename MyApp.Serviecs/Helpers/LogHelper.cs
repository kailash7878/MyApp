using log4net;
using log4net.Config;
using System.Reflection;

namespace MyApp.Serviecs.Helpers
{
    public static class LogHelper
    {
        #region Variables

        private static ILog? _log;
        private const string ExceptionName = "Exception";
        private const string InnerExceptionName = "Inner Exception";
        private const string ExceptionMessageWithoutInnerException = "{0}{1}: {2}Message: {3}{4}StackTrace: {5}.";
        private const string ExceptionMessageWithInnerException = "{0}{1}{2}";

        #endregion

        static LogHelper()
        {
            EnsureLogger();
        }

        #region Public Methods

        /// <summary>
        ///    Log a message object with the log4net.Core.Level.Debug level.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Debug(object message) => _log?.Debug(message);

        /// <summary>
        ///  Logs a message object with the log4net.Core.Level.Info level.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Info(object message) => _log?.Info(message);

        /// <summary>
        ///  Logs a message object with the log4net.Core.Level.Info Warning.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Warning(object message) => _log?.Warn(message);

        /// <summary>
        ///  Logs a message object with the log4net.Core.Level.Error level.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Error(string message) => _log?.Error(message);

        /// <summary>
        ///    Log a exception with the log4net.Core.Level.Fatal level.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public static void Error(Exception ex) => _log?.Error(GeDetailFromExceptipon(ex, ExceptionName));

        /// <summary>
        ///  Log a message object with the log4net.Core.Level.Error level including the
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Error(object message, Exception exception) => _log?.Error(message, exception);

        /// <summary>
        /// Log a message object with the log4net.Core.Level.Fatal level.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Fatal(string message) => _log?.Fatal(message);

        /// <summary>
        /// Log a exception with the log4net.Core.Level.Fatal level.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public static void Fatal(Exception ex) => _log?.Fatal(GeDetailFromExceptipon(ex, ExceptionName));

        /// <summary>
        /// Log a message object with the log4net.Core.Level.Fatal level including the
        //  stack trace of the System.Exception passed as a parameter.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Fatal(object message, Exception exception) => _log?.Fatal(message, exception);

        #endregion

        #region Private Methods

        /// <summary>
        ///     Gets the complete message and stack trace.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="exceptionString">The exception string.</param>
        /// <returns></returns>
        private static string GeDetailFromExceptipon(Exception ex, string exceptionString)
        {
            var mesgAndStackTrace = string.Format(ExceptionMessageWithoutInnerException, Environment.NewLine,
                exceptionString, Environment.NewLine, ex.Message, Environment.NewLine, ex.StackTrace);

            if (ex.InnerException != null)
            {
                mesgAndStackTrace = string.Format(ExceptionMessageWithInnerException, mesgAndStackTrace,
                    Environment.NewLine,
                    GeDetailFromExceptipon(ex.InnerException, InnerExceptionName));
            }

            return mesgAndStackTrace + Environment.NewLine;
        }

        private static void EnsureLogger()
        {
            if (_log != null) return;

            var assembly = Assembly.GetEntryAssembly();
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            var configFile = GetConfigFile();

            // Configure Log4Net
            XmlConfigurator.Configure(logRepository, configFile);
            _log = LogManager.GetLogger(assembly, assembly?.ManifestModule.Name.Replace(".dll", "").Replace(".", " "));
        }

        private static FileInfo GetConfigFile()
        {
            FileInfo? configFile = null;

            // Search config file
            var configFileNames = new[] { "Config/log4net.config", "log4net.config" };

            foreach (var configFileName in configFileNames)
            {
                configFile = new FileInfo(configFileName);

                if (configFile.Exists) break;
            }

            if (configFile == null || !configFile.Exists) throw new NullReferenceException("Log4net config file not found.");

            return configFile;
        }

        #endregion
    }
}
