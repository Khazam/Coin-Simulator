using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFlipper : MonoBehaviour
{
    public GameObject coin;
    public float coinWidth = 1f, radiusToWidthRatio = 1f, coinDensity = 1f, coinElasticity;
    public int NumberOfCoins = 10;
    public float rate = 0.5f;
    private float timer = 0, period;
    private int counter = 0;
    public float force = 10000, forceNoise = 0.1f;
    public Vector3 forceDirectionNoise;
    private float timeSpeed = 1;


    // Update is called once per frame

    private void Start()
    {
        loadSettings();


        Coin.force = force;
        Coin.forceNoise = forceNoise;
        Coin.forceDirectionNoise = forceDirectionNoise;
        Time.timeScale = 1 * timeSpeed;
        period = 1 / rate;
    }

    private void loadSettings()
    {
        rate = Settings.flip_rate;
        radiusToWidthRatio = Settings.ratio;
        NumberOfCoins = Settings.number_of_flips;
        forceNoise = Settings.randomness;
        forceDirectionNoise = new Vector3(Settings.randomness, 0, Settings.randomness);
        timeSpeed = Settings.time_scale;
        coinDensity = Settings.coin_density;
        coinElasticity = Settings.coin_elasticity;

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > period && counter < NumberOfCoins)
        {
            counter++;
            timer -= period;
            GameObject g = Instantiate(coin);
            g.transform.position = transform.position;

            Coin temp = g.GetComponent<Coin>();
            temp.setWidth(coinWidth, radiusToWidthRatio);
            temp.setDensity(coinDensity);
            temp.runFlip();
        }

    }
}
