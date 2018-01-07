using UnityEngine;
using System;

public abstract class SaganComponent : MonoBehaviour
{
    protected Root Root { get; private set; }

    /// <summary>
    /// Sets the root object for this component. ONLY Root itself can invoke this method!
    /// </summary>
    /// <param name="root"></param>
    public void SetRoot(Root root)
    {
      if (Root != null)
      {
          throw new InvalidOperationException("Root already set!");
      }
      Root = root;
    }

    /// <summary>
    /// Method which is synchronously invoked immediately after the prefab containing this component
    /// is instantiated. ONLY the Root object should invoke this method!
    /// </summary>
    public virtual void OnCreate()
    {

    }
}
