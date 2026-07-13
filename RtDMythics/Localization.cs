using System.Collections.Generic;
using BepInEx;
using Jotunn.Entities;
using Jotunn.Managers;
using UnityEngine;

namespace RtDMythics                        
{
    internal partial class RtDMythics : BaseUnityPlugin   
    {
        private CustomLocalization Localization;
        
        public void JSONSupport()
        {
            TextAsset[] textAssets = MyAssets.LoadAllAssets<TextAsset>();
            foreach (var textAsset in textAssets)
            {
                var lang = textAsset.name.Replace("_RtDMythics.json", null);
                Localization.AddJsonFile(lang, textAsset.ToString());
            }
        }
        
        public void Addlocalizations()
        {
            Localization = LocalizationManager.Instance.GetLocalization();
            Localization.AddTranslation("English", new Dictionary<string, string>
            {
                // Existing Stuff
                { "$AshLandsFairy_RtD", "Fire Fairy" },
                { "$AshLandsPixie_RtD", "Fire Pixie" },
                { "$BlackForestFairy_RtD", "Lightning Fairy" },
                { "$BlackForestPixie_RtD", "Lightning Pixie" },
                { "$DeepNorthFairy_RtD", "Arcane Fairy" },
                { "$DeepNorthPixie_RtD", "Arcane Pixie" },
                { "$MeadowsFairy_RtD", "Air Fairy" },
                { "$MeadowsPixie_RtD", "Air Pixie" },
                { "$MistlandsFairy_RtD", "Light Fairy" },
                { "$MistlandsPixie_RtD", "Light Pixie" },
                { "$MountainFairy_RtD", "Frost Fairy" },
                { "$MountainPixie_RtD", "Frost Pixie" },
                { "$PlainsFairy_RtD", "Void Fairy" },
                { "$PlainsPixie_RtD", "Void Pixie" },
                { "$SwampFairy_RtD", "Earth Fairy" },
                { "$SwampPixie_RtD", "Earth Pixie" },
                { "$AshLandsCrystal_RtD", "Fire Crystal" },
                { "$AshLandsCrystal_desc_RtD", "Hardened from the screaming heat of the Ashlands. Something is still trapped inside it." },
                { "$BlackForestCrystal_RtD", "Lightning Crystal" },
                { "$BlackForestCrystal_desc_RtD", "It crackles against your palm like a warning. The forest did not give this up willingly." },
                { "$DeepNorthCrystal_RtD", "Arcane Crystal" },
                { "$DeepNorthCrystal_desc_RtD", "Older than the ice around it. The magic within has had a very long time to grow bitter." },
                { "$MeadowsCrystal_RtD", "Air Crystal" },
                { "$MeadowsCrystal_desc_RtD", "Light enough to feel like nothing. Do not mistake that for harmlessness." },
                { "$MistlandsCrystal_RtD", "Light Crystal" },
                { "$MistlandsCrystal_desc_RtD", "It glows faintly in the dark, like something trying to be found. Or trying to lure." },
                { "$MountainCrystal_RtD", "Ice Crystal" },
                { "$MountainCrystal_desc_RtD", "The cold inside it is not natural. It does not melt. It waits." },
                { "$PlainsCrystal_RtD", "Void Crystal" },
                { "$PlainsCrystal_desc_RtD", "Looking into it too long leaves a hollow feeling you cannot name and cannot shake." },
                { "$SwampCrystal_RtD", "Earth Crystal" },
                { "$SwampCrystal_desc_RtD", "Pulled from deep below the bog. Whatever it absorbed down there is now part of it." },
                { "$AshLandsFairyTotem_RtD", "Fire Totem" },
                { "$AshLandsFairyTotem_desc_RtD", "Bind 5 Fire Crystals to the totem and the soul within is forced back into service. It remembers burning. Now it burns for you." },
                { "$BlackForestFairyTotem_RtD", "Lightning Totem" },
                { "$BlackForestFairyTotem_desc_RtD", "5 Lightning Crystals is enough to pin a restless soul in place. It does not want to be here. That rage is the point." },
                { "$DeepNorthFairyTotem_RtD", "Arcane Totem" },
                { "$DeepNorthFairyTotem_desc_RtD", "The soul sealed inside fought hard to be free. Feed it 5 Arcane Crystals and it fights just as hard — for you, whether it wishes to or not." },
                { "$MeadowsFairyTotem_RtD", "Air Totem" },
                { "$MeadowsFairyTotem_desc_RtD", "What was once a wandering soul is now a leash. 5 Air Crystals binds it to your gate. It howls. Your enemies hear it first." },
                { "$MistlandsFairyTotem_RtD", "Light Totem" },
                { "$MistlandsFairyTotem_desc_RtD", "5 Light Crystals and the totem drinks in a soul that has not rested since it died. It will not rest now either. You have made sure of that." },
                { "$MountainFairyTotem_RtD", "Ice Totem" },
                { "$MountainFairyTotem_desc_RtD", "Slain on the mountain, refused peace in death. 5 Ice Crystals keeps it that way — frozen in service, furious, and entirely yours." },
                { "$PlainsFairyTotem_RtD", "Void Totem" },
                { "$PlainsFairyTotem_desc_RtD", "The soul did not go anywhere when the body fell. 5 Void Crystals gives it somewhere to be. It is not grateful. Use that." },
                { "$SwampFairyTotem_RtD", "Earth Totem" },
                { "$SwampFairyTotem_desc_RtD", "The bog never truly releases what dies in it. 5 Earth Crystals and you become the thing holding the leash. It knows what you did." },
                
                // Horrors
                
                {"se_armorweakness_name", "Physical Weakness"},
                {"se_armorweakness_tooltip", "Physical Weakness"},
                {"se_armorweakness_start", "Physical Weakness"},
                {"se_frosted_name", "Frost Weakness"},
                {"se_frosted_tooltip", "Frost Weakness"},
                {"se_frosted_start", "Frost Weakness"},
                {"se_shocked_name", "Electric Weakness"},
                {"se_shocked_tooltip", "Electric Weakness"},
                {"se_shocked_start", "Electric Weakness"},
                {"se_weakened_name", "Poison Weakness"},
                {"se_weakened_tooltip", "Poison Weakness"},
                {"se_weakened_start", "Poison Weakness"},
                //
                {"AshLandsCrawler_RtD", "Scorched Crawler"},
                {"AshLandsHorror01_RtD", "Cindered Corpse"},
                {"AshLandsHorror_RtD", "Cindered Corpse"},
                {"BlackForestHorror01_RtD", "Mossgrown Shambler"},
                {"BlackForestHorror_RtD", "Mossgrown Shambler"},
                {"DeepNorthHorror_RtD", "Frozen Corpse"},
                {"MeadowsHorror01_RtD", "Rotting Wanderer"},
                {"MeadowsHorror_RtD", "Rotting Wanderer"},
                {"MistlandsHorror_RtD", "Pallid Shambler"},
                {"SeekerMutant_RtD", "Festering Seeker"},
                {"MountainHorror01_RtD", "Frostbitten Corpse"},
                {"MountainHorror_RtD", "Frostbitten Corpse"},
                {"PlainsHorror01_RtD", "Sunbaked Corpse"},
                {"PlainsHorror_RtD", "Sunbaked Corpse"},
                {"SwampChaser_RtD", "Bloated Chaser"},
                {"SwampHorror01_RtD", "Bog Rotter"},
                
                // Mini Bosses
                
                {"MeadowsPixie_Miniboss_RtD", "Air Queen"},
                {"BlackForestPixie_Miniboss_RtD", "Lightning Queen"},
                {"SwampPixie_Miniboss_RtD", "Earth Queen"},
                {"MountainPixie_Miniboss_RtD", "Ice Queen"},
                {"PlainsPixie_Miniboss_RtD", "Void Queen"},
                {"MistlandsPixie_Miniboss_RtD", "Light Queen"},
                {"AshLandsPixie_Miniboss_RtD", "Fire Queen"},
                {"DeepNorthPixie_Miniboss_RtD", "Arcane Queen"},
                
                // Souls
                
                {"AngrySpirit_RtD", "Wrathful Spirit"},
                {"FriendlySpirit_RtD", "Helpful Spirit"},
                
                // Meadows story part 1
                
                {"RuneStone_Meadows_desc_RtD", "Odin did not bring us here to thrive. He brought us here to remember. My village was green once — soft hills, laughing children, smoke rising from warm hearths. Then the ravens came. Not birds, but omens wearing feathers. We woke to ash. We woke to nothing. He took it all and called it purpose."},
                
                // Meadows story part 2
                
                {"RuneStone_Fae_Meadows_desc_RtD", "I buried my brother in the meadow at dawn. By nightfall something had dug him free. I heard his voice in the dark calling my name, but it was not him — not anymore. Whatever wore his face knew my name, my fears, my love for him. It used every one against me. Odin watches. Odin does nothing."},
                
                // BlackForest story part 1
                
                {"RuneStone_BlackForest_desc_RtD", "We found the altar in the pines and a woman was praying there, her fingers blackened to the bone. She said she had traded her sight for knowledge of the deep roots, the language beneath soil. When we asked what she had learned, she screamed. She has not stopped screaming. The trees listen and do not care."},
                
                // BlackForest story part 2
                
                {"RuneStone_Fae_BlackForest_desc_RtD", "My son wandered into the pines chasing fireflies. He returned three days later with eyes the color of fog and runes burned into his palms. He spoke in no tongue I knew. The runes wept amber sap. I held his hands and felt the magic eat into me — hungry, patient, ancient. We burned those pines. They regrew by morning."},
                
                // Swamp story part 1
                
                {"RuneStone_Swamp_desc_RtD", "It rose from the water not to kill, but to offer. A voice from everywhere and nowhere said it could unmake my suffering — dissolve it into the rot, into the mire where feeling cannot follow. I nearly said yes. I nearly let it take what remained of me. The worst part is I am still not certain I made the right choice."},
                
                // Swamp story part 2
                
                {"RuneStone_Fae_Swamp_desc_RtD", "The crypts do not bury the dead. They keep them awake. I heard them through the stone walls — weeping, begging, scratching at the dark. When I opened the door one reached out. Not to attack. Just to touch something living. I felt their despair pass through my skin like cold iron. I carry it still. Every single one of them."},
                
                // Mountain story part 1
                
                {"RuneStone_Mountain_desc_RtD", "She does not roar. She sings. High and cold as the wind before a blizzard, a sound that strips warmth from your blood and replaces it with something ancient and grieving. Men have removed their armor on the peaks, weeping, grateful to finally feel something true. The cold takes them tenderly. That is what makes her so terrible."},
                
                // Mountain story part 2
                
                {"RuneStone_Fae_Mountain_desc_RtD", "I found a man standing upright in the ice, eyes open, mid-stride as though still walking. His expression was not fear. It was resolve — the terrible resolve of someone who chose this, who walked into the cold with purpose. Carved in the ice around him were runes I could read: I am done waiting for rescue. This is my warmth now."},
                
                // Plains story part 1
                
                {"RuneStone_Plains_desc_RtD", "They made the child drink from the black stone bowl before battle. I watched from the grass — unable to move, bound by some magic in the earth. The child did not resist. Afterward he was larger, faster, his eyes filled with fire that had no warmth. On the battlefield he was the last one standing. And he was weeping over the bodies of his kin."},
                
                // Plains story part 2
                
                {"RuneStone_Fae_Plains_desc_RtD", "The skeleton on the throne was not always there. Travelers say he was once a king who swallowed every seiðr spell he could find, consuming magic like plague, becoming something past human, past god. Now he sits unmovable and eternal, too vast to die, too broken to live. Power, it seems, is just suffering with better posture."},
                
                // Mistlands story part 1
                
                {"RuneStone_Mistlands_desc_RtD", "The mist is not weather. It is intention. It moves toward the lonely, the lost, the grieving — and it fills the hollow places in them not with comfort but with longing so sharp it becomes indistinguishable from purpose. I have been in the Mistlands forty days. I no longer remember what I came here to find. I only know I cannot leave."},
                
                // Mistlands story part 2
                
                {"RuneStone_Fae_Mistlands_desc_RtD", "They carved their grief into the walls of their own tombs and sealed themselves inside while still alive. Not in madness — in calculation. The Dvergr believed that suffering, if recorded perfectly, could be preserved forever, outlasting even stone. They were right. I pressed my hand to the wall and felt centuries of sorrow flood into me like a tide."},
                
                // AshLands story part 1
                
                {"RuneStone_AshLands_desc_RtD", "She loved him so completely that when he died in the fire she stepped in after him. Not to die — to follow. The flames did not kill her. They accepted her. Now she walks the Ashlands eternal, half-ember, half-woman, calling a name no one else remembers. The dead here are not angry. They are faithful. That is so much worse."},
                
                // AshLands story part 2
                
                {"RuneStone_Fae_AshLands_desc_RtD", "The world did not always burn here. I found records in a sealed vault — maps of rivers, forests, fields of grain. Someone had loved this land. Then came the ritual, the hateful magic that cracked the sky open and let fire through like a judgment. Whoever cast it did not survive. But their hatred did. Hatred always outlives its host."},
                
                // DeepNorth story part 1
                
                {"RuneStone_DeepNorth_desc_RtD", "I came here to die in peace, away from the ravens, the tests, the god who treats lives like firewood. But the Deep North does not grant peace. It grants witness. It makes you watch — all of it, again, from the beginning. Every choice. Every failure. Every face. Then it asks you, in no language you can hear but only feel: was it worth it?"},
                
                // DeepNorth story part 2
                
                {"RuneStone_Fae_DeepNorth_desc_RtD", "There is a stone here carved in Odin's own hand. I know his runes — I have bled for them. The inscription reads: I too have lost everything. I too have wept at the edge of the world. I built this place as a grave for my grief, then forgot where I put it. Forgive me. Below it, someone else has carved: We do not."},
                
                // Fairy Cores
                
                {"FairyCoreMeadows_RtD", "Sunlit Fae Core"},
                {"FairyCoreMeadows_desc_RtD", "Warm with a light that does not belong here. The magic within hums like something that has not yet learned grief."},
                {"FairyCoreBlackForest_RtD", "Hollow Fae Core"},
                {"FairyCoreBlackForest_desc_RtD", "Something lived inside this once. It left in a hurry, and whatever replaced it is not interested in being named."},
                {"FairyCoreSwamp_RtD", "Drowned Fae Core"},
                {"FairyCoreSwamp_desc_RtD", "Waterlogged and seething. The magic inside never stops struggling, never drowns, never rests. It is very, very angry."},
                {"FairyCoreMountain_RtD", "Frost-Sealed Fae Core"},
                {"FairyCoreMountain_desc_RtD", "Cold to the bone and silent as a held breath. The magic within has been waiting under the ice longer than you have been alive."},
                {"FairyCorePlains_RtD", "Void-Sealed Fae Core"},
                {"FairyCorePlains_desc_RtD", "The void does not hold things gently. Whatever is trapped inside is still screaming. It has been screaming for a very long time."},
                {"FairyCoreMistlands_RtD", "Veiled Fae Core"},
                {"FairyCoreMistlands_desc_RtD", "You cannot quite look at it directly. The magic shifts like something trying not to be seen — and failing, just barely, on purpose."},
                {"FairyCoreAshLands_RtD", "Cinder Fae Core"},
                {"FairyCoreAshLands_desc_RtD", "Still hot. Still burning from the inside. The magic within has not forgiven whatever came before, and has no intention of starting."},
                {"FairyCoreDeepNorth_RtD", "Ashen Fae Core"},
                {"FairyCoreDeepNorth_desc_RtD", "Pale as old bone and heavier than it looks. The magic inside has endured so long it has become indistinguishable from despair."},
                
                // Magic Items
                
                {"AshLandsMageChest_RtD", "<#9289AA>Ljósálfar Ember Robes"},
                {"AshLandsMageChest_desc_RtD", "Woven from ash-silk and the shed skin of things that should not have survived the Ashlands. It is warm in a way that has nothing to do with comfort."},
                {"AshLandsMageHood_RtD", "<#9289AA>Ljósálfar Ember Hood"},
                {"AshLandsMageHood_desc_RtD", "Stitched from demon hide by hands that knew exactly what they were doing and did it anyway. The inside is always slightly too warm."},
                {"AshLandsMageLegs_RtD", "<#9289AA>Ljósálfar Ember Legs"},
                {"AshLandsMageLegs_desc_RtD", "Forged for mages who walk through fire and expect to arrive. The char marks on the hem are not decoration."},
                {"BlackForestMageChest_RtD", "<#9289AA>Thornweave Garment"},
                {"BlackForestMageChest_desc_RtD", "The forest gave up these threads reluctantly. Wear it long enough and you begin to feel the roots thinking beneath your feet."},
                {"BlackForestMageHood_RtD", "<#9289AA>Thornweave Hood"},
                {"BlackForestMageHood_desc_RtD", "Shadows pool inside it no matter the light. Mages of the Black Forest preferred it that way."},
                {"BlackForestMageLegs_RtD", "<#9289AA>Thornweave Legs"},
                {"BlackForestMageLegs_desc_RtD", "Move silently through the dark. The things that hunt here track sound and heartbeat. This helps with one of those."},
                {"DeepNorthMageChest_RtD", "<#9289AA>Fae Arcane Robes"},
                {"DeepNorthMageChest_desc_RtD", "Older than anything you have built or broken. The stitching rewrites itself when you are not looking."},
                {"DeepNorthMageHood_RtD", "<#9289AA>Fae Arcane Hood"},
                {"DeepNorthMageHood_desc_RtD", "It does not keep you warm. It keeps the cold out just enough that you remember what warmth was. That is worse."},
                {"DeepNorthMageLegs_RtD", "<#9289AA>Fae Arcane Legs"},
                {"DeepNorthMageLegs_desc_RtD", "Crafted in a place where the sky has been dark so long the stars forgot their names. The magic in the cloth has not forgotten anything."},
                {"MountainMageCape_RtD", "<#9289AA>Frostfell Wrap"},
                {"MountainMageCape_desc_RtD", "Cut from something that died on the peak and was never recovered. It carries the cold of that final moment."},
                {"MountainMageChest_RtD", "<#9289AA>Frostfell Tunic"},
                {"MountainMageChest_desc_RtD", "The weave tightens in extreme cold as if bracing for something it has faced before and did not enjoy."},
                {"MountainMageHood_RtD", "<#9289AA>Frostfell Hood"},
                {"MountainMageHood_desc_RtD", "It muffles the wind just enough to hear what the mountain is saying beneath it. Most mages wished it did not."},
                {"MountainMageLegs_RtD", "<#9289AA>Frostfell Legs"},
                {"MountainMageLegs_desc_RtD", "Built for mages who climbed too far and refused to come back down. The enchantment in the hem still pulls upward."},
                {"PlainsMageCape_RtD", "<#9289AA>Lox Void Cloak"},
                {"PlainsMageCape_desc_RtD", "Heavy enough to remind you of the weight of what you carry. Light enough that you keep forgetting it is there."},
                {"PlainsMageChest_RtD", "<#9289AA>Lox Void Raiment"},
                {"PlainsMageChest_desc_RtD", "The hide has been treated with something that drinks in light. Standing in sunlight wearing this feels like a quiet act of defiance."},
                {"PlainsMageHood_RtD", "<#9289AA>Lox Void Hood"},
                {"PlainsMageHood_desc_RtD", "The void does not look back. This hood makes it easier to stop looking first."},
                {"PlainsMageLegs_RtD", "<#9289AA>Lox Void Pants"},
                {"PlainsMageLegs_desc_RtD", "Stitched with thread that has no color in direct light. The Fuling shamans feared the mages who wore these. That is recommendation enough."},
                {"SwampMageCape_RtD", "<#9289AA>Mage Blood Drape"},
                {"SwampMageCape_desc_RtD", "It does not dry. It has never dried. Whatever soaked into it during crafting made a permanent home."},
                {"SwampMageChest_RtD", "<#9289AA>Mage Blood Garment"},
                {"SwampMageChest_desc_RtD", "Deer hide cured in guck and something fouler. The Swamp does not give materials. It makes trades."},
                {"SwampMageHood_RtD", "<#9289AA>Mage Blood Hood"},
                {"SwampMageHood_desc_RtD", "Keeps the mist from your eyes and the rot from your lungs. What it lets through instead is a matter of some debate."},
                {"SwampMageLegs_RtD", "<#9289AA>Mage Blood Legs"},
                {"SwampMageLegs_desc_RtD", "The enchantment keeps the creatures of the Swamp from your ankles. Not because it repels them. Because it reminds them of something they fear."},
                {"HealingStaff_T1_RtD", "<#FFA089>Eir Staff T1"},
                {"HealingStaff_T1_desc_RtD", "The goddess lends the faintest touch of her grace. It is enough. For now."},
                {"HealingStaff_T2_RtD", "<#FF9075>Eir Staff T2"},
                {"HealingStaff_T2_desc_RtD", "Eir does not heal out of mercy. She heals because the dead are less interesting than the suffering."},
                {"HealingStaff_T3_RtD", "<#FF8062>Eir Staff T3"},
                {"HealingStaff_T3_desc_RtD", "The wounds close faster than they should. Do not ask what it costs the staff to do that."},
                {"HealingStaff_T4_RtD", "<#FF714E>Eir Staff T4"},
                {"HealingStaff_T4_desc_RtD", "To wield this is to understand that Eir's gift and Eir's punishment are the same thing."},
                {"AshLandsStaff1_RtD", "<#C5B358>Freyr Staff T1"},
                {"AshLandsStaff1_desc_RtD", "Freyr blessed this staff before the war took everything from him. The warmth in it has nowhere left to go."},
                {"AshLandsStaff2_RtD", "<#C5B358>Freyr Staff T2"},
                {"AshLandsStaff2_desc_RtD", "The fire in this staff does not burn clean. It burns with the grief of a god who gave up his sword and regrets it still."},
                {"AshLandsStaff3_RtD", "<#C5B358>Freyr Staff T3"},
                {"AshLandsStaff3_desc_RtD", "At its peak it channels something Freyr never intended to give. He has not noticed. Or he has, and decided not to stop it."},
                {"BlackForestFireStaff_RtD", "<#B22222>Fire Staff"},
                {"BlackForestFireStaff_desc_RtD", "The Black Forest does not burn easily. This staff is why. It remembers every tree it has taken."},
                {"BlackForestLightStaff_RtD", "<#ADD8E6>Light Staff"},
                {"BlackForestLightStaff_desc_RtD", "Light that cuts through the dark between the pines. The things living there hate it. That is exactly the point."},
                {"DeepNorthStaff1_RtD", "<#5218FA>Arcane Staff T1"},
                {"DeepNorthStaff1_desc_RtD", "The first word of a language older than the gods. It hums even when you are not holding it."},
                {"DeepNorthStaff2_RtD", "<#6531FB>Arcane Staff T2"},
                {"DeepNorthStaff2_desc_RtD", "The magic in this staff does not come from the world. It comes from somewhere the world borrowed from and never paid back."},
                {"DeepNorthStaff3_RtD", "<#774AFB>Arcane Staff T3"},
                {"DeepNorthStaff3_desc_RtD", "To master this is to understand a truth the Deep North has always known — some power was never meant to be held by the living."},
                {"MeadowsAirStaff_RtD", "<#5D8AA8>Air Staff"},
                {"MeadowsAirStaff_desc_RtD", "Deceptively gentle. Air does not wound like fire or freeze like ice. It simply removes your ability to stand, breathe, and argue."},
                {"MeadowsLighteningStaff_RtD", "<#FBC72A>Lightning Staff"},
                {"MeadowsLighteningStaff_desc_RtD", "The storm does not discriminate. Neither does this. Make sure you are not the tallest thing around when you use it."},
                {"MistlandsQuakeStaff_RtD", "<#E0ECF5>Mistwalker Staff"},
                {"MistlandsQuakeStaff_desc_RtD", "The mist parts for it. Not out of respect. Out of recognition."},
                {"MountainIceStaff_RtD", "<#76A5AF>Ice Staff"},
                {"MountainIceStaff_desc_RtD", "The cold it channels is not weather. It is intention. The mountain decided long ago what it wanted to do to warm things."},
                {"PlainsVoidStaff_RtD", "<#AA08D0>Void Staff"},
                {"PlainsVoidStaff_desc_RtD", "It does not channel darkness. It channels the absence of everything else. There is a difference. You feel it immediately."},
                {"SwampEarthStaff_RtD", "<#CAE2C2>Earth Staff"},
                {"SwampEarthStaff_desc_RtD", "The bog answers when this staff speaks. What it says in return is between you and the deep roots."},
                {"AshLandsFireWand_RtD", "Fire Wand"},
                {"AshLandsFireWand_desc_RtD", "Warm to the touch before you even cast. Something inside it has been burning since before you found it."},
                {"BlackForestLightningWand_RtD", "<#FBC72A>Lightning Wand"},
                {"BlackForestLightningWand_desc_RtD", "It twitches toward metal. Keep it away from your other hand."},
                {"DeepNorthArcaneWand_RtD", "<#5218FA>Arcane Wand"},
                {"DeepNorthArcaneWand_desc_RtD", "It hums at a frequency just below hearing. You feel it in your back teeth and behind your eyes."},
                {"MeadowsAirWand_RtD", "<#5D8AA8>Air Wand"},
                {"MeadowsAirWand_desc_RtD", "Light as a held breath. It will take yours away just as easily."},
                {"MistlandsElementWand_RtD", "<#E0ECF5>Element Wand"},
                {"MistlandsElementWand_desc_RtD", "It does not choose an element. It chooses what hurts most. They are not always the same thing."},
                {"MountainIceWand_RtD", "<#76A5AF>Ice Wand"},
                {"MountainIceWand_desc_RtD", "The cold radiates from it even in summer. Grip it long enough and you stop noticing. That is the warning."},
                {"PlainsVoidWand_RtD", "<#AA08D0>Void Wand"},
                {"PlainsVoidWand_desc_RtD", "Hold it in the dark and nothing changes. That is how you know it is working."},
                {"SwampPoisonWand_RtD", "<#CAE2C2>Poison Wand"},
                {"SwampPoisonWand_desc_RtD", "The death it offers is not fast. It was never meant to be. The Swamp is patient and it taught this wand everything it knows."},
                {"SBlackSoup_RtD", "Murk Broth"},
                {"SBlackSoup_desc_RtD", "What lives in the Swamp ends up in this eventually. It keeps you alive despite your better judgment."},
                {"SBloodPudding_RtD", "Sanguine Pudding"},
                {"SBloodPudding_desc_RtD", "Do not ask whose blood. Do not ask whose recipe. Eat it and be grateful something in this world still nourishes you."},
                {"SCarrotSoup_RtD", "Pale Root Soup"},
                {"SCarrotSoup_desc_RtD", "Pulled from soil that has tasted too much death. The carrots grew fast and wrong and somehow better for it."},
                {"SEyeScream_RtD", "Frozen Eyescream"},
                {"SEyeScream_desc_RtD", "Cold enough to stop thought for a moment. Sometimes a moment is all you need."},
                {"SOnionSoup_RtD", "Bitter Cold Soup"},
                {"SOnionSoup_desc_RtD", "Tastes like regret and the tail end of winter. Sustaining in the way only deeply unpleasant things can be."},
                {"SQueensJam_RtD", "Hexed Jam"},
                {"SQueensJam_desc_RtD", "Sweet enough to make you forget where you are. That is not an accident."},
                {"SShockolateShake_RtD", "Shockolate Shake"},
                {"SShockolateShake_desc_RtD", "Brewed with ingredients that should cancel each other out. They do not. The result is something the body accepts only out of desperation."},
                {"STurnipStew_RtD", "Bitter Root Stew"},
                {"STurnipStew_desc_RtD", "Turnips pulled from cursed ground taste of iron and old grief. They keep you standing. That will have to be enough."},
                {"SE_MageArmorAshLands_RtD", "Ember Binding"},
                {"SE_MageArmorAshLands_desc_RtD", "The Ashlands set. Fire does not harm you now. It merely reminds you of what you are becoming."},
                {"SE_MageArmorBlackForest_desc_RtD", "The Black Forest set. The roots know your name. They have decided, for now, you are not food."},
                {"SE_MageArmorBlackForest_RtD", "Root Covenant"},
                {"SE_MageArmorDeepNorth_RtD", "Arcane Vigil"},
                {"SE_MageArmorDeepNorth_desc_RtD", "The Deep North set. Something ancient has noticed you. It is not alarmed. That should alarm you."},
                {"SE_MageArmorMistlands_RtD", "Veilborn Sight"},
                {"SE_MageArmorMistlands_desc_RtD", "The Mistlands set. You see through the mist now. What sees back is a separate matter entirely."},
                {"SE_MageArmorMountain_RtD", "Frost Pact"},
                {"SE_MageArmorMountain_desc_RtD", "The Mountain set. The cold no longer tries to kill you. It is waiting to see if you are worth the effort."},
                {"SE_MageArmorPlains_RtD", "Void Mantle"},
                {"SE_MageArmorPlains_desc_RtD", "The Plains set. The void has wrapped itself around you. You are not protected. You are claimed."},
                {"SE_MageArmorSwamp_RtD", "Bog Pact"},
                {"SE_MageArmorSwamp_desc_RtD", "The Swamp set. The rot has accepted you as one of its own. Whether that is a blessing depends entirely on your perspective."},
                {"MistlandsMageCape_RtD", "<#E0ECF5>Mistwalker Cape"},
                {"MistlandsMageCape_desc_RtD", "The mist clings to it even in clear air, as though the Mistlands refused to fully let go."},
                {"MistlandsMageChest_RtD", "<#E0ECF5>Mistwalker Chest"},
                {"MistlandsMageChest_desc_RtD", "Robes that shift color at the edge of vision. Not a trick of the light. A feature."},
                {"MistlandsMageHood_RtD", "<#E0ECF5>Mistwalker Hood"},
                {"MistlandsMageHood_desc_RtD", "It obscures your face just enough that things in the mist mistake you for one of their own. So far that has worked out."},
                {"MistlandsMageLegs_RtD", "<#E0ECF5>Mistwalker Legs"},
                {"MistlandsMageLegs_desc_RtD", "Your footsteps make no sound in the mist. You did not notice until something that hunts by sound walked past you."},
                {"MeadowsElemental_RtD", "<#E0ECF5>Storm Orb"},
                {"MeadowsElemental_desc_RtD", "A tempest compressed into something you can hold. It is not comfortable with that arrangement."},
                {"BlackForestElemental_RtD", "<#E0ECF5>Star Orb"},
                {"BlackForestElemental_desc_RtD", "Light from somewhere too far away to name, trapped in glass and fury. It pulses like it is counting down to something."},
                {"SwampElemental_RtD", "<#E0ECF5>Nature Orb"},
                {"SwampElemental_desc_RtD", "The bog distilled into a single object. It smells of deep earth and things decomposing into something new."},
                {"MountainElemental_RtD", "<#E0ECF5>Snow Orb"},
                {"MountainElemental_desc_RtD", "A blizzard held in suspension. When you grip it too long, your fingers forget they were ever warm."},
                {"PlainsElemental_RtD", "<#E0ECF5>Void Orb"},
                {"PlainsElemental_desc_RtD", "It absorbs light around the edges. Looking at it directly is fine. Looking at it too long is not."},
                {"MistlandsElemental_RtD", "<#E0ECF5>Wisp Orb"},
                {"MistlandsElemental_desc_RtD", "Something is inside it. It moves when you are not watching. It stops when you are."},
                {"AshLandsElemental_RtD", "<#E0ECF5>Ash Orb"},
                {"AshLandsElemental_desc_RtD", "Still warm from whatever died to make it. The ash inside shifts without wind, tracing patterns no one has translated yet."},
                {"DeepNorthElemental_RtD", "<#E0ECF5>Arcane Orb"},
                {"DeepNorthElemental_desc_RtD", "It hums in a key that does not exist. Mages of the Deep North carried these until the orbs carried them instead."},
                
            });
        }
    }
}