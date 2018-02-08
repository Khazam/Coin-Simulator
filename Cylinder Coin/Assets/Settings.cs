using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static GameObject myGameObject;
    public static float ratio, randomness, time_scale, flip_rate;
    public static int number_of_flips;

    void Start()
    {
        if (myGameObject == null)
        {
            DontDestroyOnLoad(gameObject);
            myGameObject = gameObject;
            ratio = randomness = time_scale = flip_rate = 0;
            number_of_flips = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static bool ready()
    {
        if (ratio <= 0 || number_of_flips <= 0 || randomness <= 0 || time_scale <= 0 || flip_rate <= 0)
        {
            return false;
        }

        return true;
    }
}
