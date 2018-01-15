using UnityEngine;

public abstract class SaganService : MonoBehaviour
{
    protected Root Root { get; private set; }

    protected void Awake()
    {
        Root = GetComponent<Root>();
    }
}