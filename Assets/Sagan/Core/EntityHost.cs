using System;
using Sagan.Specs;
using Specs.Core;
using Specs.Generated;
using UnityEngine;

namespace Sagan.Core
{
  public class EntityHost : MonoBehaviour
  {
    public Res Res;
    private CompositeSpec _spec;
 
    public void OnEnable()
    {
      _spec = Create();
      _spec.LoadRoot(Res, gameObject);
    }
 
    private static CompositeSpec Create() =>
      new OverlayCanvasSpec(
        Spec.List<Spec>(
          new ControlWindowSpec(
            windowName: "Pxxxccxcvroduction",
            windowTitle: "AUTOFACTORY 003",
            children: Spec.List(
              new ControlBoxSpec(
                boxName: "Production",
                boxTitle: "PRODUCTION",
                children: Spec.List<Spec>(
                  new ProductionItemSpec(UnitType.Probe)))))));
  }
}