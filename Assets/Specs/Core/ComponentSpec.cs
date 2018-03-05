using System.Collections.Generic;
using System.Text;
using Specs.Generated;
using UnityEngine;

namespace Specs.Core
{
  public abstract class ComponentSpec<T> : Spec<T> where T: Component
  { 
    protected override T Mount(Res res, GameObject parent, bool reuseFromCache)
    {
      var instance = GetComponent(parent);

      if (instance == null)
      {
        return AddComponent(parent);
      }

      return instance;
    }

    public sealed override void AddChildHashes(LinkedList<byte[]> children) => 
      children.AddLast(Encoding.UTF8.GetBytes(Name));

    protected sealed override void Update(Res res, GameObject parent)
    {
      var instance = parent.GetComponent<T>();
      UpdateComponent(res, instance);
    }
 
    protected abstract void UpdateComponent(Res res, T instance);

    protected virtual T GetComponent(GameObject gameObject) =>
      gameObject.GetComponent<T>();

    protected virtual T AddComponent(GameObject gameObject) =>
      gameObject.AddComponent<T>();
  }
}