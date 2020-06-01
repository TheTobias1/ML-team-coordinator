using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : Item
{
    public abstract void Fry();

    public abstract void Boil();

    public abstract void Roast();

    public abstract void Prep();
}
