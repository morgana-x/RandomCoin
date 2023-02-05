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
        
        /// LOGS
        [Description("Prefix of coinflip logs")]
        public string coinflip_prefix { get; set; } = "[Random Coin] ";

        // MAIN

        [Description("Whether to notify the player when they get an effect/item")]
        public bool coinflip_notifyplayer { get; set; } = true;

        [Description("Whether the coin gets destroyed when it's used.")]
        public bool coinflip_destroycoin { get; set; } = true;


        [Description("Amount of time an effect stays")]
        public float coinflip_effect_time { get; set; } = 120.0f;

        /// ////////////////////////////////////
        [Description("Chance of coinflip giving an item")]
        public int coinflip_item_chance { get; set; } = 50; // ITEM CHANCE


        [Description("Chance of coinflip giving an effect")]
        public int coinflip_effect_chance { get; set; } = 50; // EFFECT CHANCE
        /// ////////////////////////////////////
        /// 
        /// ////////////////////////////////////

        [Description("Chances of items when a coinflip gives an item")]
        public IDictionary<ItemType, int> coinflip_items { get; set; } = new Dictionary<ItemType, int>() // ITEM CHANCES
        {
    
      

            // GUNS
            [ItemType.GunAK] = 3,
            [ItemType.GunCOM15] = 10,
            [ItemType.GunCOM18] = 20,
            [ItemType.GunCom45] = 20,
            [ItemType.GunCrossvec] = 5,
            [ItemType.GunFSP9] = 20,
            [ItemType.GunLogicer] = 4,
            [ItemType.GunRevolver] = 4,
            [ItemType.GunShotgun] = 4,
            [ItemType.GunE11SR] = 3,
            
            // GRENADES
            [ItemType.GrenadeFlash] = 5,
            [ItemType.GrenadeHE] = 5,

            // Misc
            [ItemType.Coin] = 0,
            [ItemType.Jailbird] = 0,
            [ItemType.ParticleDisruptor] = 0,
            [ItemType.MicroHID] = 0,
            [ItemType.Radio] = 15,
            [ItemType.Flashlight] = 20,
            
            // Medical
            [ItemType.Painkillers] = 25,
            [ItemType.Medkit] = 15,
            [ItemType.SCP500] = 0,

            //  SCP
            [ItemType.SCP207] = 1,
            [ItemType.SCP018] = 0,
            [ItemType.SCP2176] = 0,

            // Armor

            [ItemType.ArmorCombat] = 10,
            [ItemType.ArmorHeavy] = 5,
            [ItemType.ArmorLight] = 15,

            // KEYCARDS
            [ItemType.KeycardO5] = 2,
            [ItemType.KeycardChaosInsurgency] = 5,
            [ItemType.KeycardResearchCoordinator] = 5,
            [ItemType.KeycardNTFCommander] = 4,
            [ItemType.KeycardNTFLieutenant] = 4,
            [ItemType.KeycardNTFOfficer] = 4,
            [ItemType.KeycardFacilityManager] = 4,
            [ItemType.KeycardResearchCoordinator] = 4,
            [ItemType.KeycardZoneManager] = 4,
            [ItemType.KeycardGuard] = 11,
            [ItemType.KeycardScientist] = 25,
            [ItemType.KeycardJanitor] = 25,

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
            [EffectType.SeveredHands] = 0,
            [EffectType.RainbowTaste] = 2,
            [EffectType.SinkHole] = 4,
            [EffectType.Scp1853] = 3,
            [EffectType.Stained] = 4,
            [EffectType.Poisoned] = 3,
            [EffectType.Hemorrhage] = 1,
            [EffectType.Disabled] = 2,
            [EffectType.Concussed] = 4,
            [EffectType.CardiacArrest] = 0,
            [EffectType.Burned] = 0,
            [EffectType.Asphyxiated] = 2,
            [EffectType.AmnesiaVision] = 2,
            [EffectType.Flashed] = 2,
            [EffectType.Exhausted] = 6,
            [EffectType.InsufficientLighting] = 5,
            [EffectType.Ensnared] = 3,
        };

        ////////////////////////////////////////////
        

    }
}
