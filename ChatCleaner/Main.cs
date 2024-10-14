using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;
using Rocket.Core.Plugins;
using SDG.Unturned;
using UnityEngine;
using Rocket.Core.Commands;

namespace ChatCleaner
{
    public class ChatCleanerPlugin : RocketPlugin
    {
        protected override void Load()
        {
            Rocket.Core.Logging.Logger.Log("ChatCleaner plugin loaded!");
        }

        protected override void Unload()
        {
            Rocket.Core.Logging.Logger.Log("ChatCleaner plugin unloaded.");
        }

        [RocketCommand("clearchat", "Clears the chat.", "", AllowedCaller.Both)]
        [RocketCommandAlias("cc")]
        [RocketCommandAlias("clear")]
        public void ExecuteCommand(IRocketPlayer caller, string[] command)
        {
            if (caller is ConsolePlayer || (caller is UnturnedPlayer && ((UnturnedPlayer)caller).HasPermission("chatcleaner.use")))
            {
                ClearChat();
                UnturnedChat.Say(caller, "Chat has been cleared!", Color.green);
            }
            else
            {
                UnturnedChat.Say(caller, "You do not have permission to use this command.", Color.red);
            }
        }

        private void ClearChat()
        {
            for (int i = 0; i < 50; i++)
            {
                ChatManager.serverSendMessage(string.Empty, Color.clear, null, null, EChatMode.GLOBAL, null, true);
            }
        }
    }
}
