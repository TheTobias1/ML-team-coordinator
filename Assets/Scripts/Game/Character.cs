using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Kitchen kitchen;

    public List<Item> inventory = new List<Item>();
    public Dictionary<string, Item> itemMemory = new Dictionary<string, Item>();

    private void Start()
    {
        FindItemByName("green");
        Debug.Log(itemMemory.ToString());
        StartCoroutine(PickupItemByName("red"));
    }

    public bool Goto(Vector3 position, float delta, bool snap = true)
    {
        position.y = transform.position.y;
        
        if (Vector3.Distance(transform.position, position) > 1f)
        {
            Vector3 vel = position - transform.position;
            vel *= delta;

            vel = Vector3.ClampMagnitude(vel, 5 * delta);

            transform.Translate(vel, Space.World);
            transform.LookAt(position);

            return false;
        }
        else
        {
            if(snap)
            {
                transform.position = position;
                transform.rotation = Quaternion.identity;
            }

            return true;
        }
    }

    public void Pickup(Item i)
    {
        inventory.Add(i);
        i.transform.parent = transform;
        i.transform.localPosition = new Vector3(0, 1.5f, 0);
    }

    #region Actions

    public void FindItemByName(string n)
    {
        Item i = kitchen.FindItemByName(n);

        if(i != null)
        {
            if(itemMemory.ContainsKey(n))
            {
                itemMemory[n] = i;
            }
            else
            {
                itemMemory.Add(n, i);
            }
        }
    }

    public IEnumerator PickupItemByName(string n)
    {
        bool rawIngredient = kitchen.IsRawIngredient(n);
        GameObject target = null;
        Item itemObject = null;

        //locate

        if (rawIngredient)
        {
            target = kitchen.fridge;
        }
        else
        {
            if(itemMemory.ContainsKey(n))
            {
                itemObject = itemMemory[n];
                target = itemObject.gameObject;
            }
        }

        //goto

        float delta = Time.deltaTime;
        float timeStamp = Time.time;

        if(target != null)
        {
            bool arrived = Goto(target.transform.position, delta, false);
            yield return null;

            while(!arrived)
            {
                delta = Time.time - timeStamp;
                timeStamp = Time.time;
                arrived = Goto(target.transform.position, delta, false);
                yield return null;
            }

            //pickup

            if (rawIngredient)
            {
                itemObject = kitchen.SpawnRawIngredient(n);
            }

            if (itemObject != null)
            {
                Pickup(itemObject);
            }
        }

    }

    #endregion
}
