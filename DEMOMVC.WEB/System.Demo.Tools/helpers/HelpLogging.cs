namespace System.Demo.Tools.helpers
{
    using log4net;
    using log4net.Config;
    using System;
    using System.Diagnostics;


    public static class HelpLogging
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(HelpLogging));

        static HelpLogging()
        {
            Debug.WriteLine("Server Logger initializing...");

            XmlConfigurator.Configure();

            if (mLog != null)
            {
                Debug.WriteLine("Server Logger initialized");
                Debug.WriteLine(string.Format("Debug: {0}, Error: {1}, Info: {2}, Warning {3}",
                                mLog.IsDebugEnabled, mLog.IsErrorEnabled, mLog.IsInfoEnabled, mLog.IsWarnEnabled));
            }
            else
            {
                Debug.WriteLine("Failed initializing Server Logger");
            }

        }

        public static void PublishException(Exception exception)
        {
            if (mLog != null)
                mLog.Error("Exception", exception);
        }

        public static void WriteVerbose(string category, Exception message, string user)
        {
            if (mLog != null)
            {
                string mensaje = message.Message;
                if (message.InnerException != null)
                    mensaje = mensaje + " | " + message.InnerException.Message;
                mLog.Debug(FormatMessage(category, mensaje, user));
            }
        }

        public static void WriteInfo(string category, Exception message, string user)
        {
            if (mLog != null)
            {
                string mensaje = message.Message;
                if (message.InnerException != null)
                    mensaje = mensaje + " | " + message.InnerException.Message;
                mLog.Info(FormatMessage(category, mensaje, user));
            }
        }

        public static void WriteWarning(string category, Exception message, string user)
        {
            if (mLog != null)
            {
                string mensaje = message.Message;
                if (message.InnerException != null)
                    mensaje = mensaje + " | " + message.InnerException.Message;
                mLog.Warn(FormatMessage(category, mensaje, user));
            }
        }

        public static void TraceError(string category, string message, string user)
        {
            if (mLog != null)
                mLog.Error(FormatMessage(category, message, user));
        }

        public static void TraceError(string category, Exception message, string user)
        {
            if (mLog != null)
            {
                string mensaje = message.Message;
                if (message.InnerException != null)
                    mensaje = mensaje + " | " + message.InnerException.Message;
                mLog.Error(FormatMessage(category, mensaje, user));
            }
        }

        public static void Write(TraceLevel level, string category, string message, string user = "USUARIO", string codEmpresa = "0")
        {
            log4net.Config.XmlConfigurator.Configure();
            user = string.Format("IdEmp: {0} - User: {1}", codEmpresa, user);
            Exception ex = new Exception(message);
            switch (level)
            {
                case TraceLevel.Verbose:
                    WriteVerbose(category, ex, user);
                    break;
                case TraceLevel.Info:
                    WriteInfo(category, ex, user);
                    break;
                case TraceLevel.Warning:
                    WriteWarning(category, ex, user);
                    break;
                case TraceLevel.Error:
                    TraceError(category, ex, user);
                    break;
            }
        }

        public static void Write(TraceLevel level, string category, Exception message, string user = "USUARIO", string codEmpresa = "0")
        {
            log4net.Config.XmlConfigurator.Configure();
            user = string.Format("IdEmp: {0} - User: {1}", codEmpresa, user);
            switch (level)
            {
                case TraceLevel.Verbose:
                    WriteVerbose(category, message, user);
                    break;
                case TraceLevel.Info:
                    WriteInfo(category, message, user);
                    break;
                case TraceLevel.Warning:
                    WriteWarning(category, message, user);
                    break;
                case TraceLevel.Error:
                    TraceError(category, message, user);
                    break;
            }
        }

        private const string MessageFormat = "{0} | {1} | {2}";

        private const int MaxCategoryNameLength = 40;

        private static string FormatMessage(string category, string message, string user)
        {
            string output = string.Format(MessageFormat,
                                          FormatName(user, MaxCategoryNameLength),
                                          FormatName(category, MaxCategoryNameLength),
                                          message);
            return output;
        }

        private static string FormatName(string name, int minLength)
        {
            string result;
            string trimName = name != null ? name.Trim() : string.Empty;
            if (trimName.Length >= minLength)
                result = trimName;
            else
                result = trimName.PadRight(minLength);
            return result;
        }
    }
}
