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
    [HideInInspector] private GameObject _root;
 
    public void OnEnable()
    {
      _spec = Create();
      if (_root == null)
      {
        _root = _spec.MountRoot(Res, gameObject);
        _spec.PerformUpdate(Res, gameObject);
      }
      else
      {
        try
        {
          _spec.PerformUpdate(Res, gameObject);
        }
        catch (Exception e)
        {
          Debug.LogError(e.Message);
          Debug.Log(message: "Failed to update spec, attempting full rebuild");
          DestroyImmediate(_root);
          _root = _spec.MountRoot(Res, gameObject);
        }
      }
    }

    private static CompositeSpec Create() =>
      new OverlayCanvasSpec(
        Spec.List<ISpec>(
          new ControlWindowSpec(
            windowName: "Production",
            windowTitle: "AUTOFACTORY 002",
            children: Spec.List<ControlBoxSpec>())));
 
//            children: Spec.List(
//              new ControlBoxSpec(
//                boxName: "Production",
//                boxTitle: "PRODUCTION",
//                children: Spec.List<ISpec>(
//                  new ProductionItemSpec(UnitType.Probe)))))));
  }
}