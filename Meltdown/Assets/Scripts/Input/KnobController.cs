using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobController : MonoBehaviour
{
    [SerializeField]
    private float setControlValue;
    public float incrementValue;
    private float orgControlValue;
    private float orgRotValue;
    public enum ControlValue
    {
        Amplitude,
        Frequency,
        Phase,
    }
    public Grapher1 graph;
    public ControlValue controlValue;
    Vector3 startPos;
    Vector3 mousePos;
    bool isDragging;
    [SerializeField]
    private float mul;
    [SerializeField]
    private float noOfDiscreteValues;
    private float turnAngle;
    private float nearestValue;
    private float rotateValue;
    //public float incrementValue;
    private float delta;
    void Awake()
    {
        switch (controlValue)
        {
            case ControlValue.Amplitude:
                Grapher1._amplitude = setControlValue;
                Debug.Log(Grapher1._amplitude);
                break;
            case ControlValue.Frequency:
                Grapher1._frequency = setControlValue;
                Debug.Log(Grapher1._frequency);
                break;
            case ControlValue.Phase:
                Grapher1._phase = setControlValue;
                Debug.Log(Grapher1._phase);
                break;
        }
    }
    void Start()
    {
        delta = 0f;
        orgRotValue = transform.localEulerAngles.x;
        turnAngle = 180f / (noOfDiscreteValues - 1);
        startPos = Input.mousePosition;
    }
    void OnMouseOver()
    {
        delta = 0f;
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
        var controlDelta = (transform.localEulerAngles.x > 180 ? 360 - transform.localEulerAngles.x : transform.localEulerAngles.x) * incrementValue / turnAngle;
        switch (controlValue)
        {
            case ControlValue.Amplitude:
                Grapher1._amplitude = Grapher1.orgAmplitudeValue + controlDelta;
                break;
            case ControlValue.Frequency:
                Grapher1._frequency = Grapher1.orgFrequencyValue + controlDelta;
                break;
            case ControlValue.Phase:
                Grapher1._phase = Grapher1.orgFrequencyValue + controlDelta;
                break;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            //nearestValue = transform.localEulerAngles.x > 0 ? Mathf.Floor(transform.localEulerAngles.x / turnAngle) * turnAngle : Mathf.Ceil(transform.localEulerAngles.x / turnAngle) * turnAngle;
            nearestValue = Mathf.Floor(transform.localEulerAngles.x / turnAngle) * turnAngle;
            transform.localEulerAngles = new Vector3(nearestValue, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        if (isDragging)
        {
            mousePos = Input.mousePosition;
            var dragDelta = (mousePos.x > startPos.x ? -1 : 1) * Vector3.Distance(mousePos, startPos);
            rotateValue = dragDelta * Time.deltaTime;
            transform.Rotate(transform.up, rotateValue, Space.World);
        }
    }
}