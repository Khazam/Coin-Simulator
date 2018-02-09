using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static GameObject myGameObject;
    public static float ratio, randomness, force, time_scale, flip_rate, coin_density, coin_elasticity, surface_static_friction, surface_dynamic_friction;
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
        if (ratio <= 0 || number_of_flips <= 0 || randomness < 0 || force <= 0 || time_scale <= 0 || flip_rate <= 0 || coin_density <= 0 || surface_dynamic_friction < 0 || surface_static_friction < 0 || coin_elasticity < 0 || coin_elasticity > 1)
        {
            return false;
        }

        return true;
    }
}
