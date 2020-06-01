using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppableResource : Resource
{
    public bool chopped;
    public bool cooked;

    public override void Fry()
    {
        if (!chopped)
        {
            cooked = true;
        }
        else
        {
            Waste();
        }
    }

    public override void Boil()
    {
        if(!cooked)
        {
            Waste();
        }
    }

    public override void Roast()
    {
        cooked = true; 
    }

    public override void Prep()
    {
        chopped = true;
    }

    public override string GetKey()
    {
        string original = base.GetKey();
        string additive = "";

        if (cooked)
            additive = "cooked_";

        if (chopped)
            additive += "chopped_";

        return additive + original;
    }
}
