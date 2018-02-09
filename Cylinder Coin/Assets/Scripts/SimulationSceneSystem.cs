using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulationSceneSystem : MonoBehaviour
{

    public void back()
    {
        SceneManager.LoadScene("Main");//I really should change the scene name
    }
}
