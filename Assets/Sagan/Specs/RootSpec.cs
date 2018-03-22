using Sagan.Specs;
using Specs.Core;

public static class RootSpec
{
  public static CompositeSpec New() =>
    new OverlayCanvasSpec(
     Spec.List(new ControlWindowSpec(
       windowName: "Production",
       windowTitle: "AUTOFACTORY 123",
       children: Spec.List(
         ProductionBoxSpec.New()))));
}