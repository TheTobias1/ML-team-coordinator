using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilableResource : Resource
{
    public bool boiled;

    public override void Fry()
    {
        if(!boiled)
        {
            Waste();
        }
    }

    public override void Boil()
    {
        boiled = true;
    }

    public override void Roast()
    {
        Waste();
    }

    public override void Prep()
    {
        Waste();
    }

    public override string GetKey()
    {
        if(boiled)
        {
            return "boiled_" + base.GetKey();
        }
        else
        {
            return base.GetKey();
        }
    }
}
