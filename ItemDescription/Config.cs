using Exiled.API.Interfaces;
using System;
using System.ComponentModel;

namespace ItemDescription;

public class Config : IConfig
{
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; } = false;
    [Description("Wrapper for the item description. {0} is then replaced with the description itself")]
    public string DescriptionWrapper { get; set; } = "<b>{0}</b>";
}