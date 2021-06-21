using System;
using System.Linq;
using System.Reflection;

namespace Desktop.Infrastructure.Service
{
    public class Diagnostic
    {

        public static void Start()
        {
            AddComputerInformation();
        }

        private static void AddComputerInformation()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if(db.Logs.Count() == 0)
                {
                    var osBit = Environment.Is64BitOperatingSystem ? "64" : "32";
                    ActionLog.Set(
                        $"OS: {Environment.OSVersion.VersionString}, {osBit}bit {Environment.OSVersion.ServicePack}, " +
                        $"Processor: {Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE", EnvironmentVariableTarget.Machine)}, " +
                        $"App: {Assembly.GetExecutingAssembly().GetName().Version}");
                }
            }
        }
    }
}
