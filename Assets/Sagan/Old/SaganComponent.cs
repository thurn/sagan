using UnityEngine;
using System;

public abstract class SaganComponent : MonoBehaviour
{
    private Root _root;

    public Root Root
    {
        get
        {
            if (_root == null)
            {
                throw new InvalidOperationException("Component does not have a Root! " + this);
            }
            return _root;
        }
        set
        {
            if (_root != null)
            {
                throw new InvalidOperationException("Root already set!");
            }
            _root = value;
        }
    }

    /// <summary>
    /// Method which is synchronously invoked immediately after the prefab containing this component
    /// is instantiated. ONLY the Root object should invoke this method!
    /// </summary>
    public void CallOnCreateFromRoot()
    {
        if (_root == null)
        {
            throw new InvalidOperationException("Component instantiated without a Root! " + this);
        }

        OnCreate();
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