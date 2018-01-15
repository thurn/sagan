using UnityEngine;
using System;

public abstract class SaganComponent : MonoBehaviour
{
    public bool Initialized { get; private set; }

    protected Root Root { get; private set; }

    /// <summary>
    /// Sets the root object for this component. ONLY Root itself can invoke this method!
    /// </summary>
    /// <param name="root"></param>
    public void SetRootFromRoot(Root root)
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
    public void CallOnCreateFromRoot()
    {
        if (Root == null)
        {
            throw new InvalidOperationException("Component instantiated without a Root! " + this);
        }

        OnCreate();
        Initialized = true;
    }

    /// <summary>
    /// Initialization method for Sagan Components. Unlike Unity's Start() and Awake()
    /// methods, this method is guaranteed to be invoked *after* the component has a root
    /// but *before* Root.InstatiatePrefab() returns.
    /// </summary>
    protected virtual void OnCreate()
    {
    }

    protected void Awake()
    {
    }

    protected void Start()
    {
    }
}