using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSystem : MonoBehaviour
{
    //    private Settings settings;
    [SerializeField]
    private InputField ratio, number_of_flips, randomness, time_scale, flip_rate;

    private void Start()
    {
        if (Settings.ratio > 0)
        {
            ratio.text = Settings.ratio + "";
        }
        if (Settings.number_of_flips > 0)
        {
            number_of_flips.text = Settings.number_of_flips + "";
        }
        if (Settings.randomness > 0)
        {
            randomness.text = Settings.randomness + "";
        }
        if (Settings.time_scale > 0)
        {
            time_scale.text = Settings.time_scale + "";
        }
        if (Settings.flip_rate > 0)
        {
            flip_rate.text = Settings.flip_rate + "";
        }
    }

    public void exit()
    {
        Application.Quit();
    }

    public void startSimulation()
    {
        float.TryParse(ratio.text, out Settings.ratio);
        int.TryParse(number_of_flips.text, out Settings.number_of_flips);
        float.TryParse(randomness.text, out Settings.randomness);
        float.TryParse(time_scale.text, out Settings.time_scale);
        float.TryParse(flip_rate.text, out Settings.flip_rate);

        if (Settings.ready())
        {
            SceneManager.LoadScene("Test");//I really should change the scene name
        }
        else
        {
            Debug.Log(Settings.ratio + ":" + Settings.number_of_flips + ":" + Settings.randomness + ":" + Settings.time_scale + ":" + Settings.flip_rate);
        }
    }
}
