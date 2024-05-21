using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using Exiled.Events.EventArgs.Player;
using MEC;
using UnityEngine;
using Handlers = Exiled.Events.Handlers;

namespace ItemDescription;

public class Plugin : Plugin<Config>
{
    public override string Prefix => "ItemDescription";
    public override string Name => Prefix;
    public override string Author => "BanalnyBanan";
    public override Version Version { get; } = new (1, 0, 0);
    public static Plugin Instance;

    public override void OnEnabled()
    {
        Instance = this;
        Handlers.Player.ItemAdded += OnItemAdded;
        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        Instance = null;
        Handlers.Player.ItemAdded -= OnItemAdded;
        base.OnDisabled();
    }

    public static readonly Dictionary<ushort, string> ItemDescriptions = [];

    private void OnItemAdded(ItemAddedEventArgs ev)
    {
        if(ev.Item is null) return;
        if(ItemDescriptions.TryGetValue(ev.Item.Serial, out var description))
        {
            ev.Player.ShowHint(Config.DescriptionWrapper.Replace("{0}", description), Mathf.Max(description.Length * 0.07f, 3f));
        }
    }
}