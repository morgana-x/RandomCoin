using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Exiled.API.Interfaces;
using Exiled.API.Features;
using Exiled.API.Enums;
using System.Collections.Specialized;
namespace CoinFlip
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;


        ////////////// COIN FLIP CONFIG////////////////////////////////

        [Description("Message that shows to player when they get an item")]
        public string coinflip_itemmessage { get; set; } = "You have been given {itemName}!";

        [Description("Message that shows to player when they get an effect")]
        public string coinflip_effectmesssage { get; set; } = "Given {effectName} effect for {time} seconds!";


        // MAIN

        [Description("Whether to notify the player when they get an effect/item")]
        public bool coinflip_notifyplayer { get; set; } = true;

        [Description("Whether the coin gets destroyed when it's used.")]
        public bool coinflip_destroycoin { get; set; } = true;


        [Description("Amount of time an effect stays")]
        public float coinflip_effect_time { get; set; } = 120.0f;

        /// ////////////////////////////////////
        [Description("Decide whether it's an effect or item by checking if it's heads or tails instead, will make item chance and effect chance redundant")]
        public bool coinflip_headstails { get; set; } = true;

        [Description("Chance of coinflip giving an item (IGNORE IF HEADSTAILS IS SET TO TRUE)")]
        public int coinflip_item_chance { get; set; } = 50; // ITEM CHANCE


        [Description("Chance of coinflip giving an effect (IGNORE IF HEADSTAILS IS SET TO TRUE)")]
        public int coinflip_effect_chance { get; set; } = 50; // EFFECT CHANCE
        /// ////////////////////////////////////
        /// 
        /// ////////////////////////////////////

        [Description("Chances of items when a coinflip gives an item")]
        public IDictionary<ItemType, int> coinflip_items { get; set; } = new Dictionary<ItemType, int>() // ITEM CHANCES
        {
    
            // GUNS
            [ItemType.GunAK] = 3,
            [ItemType.GunCOM15] = 4,
            [ItemType.GunCOM18] = 4,
            [ItemType.GunCrossvec] = 3,
            [ItemType.GunFSP9] = 4,
            [ItemType.GunLogicer] = 3,
            [ItemType.GunRevolver] = 5,
            [ItemType.GunShotgun] = 2,
            [ItemType.GunE11SR] = 3,
            
            // GRENADES
            [ItemType.GrenadeFlash] = 5,
            [ItemType.GrenadeHE] = 3,

            // Misc
            [ItemType.Coin] = 0,
            [ItemType.Jailbird] = 2,
            [ItemType.ParticleDisruptor] = 2,
            [ItemType.MicroHID] = 1,
            [ItemType.Radio] = 5,
            [ItemType.Flashlight] = 6,
            [ItemType.GunCom45] = 1,

            // Medical
            [ItemType.Painkillers] = 6,
            [ItemType.Medkit] = 5,
            [ItemType.SCP500] = 1,
            [ItemType.Adrenaline] = 4,

            //  SCP
            [ItemType.SCP207] = 2,
            [ItemType.SCP018] = 1,
            [ItemType.SCP2176] = 1,
            [ItemType.SCP330] = 1,
            [ItemType.SCP1853] = 1,
            [ItemType.SCP018] = 1,
            [ItemType.SCP268] =2,
            [ItemType.SCP244a] = 1,
            [ItemType.SCP244b] = 1,
            // Armor

            [ItemType.ArmorCombat] = 4,
            [ItemType.ArmorHeavy] = 3,
            [ItemType.ArmorLight] = 6,

            // KEYCARDS
            [ItemType.KeycardO5] = 1,
            [ItemType.KeycardChaosInsurgency] = 2,
            [ItemType.KeycardResearchCoordinator] = 4,
            [ItemType.KeycardNTFCommander] = 2,
            [ItemType.KeycardNTFLieutenant] = 3,
            [ItemType.KeycardNTFOfficer] = 4,
            [ItemType.KeycardFacilityManager] = 4,
            [ItemType.KeycardResearchCoordinator] = 4,
            [ItemType.KeycardZoneManager] = 4,
            [ItemType.KeycardGuard] = 5,
            [ItemType.KeycardScientist] = 5,
            [ItemType.KeycardJanitor] = 6,

        };
        ////////////////////////////////////////
        

        ////////////EFFECTS/////////////////////




        [Description("Chances of effects when a coinflip gives an effect")]
        public IDictionary<EffectType, int> coinflip_effects { get; set; } = new Dictionary<EffectType, int>() // NEGATIVE EFFECT CHANCES
        {
            [EffectType.DamageReduction] = 1,
            [EffectType.Bleeding] = 5,
            [EffectType.Blinded] = 5,
            [EffectType.Deafened] = 5,
            [EffectType.MovementBoost] = 3,
            [EffectType.Vitality] = 2,
            [EffectType.Invigorated] = 2,
            [EffectType.Invisible] = 1,
            [EffectType.SeveredHands] = 1,
            [EffectType.RainbowTaste] = 2,
            [EffectType.SinkHole] = 4,
            [EffectType.Scp1853] = 3,
            [EffectType.Stained] = 4,
            [EffectType.Poisoned] = 3,
            [EffectType.Hemorrhage] = 1,
            [EffectType.Disabled] = 2,
            [EffectType.Concussed] = 4,
            [EffectType.CardiacArrest] = 0,
            [EffectType.Burned] = 1,
            [EffectType.Asphyxiated] = 2,
            [EffectType.AmnesiaVision] = 2,
            [EffectType.Flashed] = 2,
            [EffectType.Exhausted] = 6,
            [EffectType.InsufficientLighting] = 5,
            [EffectType.Ensnared] = 3,
            [EffectType.Scp207] = 3,
        };

        ////////////////////////////////////////////
        
        

    }
}
