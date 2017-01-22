using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float[] winValues = {0.5f, 1f, -2f};
    // Update is called once per frame
    void Update()
    {
        if (Grapher1._amplitude == winValues[0] && Grapher1._frequency == winValues[1] && Grapher1._phase == winValues[2])
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
