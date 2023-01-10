// WandsDoMore
// a Valheim mod to add functionality to vanilla magic
// 
// File:    WandsDoMore.cs
// Project: WandsDoMore

using BepInEx;
using BepInEx.Configuration;
using Jotunn.Configs;
using Jotunn.Managers;
using System.Collections.Generic;
using UnityEngine;

namespace WandsDoMore
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class WandsDoMore : BaseUnityPlugin
    {
        public const string PluginGUID = "com.ellyouseekaywhy.WandsDoMore";
        public const string PluginName = "WandsDoMore";
        public const string PluginVersion = "0.0.2";

        public ButtonConfig ConvocateButton;

        private ConfigEntry<KeyCode> ConvocateConfig;

        private void Awake()
        {
            // Jotunn comes with its own Logger class to provide a consistent Log style for all mods using it
            Jotunn.Logger.LogInfo("WandsDoMore has landed");
            CreateConfigValues();
            AddInputs();
        }

        private void Update()
        {
            if (ZInput.instance != null)
            {
                // Check if hotkey is used while holding correct magic item
                if (ConvocateButton != null && ZInput.GetButtonDown(ConvocateButton.Name) && Player.m_localPlayer != null && Player.m_localPlayer.m_visEquipment.m_leftItem == "StaffSkeleton")
                {
                    TeleportFollowingMinionsToPlayer(Player.m_localPlayer);
                }
            }
        }

        private void CreateConfigValues()
        {
            Config.SaveOnConfigSet = true;
            ConvocateConfig = Config.Bind("Client config", "Convocate Activation", KeyCode.G,
                new ConfigDescription("Key to Convocate recalling following minions to you"));
        }

        private void AddInputs()
        {
            ConvocateButton = new ButtonConfig
            {
                Name = "Convocate",
                Config = ConvocateConfig,

                BlockOtherInputs = true
            };
            InputManager.Instance.AddButton(PluginGUID, ConvocateButton);
        }

        public void TeleportFollowingMinionsToPlayer(Player player)
        {
            // based off BaseAI.FindClosestCreature
            List<Character> allCharacters = Character.GetAllCharacters();
            foreach (Character item in allCharacters)
            {
                if (item.IsDead())
                {
                    continue;
                }

                if (item.GetComponent<MonsterAI>()?.GetFollowTarget() == player.gameObject)
                {
                    item.transform.position = player.transform.position;
                }
            }
        }
    }
}

