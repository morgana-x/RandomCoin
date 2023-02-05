using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;
using RemoteAdmin;

namespace CoinFlip.Commands
{
    using Exiled.API.Features.Items;

    //[CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    class CoinFlip : ICommand // CAN ONLY BE USED BY SERVER CONSOLE FOR DEBUG REASONS
    {
        public string Command { get; } = "givecoin";

        public string[] Aliases { get; } = new string[] { "coin", "givecoin" };

        public string Description { get; } = "A command that gives a coin for debug purposes";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender player)
            {
                response = $"Hello {player.Nickname}!";
                foreach (Player pl in (Player.List))
                    if (pl.Nickname == player.Nickname)
                    {
                        response = "Gave coin to " + pl.Nickname;
                        pl.AddItem(ItemType.Coin);
                        return true;
                    }

            }
            foreach (Player pl in (Player.List))
                    pl.AddItem(ItemType.Coin);
            response = "Gave coins to everyone!";
            return true;
        }

    }
}
