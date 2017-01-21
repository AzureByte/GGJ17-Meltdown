using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
    public string NameOfLevelToLoad;
	// Use this for initialization

    public void Load()
    {
        SceneManager.LoadScene(NameOfLevelToLoad);
    }

}
