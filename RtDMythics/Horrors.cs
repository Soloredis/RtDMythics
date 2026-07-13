using System;
using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using UnityEngine;

namespace RtDMythics
{
    internal partial class RtDMythics : BaseUnityPlugin  
    {
        
        public string[] StaticList1 = new string[]
        {
            "MeadowsHorror_RtD"
        };

        public string[] StaticList2 = new string[]
        {
            "BlackForestHorror_RtD"
        };

        public string[] StaticList3 = new string[]
        {
            "SwampChaser_RtD"
        };

        public string[] StaticList4 = new string[]
        {
            "MountainHorror_RtD"
        };

        public string[] StaticList5 = new string[]
        {
            "PlainsHorror_RtD"
        };

        public string[] StaticList6 = new string[]
        {
            "MistlandsHorror_RtD"
        };

        public string[] StaticList7 = new string[]
        {
            "AshLandsHorror_RtD"
        };

        public string[] StaticList8 = new string[]
        {
            "DeepNorthHorror_RtD"
        };

        public static SpawnConfig[] MeadowsSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 240,
                SpawnChance = 30,
                SpawnAtNight = true,
                SpawnAtDay = false,
                MaxSpawned = 3,
                MinGroupSize = 2,
                MaxGroupSize = 3,
                MaxLevel = 2,
                MinAltitude = 3,
                MaxAltitude = 250,
                Biome = Heightmap.Biome.Meadows
            }
        };

        public static SpawnConfig[] BlackForestSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 240,
                SpawnChance = 30,
                SpawnAtNight = true,
                SpawnAtDay = false,
                MaxSpawned = 3,
                MinGroupSize = 2,
                MaxGroupSize = 3,
                MaxLevel = 2,
                MinAltitude = 3,
                MaxAltitude = 250,
                Biome = Heightmap.Biome.BlackForest
            }
        };

        public static SpawnConfig[] SwampSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 240,
                SpawnChance = 30,
                SpawnAtNight = true,
                SpawnAtDay = false,
                MaxSpawned = 3,
                MinGroupSize = 2,
                MaxGroupSize = 3,
                MaxLevel = 2,
                MinAltitude = 3,
                MaxAltitude = 250,
                Biome = Heightmap.Biome.Swamp
            }
        };

        public static SpawnConfig[] MountainSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 240,
                SpawnChance = 30,
                MinGroupSize = 2,
                MaxGroupSize = 3,
                SpawnAtNight = true,
                SpawnAtDay = false,
                MaxSpawned = 3,
                MaxLevel = 2,
                MinAltitude = 3,
                MaxAltitude = 500,
                Biome = Heightmap.Biome.Mountain
            }
        };

        public static SpawnConfig[] PlainsSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 240,
                SpawnChance = 30,
                MinGroupSize = 2,
                MaxGroupSize = 3,
                SpawnAtNight = true,
                SpawnAtDay = false,
                MaxSpawned = 3,
                MaxLevel = 2,
                MinAltitude = 3,
                MaxAltitude = 250,
                Biome = Heightmap.Biome.Plains
            }
        };

        public static SpawnConfig[] MistlandsSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 240,
                SpawnChance = 30,
                MinGroupSize = 2,
                MaxGroupSize = 3,
                SpawnAtNight = true,
                SpawnAtDay = false,
                MaxSpawned = 3,
                MaxLevel = 2,
                MinAltitude = 3,
                MaxAltitude = 500,
                Biome = Heightmap.Biome.Mistlands
            }
        };

        public static SpawnConfig[] AshLandsSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 360,
                SpawnChance = 10,
                MinGroupSize = 2,
                MaxGroupSize = 3,
                SpawnAtNight = true,
                SpawnAtDay = false,
                MaxSpawned = 3,
                MaxLevel = 2,
                MinAltitude = 3,
                MaxAltitude = 275,
                Biome = Heightmap.Biome.AshLands
            }
        };

        public static SpawnConfig[] DeepNorthSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 360,
                SpawnChance = 5,
                MinGroupSize = 2,
                MaxGroupSize = 3,
                SpawnAtNight = true,
                SpawnAtDay = false,
                MaxSpawned = 3,
                MaxLevel = 2,
                MinAltitude = 3,
                MaxAltitude = 450,
                Biome = Heightmap.Biome.DeepNorth
            }
        };

        public static CreatureConfig MeadowsCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.ForestMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = MeadowsSpawnConfig
        };

        public void MeadowsSpawner()
        {
            try
            {
                foreach (string prefabName in StaticList1)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, MeadowsCreatureConfig));
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

        public static CreatureConfig BlackForestCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.ForestMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = BlackForestSpawnConfig
        };

        public void BlackForestSpawner()
        {
            try
            {
                foreach (string prefabName in StaticList2)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, BlackForestCreatureConfig));
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

        public static CreatureConfig SwampCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.Undead,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = SwampSpawnConfig
        };

        public void SwampSpawner()
        {
            try
            {
                foreach (string prefabName in StaticList3)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, SwampCreatureConfig));
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

        public static CreatureConfig MountainCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.MountainMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = MountainSpawnConfig
        };

        public void MountainSpawner()
        {
            try
            {
                foreach (string prefabName in StaticList4)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, MountainCreatureConfig));
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

        public static CreatureConfig PlainsCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.PlainsMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = PlainsSpawnConfig
        };

        public void PlainsSpawner()
        {
            try
            {
                foreach (string prefabName in StaticList5)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, PlainsCreatureConfig));
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

        public static CreatureConfig MistlandsCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.MistlandsMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = MistlandsSpawnConfig
        };

        public void MistlandsSpawner()
        {
            try
            {
                foreach (string prefabName in StaticList6)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, MistlandsCreatureConfig));
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

        public static CreatureConfig AshLandsCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.Demon,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = AshLandsSpawnConfig
        };

        public void AshlandsSpawner()
        {
            try
            {
                foreach (string prefabName in StaticList7)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, AshLandsCreatureConfig));
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

        public static CreatureConfig DeepNorthCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.MountainMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = DeepNorthSpawnConfig
        };

        public void DeepNorthSpawner()
        {
            try
            {
                foreach (string prefabName in StaticList8)
                {
                    GameObject prefab = MyAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, DeepNorthCreatureConfig));
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
    }
}