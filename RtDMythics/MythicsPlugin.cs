using System.Reflection;
using System;
using BepInEx;
using BepInEx.Configuration;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace RtDMythics
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Major)]
    [BepInDependency("com.jotunn.jotunn", BepInDependency.DependencyFlags.HardDependency)]
    [BepInIncompatibility("blacks7ar.SeedBed")]
    internal partial class RtDMythics : BaseUnityPlugin
    {
        public const string PluginGUID = "soloredis.rtdmythics";

        public const string PluginName = "RtDMythics";

        public const string PluginVersion = "1.2.93";

        private AssetBundle MyAssets;

        public ConfigEntry<bool> LoggingEnable;

        public string[] CustomSEShieldList = new string[]
        {
            // Status Effects
            "SE_AshLandsShield_RtD",
            "SE_BlackForestShield_RtD",
            "SE_DeepNorthShield_RtD",
            "SE_MeadowsShield_RtD",
            "SE_MistlandsShield_RtD", 
            "SE_MountainShield_RtD",
            "SE_PlainsShield_RtD",
            "SE_SwampShield_RtD",
            "SE_AshLandsShield_Player_RtD",
            "SE_BlackForestShield_Player_RtD",
            "SE_DeepNorthShield_Player_RtD",
            "SE_MeadowsShield_Player_RtD",
            "SE_MistlandsShield_Player_RtD",
            "SE_MountainShield_Player_RtD",
            "SE_PlainsShield_Player_RtD",
            "SE_SwampShield_Player_RtD"
        };

        public string[] CustomSEList = new string[]
        {
            // Status Effects
            "SE_AshLandsHeal_RtD",
            "SE_BlackForestHeal_RtD",
            "SE_DeepNorthHeal_RtD",
            "SE_MeadowsHeal_RtD",
            "SE_MistlandsHeal_RtD",
            "SE_MountainHeal_RtD",
            "SE_PlainsHeal_RtD",
            "SE_SwampHeal_RtD",
            "SE_Cast_T1_RtD",
            "SE_Cast_T2_RtD",
            "SE_Cast_T3_RtD",
            "SE_Cast_T4_RtD",
            "SE_Healing_Staff_T1_RtD",
            "SE_Healing_Staff_T2_RtD",
            "SE_Healing_Staff_T3_RtD",
            "SE_Healing_Staff_T4_RtD",
            "SE_Mage_Armor_AshLands_RtD",
            "SE_Mage_Armor_BlackForest_RtD",
            "SE_Mage_Armor_DeepNorth_RtD",
            "SE_Mage_Armor_Mistlands_RtD",
            "SE_Mage_Armor_Mountain_RtD",
            "SE_Mage_Armor_Plains_RtD",
            "SE_Mage_Armor_Swamp_RtD"
        };
        
        public string[] ItemsList = new string[]
        {
            // Items
            "MeadowsCrystal_RtD",
            "BlackForestCrystal_RtD",
            "SwampCrystal_RtD",
            "MountainCrystal_RtD",
            "PlainsCrystal_RtD",
            "MistlandsCrystal_RtD",
            "AshLandsCrystal_RtD",
            "DeepNorthCrystal_RtD",
            "SpiritEssense_RtD",
            "FairyCoreMeadows_RtD",
            "FairyCoreBlackForest_RtD",
            "FairyCoreSwamp_RtD",
            "FairyCoreMountain_RtD",
            "FairyCorePlains_RtD",
            "FairyCoreMistlands_RtD",
            "FairyCoreAshLands_RtD",
            "FairyCoreDeepNorth_RtD"
        
        };

        public string[] PrefabsList = new string[]
        {
            // Prefabs
            "fx_FaeShieldBreak_RtD",
            "fx_FaeShieldHit_RtD",
            //AshLands Fae
            "ArcaneExplosionAshLandsFairy_RtD",
            "FaeHealAOEAshLands_RtD",
            "FaeHealSpellAshLands_RtD",
            "FaeMeleeAshLands_RtD",
            "FaeProtectAOEAshLands_RtD",
            "FaeProtectSpellAshLands_RtD",
            "FaeSpellAshLands_RtD",
            "FireExplosionFairy_RtD",
            "FireProjectileFairy_RtD",

            //AshLands Pixie
            "ArcaneExplosionAshlandsPixie_RtD",
            "PixieExplosionAshLands_RtD",
            "PixieHealAOEAshLands_RtD",
            "PixieHealSpellAshLands_RtD",
            "PixieMeleeAshLands_RtD",
            "PixieProjectileAshLands_RtD",
            "PixieProtectAOEAshLands_RtD",
            "PixieProtectSpellAshLands_RtD",
            "PixieSpellAshLands_RtD",

            // BlackForest Fae
            "ArcaneExplosionBlackForestFairy_RtD",
            "FaeHealAOEBlackForest_RtD",
            "FaeHealSpellBlackForest_RtD",
            "FaeMeleeBlackForest_RtD",
            "FaeProtectAOEBlackForest_RtD",
            "FaeProtectSpellBlackForest_RtD",
            "FaeSpellBlackForest_RtD",
            "LightningExplosionBlackForest_RtD",
            "LightningProjectileBlackForest_RtD",

            // BlackForest Pixie
            "ArcaneExplosionBlackForestPixie_RtD",
            "LightningExplosionPixie_RtD",
            "LightningProjectilePixie_RtD",
            "PixieHealAOEBlackForest_RtD",
            "PixieHealSpellBlackForest_RtD",
            "PixieMeleeBlackForest_RtD",
            "PixieProtectAOEBlackForest_RtD",
            "PixieProtectSpellBlackForest_RtD",
            "PixieSpellBlackForest_RtD",

            // DeepNorth Fae
            "ArcaneExplosionDeepNorthFairy_RtD",
            "ArcaneExplosionDeepNorthFairyDeath_RtD",
            "ArcaneProjectileDeepNorthFairy_RtD",
            "FaeHealAOEDeepNorth_RtD",
            "FaeHealSpellDeepNorth_RtD",
            "FaeMeleeDeepNorth_RtD",
            "FaeProtectAOEDeepNorth_RtD",
            "FaeProtectSpellDeepNorth_RtD",
            "FaeSpellDeepNorth_RtD",

            // DeepNorth Pixie
            "ArcaneExplosionDeepNorthPixieDeath_RtD",
            "ArcaneProfjectileDeepNorthPixie_RtD",
            "ArecaneExplosionDeepNorthPixie_RtD",
            "PixieHealAOEDeepNorth_RtD",
            "PixieHealSpellDeepNorth_RtD",
            "PixieMeleeDeepNorth1_RtD",
            "PixieMeleeDeepNorth2_RtD",
            "PixieMeleeDeepNorth3_RtD",
            "PixieProtectAOEDeepNorth_RtD",
            "PixieProtectSpellDeepNorth_RtD",
            "PixieSpellDeepNorth_RtD",

            // Meadows Fae
            "AirExplosionFairy_RtD",
            "AirProjectileFairy_RtD",
            "ArcaneExplosionMeadowsFairy_RtD",
            "FaeHealAOEMeadows_RtD",
            "FaeHealSpellMeadows_RtD",
            "FaeMeleeMeadows_RtD",
            "FaeProtectAOEMeadows_RtD",
            "FaeProtectSpellMeadows_RtD",
            "FaeSpellMeadows_RtD",

            // Meadows Pixie'
            "AirExplosionPixie_RtD",
            "AirProjectilePixie_RtD",
            "ArcaneExplosionMeadowsPixie_RtD",
            "PixieHealAOEMeadows_RtD",
            "PixieHealSpellMeadows_RtD",
            "PixieMeleeMeadows_RtD",
            "PixieProtectAOEMeadows_RtD",
            "PixieProtectSpellMeadows_RtD",
            "PixieSpellMeadows_RtD",

            // Mistlands Fae
            "ArcaneExplosionMistlandsFairy_RtD",
            "FaeHealAOEMistlands_RtD",
            "FaeHealSpellMistlands_RtD",
            "FaeMeleeMistlands_RtD",
            "FaeProtectAOEMistlands_RtD",
            "FaeProtectSpellMistlands_RtD",
            "FaeSpellMistlands_RtD",
            "LightExplosionFairy_RtD",
            "LightProjectileFairy_RtD",

            // Mistlands Pixie
            "ArcaneExplosionMistlandsPixie_RtD",
            "LightExplosionPixie_RtD",
            "LightProjectilePixie_RtD",
            "PixieHealAOEMistlands_RtD",
            "PixieHealSpellMistlands_RtD",
            "PixieMeleeMistlands_RtD",
            "PixieProtectAOEMistlands_RtD",
            "PixieProtectSpellMistlands_RtD",
            "PixieSpellMistlands_RtD",

            // Mountain Fae
            "ArcaneExplosionMountainFairy_RtD",
            "FaeHealAOEMountain_RtD",
            "FaeHealSpellMountain_RtD",
            "FaeMeleeMountain_RtD",
            "FaeProtectAOEProtectMountain_RtD",
            "FaeProtectSpellProtectMountain_RtD",
            "FaeSpellMountain_RtD",
            "IceExplosionMountain_RtD",
            "IceProjectileMountain_RtD",

            // Mountain Pixie
            "ArcaneExplosionMountainPixie_RtD",
            "IceExplosionPixie_RtD",
            "IceProjectilePixie_RtD",
            "PixeHealSpellMountain_RtD",
            "PixieHealAOEMountain_RtD",
            "PixieMeleeMountain_RtD",
            "PixieProtectAOEMountain_RtD",
            "PixieProtectSpellMountain_RtD",
            "PixieSpellMountain_RtD",

            // Plains Fae
            "ArcaneExplosionPlainsFairy_RtD",
            "FaeHealAOEPlains_RtD",
            "FaeHealSpellPlains_RtD",
            "FaeMeleePlains_RtD",
            "FaeProtectAOEPlains_RtD",
            "FaeProtectSpellPlains_RtD",
            "FaeSpellPlains_RtD",
            "VoidExplosionPlainsFairy_RtD",
            "VoidProjectilePlainsFairy_RtD",

            // Plains Pixie
            "ArcaneExplosionPlainsPixie_RtD",
            "PixieHealAOEPlains_RtD",
            "PixieHealSpellPlains_RtD",
            "PixieMeleePlains_RtD",
            "PixieProtectAOEPlains_RtD",
            "PixieProtectSpellPlains_RtD",
            "PixieSpellPlains_RtD",
            "VoidExplosionPlainsPixie_RtD",
            "VoidProjectilePlainsPixie_RtD",

            // Swamp Fairy 
            "ArcaneExplosionSwampFairy_RtD",
            "EarthExlosionFairy_RtD",
            "EarthProjectileFairy_RtD",
            "FaeHealAOESwamp_RtD",
            "FaeHealSpellSwamp_RtD",
            "FaeMeleeSwamp_RtD",
            "FaeProtectAOESpellSwamp_RtD",
            "FaeProtectSpellSwamp_RtD",
            "FaeSpellSwamp_RtD",

            // Swamp Pixie
            "ArcaneExplosionSwampPixie_RtD",
            "EarthExplosionPixie_RtD",
            "EarthProjectilePixie_RtD",
            "PixieHealAOESwamp_RtD",
            "PixieHealSpellSwamp_RtD",
            "PixieMeleeSwamp_RtD",
            "PixieProtectAOESwamp_RtD",
            "PixieProtectSpellSwamp_RtD",
            "PixieSpellSwamp_RtD",

            // FX
            "fx_faehit_RtD",
            "fx_fae_protect_RtD",
            "vfx_FaeShield_RtD",
            "fx_faedeath_RtD",
            "vfx_FaeShield_Player_RtD",
            
            // Spawners
            "Spawner_PixieMeadows_RtD",
            "Spawner_PixieBlackForest_RtD",
            "Spawner_PixieSwamp_RtD",
            "Spawner_PixieMountain_RtD",
            "Spawner_PixiePlains_RtD",
            "Spawner_PixieMistlands_RtD",
            "Spawner_PixieAshLands_RtD",
            "Spawner_PixieDeepNorth_RtD",
            "Spawner_QueenMeadows_RtD",
            "Spawner_QueenBlackForest_RtD",
            "Spawner_QueenSwamp_RtD",
            "Spawner_QueenMountain_RtD",
            "Spawner_QueenPlains_RtD",
            "Spawner_QueenMistlands_RtD",
            "Spawner_QueenAshLands_RtD",
            "Spawner_QueenDeepNorth_RtD",
            "Spawner_UndeadMeadows_RtD",
            "Spawner_UndeadBlackForest_RtD",
            "Spawner_UndeadSwamp_RtD",
            "Spawner_UndeadMountain_RtD",
            "Spawner_UndeadPlains_RtD",
            "Spawner_UndeadMistlands_RtD",
            "Spawner_UndeadAshLands_RtD",
            "Spawner_UndeadDeepNorth_RtD",
            
            // Whisps Attacks
            "SAshLandsAttackA_RtD",
            "SAshLandsAttackF_RtD",
            "SBlackForestAttackA_RtD",
            "SBlackForestAttackF_RtD",
            "SDeepNorthAttackA_RtD",
            "SDeepNorthAttackF_RtD",
            "SMeadowsAttackA_RtD",
            "SMeadowsAttackF_RtD",
            "SMistlandsAttackA_RtD",
            "SMIstlandsAttackF_RtD",
            "SMountainAttackA_RtD",
            "SMountainAttackF_RtD",
            "SPlainsAttackA_RtD",
            "SPlainsAttackF_RtD",
            "SSwampAttackA_RtD",
            "SSwampAttackF_RtD",

            // Whisp FX
            "vfx_bluespirit_death_RtD",
            "vfx_greenspirit_death_RtD",
            "vfx_pinkspirit_death_RtD",
            "vfx_redspirit_death_RtD",
            "vfx_whitespirit_death_RtD",
            "vfx_yellowspirit_death_RtD",

            // Spirit Attacks
            "SAshLandsAttackF_RtD1",
            "SBlackForestAttackF_RtD1",
            "SDeepNorthAttackF_RtD1",
            "SMeadowsAttackF_RtD1",
            "SMIstlandsAttackF_RtD1",
            "SMountainAttackF_RtD1",
            "SPlainsAttackF_RtD1",
            "SSwampAttackF_RtD1",

            // Spirit FX
            "vfx_spiritmonster_death2_RtD",
            "vfx_spirittmonster_hit2_RtD",
            
            //Healing FX
            "HealingAOE_T1_RtD",
            "HealingAOE_T2_RtD",
            "HealingAOE_T3_RtD",
            "HealingAOE_T4_RtD",
            "HealingCAST_T1_RtD",
            "HealingCAST_T2_RtD",
            "HealingCAST_T3_RtD",
            "HealingCAST_T4_RtD",

            //Staff AOE
            "AirTornadoMeadowsAOE_RtD",
            "ArcaneLargeAOE_RtD",
            "ArcaneMediumAOE_RtD",
            "ArcaneSmallAOE_RtD",
            "EarthQuakeMistLandsAOE_RtD",
            "EarthShieldSwampAOE_RtD",
            "FireLargeAOE_RtD",
            "FireMediumAOE_RtD",
            "FireRingBlackForestAOE_RtD",
            "FireSmallAOE_RtD",
            "FrostEnchantmentMountainAOE_RtD",
            "LightDamgeAOE_RtD",
            "LighteningRainBlackForestAOE_RtD",
            "VoidAOE_RtD",
            "WaterAOE_RtD",

            //Staff Projectiles
            "AirProjectileS_RtD",
            "ArcaneProjectileLargeS_RtD",
            "ArcaneProjectileLargeSecondaryS_RtD",
            "ArcaneProjectileMediumS_RtD",
            "ArcaneProjectileSmallS_RtD",
            "EarthProjectileQuake_RtD",
            "EarthProjectileS_RtD",
            "FireProjectileLargeS_RtD",
            "FireProjectileLargeSecondaryS_RtD",
            "FireProjectileMediumS_RtD",
            "FireProjectileS_RtD",
            "FrostProjectileLargeS_RtD",
            "FrostProjectileS_RtD",
            "LighteningProjectileS_RtD",
            "LightProjectileS_RtD",
            "SpawnerProjectileTemplate",
            "VoidProjectileS_RtD",
            "WaterProjectileS_RtD",

            //Staff Explosions
            "ArcaneExplosionLargeS_RtD",
            "ArcaneExplosionMediumS_RtD",
            "ArcaneExplosionSmallS_RtD",
            "EarthExplosionLargeS_RtD",
            "EarthExplosionSmallS_RtD",
            "FireExplosionLargeS_RtD",
            "FireExplosionMediumS_RtD",
            "FireExplosionSmallS_RtD",
            "FrostExplosionLargeS_RtD",
            "FrostExplosionSmallS_RtD",
            "LightExplosionSmallS_RtD",
            "LightningExplosionSmallS_RtD",
            "StormExplosionSmallS_RtD",
            "VoidExplosionSmallS_RtD",
            "WaterExplosionS_RtD",

            //Wand Projectiles
            "AirWandProjectile_RtD",
            "ArcaneWandProjectile_RtD",
            "EarthWandProjectile_RtD",
            "FireWandAshProjectile_RtD",
            "FireWandProjectile_RtD",
            "IceWandProjectile_RtD",
            "LighteningWandProjectile_RtD",
            "LightWandProjectile_RtD",
            "VoidWandProjectile_RtD",
            "WaterWandProjectile_RtD",

            //Wand Explosions
            "AirExplosionWand_RtD",
            "ArcaneExplosionWand_RtD",
            "EarthExplosionWand_RtD",
            "FireExplosionAshWand_RtD",
            "FireExplosionWand_RtD",
            "FrostExplosionWand_RtD",
            "LighteningExplosionWand_RtD",
            "LightExplosionWand_RtD",
            "VoidExplosionWand_RtD",
            "WaterExplosionWand_RtD",

            //Wand AOE
            "ArcaneMuzzleAOE_RtD",
            "EarthMuzzleAOE_RtD",
            "FireMuzzleAOE_RtD",
            "FrostMuzzleAOE_RtD",
            "LifeMuzzleAOE_RtD",
            "LightMuzzleAOE_RtD",
            "LightningMuzzleAOE_RtD",
            "ShadowMuzzleAOE_RtD",
            "StormMuzzleAOE_RtD",
            "WaterMuzzleAOE_RtD",

            //Projectile Spawn AOE
            "AirProjectileAOE_RtD",
            "ArcaneProjectileAOE_RtD",
            "EarthProjectileAOE_RtD",
            "FireProjectileAOE_RtD",
            "FrostProjectileAOE_RtD",
            "LightProjectileAOE_RtD",
            "VoidProjectileAOE_RtD",
            "WaterProjectileAOE_RtD",
            
            "webeggprojectile_RtD1",
            "blackforestmutantprojectile_RtD1",
            "deepnorthmutantprojectile_RtD1",
            "meadowsmutantprojectile_RtD1",
            "mistlandsmutantprojectile_RtD1",
            "mountainmutantprojectile2_RtD1",
            "mountainmutantprojectile3_RtD1",
            "mountainmutantprojectile_RtD1",
            "plainsmutantprojectile_RtD2",
            "sizzleprojectile_RtD1",
            "spawn_earthstorm_RtD1",
            "spawn_firestorm_RtD1",
            "spawn_icestorm2_RtD1",
            "spawn_icestorm_RtD1",
            "spawn_meteorstorm_RtD1",
            "spawn_sizzlerstorm_RtD1",
            "spawn_spikeballstorm_RtD1",
            "spawn_voidstorm_RtD1",
            "swampmutantprojectile2_RtD1",
            "swampmutantprojectile_RtD1",
            "mountainmutantprojectile_RtD2",
            "ashlandsmutantprojectile_RtD1",
            "AirBlast_RtD1",
            "ArcaneBlast_RtD1",
            "EarthBlast_RtD1",
            "EarthCurse_RtD1",
            "ElectricBlast_RtD1",
            "FireBlast_RtD1",
            "FrostBlast_RtD1",
            "HealingBlast_RtD1",
            "HolyBlast_RtD1",
            "LighteningCurse_RtD1",
            "StormCurse_RtD1",
            "VoidCurse_RtD1",
            "WaterBlast_RtD1",
            "AirSpray_RtD1",
            "ArcaneSpray_RtD1",
            "EarthSpray_Rtd1",
            "ElectricSpray_RtD1",
            "FireSpray_RtD1",
            "FireSprayAOE_RtD1",
            "FrostSpray_RtD1",
            "HealingSpray_RtD1",
            "HolySpray_RtD1",
            "VoidSpray_RtD1",
            "WaterSpray_RtD1",
            "AirRainAOE1_RtD1",
            "ArcaneRain1_RtD1",
            "EarthPillarM_RtD1",
            "EarthRainAOE2_RtD1",
            "EarthRainAOE1_RtD1",
            "ElectricRainAOE1_RtD1",
            "FirePillarMAOE1_RtD1",
            "FireRainAOE2_RtD1",
            "FireRainAOE1_RtD1",
            "FrostRainAOE2_RtD1",
            "FrostRainAOE3_RtD1",
            "FrostRainAOE1_RtD1",
            "HealingRainAOE1_RtD1",
            "HolyRainAOE1_RtD1",
            "IcePillarM1_RtD1",
            "LighteningPillarB_RtD1",
            "VoidRainAOE2_RtD1",
            "VoidRainAOE1_RtD1",
            "WaterRainAOE1_RtD1",
            "FrostBlast01_RtD",
            "AirBlast01_RtD",
            "Ragdoll_AshLandsHorror_RtD",
            "Ragdoll_AshLandsHorror01_RtD",
            "Ragdoll_BlackForestHorror_RtD",
            "Ragdoll_BlackForestHorror01_RtD",
            "Ragdoll_DeepNorthHorror_RtD",
            "Ragdoll_MeadowsHorror_RtD",
            "Ragdoll_MeadowsHorror01_RtD",
            "Ragdoll_MistlandsHorror_RtD",
            "Ragdoll_SeekerMutant_RtD",
            "Ragdoll_MountainHorror_RtD",
            "Ragdoll_MountainHorror01_RtD",
            "Ragdoll_PlainsHorror_RtD",
            "Ragdoll_PlainsHorror01_RtD",
            "Ragdoll_SwampChaser_RtD",
            "Ragdoll_SwampHorror01_RtD",
            "AshLandsMutantMelee1_RtD",
            "AshLandsMutantMelee2_RtD",
            "AshLandsMutantSpell_RtD",
            "AshLandsMutantSummon_RtD",
            "BlackForestMutantMelee1_RtD",
            "BlackForestMutantMelee2_RtD",
            "BlackForestMutantMelee3_RtD",
            "BlackForestMutantSpell_RtD",
            "DeepNorthMutantMeele1_RtD",
            "DeepNorthMutantMelee2_RtD",
            "DeepNorthMutantMelee3_RtD",
            "DeepNorthMutantSpell_RtD",
            "MeadowsMutantHeal_RtD",
            "MeadowsMutantMelee1_RtD",
            "MeadowsMutantMelee2_RtD",
            "MeadowsMutantSpell_RtD",
            "MistlandsMutantMelee1_RtD",
            "MistlandsMutantMelee2_RtD",
            "MistlandsMutantSpell_RtD",
            "MistlandsMutantSummon_RtD",
            "MountainMutantMelee1_RtD",
            "MountainMutantMelee2_RtD",
            "MountainMutantMelee3_RtD",
            "MountainMutantSpell_RtD",
            "PlainsMutantMelee1_RtD",
            "PlainsMutantMelee2_RtD",
            "PlainsMutantSpell_RtD",
            "PlainsMutantSummon_RtD",
            "SwampMutantMelee1_RtD",
            "SwampMutantMelee2_RtD",
            "SwampMutantMelee3_RtD",
            "SwampMutantSpell_RtD",
            "AshLandsMutantMelee1_RtD1",
            "BlackForestMutantMelee1_01_RtD",
            "BlackForestMutantMelee3_01_RtD",
            "MeadowsMutantSummon01_RtD",
            "LightningBlast01_RtD4",
            "MountainMutantSpell01_RtD",
            "seeker_attack1_RtD",
            "seeker_attack2_RtD",
            "seeker_attack3_RtD",
            "seeker_attack4_RtD",
            "seeker_attack5_RtD",
            "seeker_land1_RtD",
            "seeker_takeoff1_RtD",
            "PlainsMutantMelee01_RtD",
            "PlainsMutantSpell01_RtD",
            "ShadowBlast01_RtD",
            "SwampHorrorMelee1_RtD",
            "SwampHorrorMelee3_RtD",
            "SwampHorrorSpell_RtD",
            "SwampHorrorSummon1_RtD",
            "ArcaneExplosionSmall1_RtD1",
            "EarthExplosionLarge1_RtD1",
            "EarthExplosionSmall1_RtD1",
            "EggExplosion_RtD1",
            "FireExplosionSmall1_RtD1",
            "FrostExplosionLarge1_RtD1",
            "FrostExplosionSmall1_RtD1",
            "LightningExplosionSmall1_RtD1",
            "SpikyExplosionSmall1_RtD1",
            "StormExplosionSmall1_RtD1",
            "vfx_bloodsplat_death_RtD1",
            "vfx_bloodsplat_hit_RtD1",
            "VFX_IceSpray_RtD1",
            "VoidExplosionSmall1_RtD1",
            "fx_Queen_Run_RtD1",
            "fx_Queen_Walk_RtD1",
            "Spawner_AshLandsHorror_RtD",
            "Spawner_BlackForestHorror_RtD",
            "Spawner_DeepNorthHorror_RtD",
            "Spawner_MeadowsHorror_RtD",
            "Spawner_MistlandsHorror_RtD",
            "Spawner_MountainHorror_RtD",
            "Spawner_PlainsHorror_RtD",
            "Spawner_SwampHorror_RtD",
            "Spawner_AshLandsHorror01_RtD",
            "Spawner_BlackForestHorror01_RtD",
            "Spawner_MeadowsHorror01_RtD",
            "Spawner_MountainHorror01_RtD",
            "Spawner_PlainsHorror01_RtD",
            "Spawner_SeekerMutant_RtD",
            "Spawner_SwampHorror01_RtD"
        };

        public string[] SoundEffectList = new string[]
        {
            // Sound Effects
            "sfx_fae_alerted_RtD",
            "sfx_fae_death_RtD",
            "sfx_fae_attack_RtD",
            "sfx_fae_idle_RtD",
            "sfx_fae_heal_RtD",
            "sfx_fae_shield_RtD",
            "sfx_fae_spell_RtD",
            "sfx_flapping_RtD",
            "sfx_angryspirit_death_RtD",
            "sfx_friendlyspirit_death_RtD",
            "sfx_spirit_hit_RtD",
            "sfx_angryspirit_death1_RtD",
            "sfx_arcane_RtD",
            "sfx_earthcast_RtD",
            "sfx_firecast_RtD",
            "sfx_icecast_RtD",
            "sfx_lifecast_RtD",
            "sfx_lightcast_RtD",
            "sfx_lighteningcast_RtD",
            "sfx_naturecast_RtD",
            "sfx_stormcast_RtD",
            "sfx_voidcast_RtD",
            "sfx_watercast_RtD",
            "sfx_mutant1_death_RtD",
            "sfx_mutant1_hit_RtD",
            "sfx_mutant2_attack_RtD",
            "sfx_mutant2_death_RtD",
            "sfx_mutant2_hit_RtD",
            "sfx_mutant3_attack_RtD",
            "sfx_mutant3_death_RtD",
            "sfx_mutant3_hit_RtD",
            "sfx_mutant4_attack_RtD",
            "sfx_mutant4_death_RtD",
            "sfx_mutant4_hit_RtD",
            "sfx_mutant5_attack_RtD",
            "sfx_mutant5_death_RtD",
            "sfx_mutant5_hit_RtD",
            "sfx_mutant6_attack_RtD",
            "sfx_mutant6_death_RtD",
            "sfx_mutant6_hit_RtD",
            "sfx_mutant7_attack_RtD",
            "sfx_mutant7_death_RtD",
            "sfx_mutant7_hit_RtD",
            "sfx_mutant8_attack_RtD",
            "sfx_mutant8_death_RtD",
            "sfx_mutant8_hit_RtD",
            "sfx_mutantranged1_RtD",
            "sfx_mutantranged2_RtD",
            "sfx_mutantranged3_RtD",
            "sfx_mutantranged4_RtD",
            "sfx_mutantranged5_RtD",
            "sfx_mutantranged6_RtD",
            "sfx_mutantranged7_RtD",
            "sfx_mutantranged8_RtD",
            "sfx_mutant1_alerted_RtD",
            "sfx_mutant1_idle_RtD",
            "sfx_mutant2_alerted_RtD",
            "sfx_mutant2_idle_RtD",
            "sfx_mutant3_alerted_RtD",
            "sfx_mutant3_idle_RtD",
            "sfx_mutant4_alerted_RtD",
            "sfx_mutant4_idle_RtD",
            "sfx_mutant5_alerted_RtD",
            "sfx_mutant5_idle_RtD",
            "sfx_mutant6_alerted_RtD",
            "sfx_mutant6_idle_RtD",
            "sfx_mutant7_alerted_RtD",
            "sfx_mutant7_idle_RtD",
            "sfx_mutant8_alerted_RtD",
            "sfx_mutant8_idle_RtD",
            "sfx_mutant1_attack_RtD"
        };

        public string[] StaticFaeList0 = new string[]
        {
            "MeadowsPixie_RtD"
        };

        public string[] StaticFaeList1 = new string[]
         {
            "MeadowsFairy_RtD"
         };

        public string[] StaticFaeList2 = new string[]
        {
            "BlackForestFairy_RtD",
            "BlackForestPixie_RtD"
        };

        public string[] StaticFaeList3 = new string[]
        {
            "SwampFairy_RtD",
            "SwampPixie_RtD"
        };

        public string[] StaticFaeList4 = new string[]
        {
            "MountainFairy_RtD",
            "MountainPixie_RtD"
        };

        public string[] StaticFaeList5 = new string[]
        {
            "PlainsFairy_RtD",
            "PlainsPixie_RtD"
        };

        public string[] StaticFaeList6 = new string[]
        {
            "MistlandsFairy_RtD",
            "MistlandsPixie_RtD"
        };

        public string[] StaticFaeList7 = new string[]
        {
            "AshLandsFairy_RtD",
            "AshLandsPixie_RtD"
        };

        public string[] StaticFaeList8 = new string[]
        {
            "DeepNorthFairy_RtD",
            "DeepNorthPixie1_RtD",
            "DeepNorthPixie2_RtD",
            "DeepNorthPixie3_RtD"
        };
        
        public string[] BossFaeList = new string[]
        {
            "MeadowsPixie_Miniboss_RtD",
            "BlackForestPixie_Miniboss_RtD",
            "SwampPixie_Miniboss_RtD",
            "MountainPixie_Miniboss_RtD",
            "PlainsPixie_Miniboss_RtD",
            "MistlandsPixie_Miniboss_RtD",
            "AshLandsPixie_Miniboss_RtD",
            "DeepNorthPixie_Miniboss_RtD",
            
            // Spirits
            "AshLandsDarkS_RtD",
            "AshLandsFairyS_RtD",
            "BlackForestNatureS_RtD",
            "BlackForestShockG_RtD",
            "DeepNorthArcaneS_RtD",
            "DeepNorthFairyS_RtD",
            "MeadowsAirS_RtD",
            "MeadowsNatureS_RtD",
            "MistlandsFairyS_RtD",
            "MistlandsUniverseS_RtD",
            "MountainHolyS_RtD",
            "MountainIceS_RtD",
            "OceanHolyS_RtD",
            "OceanWaterS_RtD",
            "PlainsVoidS_RtD",
            "PlainsHolyS_RtD",
            "SwampDarkS_RtD",
            "SwampNatureS_RtD",

            // Universal Whisps
            "AshLandsWhispA_RtD",
            "AshLandsWhispF_RtD",
            "BlackForestWhispA_RtD",
            "BlackForestWhispF_RtD",
            "DeepNorthWhispA_RtD",
            "DeepNorthWhispF_RtD",
            "MeadowsWhispA_RtD",
            "MeadowsWhispF_RtD",
            "MistlandsWhispA_RtD",
            "MistlandsWhispF_RtD",
            "MountainWhispA_RtD",
            "MountainWhispF_RtD",
            "PlainsWhispA_RtD",
            "PlainsWhispF_RtD",
            "SwampWhispA_RtD",
            "SwampWhispF_RtD",
            
            // Mutant Seeker
            "SeekerMutant_RtD"
        };


        public static SpawnConfig[] MeadowsSpawnConfigFae = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 640,
                SpawnChance = 4,
                SpawnAtNight = true,
                SpawnAtDay = true,
                MaxSpawned = 1,
                MaxLevel = 2,
                MaxGroupSize = 2,
                Biome = Heightmap.Biome.Meadows,
                MinAltitude = 2
            }
        };

        public static SpawnConfig[] BlackForestSpawnConfigFae = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 640,
                SpawnChance = 10,
                SpawnAtNight = true,
                SpawnAtDay = true,
                MaxSpawned = 2,
                MaxLevel = 2,
                MaxGroupSize = 2,
                Biome = Heightmap.Biome.BlackForest,
                MinAltitude = 2
            }
        };

        public static SpawnConfig[] SwampSpawnConfigFae = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 640,
                SpawnChance = 10,
                SpawnAtNight = true,
                SpawnAtDay = true,
                MaxSpawned = 2,
                MaxLevel = 2,
                MaxGroupSize = 2,
                Biome = Heightmap.Biome.Swamp,
                MinAltitude = 1
            }
        };

        public static SpawnConfig[] MountainSpawnConfigFae = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 640,
                SpawnChance = 10,
                SpawnAtNight = true,
                SpawnAtDay = true,
                MaxSpawned = 2,
                MaxLevel = 2,
                MaxGroupSize = 2,
                Biome = Heightmap.Biome.Mountain,
            }
        };

        public static SpawnConfig[] PlainsSpawnConfigFae = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 640,
                SpawnChance = 10,
                SpawnAtNight = true,
                SpawnAtDay = true,
                MaxSpawned = 2,
                MaxLevel = 2,
                MaxGroupSize = 2,
                Biome = Heightmap.Biome.Plains,
                MinAltitude = 2
            }
        };

        public static SpawnConfig[] MistlandsSpawnConfigFae = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 640,
                SpawnChance = 10,
                SpawnAtNight = true,
                SpawnAtDay = true,
                MaxSpawned = 2,
                MaxLevel = 2,
                MaxGroupSize = 2,
                Biome = Heightmap.Biome.Mistlands,
                MinAltitude = 2
            }
        };

        public static SpawnConfig[] AshLandsSpawnConfigFae = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 640,
                SpawnChance = 10,
                SpawnAtNight = true,
                SpawnAtDay = true,
                MaxSpawned = 2,
                MaxLevel = 2,
                MaxGroupSize = 2,
                Biome = Heightmap.Biome.AshLands,
                MinAltitude = 2
            }
        };
        
        public static SpawnConfig[] DeepNorthSpawnConfigFae = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 640,
                SpawnChance = 10,
                SpawnAtNight = true,
                SpawnAtDay = true,
                MaxSpawned = 2,
                MaxLevel = 2,
                MaxGroupSize = 2,
                Biome = Heightmap.Biome.DeepNorth,
                MinAltitude = 2
            }
        };

        private void Awake()
        {
            CreateConfigs();
            LoadBundle();
            Addlocalizations();
            JSONSupport();
            AddSEStatusEffect();
            AddSoundEffects();
            AddShieldEffect();
            Locations();
            Runestones();
            AddItems();
            CreateRecipes();
            AddPieces();
            Bosses();
            AddMeadowsPixie();
            MeadowsSpawnerFae();
            BlackForestSpawnerFae();
            SwampSpawnerFae();
            MountainSpawnerFae();
            PlainsSpawnerFae();
            MistlandsSpawnerFae();
            AshLandsSpawnerFae();
            DeepNorthSpawnerFae();
            MeadowsSpawner();
            BlackForestSpawner();
            SwampSpawner();
            MountainSpawner();
            PlainsSpawner();
            MistlandsSpawner();
            AshlandsSpawner();
            DeepNorthSpawner();
            
            // On prefabs awake
            
            PrefabManager.OnVanillaPrefabsAvailable += AddPrefabsFae;
            
            // Modify Items
            
            PrefabManager.OnVanillaPrefabsAvailable += ModifyItems;
            
            // Volume Mixer
            
            PrefabManager.OnPrefabsRegistered += FixSFX;

            if (LoggingEnable.Value) { Logger.LogWarning("Logging is enabled in the config."); }
        }

        private void LoadBundle()
        {
            try
            {
                MyAssets = AssetUtils.LoadAssetBundleFromResources("mythics", Assembly.GetExecutingAssembly());

            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while loading bundle: {ex}");
            }
        }

        private void CreateConfigs()
        {
            try
            {
                Config.SaveOnConfigSet = true;

                LoggingEnable = Config.Bind("Logging", "Enable", false, new ConfigDescription("Enable or Disable Logging.", null, new ConfigurationManagerAttributes
                {
                    IsAdminOnly = true,
                    Order = 15
                }));

                // Item recipes - one Enabled toggle + per-requirement item/cost
                // overrides for every craftable item, see MythicsItemConfigs.cs
                CreateItemRecipeConfigs();
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding configuration values: {arg}");
            }
        }
        
        private void Bosses()
        {
            try
            {
                foreach (string prefabNameU1 in BossFaeList)
                {
                    GameObject prefabU1 = MyAssets.LoadAsset<GameObject>(prefabNameU1);
                    if (prefabU1 != null)
                    {
                        CustomCreature customPrefabU1 = new CustomCreature(prefabU1, true);
                        CreatureManager.Instance.AddCreature(customPrefabU1);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefabNameU1 + " to the Object database"); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabNameU1 + " to the object database");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }
        
        private void FixSFX()
        {
            try
            {
                AudioSource mixerGroupSFX = PrefabManager.Cache.GetPrefab<AudioSource>("sfx_arrow_hit");

                foreach (string prefabName in SoundEffectList)
                {
                    GameObject prefab = PrefabManager.Cache.GetPrefab<GameObject>(prefabName);
                    prefab.GetComponentInChildren<AudioSource>().outputAudioMixerGroup = mixerGroupSFX.outputAudioMixerGroup;

                    if (LoggingEnable.Value) { Logger.LogMessage("Audio Mixer set on: " + prefabName); }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while fixing custom audio: {arg}");
            }
            finally
            {
                PrefabManager.OnPrefabsRegistered -= FixSFX;
            }
        }
        
        private void Runestones()
        {
            try
            {
                
                GameObject Locations1 = MyAssets.LoadAsset<GameObject>("RuneStone_Fae_Meadows_RtD");
                CustomLocation Objects1 = new(Locations1, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Meadows),
                    BiomeArea = Heightmap.BiomeArea.Edge,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects1);
                
                GameObject Locations2 = MyAssets.LoadAsset<GameObject>("RuneStone_Fae_BlackForest_RtD");
                CustomLocation Objects2 = new(Locations2, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.BlackForest),
                    BiomeArea = Heightmap.BiomeArea.Median,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects2);
                
                GameObject Locations3 = MyAssets.LoadAsset<GameObject>("RuneStone_Fae_Swamp_RtD");
                CustomLocation Objects3 = new(Locations3, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Swamp),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = -1f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 10,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects3);
                
                GameObject Locations4 = MyAssets.LoadAsset<GameObject>("RuneStone_Fae_Mountain_RtD");
                CustomLocation Objects4 = new(Locations4, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Mountain),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 10,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects4);
                
                GameObject Locations5 = MyAssets.LoadAsset<GameObject>("RuneStone_Fae_Plains_RtD");
                CustomLocation Objects5 = new(Locations5, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Plains),
                    BiomeArea = Heightmap.BiomeArea.Median,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects5);
                
                GameObject Locations6 = MyAssets.LoadAsset<GameObject>("RuneStone_Fae_Mistlands_RtD");
                CustomLocation Objects6 = new(Locations6, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Mistlands),
                    BiomeArea = Heightmap.BiomeArea.Median,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects6);

                GameObject Locations7 = MyAssets.LoadAsset<GameObject>("RuneStone_Fae_AshLands_RtD");
                CustomLocation Objects7 = new(Locations7, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.AshLands),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = 0f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects7);

                GameObject Locations8 = MyAssets.LoadAsset<GameObject>("RuneStone_Fae_DeepNorth_RtD");
                CustomLocation Objects8 = new(Locations8, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.DeepNorth),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects8);
                
                GameObject Locations9 = MyAssets.LoadAsset<GameObject>("RuneStone_Meadows_RtD");
                CustomLocation Objects9 = new(Locations9, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Meadows),
                    BiomeArea = Heightmap.BiomeArea.Median,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects9);

                GameObject Locations10 = MyAssets.LoadAsset<GameObject>("RuneStone_BlackForest_RtD");
                CustomLocation Objects10 = new(Locations10, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.BlackForest),
                    BiomeArea = Heightmap.BiomeArea.Median,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects10);

                GameObject Locations11 = MyAssets.LoadAsset<GameObject>("RuneStone_Swamp_RtD");
                CustomLocation Objects11 = new(Locations11, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Swamp),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = -1f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 10,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects11);

                GameObject Locations12 = MyAssets.LoadAsset<GameObject>("RuneStone_Mountain_RtD");
                CustomLocation Objects12 = new(Locations12, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Mountain),
                    BiomeArea = Heightmap.BiomeArea.Median,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects12);

                GameObject Locations13 = MyAssets.LoadAsset<GameObject>("RuneStone_Plains_RtD");
                CustomLocation Objects13 = new(Locations13, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Plains),
                    BiomeArea = Heightmap.BiomeArea.Median,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects13);

                GameObject Locations14 = MyAssets.LoadAsset<GameObject>("RuneStone_Mistlands_RtD");
                CustomLocation Objects14 = new(Locations14, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Mistlands),
                    BiomeArea = Heightmap.BiomeArea.Median,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects14);

                GameObject Locations15 = MyAssets.LoadAsset<GameObject>("RuneStone_AshLands_RtD");
                CustomLocation Objects15 = new(Locations15, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.AshLands),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = 1f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 3,
                    MinDistanceFromSimilar = 170,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects15);
                
                GameObject Locations16 = MyAssets.LoadAsset<GameObject>("RuneStone_DeepNorth_RtD");
                CustomLocation Objects16 = new(Locations16, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.DeepNorth),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 2,
                    Quantity = 46,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(Objects16);

            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding custom location: {ex}");
            }
        }

        private void AddMeadowsPixie()
        {
            try
            {
                foreach (string prefabNameM1 in StaticFaeList0)
                {
                    GameObject prefabM1 = MyAssets.LoadAsset<GameObject>(prefabNameM1);
                    if (prefabM1 != null)
                    {
                        CustomCreature customPrefabM1 = new CustomCreature(prefabM1, true);
                        CreatureManager.Instance.AddCreature(customPrefabM1);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefabNameM1 + " to the Object database"); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabNameM1 + " to the object database");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }

        private void AddShieldEffect()
        {
            try
            {
                foreach (string prefabNameSE1 in CustomSEShieldList)
                {
                    // You would change SE_Stats here, to what ever SE base you used, like SE_Infection_HS or SE_Smoke etc.
                    SE_Shield statusEffect1 = MyAssets.LoadAsset<SE_Shield>(prefabNameSE1);
                    if (statusEffect1 != null)
                    {
                        CustomStatusEffect customEffect1 = new(statusEffect1, true);
                        ItemManager.Instance.AddStatusEffect(customEffect1);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + statusEffect1 + " to the Object database"); }
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding SE_Stats Effects: {arg}");
            }
        }

        private void AddSEStatusEffect()
        {
            try
            {
                foreach (string prefabNameSE in CustomSEList)
                {
                    // You would change SE_Stats here, to what ever SE base you used, like SE_Infection_HS or SE_Smoke etc.
                    SE_Stats statusEffect = MyAssets.LoadAsset<SE_Stats>(prefabNameSE);
                    if (statusEffect != null)
                    {
                        CustomStatusEffect customEffect = new(statusEffect, true);
                        ItemManager.Instance.AddStatusEffect(customEffect);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + statusEffect + " to the Object database"); }
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding SE_Stats Effects: {arg}");
            }
        }

        private void AddItems()
        {
            try
            {
                foreach (string prefab1 in ItemsList)
                {
                    GameObject prefabbed1 = MyAssets.LoadAsset<GameObject>(prefab1);
                    if (prefabbed1 != null)
                    {
                        CustomItem customPrefabS1 = new CustomItem(prefabbed1, true);
                        ItemManager.Instance.AddItem(customPrefabS1);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefab1 + " to the Object database"); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefab1 + " to the object database");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }

        private void AddPrefabsFae()
        {
            try
            {
                foreach (string prefabName1 in PrefabsList)
                {
                    GameObject prefab1 = MyAssets.LoadAsset<GameObject>(prefabName1);
                    if (prefab1 != null)
                    {
                        CustomPrefab customPrefab1 = new CustomPrefab(prefab1, true);
                        PrefabManager.Instance.AddPrefab(customPrefab1);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefabName1 + " to the Object database"); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName1 + " to the object database");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
            PrefabManager.OnVanillaPrefabsAvailable -= AddPrefabsFae;
        }

        public static CreatureConfig MeadowsFaeConfig = new CreatureConfig
        {
            Faction = Character.Faction.ForestMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = MeadowsSpawnConfigFae
        };
        
        private void MeadowsSpawnerFae()
        {
            try
            {
                foreach (string prefabName in StaticFaeList1)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, MeadowsFaeConfig));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added monster: " + prefabName); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monsters: {arg}");
            }
        }

        public static CreatureConfig BlackForestFaeConfig = new CreatureConfig
        {
            Faction = Character.Faction.ForestMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = BlackForestSpawnConfigFae
        };

        private void BlackForestSpawnerFae()
        {
            try
            {
                foreach (string prefabName in StaticFaeList2)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, BlackForestFaeConfig));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added monster: " + prefabName); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monsters: {arg}");
            }
        }

        public static CreatureConfig SwampFaeConfig = new CreatureConfig
        {
            Faction = Character.Faction.Undead,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = SwampSpawnConfigFae
        };

        private void SwampSpawnerFae()
        {
            try
            {
                foreach (string prefabName in StaticFaeList3)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, SwampFaeConfig));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added monster: " + prefabName); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monsters: {arg}");
            }
        }

        public static CreatureConfig MountainFaeConfig = new CreatureConfig
        {
            Faction = Character.Faction.MountainMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = MountainSpawnConfigFae
        };

        private void MountainSpawnerFae()
        {
            try
            {
                foreach (string prefabName in StaticFaeList4)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, MountainFaeConfig));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added monster: " + prefabName); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monsters: {arg}");
            }
        }

        public static CreatureConfig PlainsFaeConfig = new CreatureConfig
        {
            Faction = Character.Faction.PlainsMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = PlainsSpawnConfigFae
        };

        private void PlainsSpawnerFae()
        {
            try
            {
                foreach (string prefabName in StaticFaeList5)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, PlainsFaeConfig));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added monster: " + prefabName); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monsters: {arg}");
            }
        }

        public static CreatureConfig MistlandsFaeConfig = new CreatureConfig
        {
            Faction = Character.Faction.MistlandsMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = MistlandsSpawnConfigFae
        };

        private void MistlandsSpawnerFae()
        {
            try
            {
                foreach (string prefabName in StaticFaeList6)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, MistlandsFaeConfig));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added monster: " + prefabName); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monsters: {arg}");
            }
        }

        public static CreatureConfig AshLandsFaeConfig = new CreatureConfig
        {
            Faction = Character.Faction.Demon,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = AshLandsSpawnConfigFae
        };

        private void AshLandsSpawnerFae()
        {
            try
            {
                foreach (string prefabName in StaticFaeList7)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, AshLandsFaeConfig));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added monster: " + prefabName); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monsters: {arg}");
            }
        }

        public static CreatureConfig DeepNorthFaeConfig = new CreatureConfig
        {
            Faction = Character.Faction.MountainMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = DeepNorthSpawnConfigFae
        };

        private void DeepNorthSpawnerFae()
        {
            try
            {
                foreach (string prefabName in StaticFaeList8)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, DeepNorthFaeConfig));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added monster: " + prefabName); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monsters: {arg}");
            }
        }

        private void AddSoundEffects()
        {
            try
            {
                foreach (string prefabNameI1 in SoundEffectList)
                {
                    GameObject prefabI1 = MyAssets.LoadAsset<GameObject>(prefabNameI1);
                    if (prefabI1 != null)
                    {
                        CustomPrefab customPrefab4 = new CustomPrefab(prefabI1, true);
                        PrefabManager.Instance.AddPrefab(customPrefab4);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefabNameI1 + " to the Object database"); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabNameI1 + " to the object database");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }

        private void AddPieces()
        {
            try
            {
                PieceConfig val1 = new PieceConfig();
                val1.PieceTable = PieceTables.Hammer;
                val1.AddRequirement(new RequirementConfig("MeadowsCrystal_RtD", 10, 0, true));
                val1.AddRequirement(new RequirementConfig("Stone", 25, 0, true));
                val1.Category = "Misc";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "MeadowsFairyTotem_RtD", true, val1));

                PieceConfig val2 = new PieceConfig();
                val2.PieceTable = PieceTables.Hammer;
                val2.AddRequirement(new RequirementConfig("BlackForestCrystal_RtD", 10, 0, true));
                val2.AddRequirement(new RequirementConfig("Stone", 25, 0, true));
                val2.Category = "Misc";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "BlackForestFairyTotem_RtD", true, val2));

                PieceConfig val3 = new PieceConfig();
                val3.PieceTable = PieceTables.Hammer;
                val3.AddRequirement(new RequirementConfig("SwampCrystal_RtD", 10, 0, true));
                val3.AddRequirement(new RequirementConfig("Stone", 25, 0, true));
                val3.Category = "Misc";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "SwampFairyTotem_RtD", true, val3));

                PieceConfig val4 = new PieceConfig();
                val4.PieceTable = PieceTables.Hammer;
                val4.AddRequirement(new RequirementConfig("MountainCrystal_RtD", 10, 0, true));
                val4.AddRequirement(new RequirementConfig("Stone", 25, 0, true));
                val4.Category = "Misc";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "MountainFairyTotem_RtD", true, val4));

                PieceConfig val5 = new PieceConfig();
                val5.PieceTable = PieceTables.Hammer;
                val5.AddRequirement(new RequirementConfig("PlainsCrystal_RtD", 10, 0, true));
                val5.AddRequirement(new RequirementConfig("Stone", 25, 0, true));
                val5.Category = "Misc";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "PlainsFairyTotem_RtD", true, val5));

                PieceConfig val6 = new PieceConfig();
                val6.PieceTable = PieceTables.Hammer;
                val6.AddRequirement(new RequirementConfig("MistlandsCrystal_RtD", 10, 0, true));
                val6.AddRequirement(new RequirementConfig("Stone", 25, 0, true));
                val6.Category = "Misc";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "MistlandsFairyTotem_RtD", true, val6));

                PieceConfig val7 = new PieceConfig();
                val7.PieceTable = PieceTables.Hammer;
                val7.AddRequirement(new RequirementConfig("AshLandsCrystal_RtD", 10, 0, true));
                val7.AddRequirement(new RequirementConfig("Stone", 25, 0, true));
                val7.Category = "Misc";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "AshLandsFairyTotem_RtD", true, val7));

                PieceConfig val8 = new PieceConfig();
                val8.PieceTable = PieceTables.Hammer;
                val8.AddRequirement(new RequirementConfig("DeepNorthCrystal_RtD", 10, 0, true));
                val8.AddRequirement(new RequirementConfig("Stone", 25, 0, true));
                val8.Category = "Misc";
                PieceManager.Instance.AddPiece(new CustomPiece(MyAssets, "DeepNorthFairyTotem_RtD", true, val8));
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }

        private void Locations()
        {
            try
            {
                // Location1
                GameObject FaeLocation1 = MyAssets.LoadAsset<GameObject>("PixieCamp_Meadows_RtD");
                CustomLocation FaeObject1 = new(FaeLocation1, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Meadows),
                    BiomeArea = Heightmap.BiomeArea.Edge,
                    ForestTresholdMin = 0,
                    MinAltitude = 1f,
                    MaxAltitude = 500f,
                    Quantity = 25,
                    ExteriorRadius = 10f,
                    MaxTerrainDelta = 3,
                    MinDistanceFromSimilar = 200,
                    ClearArea = true,
                    RandomRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(FaeObject1);

                // Location2
                GameObject FaeLocation2 = MyAssets.LoadAsset<GameObject>("PixieCamp_BlackForest_RtD");
                CustomLocation FaeObject2 = new(FaeLocation2, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.BlackForest),
                    BiomeArea = Heightmap.BiomeArea.Median,
                    MinAltitude = 1f,
                    MaxAltitude = 500f,
                    Quantity = 36,
                    ExteriorRadius = 10f,
                    MaxTerrainDelta = 3,
                    MinDistanceFromSimilar = 200,
                    ClearArea = true,
                    RandomRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(FaeObject2);

                // Location3
                GameObject FaeLocation3 = MyAssets.LoadAsset<GameObject>("PixieCamp_Swamp_RtD");
                CustomLocation FaeObject3 = new(FaeLocation3, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Swamp),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = -1f,
                    MaxAltitude = 500f,
                    Quantity = 36,
                    ExteriorRadius = 10f,
                    MinDistanceFromSimilar = 170,
                    ClearArea = true,
                    RandomRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(FaeObject3);

                // Location4
                GameObject FaeLocation4 = MyAssets.LoadAsset<GameObject>("PixieCamp_Mountain_RtD");
                CustomLocation FaeObject4 = new(FaeLocation4, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Mountain),
                    BiomeArea = Heightmap.BiomeArea.Median,
                    MinAltitude = 1f,
                    MaxAltitude = 500f,
                    Quantity = 36,
                    ExteriorRadius = 10f,
                    MaxTerrainDelta = 3,
                    MinDistanceFromSimilar = 200,
                    ClearArea = true,
                    RandomRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(FaeObject4);

                // Location5
                GameObject FaeLocation5 = MyAssets.LoadAsset<GameObject>("PixieCamp_Plains_RtD");
                CustomLocation FaeObject5 = new(FaeLocation5, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Plains),
                    BiomeArea = Heightmap.BiomeArea.Median,
                    MinAltitude = 1f,
                    MaxAltitude = 500f,
                    Quantity = 36,
                    ExteriorRadius = 10f,
                    MaxTerrainDelta = 3,
                    MinDistanceFromSimilar = 200,
                    ClearArea = true,
                    RandomRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(FaeObject5);

                // Location6
                GameObject FaeLocation6 = MyAssets.LoadAsset<GameObject>("PixieCamp_Mistlands_RtD");
                CustomLocation FaeObject6 = new(FaeLocation6, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Mistlands),
                    BiomeArea = Heightmap.BiomeArea.Median,
                    MinAltitude = 1f,
                    MaxAltitude = 500f,
                    Quantity = 36,
                    ExteriorRadius = 10f,
                    MaxTerrainDelta = 3,
                    MinDistanceFromSimilar = 200,
                    ClearArea = true,
                    RandomRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(FaeObject6);

                // Location7
                GameObject FaeLocation7 = MyAssets.LoadAsset<GameObject>("PixieCamp_AshLands_RtD");
                CustomLocation FaeObject7 = new(FaeLocation7, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.AshLands),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = 1f,
                    MaxAltitude = 700,
                    Quantity = 36,
                    ExteriorRadius = 10f,
                    MaxTerrainDelta = 3,
                    MinDistanceFromSimilar = 160,
                    ClearArea = true,
                    RandomRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(FaeObject7);

                // Location8
                GameObject FaeLocation8 = MyAssets.LoadAsset<GameObject>("PixieCamp_DeepNorth_RtD");
                CustomLocation FaeObject8 = new(FaeLocation8, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.DeepNorth),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = 1f,
                    MaxAltitude = 500f,
                    Quantity = 36,
                    ExteriorRadius = 10f,
                    MaxTerrainDelta = 3,
                    MinDistanceFromSimilar = 200,
                    ClearArea = true,
                    RandomRotation = true,
                    Priotized = true
                });
                ZoneManager.Instance.AddCustomLocation(FaeObject8);
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding custom location: {ex}");
            }
        }
    }
}