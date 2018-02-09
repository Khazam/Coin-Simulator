using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCollector : MonoBehaviour
{
    public static int head = 0, tale = 0, side = 0;
    private int delete_this_head = 0, delete_this_tale = 0, delete_this_side = 0;
    public const int HEAD = 0, TALE = 1, SIDE = 2;
    public Dictionary<int, int> results = new Dictionary<int, int>();
    [SerializeField]
    private BoxCollider table;

    private void Start()
    {
        head = tale = side = 0;
        setFriction(Settings.surface_static_friction, Settings.surface_dynamic_friction);
    }

    private void OnTriggerEnter(Collider other)
    {
        //        Debug.Log("trigger detected: " + other.tag);
        if (!other.CompareTag("Untagged") && results.ContainsKey(other.gameObject.transform.parent.gameObject.GetInstanceID()))
        {
            Debug.Log("trigger id/tag/tag: " + other.gameObject.transform.parent.gameObject.GetInstanceID() + "/" + results[other.gameObject.transform.parent.gameObject.GetInstanceID()] + "/" + other.tag);
        }


        if (other.CompareTag("head"))
        {
            if (results.ContainsKey(other.gameObject.transform.parent.gameObject.GetInstanceID()))
            {
                decreament(results[other.gameObject.transform.parent.gameObject.GetInstanceID()]);
                results[other.gameObject.transform.parent.gameObject.GetInstanceID()] = HEAD;
            }
            else
            {
                results.Add(other.gameObject.transform.parent.gameObject.GetInstanceID(), HEAD);
            }
            head++;
        }
        else if (other.CompareTag("tale"))
        {
            if (results.ContainsKey(other.gameObject.transform.parent.gameObject.GetInstanceID()))
            {
                decreament(results[other.gameObject.transform.parent.gameObject.GetInstanceID()]);
                results[other.gameObject.transform.parent.gameObject.GetInstanceID()] = TALE;
            }
            else
            {
                results.Add(other.gameObject.transform.parent.gameObject.GetInstanceID(), TALE);
            }
            tale++;
        }
        else if (other.CompareTag("side"))
        {
            if (results.ContainsKey(other.gameObject.transform.parent.gameObject.GetInstanceID()))
            {
                decreament(results[other.gameObject.transform.parent.gameObject.GetInstanceID()]);
                results[other.gameObject.transform.parent.gameObject.GetInstanceID()] = SIDE;
            }
            else
            {
                results.Add(other.gameObject.transform.parent.gameObject.GetInstanceID(), SIDE);
            }
            side++;
        }

        delete_this_head = head;
        delete_this_tale = tale;
        delete_this_side = side;
    }

    private void decreament(int id)
    {
        switch (id)
        {
            case HEAD:
                head--;
                break;
            case TALE:
                tale--;
                break;
            case SIDE:
                side--;
                break;
        }
    }

    internal void setFriction(float staticFriction, float dynamicFriction)
    {
        table.material.staticFriction = staticFriction;
        table.material.dynamicFriction = dynamicFriction;
    }


}
