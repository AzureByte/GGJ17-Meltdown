using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float[] winValues;
    // Update is called once per frame
    void Update()
    {
        if (Grapher1._amplitude == winValues[0] && Grapher1._frequency == winValues[1] && Grapher1._frequency == winValues[2])
        {

        }
    }
}
