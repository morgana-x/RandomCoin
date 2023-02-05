using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;
using Exiled.API.Features;
using Exiled.API.Enums;

using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
namespace CoinFlip
{
    public class CoinFlip : Plugin<Config>
    {
        public override string Name => "My first Plugin";
        public override string Author => "Morgana";
        public override Version RequiredExiledVersion { get; } = new Version(6, 0, 0);
        public override Version Version => new Version(1, 0, 0);
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Handlers.PlayerHandler player;
       // private Handlers.ServerHandler server;
        public static CoinFlip Instance { get; } = new CoinFlip();
        private CoinFlip() { }

        public override void OnEnabled()
        {
            base.OnEnabled();
            RegisterEvents();
            Log.Info(CoinFlip.Instance.Config.coinflip_prefix + " initialized.");
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            UnregisterEvents();
        }
       
  
        public override void OnReloaded() { }
        public void RegisterEvents()
        {
            player = new Handlers.PlayerHandler();
           // server = new Handlers.ServerHandler();


          //  Player.Left += player.OnLeft;
          //  Player.Joined += player.OnJoined;
          //  Player.InteractingDoor += player.OnInteractingDoor;
          //  Player.Died += player.OnPlayerDied;
            Player.FlippingCoin += player.OnPlayerFlipCoin;
          //  Player.Spawned += player.OnPlayerSpawned;
           // Server.WaitingForPlayers += server.OnWaitingForPlayers;
           // Server.RoundStarted += server.OnRoundStarted;
        }

        private void UnregisterEvents()
        {
            player = new Handlers.PlayerHandler();
          //  server = new Handlers.ServerHandler();
           // Player.Left -= player.OnLeft;
           // Player.Joined -= player.OnJoined;
           // Player.InteractingDoor -= player.OnInteractingDoor;
          //  Player.Died -= player.OnPlayerDied;
            Player.FlippingCoin -= player.OnPlayerFlipCoin;
            //Server.WaitingForPlayers -= Server.OnWaitingForPlayers;
           // Server.RoundStarted -= Server.OnRoundStarted;

            //server = null;
            player = null;
        }
    }
}
