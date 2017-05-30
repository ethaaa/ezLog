using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLogger {
    public class EzLog {
        private const string _version = "a1.0";
        private static List<EzLogMsg> msgList = new List<EzLogMsg>();

        public static string Version() {
            return _version;
        }

        public static List<EzLogMsg> GetLogs() {
            return msgList;
        }

        public static void LogError(EzLogMsg errorMsg) { LgErr(errorMsg); }
        public static void LgErr(EzLogMsg errorMsg) {
            msgList.Add(errorMsg);
        }

        public static void LogError(string errorMsg) { LgErr(errorMsg); }
        public static void LgErr(string errorMsg) {
            msgList.Add(new EzLogMsg(errorMsg));
        }


        public static void LogWarning(EzLogMsg warningMsg) { LgWrn(warningMsg); }
        public static void LgWrn(EzLogMsg warningMsg) {
            msgList.Add(warningMsg);
        }

        public static void LogInformation(EzLogMsg infoMsg) { LgInf(infoMsg); }
        public static void LogInfo(EzLogMsg infoMsg) { LgInf(infoMsg); }
        public static void LgInf(EzLogMsg infoMsg) {
            msgList.Add(infoMsg);
        }    
    }
}
