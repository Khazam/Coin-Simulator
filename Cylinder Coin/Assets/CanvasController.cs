using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Text head, tale,side;
    // Update is called once per frame
    void Update()
    {
        head.text = DataCollector.head + "";
        tale.text = DataCollector.tale + "";
        side.text = DataCollector.side + "";
    }
}
