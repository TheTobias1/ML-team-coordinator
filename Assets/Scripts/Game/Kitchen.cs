using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    public GameObject fridge;

    public List<Item> kitchenInventory = new List<Item>();
    public List<Item> rawIngredients = new List<Item>();

    //will find an item and return it
    public Item FindItemByName(string key)
    {
        Item itemBuffer = null;
        foreach(Item i in kitchenInventory)
        {
            if(!i.inUse && key == i.GetKey())
            {
                itemBuffer = i;
                break;
            }
        }

        if(itemBuffer != null)
        {
            kitchenInventory.Remove(itemBuffer);
        }
        return itemBuffer;
    }

    public bool IsRawIngredient(string key)
    {
        foreach(Item i in rawIngredients)
        {
            if(i.GetKey() == key)
            {
                return true;
            }
        }

        return false;
    }

    public Item SpawnRawIngredient(string key)
    {
        foreach (Item i in rawIngredients)
        {
            if (i.GetKey() == key)
            {
                return Instantiate(i, Vector3.zero, Quaternion.identity);
            }
        }

        return null;
    }


}
