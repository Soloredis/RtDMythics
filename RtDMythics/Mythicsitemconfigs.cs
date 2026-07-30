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
        private static readonly string[] ItemPrefabList =
        {
            // Meadows
            "MeadowsAirWand_RtD",
            "MeadowsAirStaff_RtD",
            "MeadowsLighteningStaff_RtD",
            "BlackForestFireStaff_RtD",
            "BlackForestLightStaff_RtD",
            "BlackForestLightningWand_RtD",
            "BlackForestMageChest_RtD",
            "BlackForestMageHood_RtD",
            "BlackForestMageLegs_RtD",
            // Swamp
            "SwampEarthStaff_RtD",
            "SwampPoisonWand_RtD",
            "SwampMageChest_RtD",
            "SwampMageHood_RtD",
            "SwampMageLegs_RtD",
            "SwampMageCape_RtD",
            // Mountain
            "MountainIceStaff_RtD",
            "MountainIceWand_RtD",
            "MountainMageChest_RtD",
            "MountainMageHood_RtD",
            "MountainMageLegs_RtD",
            "MountainMageCape_RtD",
            // Plains
            "PlainsVoidStaff_RtD",
            "PlainsVoidWand_RtD",
            "PlainsMageChest_RtD",
            "PlainsMageHood_RtD",
            "PlainsMageLegs_RtD",
            "PlainsMageCape_RtD",
            // Mistlands
            "MistlandsQuakeStaff_RtD",
            "MistlandsElementWand_RtD",
            "MistlandsMageHood_RtD",
            "MistlandsMageChest_RtD",
            "MistlandsMageLegs_RtD",
            "MistlandsMageCape_RtD",
            // AshLands
            "AshLandsStaff1_RtD",
            "AshLandsStaff2_RtD",
            "AshLandsStaff3_RtD",
            "AshLandsFireWand_RtD",
            "AshLandsMageChest_RtD",
            "AshLandsMageHood_RtD",
            "AshLandsMageLegs_RtD",
            // Deep North
            "DeepNorthStaff1_RtD",
            "DeepNorthStaff2_RtD",
            "DeepNorthStaff3_RtD",
            "DeepNorthArcaneWand_RtD",
            "DeepNorthMageChest_RtD",
            "DeepNorthMageHood_RtD",
            "DeepNorthMageLegs_RtD",
            "HealingStaff_T1_RtD",
            "HealingStaff_T2_RtD",
            "HealingStaff_T3_RtD",
            "HealingStaff_T4_RtD",
            "SQueensJam_RtD",
            "SCarrotSoup_RtD",
            "SBlackSoup_RtD",
            "STurnipStew_RtD",
            "SShockolateShake_RtD",
            "SOnionSoup_RtD",
            "SEyeScream_RtD",
            "SBloodPudding_RtD",
            // Elemental Shields
            "MeadowsElemental_RtD",
            "BlackForestElemental_RtD",
            "SwampElemental_RtD",
            "MountainElemental_RtD",
            "PlainsElemental_RtD",
            "MistlandsElemental_RtD",
            "AshLandsElemental_RtD",
            "DeepNorthElemental_RtD",
        };

        private static readonly string[] ItemCategoryList =
        {
            // Meadows
            "Meadows",
            "Meadows",
            "Meadows",
            "Meadows",
            "Meadows",
            "Meadows",
            "Meadows",
            "Meadows",
            "Meadows",
            // Swamp
            "Swamp",
            "Swamp",
            "Swamp",
            "Swamp",
            "Swamp",
            "Swamp",
            // Mountain
            "Mountain",
            "Mountain",
            "Mountain",
            "Mountain",
            "Mountain",
            "Mountain",
            // Plains
            "Plains",
            "Plains",
            "Plains",
            "Plains",
            "Plains",
            "Plains",
            // Mistlands
            "Mistlands",
            "Mistlands",
            "Mistlands",
            "Mistlands",
            "Mistlands",
            "Mistlands",
            // AshLands
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            // Deep North
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            "Deep North",
            // Elemental Shields
            "Elemental Shields",
            "Elemental Shields",
            "Elemental Shields",
            "Elemental Shields",
            "Elemental Shields",
            "Elemental Shields",
            "Elemental Shields",
            "Elemental Shields",
        };

        private static readonly string[] ItemStationList =
        {
            // Meadows
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            // Swamp
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            // Mountain
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            // Plains
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            // Mistlands
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            // AshLands
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            // Deep North
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Cauldron,
            CraftingStations.Cauldron,
            CraftingStations.Cauldron,
            CraftingStations.Cauldron,
            CraftingStations.Cauldron,
            CraftingStations.Cauldron,
            CraftingStations.Cauldron,
            CraftingStations.Cauldron,
            // Elemental Shields
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
        };

        // Requirement item names, one row per item, same order as ItemPrefabList.
        private static readonly string[][] ItemReqItems =
        {
            // Meadows
            new string[] { "SpiritEssense_RtD", "Dandelion", "Wood" },
            new string[] { "SpiritEssense_RtD", "MeadowsCrystal_RtD", "TrophyEikthyr" },
            new string[] { "SpiritEssense_RtD", "MeadowsCrystal_RtD", "FairyCoreMeadows_RtD" },
            new string[] { "SpiritEssense_RtD", "BlackForestCrystal_RtD", "FairyCoreBlackForest_RtD", "MeadowsAirStaff_RtD" },
            new string[] { "SpiritEssense_RtD", "BlackForestCrystal_RtD", "FairyCoreBlackForest_RtD", "MeadowsLighteningStaff_RtD" },
            new string[] { "SpiritEssense_RtD", "BlackForestCrystal_RtD", "FairyCoreBlackForest_RtD", "MeadowsAirWand_RtD" },
            new string[] { "SpiritEssense_RtD", "BlackForestCrystal_RtD", "FairyCoreBlackForest_RtD", "TrollHide" },
            new string[] { "SpiritEssense_RtD", "BlackForestCrystal_RtD", "FairyCoreBlackForest_RtD", "TrollHide" },
            new string[] { "SpiritEssense_RtD", "BlackForestCrystal_RtD", "FairyCoreBlackForest_RtD", "TrollHide" },
            // Swamp
            new string[] { "SpiritEssense_RtD", "SwampCrystal_RtD", "FairyCoreSwamp_RtD", "BlackForestFireStaff_RtD" },
            new string[] { "SpiritEssense_RtD", "SwampCrystal_RtD", "FairyCoreSwamp_RtD", "BlackForestLightningWand_RtD" },
            new string[] { "SpiritEssense_RtD", "SwampCrystal_RtD", "FairyCoreSwamp_RtD", "BlackForestMageChest_RtD" },
            new string[] { "SpiritEssense_RtD", "SwampCrystal_RtD", "FairyCoreSwamp_RtD", "BlackForestMageHood_RtD" },
            new string[] { "SpiritEssense_RtD", "SwampCrystal_RtD", "FairyCoreSwamp_RtD", "BlackForestMageLegs_RtD" },
            new string[] { "SpiritEssense_RtD", "SwampCrystal_RtD", "FairyCoreSwamp_RtD", "BlackForestMageLegs_RtD" },
            // Mountain
            new string[] { "SpiritEssense_RtD", "MountainCrystal_RtD", "FairyCoreMountain_RtD", "SwampEarthStaff_RtD" },
            new string[] { "SpiritEssense_RtD", "MountainCrystal_RtD", "FairyCoreMountain_RtD", "SwampPoisonWand_RtD" },
            new string[] { "SpiritEssense_RtD", "MountainCrystal_RtD", "FairyCoreMountain_RtD", "SwampMageChest_RtD" },
            new string[] { "SpiritEssense_RtD", "MountainCrystal_RtD", "FairyCoreMountain_RtD", "SwampMageHood_RtD" },
            new string[] { "SpiritEssense_RtD", "MountainCrystal_RtD", "FairyCoreMountain_RtD", "SwampMageLegs_RtD" },
            new string[] { "SpiritEssense_RtD", "MountainCrystal_RtD", "FairyCoreMountain_RtD", "SwampMageCape_RtD" },
            // Plains
            new string[] { "SpiritEssense_RtD", "PlainsCrystal_RtD", "FairyCorePlains_RtD", "MountainIceStaff_RtD" },
            new string[] { "SpiritEssense_RtD", "PlainsCrystal_RtD", "FairyCorePlains_RtD", "MountainIceWand_RtD" },
            new string[] { "SpiritEssense_RtD", "PlainsCrystal_RtD", "FairyCorePlains_RtD", "MountainMageChest_RtD" },
            new string[] { "SpiritEssense_RtD", "PlainsCrystal_RtD", "FairyCorePlains_RtD", "MountainMageHood_RtD" },
            new string[] { "SpiritEssense_RtD", "PlainsCrystal_RtD", "FairyCorePlains_RtD", "MountainMageLegs_RtD" },
            new string[] { "SpiritEssense_RtD", "PlainsCrystal_RtD", "FairyCorePlains_RtD", "MountainMageCape_RtD" },
            // Mistlands
            new string[] { "SpiritEssense_RtD", "MistlandsCrystal_RtD", "FairyCoreMistlands_RtD", "PlainsVoidStaff_RtD" },
            new string[] { "SpiritEssense_RtD", "MistlandsCrystal_RtD", "FairyCoreMistlands_RtD", "PlainsVoidWand_RtD" },
            new string[] { "SpiritEssense_RtD", "MistlandsCrystal_RtD", "FairyCoreMistlands_RtD", "PlainsMageHood_RtD" },
            new string[] { "SpiritEssense_RtD", "MistlandsCrystal_RtD", "FairyCoreMistlands_RtD", "PlainsMageChest_RtD" },
            new string[] { "SpiritEssense_RtD", "MistlandsCrystal_RtD", "FairyCoreMistlands_RtD", "PlainsMageLegs_RtD" },
            new string[] { "SpiritEssense_RtD", "MistlandsCrystal_RtD", "FairyCoreMistlands_RtD", "PlainsMageCape_RtD" },
            // AshLands
            new string[] { "SpiritEssense_RtD", "AshLandsCrystal_RtD", "FairyCoreAshLands_RtD", "MistlandsQuakeStaff_RtD" },
            new string[] { "SpiritEssense_RtD", "AshLandsCrystal_RtD", "FairyCoreAshLands_RtD", "MistlandsQuakeStaff_RtD" },
            new string[] { "SpiritEssense_RtD", "AshLandsCrystal_RtD", "FairyCoreAshLands_RtD", "MistlandsQuakeStaff_RtD" },
            new string[] { "SpiritEssense_RtD", "AshLandsCrystal_RtD", "FairyCoreAshLands_RtD", "MistlandsElementWand_RtD" },
            new string[] { "SpiritEssense_RtD", "AshLandsCrystal_RtD", "FairyCoreAshLands_RtD", "MistlandsMageChest_RtD" },
            new string[] { "SpiritEssense_RtD", "AshLandsCrystal_RtD", "FairyCoreAshLands_RtD", "MistlandsMageHood_RtD" },
            new string[] { "SpiritEssense_RtD", "AshLandsCrystal_RtD", "FairyCoreAshLands_RtD", "MistlandsMageLegs_RtD" },
            // Deep North
            new string[] { "SpiritEssense_RtD", "DeepNorthCrystal_RtD", "FairyCoreDeepNorth_RtD", "AshLandsStaff1_RtD" },
            new string[] { "SpiritEssense_RtD", "DeepNorthCrystal_RtD", "FairyCoreDeepNorth_RtD", "AshLandsStaff2_RtD" },
            new string[] { "SpiritEssense_RtD", "DeepNorthCrystal_RtD", "FairyCoreDeepNorth_RtD", "AshLandsStaff3_RtD" },
            new string[] { "SpiritEssense_RtD", "DeepNorthCrystal_RtD", "FairyCoreDeepNorth_RtD", "AshLandsFireWand_RtD" },
            new string[] { "SpiritEssense_RtD", "DeepNorthCrystal_RtD", "FairyCoreDeepNorth_RtD", "AshLandsMageChest_RtD" },
            new string[] { "SpiritEssense_RtD", "DeepNorthCrystal_RtD", "FairyCoreDeepNorth_RtD", "AshLandsMageHood_RtD" },
            new string[] { "SpiritEssense_RtD", "DeepNorthCrystal_RtD", "FairyCoreDeepNorth_RtD", "AshLandsMageLegs_RtD" },
            new string[] { "SpiritEssense_RtD", "MeadowsCrystal_RtD", "FairyCoreMeadows_RtD", "TrophyEikthyr" },
            new string[] { "SpiritEssense_RtD", "BlackForestCrystal_RtD", "FairyCoreBlackForest_RtD", "HealingStaff_T1_RtD" },
            new string[] { "SpiritEssense_RtD", "SwampCrystal_RtD", "FairyCoreSwamp_RtD", "HealingStaff_T2_RtD" },
            new string[] { "SpiritEssense_RtD", "MountainCrystal_RtD", "FairyCoreMountain_RtD", "HealingStaff_T3_RtD" },
            new string[] { "SpiritEssense_RtD", "Raspberry", "Blueberries" },
            new string[] { "SpiritEssense_RtD", "MushroomYellow", "Carrot" },
            new string[] { "SpiritEssense_RtD", "RawMeat", "Turnip" },
            new string[] { "SpiritEssense_RtD", "DeerMeat", "Turnip" },
            new string[] { "SpiritEssense_RtD", "Ooze", "Bloodbag" },
            new string[] { "SpiritEssense_RtD", "WolfMeat", "Onion" },
            new string[] { "SpiritEssense_RtD", "FreezeGland", "Ooze" },
            new string[] { "SpiritEssense_RtD", "Bloodbag", "BarleyFlour", "CookedLoxMeat" },
            // Elemental Shields
            new string[] { "SpiritEssense_RtD", "Dandelion", "Wood" },
            new string[] { "SpiritEssense_RtD", "BlackForestCrystal_RtD", "FairyCoreBlackForest_RtD", "MeadowsElemental_RtD" },
            new string[] { "SpiritEssense_RtD", "SwampCrystal_RtD", "FairyCoreSwamp_RtD", "BlackForestElemental_RtD" },
            new string[] { "SpiritEssense_RtD", "MountainCrystal_RtD", "FairyCoreMountain_RtD", "SwampElemental_RtD" },
            new string[] { "SpiritEssense_RtD", "PlainsCrystal_RtD", "FairyCorePlains_RtD", "MountainElemental_RtD" },
            new string[] { "SpiritEssense_RtD", "MistlandsCrystal_RtD", "FairyCoreMistlands_RtD", "PlainsElemental_RtD" },
            new string[] { "SpiritEssense_RtD", "AshLandsCrystal_RtD", "FairyCoreAshLands_RtD", "MistlandsElemental_RtD" },
            new string[] { "SpiritEssense_RtD", "DeepNorthCrystal_RtD", "FairyCoreDeepNorth_RtD", "AshLandsElemental_RtD" },
        };

        // Requirement amounts, same shape as ItemReqItems above.
        private static readonly int[][] ItemReqAmounts =
        {
            // Meadows
            new int[] { 10, 15, 10 },
            new int[] { 10, 15, 1 },
            new int[] { 10, 15, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 15 },
            new int[] { 10, 15, 1, 10 },
            new int[] { 10, 15, 1, 15 },
            // Swamp
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            // Mountain
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            // Plains
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            // Mistlands
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            // AshLands
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            // Deep North
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 2, 1, 1 },
            new int[] { 2, 2, 4 },
            new int[] { 2, 2, 3 },
            new int[] { 2, 2, 5 },
            new int[] { 2, 3, 1 },
            new int[] { 2, 1, 4 },
            new int[] { 2, 1, 2 },
            new int[] { 2, 1, 3, 1 },
            // Elemental Shields
            new int[] { 10, 15, 10 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
            new int[] { 10, 15, 1, 1 },
        };

        // Requirement "amount per level" (upgrade cost per crafting station level).
        // Recover is always true for every requirement here, so it isn't broken out into its own array - it's just hardcoded true where it's used below.
        
        private static readonly int[][] ItemReqLevels =
        {
            // Meadows
            new int[] { 3, 5, 0 },
            new int[] { 3, 5, 0 },
            new int[] { 3, 5, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 3 },
            new int[] { 3, 5, 0, 0 },
            // Swamp
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            // Mountain
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            // Plains
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            // Mistlands
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            // AshLands
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            // Deep North
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 0, 0, 0 },
            new int[] { 0, 0, 0 },
            new int[] { 0, 0, 0 },
            new int[] { 0, 0, 0 },
            new int[] { 0, 0, 0 },
            new int[] { 0, 0, 0 },
            new int[] { 0, 0, 0 },
            new int[] { 0, 0, 0, 0 },
            // Elemental Shields
            new int[] { 3, 5, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
            new int[] { 3, 5, 0, 0 },
        };

        // Config entries, one array per field, index-matched to ItemPrefabList.
        private ConfigEntry<bool>[] ItemEnabledConfigs;
        private ConfigEntry<string>[][] ItemReqItemConfigs;
        private ConfigEntry<int>[][] ItemReqAmountConfigs;

        public void CreateItemRecipeConfigs()
        {
            try
            {
                // Order counts down so each category section reads top-to-bottom in the Configuration Manager in the same order the lists above are defined.
                
                int order = 20000;

                ItemEnabledConfigs = new ConfigEntry<bool>[ItemPrefabList.Length];
                ItemReqItemConfigs = new ConfigEntry<string>[ItemPrefabList.Length][];
                ItemReqAmountConfigs = new ConfigEntry<int>[ItemPrefabList.Length][];

                for (int i = 0; i < ItemPrefabList.Length; i++)
                {
                    string prefab = ItemPrefabList[i];
                    string section = "Item Recipes - " + ItemCategoryList[i];

                    ItemEnabledConfigs[i] = Config.Bind(section, prefab + " - Enabled", true,
                        new ConfigDescription("Enable or disable crafting/adding of " + prefab + ".", null,
                        new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                    ItemReqItemConfigs[i] = new ConfigEntry<string>[ItemReqItems[i].Length];
                    ItemReqAmountConfigs[i] = new ConfigEntry<int>[ItemReqItems[i].Length];

                    for (int j = 0; j < ItemReqItems[i].Length; j++)
                    {
                        int slot = j + 1;
                        string defaultItem = ItemReqItems[i][j];
                        int defaultAmount = ItemReqAmounts[i][j];

                        ItemReqItemConfigs[i][j] = Config.Bind(section, prefab + " - Requirement " + slot + " Item", defaultItem,
                            new ConfigDescription("Requirement " + slot + " for " + prefab + ". Prefab/item id consumed on craft (default: " + defaultItem + ").", null,
                            new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                        ItemReqAmountConfigs[i][j] = Config.Bind(section, prefab + " - Requirement " + slot + " Amount", defaultAmount,
                            new ConfigDescription("Amount of Requirement " + slot + " required to craft " + prefab + " (default item: " + defaultItem + ").",
                            new AcceptableValueRange<int>(0, 9999),
                            new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                        ItemReqItemConfigs[i][j].SettingChanged += ItemRecipeConfigChanged;
                        ItemReqAmountConfigs[i][j].SettingChanged += ItemRecipeConfigChanged;
                    }

                    ItemEnabledConfigs[i].SettingChanged += ItemRecipeConfigChanged;
                }

                // This fires once when configs sync from the server, so it catches everything in one go instead of relying on each config's own change event
                
                SynchronizationManager.OnConfigurationSynchronized += ItemRecipeConfigChanged;
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding item recipe configuration values: {arg}");
            }
        }

        public void CreateRecipes()
        {
            try
            {
                for (int i = 0; i < ItemPrefabList.Length; i++)
                {
                    string prefab = ItemPrefabList[i];

                    if (!ItemEnabledConfigs[i].Value)
                    {
                        if (LoggingEnable.Value) { Logger.LogMessage("Skipped (disabled in config): " + prefab); }
                        continue;
                    }

                    ItemConfig itemConfig = new ItemConfig();
                    itemConfig.CraftingStation = ItemStationList[i];

                    for (int j = 0; j < ItemReqItems[i].Length; j++)
                    {
                        string reqItem = ItemReqItemConfigs[i][j].Value;
                        int amount = ItemReqAmountConfigs[i][j].Value;
                        int amountPerLevel = ItemReqLevels[i][j];
                        itemConfig.AddRequirement(new RequirementConfig(reqItem, amount, amountPerLevel, true));
                    }

                    ItemManager.Instance.AddItem(new CustomItem(this.MyAssets, prefab, true, itemConfig));

                    if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefab + " to the Object database"); }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }

        // Fires on ANY item recipe config change - both local edits and Jotunn syncing the server's value into a client's config after connecting.
        private void ItemRecipeConfigChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ItemPrefabList.Length; i++)
                {
                    string prefab = ItemPrefabList[i];
                    Recipe recipe = ItemManager.Instance.GetItem(prefab)?.Recipe?.Recipe;

                    if (recipe == null)
                    {
                        // Item/recipe was never registered (most likely it was disabled at Awake time, so CreateRecipes() skipped it).
                        continue;
                    }

                    recipe.m_enabled = ItemEnabledConfigs[i].Value;

                    if (recipe.m_resources == null)
                    {
                        continue;
                    }

                    for (int j = 0; j < ItemReqItems[i].Length && j < recipe.m_resources.Length; j++)
                    {
                        string reqItemName = ItemReqItemConfigs[i][j].Value;

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
                        recipe.m_resources[j].m_amount = ItemReqAmountConfigs[i][j].Value;
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