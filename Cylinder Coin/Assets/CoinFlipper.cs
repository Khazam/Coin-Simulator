using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFlipper : MonoBehaviour
{
    public GameObject coin;
    public float coinWidth = 2.828427f, radiusToWidthRatio = 0.3535534f;
    public int NumberOfCoins = 10;
    public float rate = 0.5f;
    private float timer = 0;
    private int counter = 0;
    public float force = 10000, forceNoise = 0.1f;
    public Vector3 forceDirectionNoise;

    // Update is called once per frame

    private void Start()
    {
        Coin.force = force;
        Coin.forceNoise = forceNoise;
        Coin.forceDirectionNoise = forceDirectionNoise;
        Time.timeScale = 10;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > rate && counter < NumberOfCoins)
        {
            counter++;
            timer -= rate;
            GameObject g = Instantiate(coin);
            g.transform.position = transform.position;

            Coin temp = g.GetComponent<Coin>();
            temp.setWidth(coinWidth, radiusToWidthRatio);
            temp.runFlip();
        }

    }
}
