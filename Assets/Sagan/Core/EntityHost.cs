using System.Collections.Immutable;
using Sagan.Specs;
using Specs.Core;
using Specs.Generated;
using UnityEngine;

namespace Sagan.Core
{
  public class EntityHost : MonoBehaviour
  {
    public Res Res;
    private GameObject _root;

    public void Start()
    {
      var spec = Create();
      _root = spec.Mount(Res, gameObject);
    }

    private static CompositeSpec Create() =>
      new OverlayCanvasSpec(
        ImmutableList.Create<ISpec>(
          new ControlWindowSpec(
            windowName: "ProductionWindow",
            windowTitle: "AUTOFACTORY 001",
            children: ImmutableList.Create(
              new ControlBoxSpec(
                boxName: "Production",
                boxTitle: "PRODUCTION",
                height: 750f)))));
  }
}