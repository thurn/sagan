using System;
using UnityEngine;

public enum Item
{
    Unknown,
    Probe,
    Extractor,
    LaunchSystem,
    Autofactory
}

public static class ItemExtension
{
    public static string GetName(this Item item)
    {
        switch (item)
        {
            case Item.Probe:
                return "Probe";

            case Item.Extractor:
                return "Extractor";

            case Item.LaunchSystem:
                return "Launch System";

            case Item.Autofactory:
                return "Autofactory";
        }
        throw new InvalidOperationException("Unknown item " + item);
    }

    public static int GetProductionTimeSeconds(this Item item)
    {
        switch (item)
        {
            case Item.Probe:
                return 2;

            case Item.Extractor:
                return 25;

            case Item.LaunchSystem:
                return 25;

            case Item.Autofactory:
                return 60;
        }
        throw new InvalidOperationException("Unknown item " + item);
    }
}