using Specs.Generated;
using Specs.Util;
using UnityEngine;

namespace Specs.Core
{
  public abstract class BehaviourSpec<T> : ComponentSpec<T> where T: Behaviour
  {
    protected sealed override T Mount(Res res, GameObject parent)
    {
      var instance = parent.GetComponent<T>();
      if (instance == null)
      {
        return AddComponent(parent);
      }

      if (instance.enabled)
      {
        throw Errors.DuplicateChild(parent.name, Name);
      }

      instance.enabled = true;
      return instance;
    }
  }
}