using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
    public bool isOpen = false;
    public bool Open = false;

	void onMouseOver()
    {
        Debug.Log("MousedOver");
        if (Input.GetMouseButton(0)) {
            Debug.Log("Clicked!");
            this.gameObject.transform.position = Vector3.up*3;
        }
    }
}