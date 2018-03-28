using NLog;
using System;

namespace RLogger
{
    public static class RLogger
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        public static void LogError(Exception ex)
        {
            string message = Environment.NewLine; 
            message += Environment.NewLine;
            message += "---------------------------ERROR---------------------------";
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";

            log.Error(message);
        }
    }
}
