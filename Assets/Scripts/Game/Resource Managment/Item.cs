using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField]
    private string itemKey;
    public bool inUse;

    public void Waste()
    {
        Destroy(gameObject);
    }

    public virtual string GetKey()
    {
        return itemKey;
    }
}
