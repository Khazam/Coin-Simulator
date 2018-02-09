using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static float forceNoise = 0.1f;
    public static Vector3 forceDirectionNoise = new Vector3(0.1f, 0.1f, 0.1f);
    public static float force;
    public bool manual = false, flip = false;
    public Transform forcePoint;
    [SerializeField] Rigidbody rigi;
    public static DataCollector dc;
    private float cylendaerModelCorrection = 0.5f;

    // Use this for initialization
    void Start()
    {
        if (dc == null)
        {
            dc = GameObject.FindGameObjectWithTag("dataCollector").GetComponent<DataCollector>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (manual)
        {
            if (flip)
            {
                runFlip();
                flip = false;
            }
        }
    }

    internal void setWidth(float coinWidth, float ratio)
    {
        Vector3 s = new Vector3(ratio * coinWidth, cylendaerModelCorrection * coinWidth, ratio * coinWidth);
        transform.localScale = s;
    }

    public void runFlip()
    {
        Vector3 randDir = new Vector3(UnityEngine.Random.Range(-forceDirectionNoise.x, forceDirectionNoise.x), UnityEngine.Random.Range(-forceDirectionNoise.y, forceDirectionNoise.y), UnityEngine.Random.Range(-forceDirectionNoise.z, forceDirectionNoise.z));
        rigi.AddForceAtPosition((Vector3.up + randDir).normalized * (force + force * UnityEngine.Random.Range(-forceNoise, forceNoise)), forcePoint.position);
    }

    internal void setDensity(float coinDensity)
    {
        //rigi.SetDensity(coinDensity);
        rigi.mass = coinDensity * (transform.localScale.x / 2) * (transform.localScale.x / 2) * Mathf.PI * (transform.localScale.y * 2);
    }

    internal void setElasticity(float coinElasticity)
    {
        MeshCollider mc = GetComponent<MeshCollider>();
        mc.material.bounciness = coinElasticity;
    }
}
