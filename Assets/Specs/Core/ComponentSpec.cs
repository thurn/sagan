using Specs.Generated;
using UnityEngine;

namespace Specs.Core
{
  public abstract class ComponentSpec<T> : Spec<T> where T: Component
  { 
    protected override T Mount(Res res, GameObject parent)
    {
      // TODO: Handle the component being removed from the spec.
      var instance = parent.GetComponent<T>();

      if (instance == null)
      {
        return parent.AddComponent<T>();
      }

      return instance;
    }
 
    protected sealed override void Update(Res res, GameObject parent)
    {
      var instance = parent.GetComponent<T>();
      UpdateComponent(res, instance);
    }
 
    protected abstract void UpdateComponent(Res res, T instance);

    protected virtual T AddComponent(GameObject gameObject) =>
      gameObject.AddComponent<T>();
  }
}