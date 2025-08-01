using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace GroupManagementSystem.Localization
{
    public static class GroupManagementSystemLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(GroupManagementSystemConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(GroupManagementSystemLocalizationConfigurer).GetAssembly(),
                        "GroupManagementSystem.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
