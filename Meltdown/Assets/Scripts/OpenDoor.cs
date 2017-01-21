using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
    public bool isOpen = false;
    public bool Open = false;
    public Animator ani;

	// Update is called once per frame
	void onMouseOver()
    {
        if (Input.GetMouseButton(0)) {
            ani.SetTrigger("OnDoorClick");
        }
    }
}