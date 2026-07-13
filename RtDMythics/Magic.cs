using System;
using BepInEx;
using Jotunn.Managers;
using Jotunn.Entities;
using Jotunn.Configs;

namespace RtDMythics                        
{
    internal partial class RtDMythics : BaseUnityPlugin   
    {
        
        public void ModifyItems()
        {
            try
            {
                // Weave SE
                var statusEffect8 = PrefabManager.Cache.GetPrefab<StatusEffect>("SE_MageArmorMistlands_RtD");
                // Prefabs
                var item22 = PrefabManager.Cache.GetPrefab<ItemDrop>("HelmetMage");
                var item23 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorMageChest");
                var item24 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorMageLegs");
                // BlackMetal Helm
                item22.m_itemData.m_shared.m_setName = "WeaveSE";
                item22.m_itemData.m_shared.m_setSize = 3;
                item22.m_itemData.m_shared.m_setStatusEffect = statusEffect8;
                // BlackMetal Chest
                item23.m_itemData.m_shared.m_setName = "WeaveSE";
                item23.m_itemData.m_shared.m_setSize = 3;
                item23.m_itemData.m_shared.m_setStatusEffect = statusEffect8;
                // BlackMetal Legs
                item24.m_itemData.m_shared.m_setName = "WeaveSE";
                item24.m_itemData.m_shared.m_setSize = 3;
                item24.m_itemData.m_shared.m_setStatusEffect = statusEffect8;
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while modifing items: {ex}");
            }
            finally
            {
                PrefabManager.OnVanillaPrefabsAvailable -= ModifyItems;
            }
        }
        
    }
}