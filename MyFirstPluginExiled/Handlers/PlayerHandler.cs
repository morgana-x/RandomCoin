using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Player;
namespace CoinFlip.Handlers
{

     class PlayerHandler
    {
        Random rnd = new Random();

        public ItemType GetRandomItem(IDictionary<ItemType, int> dict)
        {
            ItemType result = ItemType.None;
            int totalWeight = 0;

            foreach (var Item in dict)
                totalWeight += Item.Value;

            int randNumber = rnd.Next(0,totalWeight);

            foreach (var Item in dict)
            {
                var value = Item.Value;

                if (randNumber >= value)
                {
                    randNumber -= value;
                }
                else
                {
                    result = Item.Key;
                    break;
                }
            }
            return result;
        }

        public EffectType GetRandomEffect(IDictionary<EffectType, int> dict)
        {
            EffectType result = EffectType.Scp207;
            int totalWeight = 0;

            foreach (var Item in dict)
                totalWeight += Item.Value;

            int randNumber = rnd.Next(0, totalWeight);

            foreach (var Item in dict)
            {
                var value = Item.Value;

                if (randNumber >= value)
                {
                    randNumber -= value;
                }
                else
                {
                    result = Item.Key;
                    break;
                }
            }
            return result;
        }
        public void OnJoined(JoinedEventArgs ev)
        {
        }

        public void OnLeft(LeftEventArgs ev)
        {
            
        }

        public void OnPlayerDied( Exiled.Events.EventArgs.Player.DiedEventArgs  ev)
        {
           
        }
        public void OnPlayerSpawned(Exiled.Events.EventArgs.Player.SpawnedEventArgs ev)
        {
  
        }
        public void OnPlayerFlipCoin(FlippingCoinEventArgs ev)
        {
            if (!ev.IsAllowed)
            {
                return;
            }
            if (!ev.Player.HasItem(ItemType.Coin))
            {
                Log.Info(ev.Player.Nickname + " has no coin, returning....");
                return;
            }
            IDictionary<ItemType, int> coinflip_items = CoinFlip.Instance.Config.coinflip_items;
            IDictionary<EffectType, int> coinflip_effects= CoinFlip.Instance.Config.coinflip_effects;

            int coinflip_item_chance = CoinFlip.Instance.Config.coinflip_item_chance;
            int coinflip_effect_chance = CoinFlip.Instance.Config.coinflip_effect_chance;

            float coinflip_effect_time = CoinFlip.Instance.Config.coinflip_effect_time;
            bool coinflip_destroycoinonuse = CoinFlip.Instance.Config.coinflip_destroycoin;

            bool coinflip_headstails = CoinFlip.Instance.Config.coinflip_headstails;
            bool coinflip_notify = CoinFlip.Instance.Config.coinflip_notifyplayer;




            Log.Info(ev.Player.Nickname + " flipped a coin!");
            int random = rnd.Next(0, 100);
            Log.Info(ev.Player.Nickname + " luck: " + random.ToString() );
            if (coinflip_destroycoinonuse)
            {
                Log.Info(  "Destroyed " + ev.Player.Nickname + "'s coin.");
                ev.Player.RemoveHeldItem(true);
            }
            int choose = 0;

            if (coinflip_headstails)
            {
                Log.Info("Using heads tails instead of chances for item or effect");
                if (ev.IsTails)
                    choose = 1;
            }
            else
            {
                if (coinflip_item_chance <= coinflip_effect_chance)
                {
                    if (random > coinflip_effect_chance)
                        choose = 1; // item
                    else
                        choose = 0; // effect
                }
                else if (coinflip_item_chance >= coinflip_effect_chance)
                {
                    if (random > coinflip_item_chance)
                        choose = 0; // effect
                    else
                        choose = 1; // item
                }
            }
            switch(choose)
            {
                case 0: // effects
             
                    EffectType effect = GetRandomEffect(coinflip_effects);
                    string effectName = effect.ToString();
                    string coinflip_effectmessage = CoinFlip.Instance.Config.coinflip_effectmesssage.Replace("{effectName}", effectName).Replace("{time}", coinflip_effect_time.ToString())  ;
                    Log.Info( ev.Player.Nickname + " got a random effect! Effect: " + effectName + " Duration: " + coinflip_effect_time.ToString());
                    ev.Player.EnableEffect(effect, coinflip_effect_time);
                    if (coinflip_notify)
                    {
                        ev.Player.Broadcast(6, coinflip_effectmessage, Broadcast.BroadcastFlags.Normal, true);
                    }
                    break;
                case 1: // items
       
                    ItemType item = GetRandomItem(coinflip_items);
                    string itemName = item.ToString();
                    Log.Info( ev.Player.Nickname + " got a random item! Item: " + itemName);
                    ev.Player.AddItem(item);
                    string coinflip_itemmessage = CoinFlip.Instance.Config.coinflip_itemmessage.Replace("{itemName}", itemName);
                    if (coinflip_notify)
                    {
                        ev.Player.Broadcast(5, coinflip_itemmessage, Broadcast.BroadcastFlags.Normal, true);
                    }
                    break;
            }

            
    

        }
        public void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            
        }
    }

}
