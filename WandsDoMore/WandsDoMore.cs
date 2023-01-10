// WandsDoMore
// a Valheim mod skeleton using Jötunn
// 
// File:    WandsDoMore.cs
// Project: WandsDoMore

using BepInEx;
using Jotunn.Entities;
using Jotunn.Managers;

namespace WandsDoMore
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class WandsDoMore : BaseUnityPlugin
    {
        public const string PluginGUID = "com.ellyouseekaywhy.WandsDoMore";
        public const string PluginName = "WandsDoMore";
        public const string PluginVersion = "0.0.1";
        
        // Use this class to add your own localization to the game
        // https://valheim-modding.github.io/Jotunn/tutorials/localization.html
        public static CustomLocalization Localization = LocalizationManager.Instance.GetLocalization();

        private void Awake()
        {
            // Jotunn comes with its own Logger class to provide a consistent Log style for all mods using it
            Jotunn.Logger.LogInfo("WandsDoMore has landed");
            
            // To learn more about Jotunn's features, go to
            // https://valheim-modding.github.io/Jotunn/tutorials/overview.html
        }
    }
}

