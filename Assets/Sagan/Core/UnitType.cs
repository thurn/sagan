using System;

namespace Sagan.Core
{

  public enum UnitType
  {
    Unknown,
    Probe,
    Extractor,
    Refinery,
    LaunchSystem,
    Autofactory
  }

  public static class UnitTypeExtension
  {
    public static string GetName(this UnitType unitType)
    {
      switch (unitType)
      {
        case UnitType.Probe:
          return "Probe";

        case UnitType.Extractor:
          return "Extractor";

        case UnitType.Refinery:
          return "Refinery";

        case UnitType.LaunchSystem:
          return "Launch System";

        case UnitType.Autofactory:
          return "Autofactory";
      }

      throw new InvalidOperationException("Unknown item " + unitType);
    }

    public static int GetProductionTimeSeconds(this UnitType unitType)
    {
      switch (unitType)
      {
        case UnitType.Probe:
          return 2;

        case UnitType.Extractor:
          return 5;

        case UnitType.Refinery:
          return 5;

        case UnitType.LaunchSystem:
          return 5;

        case UnitType.Autofactory:
          return 10;
      }

      throw new InvalidOperationException("Unknown unitType " + unitType);
    }

    public static bool IsProducer(this UnitType unitType)
    {
      switch (unitType)
      {
        case UnitType.Autofactory:
          return true;

        default:
          return false;
      }
    }
  }
}