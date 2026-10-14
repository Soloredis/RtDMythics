using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using Jotunn.Entities;
using Jotunn.Managers;
using UnityEngine;

namespace RtDMythics
{
    internal partial class RtDMythics : BaseUnityPlugin
    {
        private readonly List<Action> monsterConfigAppliers = new List<Action>();

        public void CreateMonsterConfigs()
        {
            try
            {
                int order = 5000;
                int count = 0;

                count += BindMonsterGroup("Monsters - Meadows", Join(StaticFaeList0, StaticFaeList1, StaticList1), ref order);
                count += BindMonsterGroup("Monsters - Black Forest", Join(StaticFaeList2, StaticList2), ref order);
                count += BindMonsterGroup("Monsters - Swamp", Join(StaticFaeList3, StaticList3), ref order);
                count += BindMonsterGroup("Monsters - Mountain", Join(StaticFaeList4, StaticList4), ref order);
                count += BindMonsterGroup("Monsters - Plains", Join(StaticFaeList5, StaticList5), ref order);
                count += BindMonsterGroup("Monsters - Mistlands", Join(StaticFaeList6, StaticList6), ref order);
                count += BindMonsterGroup("Monsters - AshLands", Join(StaticFaeList7, StaticList7), ref order);
                count += BindMonsterGroup("Monsters - Deep North", Join(StaticFaeList8, StaticList8), ref order);
                count += BindMonsterGroup("Monsters - Mini Bosses", Array.FindAll(BossFaeList, n => n.Contains("_Miniboss_")), ref order);
                count += BindMonsterGroup("Monsters - Spirits And Other", Array.FindAll(BossFaeList, n => !n.Contains("_Miniboss_")), ref order);

                SynchronizationManager.OnConfigurationSynchronized += (s, e) => ApplyMonsterConfigs();

                if (LoggingEnable.Value) { Logger.LogMessage("Monster configs added for " + count + " creatures."); }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monster configuration values: {arg}");
            }
        }

        private static string[] Join(params string[][] lists)
        {
            List<string> all = new List<string>();
            foreach (string[] list in lists)
            {
                if (list != null) all.AddRange(list);
            }
            return all.ToArray();
        }

        private int BindMonsterGroup(string section, string[] prefabNames, ref int order)
        {
            int count = 0;
            foreach (string prefabName in prefabNames)
            {
                CustomCreature creature = CreatureManager.Instance.GetCreature(prefabName);
                if (creature == null || creature.Prefab == null)
                {
                    if (LoggingEnable.Value) { Logger.LogMessage("No monster configs for " + prefabName + " (creature not registered)."); }
                    continue;
                }

                Character character = creature.Prefab.GetComponent<Character>();
                ConfigEntry<float> health = null;
                if (character != null)
                {
                    health = Config.Bind(section, prefabName + " - Health", character.m_health,
                        new ConfigDescription("Base health of " + prefabName + " at 1 star. Higher star levels multiply this.", null,
                        new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));
                }

                ConfigEntry<bool> enabled = null;
                ConfigEntry<float> chance = null;
                ConfigEntry<float> interval = null;
                ConfigEntry<int> maxSpawned = null;
                ConfigEntry<int> maxLevel = null;

                if (creature.Spawns.Count > 0)
                {
                    SpawnSystem.SpawnData spawn = creature.Spawns[0];

                    enabled = Config.Bind(section, prefabName + " - Spawn Enabled", spawn.m_enabled,
                        new ConfigDescription("Let " + prefabName + " spawn in the world. Dungeons, altars and spawner objects are not affected.", null,
                        new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                    chance = Config.Bind(section, prefabName + " - Spawn Chance", spawn.m_spawnChance,
                        new ConfigDescription("Chance (%) for " + prefabName + " to spawn each time the spawner checks.",
                        new AcceptableValueRange<float>(0f, 100f),
                        new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                    interval = Config.Bind(section, prefabName + " - Spawn Interval", spawn.m_spawnInterval,
                        new ConfigDescription("Seconds between spawn checks for " + prefabName + ".",
                        new AcceptableValueRange<float>(1f, 7200f),
                        new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                    maxSpawned = Config.Bind(section, prefabName + " - Max Spawned", spawn.m_maxSpawned,
                        new ConfigDescription("Most " + prefabName + " allowed around a player at once.",
                        new AcceptableValueRange<int>(1, 20),
                        new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                    maxLevel = Config.Bind(section, prefabName + " - Max Level", spawn.m_maxLevel,
                        new ConfigDescription("Highest level " + prefabName + " can spawn at (1 = no stars, 2 = one star, 3 = two stars).",
                        new AcceptableValueRange<int>(1, 10),
                        new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));
                }

                Action apply = () =>
                {
                    if (character != null && health != null)
                    {
                        character.m_health = health.Value;
                    }

                    if (enabled == null) return;

                    foreach (SpawnSystem.SpawnData data in creature.Spawns)
                    {
                        if (data == null) continue;
                        data.m_enabled = enabled.Value;
                        data.m_spawnChance = chance.Value;
                        data.m_spawnInterval = interval.Value;
                        data.m_maxSpawned = Mathf.Max(1, maxSpawned.Value);
                        data.m_maxLevel = Mathf.Max(data.m_minLevel, maxLevel.Value);
                    }
                };

                apply();
                EventHandler onChange = (s, e) => apply();
                if (health != null) health.SettingChanged += onChange;
                if (enabled != null)
                {
                    enabled.SettingChanged += onChange;
                    chance.SettingChanged += onChange;
                    interval.SettingChanged += onChange;
                    maxSpawned.SettingChanged += onChange;
                    maxLevel.SettingChanged += onChange;
                }

                monsterConfigAppliers.Add(apply);
                count++;
            }
            return count;
        }

        private void ApplyMonsterConfigs()
        {
            foreach (Action apply in monsterConfigAppliers)
            {
                try
                {
                    apply();
                }
                catch (Exception arg)
                {
                    Logger.LogWarning($"Exception caught while applying monster configs: {arg}");
                }
            }
        }
    }
}