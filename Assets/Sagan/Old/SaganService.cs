using System;
using UnityEngine;

public abstract class SaganService : MonoBehaviour
{
    protected Root Root { get; private set; }

    protected void Awake()
    {
        Root = GetComponent<Root>();
        if (Root == null)
        {
            throw new InvalidOperationException("Service instantiated without a Root! " + this);
        }
    }
}