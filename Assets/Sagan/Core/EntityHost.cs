using Specs.Core;
using Specs.Generated.Resources;
using Specs.Unity.Events;
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
      //var green = transform.Find("OverlayCanvas/TextBox");
      //Debug.Log("Green? " + green);
      //green.gameObject.AddComponent<PointerClickHandlerComponent>();
    }

    private static CompositeSpec Create() => RootSpec.New();
  }
}