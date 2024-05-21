using CommandSystem;
using Exiled.API.Features;
using System;

namespace ItemDescription;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class AddDescription : ICommand, IUsageProvider
{
    public string Command { get; } = "AddDescription";
    public string Description { get; } = "Adds a description to your current item. Players will see it when they pick it up.";
    public string[] Aliases { get; } = ["AddDesc"];
    public string[] Usage { get; } = ["Description"];

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (Player.Get(sender) is not { CurrentItem: not null } player)
        {
            response = "You must be holding an item to use this command";
            return false;
        }

        if (arguments.Count < 1)
        {
            response = "You must specify a description";
            return false;
        }

        string description = string.Join(" ", arguments);
        Plugin.ItemDescriptions[player.CurrentItem.Serial] = description;
        response = "Description added";
        return true;
    }
}