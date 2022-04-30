// #define ENABLE_LOGS

namespace _Project.Scripts.Core
{
    public static class Logger {
        public static void Debug(string msg) {
#if ENABLE_LOGS
            UnityEngine.Debug.Log(msg);
#endif
        }
    }
}