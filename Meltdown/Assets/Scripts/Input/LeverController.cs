using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public float mul;
    private Vector3 startPos;
    private Vector3 mousePos;
    private bool isDragging;
    private bool isPullingUp;
    private bool isPullingDown;
    private int currentStateIndex;
    public int maxStateIndex;
    private Vector3 leverStartPos;
    private Vector3 leverEndPos;
    private float pullTimer;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isDragging)
            {
                isDragging = true;
                startPos = Input.mousePosition;
            }
        }
    }
    void Update()
    {
        var rot = transform.localEulerAngles.x;
        if (rot > 180)
        {
            rot %= 360; rot -= 360;
        }
        if (rot > 2 || rot < -2)
        {
            isDragging = false;
        }
        //transform.localEulerAngles = new Vector3(Mathf.Clamp(transform.localEulerAngles.x, -2f, 2f), transform.localEulerAngles.y, transform.localEulerAngles.y);
        if (isDragging)
        {
            mousePos = Input.mousePosition;
            mousePos = Input.mousePosition;
            var dragDelta = (mousePos.y > startPos.y ? -1 : 1) * Vector3.Distance(mousePos, startPos);
            transform.Rotate(transform.right, dragDelta * Time.deltaTime * mul, Space.World);
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            
            if (rot > 180)
            {
                rot %= 360; rot -= 360;
            }
            if (rot < -1f)
            {
                transform.localEulerAngles = new Vector3(-2, transform.localEulerAngles.y, transform.localEulerAngles.z);
                Grapher1.particleColor = new Color(1f, 0f, 0f);
            }
            else if (rot < 1f)
            {
                transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, transform.localEulerAngles.z);
                Grapher1.particleColor = new Color(0f, 1f, 0f);
            }
            else
            {
                transform.localEulerAngles = new Vector3(2, transform.localEulerAngles.y, transform.localEulerAngles.z);
                Grapher1.particleColor = new Color(0f, 0f, 1f);
            }
        }
    }

    //IEnumerator PullUp()
    //{
    //    if (!isPullingUp && !isPullingDown && currentStateIndex < maxStateIndex)
    //    {
    //        isPullingUp = true;
    //        currentStateIndex++;
    //        leverStartPos = transform.localEulerAngles;
    //        leverEndPos = new Vector3(transform.localEulerAngles.x - 2f, transform.localEulerAngles.y, transform.localEulerAngles.z);
    //        yield return new WaitForSeconds(waitTime);
    //        isPullingUp = false;
    //        pullTimer = 0f;
    //    }
    //}
    //IEnumerator PullDown()
    //{
    //    if (!isPullingDown && !isPullingUp && currentStateIndex > -maxStateIndex)
    //    {
    //        isPullingDown = true;
    //        currentStateIndex--;
    //        leverStartPos = transform.localEulerAngles;
    //        leverEndPos = new Vector3(transform.localEulerAngles.x + 2f, transform.localEulerAngles.y, transform.localEulerAngles.z);
    //        yield return new WaitForSeconds(waitTime);
    //        isPullingDown = false;
    //        pullTimer = 0f;
    //    }
    //}
}
