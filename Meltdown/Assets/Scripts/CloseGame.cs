using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGame : MonoBehaviour {

	void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("I CANT ESCAPE HELP!!!");
            Application.Quit();

        }

    }
    public void Close()
    {
        Debug.Log("I CANT ESCAPE HELP!!!");
        Application.Quit();
    }
}
