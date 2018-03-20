using Sagan.Core;
using Sagan.Specs;
using Specs.Core;

public static class ProductionBoxSpec
{
  public static Spec New() =>
    new ControlBoxSpec(
      boxName: "Production",
      boxTitle: "PRODUCTION",
      children: Spec.List(
        new ProductionItemSpec(UnitType.Probe),
        new ProductionItemSpec(UnitType.Extractor),
        new ProductionItemSpec(UnitType.Refinery),
        new ProductionItemSpec(UnitType.Autofactory)));
}