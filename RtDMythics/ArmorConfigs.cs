using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using UnityEngine;

namespace RtDMythics
{
    internal partial class RtDMythics : BaseUnityPlugin
    {
        private static readonly string[] ArmorPrefabList =
        {
            // Meadows
            "BlackForestMageChest_RtD",
            "BlackForestMageHood_RtD",
            "BlackForestMageLegs_RtD",
            // Swamp
            "SwampMageChest_RtD",
            "SwampMageHood_RtD",
            "SwampMageLegs_RtD",
            "SwampMageCape_RtD",
            // Mountain
            "MountainMageChest_RtD",
            "MountainMageHood_RtD",
            "MountainMageLegs_RtD",
            "MountainMageCape_RtD",
            // Plains
            "PlainsMageChest_RtD",
            "PlainsMageHood_RtD",
            "PlainsMageLegs_RtD",
            "PlainsMageCape_RtD",
            // Mistlands
            "MistlandsMageHood_RtD",
            "MistlandsMageChest_RtD",
            "MistlandsMageLegs_RtD",
            "MistlandsMageCape_RtD",
            // AshLands
            "AshLandsMageChest_RtD",
            "AshLandsMageHood_RtD",
            "AshLandsMageLegs_RtD",
            // Deep North
            "DeepNorthMageChest_RtD",
            "DeepNorthMageHood_RtD",
            "DeepNorthMageLegs_RtD",
        };

        private static readonly string[] ArmorCategoryList =
        {
            // Meadows
            "Meadows",
            "Meadows",
            "Meadows",
            // Swamp
            "Swamp",
            "Swamp",
            "Swamp",
            "Swamp",
            // Mountain
            "Mountain",
            "Mountain",
            "Mountain",
            "Mountain",
            // Plains
            "Plains",
            "Plains",
            "Plains",
            "Plains",
            // Mistlands
            "Mistlands",
            "Mistlands",
            "Mistlands",
            "Mistlands",
            // AshLands
            "AshLands",
            "AshLands",
            "AshLands",
            // Deep North
            "Deep North",
            "Deep North",
            "Deep North",
        };

        private static readonly string[] ArmorStationList =
        {
            // Meadows
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            // Swamp
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            // Mountain
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            // Plains
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            // Mistlands
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            // AshLands
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            // Deep North
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
        };

        // Requirement item names, one row per item, same order as ArmorPrefabList.
        private static readonly string[][] ArmorReqItems =
        {
            // Meadows
            new string[] { "SpiritEssense_RtD", "BlackForestCrystal_RtD", "FairyCoreBlackForest_RtD", "TrollHide" },
            new string[] { "SpiritEssense_RtD", "BlackForestCrystal_RtD", "FairyCoreBlackForest_RtD", "TrollHide" },
            new string[] { "SpiritEssense_RtD", "BlackForestCrystal_RtD", "FairyCoreBlackForest_RtD", "TrollHide" },
            // Swamp
            new string[] { "SpiritEssense_RtD", "SwampCrystal_RtD", "FairyCoreSwamp_RtD", "BlackForestMageChest_RtD" },
            new string[] { "SpiritEssense_RtD", "SwampCrystal_RtD", "FairyCoreSwamp_RtD", "BlackForestMageHood_RtD" },
            new string[] { "SpiritEssense_RtD", "SwampCrystal_RtD", "FairyCoreSwamp_RtD", "BlackForestMageLegs_RtD" },
            new string[] { "SpiritEssense_RtD", "SwampCrystal_RtD", "FairyCoreSwamp_RtD", "CapeDeerHide" },
            // Mountain
            new string[] { "SpiritEssense_RtD", "MountainCrystal_RtD", "FairyCoreMountain_RtD", "SwampMageChest_RtD" },
            new string[] { "SpiritEssense_RtD", "MountainCrystal_RtD", "FairyCoreMountain_RtD", "SwampMageHood_RtD" },
            new string[] { "SpiritEssense_RtD", "MountainCrystal_RtD", "FairyCoreMountain_RtD", "SwampMageLegs_RtD" },
            new string[] { "SpiritEssense_RtD", "MountainCrystal_RtD", "FairyCoreMountain_RtD", "SwampMageCape_RtD" },
            // Plains
            new string[] { "SpiritEssense_RtD", "PlainsCrystal_RtD", "FairyCorePlains_RtD", "MountainMageChest_RtD" },
            new string[] { "SpiritEssense_RtD", "PlainsCrystal_RtD", "FairyCorePlains_RtD", "MountainMageHood_RtD" },
            new string[] { "SpiritEssense_RtD", "PlainsCrystal_RtD", "FairyCorePlains_RtD", "MountainMageLegs_RtD" },
            new string[] { "SpiritEssense_RtD", "PlainsCrystal_RtD", "FairyCorePlains_RtD", "MountainMageCape_RtD" },
            // Mistlands
            new string[] { "SpiritEssense_RtD", "MistlandsCrystal_RtD", "FairyCoreMistlands_RtD", "PlainsMageHood_RtD" },
            new string[] { "SpiritEssense_RtD", "MistlandsCrystal_RtD", "FairyCoreMistlands_RtD", "PlainsMageChest_RtD" },
            new string[] { "SpiritEssense_RtD", "MistlandsCrystal_RtD", "FairyCoreMistlands_RtD", "PlainsMageLegs_RtD" },
            new string[] { "SpiritEssense_RtD", "MistlandsCrystal_RtD", "FairyCoreMistlands_RtD", "PlainsMageCape_RtD" },
            // AshLands
            new string[] { "SpiritEssense_RtD", "AshLandsCrystal_RtD", "FairyCoreAshLands_RtD", "MistlandsMageChest_RtD" },
            new string[] { "SpiritEssense_RtD", "AshLandsCrystal_RtD", "FairyCoreAshLands_RtD", "MistlandsMageHood_RtD" },
            new string[] { "SpiritEssense_RtD", "AshLandsCrystal_RtD", "FairyCoreAshLands_RtD", "MistlandsMageLegs_RtD" },
            // Deep North
            new string[] { "SpiritEssense_RtD", "DeepNorthCrystal_RtD", "FairyCoreDeepNorth_RtD", "AshLandsMageChest_RtD" },
            new string[] { "SpiritEssense_RtD", "DeepNorthCrystal_RtD", "FairyCoreDeepNorth_RtD", "AshLandsMageHood_RtD" },
            new string[] { "SpiritEssense_RtD", "DeepNorthCrystal_RtD", "FairyCoreDeepNorth_RtD", "AshLandsMageLegs_RtD" },
        };

        // Requirement amounts, same shape as ArmorReqItems above.
        private static readonly int[][] ArmorReqAmounts =
        {
            // Meadows
            new int[] { 10, 15, 1, 15 },
            new int[] { 10, 15, 1, 10 },
            new int[] { 10, 15, 1, 15 },
            // Swamp
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            // Mountain
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            // Plains
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            // Mistlands
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            // AshLands
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            // Deep North
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
        };

        // Requirement "amount per level" (upgrade cost per crafting station level).
        // Recover is always true for every requirement here, so it isn't broken out into its own array - it's just hardcoded true where it's used below.
        private static readonly int[][] ArmorReqLevels =
        {
            // Meadows
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 3 },
            new int[] { 3, 5, 0, 0 },
            // Swamp
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            // Mountain
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            // Plains
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            // Mistlands
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            // AshLands
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            // Deep North
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
        };

        // Config entries, one array per field, index-matched to ArmorPrefabList.
        private ConfigEntry<bool>[] ArmorEnabledConfigs;
        private ConfigEntry<string>[][] ArmorReqItemConfigs;
        private ConfigEntry<int>[][] ArmorReqAmountConfigs;

        private void CreateArmorRecipeConfigs(ref int order)
        {
            try
            {
                ArmorEnabledConfigs = new ConfigEntry<bool>[ArmorPrefabList.Length];
                ArmorReqItemConfigs = new ConfigEntry<string>[ArmorPrefabList.Length][];
                ArmorReqAmountConfigs = new ConfigEntry<int>[ArmorPrefabList.Length][];

                for (int i = 0; i < ArmorPrefabList.Length; i++)
                {
                    string prefab = ArmorPrefabList[i];
                    string section = "Item Recipes - " + ArmorCategoryList[i];

                    ArmorEnabledConfigs[i] = Config.Bind(section, prefab + " - Enabled", true,
                        new ConfigDescription("Enable or disable crafting/adding of " + prefab + ".", null,
                        new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                    ArmorReqItemConfigs[i] = new ConfigEntry<string>[ArmorReqItems[i].Length];
                    ArmorReqAmountConfigs[i] = new ConfigEntry<int>[ArmorReqItems[i].Length];

                    for (int j = 0; j < ArmorReqItems[i].Length; j++)
                    {
                        int slot = j + 1;
                        string defaultItem = ArmorReqItems[i][j];
                        int defaultAmount = ArmorReqAmounts[i][j];

                        ArmorReqItemConfigs[i][j] = Config.Bind(section, prefab + " - Requirement " + slot + " Item", defaultItem,
                            new ConfigDescription("Requirement " + slot + " for " + prefab + ". Prefab/item id consumed on craft (default: " + defaultItem + ").", null,
                            new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                        ArmorReqAmountConfigs[i][j] = Config.Bind(section, prefab + " - Requirement " + slot + " Amount", defaultAmount,
                            new ConfigDescription("Amount of Requirement " + slot + " required to craft " + prefab + " (default item: " + defaultItem + ").",
                            new AcceptableValueRange<int>(0, 9999),
                            new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                        ArmorReqItemConfigs[i][j].SettingChanged += ItemRecipeConfigChanged;
                        ArmorReqAmountConfigs[i][j].SettingChanged += ItemRecipeConfigChanged;
                    }

                    ArmorEnabledConfigs[i].SettingChanged += ItemRecipeConfigChanged;
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding item recipe configuration values: {arg}");
            }
        }

        private void CreateArmorRecipes()
        {
            try
            {
                for (int i = 0; i < ArmorPrefabList.Length; i++)
                {
                    string prefab = ArmorPrefabList[i];

                    if (!ArmorEnabledConfigs[i].Value)
                    {
                        if (LoggingEnable.Value) { Logger.LogMessage("Skipped (disabled in config): " + prefab); }
                        continue;
                    }

                    ItemConfig itemConfig = new ItemConfig();
                    itemConfig.CraftingStation = ArmorStationList[i];

                    for (int j = 0; j < ArmorReqItems[i].Length; j++)
                    {
                        string reqItem = ArmorReqItemConfigs[i][j].Value;
                        int amount = ArmorReqAmountConfigs[i][j].Value;
                        int amountPerLevel = ArmorReqLevels[i][j];
                        itemConfig.AddRequirement(new RequirementConfig(reqItem, amount, amountPerLevel, true));
                    }

                    ItemManager.Instance.AddItem(new CustomItem(this.MyAssets, prefab, false, itemConfig));

                    if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefab + " to the Object database"); }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }

        private void ArmorRecipeConfigChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ArmorPrefabList.Length; i++)
                {
                    string prefab = ArmorPrefabList[i];
                    Recipe recipe = ItemManager.Instance.GetItem(prefab)?.Recipe?.Recipe;

                    if (recipe == null)
                    {
                        // Item/recipe was never registered (most likely it was disabled at Awake time, so CreateRecipes() skipped it).
                        continue;
                    }

                    recipe.m_enabled = ArmorEnabledConfigs[i].Value;

                    if (recipe.m_resources == null)
                    {
                        continue;
                    }

                    for (int j = 0; j < ArmorReqItems[i].Length && j < recipe.m_resources.Length; j++)
                    {
                        string reqItemName = ArmorReqItemConfigs[i][j].Value;

                        if (string.IsNullOrWhiteSpace(reqItemName))
                        {
                            continue;
                        }

                        GameObject reqPrefab = PrefabManager.Instance.GetPrefab(reqItemName.Trim());
                        ItemDrop reqItemDrop = reqPrefab != null ? reqPrefab.GetComponent<ItemDrop>() : null;

                        if (reqItemDrop == null)
                        {
                            Logger.LogWarning("Could not resolve requirement item '" + reqItemName + "' for " + prefab + " - leaving that requirement slot unchanged.");
                            continue;
                        }

                        recipe.m_resources[j].m_resItem = reqItemDrop;
                        recipe.m_resources[j].m_amount = ArmorReqAmountConfigs[i][j].Value;
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while re-applying item recipe configs: {arg}");
            }
        }
    }
}