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
    [SerializeField] private string _lastSpecHash;
 
    public void OnEnable()
    {
      _spec = Create();
      var specHash = _spec.GetStructuralHash();
      _spec.LoadRoot(Res, gameObject, reuseFromCache: specHash == _lastSpecHash);
      _lastSpecHash = specHash;
    }
 
    private static CompositeSpec Create() =>
      new OverlayCanvasSpec(
        Spec.List<Spec>(
          new ControlWindowSpec(
            windowName: "Production",
            windowTitle: "AUTOFACTORY 123",
            children: Spec.List(
              new ControlBoxSpec(
                boxName: "Production",
                boxTitle: "PRODUCTION",
                children: Spec.List<Spec>(
                  new ProductionItemSpec(UnitType.Probe)))))));
  }
}