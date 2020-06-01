using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoResource : BoilableResource
{
    public bool roasted;
    public bool mashed;

    public override void Fry()
    {
        Waste();
    }

    public override void Boil()
    {
        if(!roasted)
        {
            boiled = true;
        }
        else
        {
            Waste();
        }
    }

    public override void Roast()
    {
        if(!mashed)
        {
            roasted = true;
        }
        else
        {
            Waste();
        }
    }

    public override void Prep()
    {
        if (boiled)
        {
            mashed = true;
        }
        else
        {
            Waste();
        }
    }

    public override string GetKey()
    {
        string original = base.GetKey();
        
        if(roasted)
        {
            return "roasted_" + original;
        }

        if(mashed)
        {
            return "mashed_" + original;
        }

        if(boiled)
        {
            return "boiled_" + original;
        }

        return original;
    }
}
