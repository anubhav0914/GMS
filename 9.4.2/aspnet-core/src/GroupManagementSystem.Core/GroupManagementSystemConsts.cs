using GroupManagementSystem.Debugging;

namespace GroupManagementSystem
{
    public class GroupManagementSystemConsts
    {
        public const string LocalizationSourceName = "GroupManagementSystem";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "0bd5ef2bc2e64853a67a03734488467b";
    }
}
