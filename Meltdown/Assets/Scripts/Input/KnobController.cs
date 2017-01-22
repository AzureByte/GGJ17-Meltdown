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
        Noise
    }
    //public Grapher1 graph;
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
    //public int[] clampValues;
    //private int clampMin;
    //private int clampMax;
    void Awake()
    {
        //clampMin = clampValues[0];
        //clampMax = clampValues[clampValues.Length - 1];
        switch (controlValue)
        {
            case ControlValue.Amplitude:
                Grapher1._amplitude = setControlValue;
                Grapher1.orgAmplitudeValue = setControlValue;
                break;
            case ControlValue.Frequency:
                Grapher1._frequency = setControlValue;
                Grapher1.orgFrequencyValue = setControlValue;
                break;
            case ControlValue.Phase:
                Grapher1._phase = setControlValue;
                Grapher1.orgPhaseValue = setControlValue;
                break;
            case ControlValue.Noise:
                Grapher1._noise = setControlValue;
                Grapher1.orgNoiseValue = setControlValue;
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
                Grapher1._phase = Grapher1.orgPhaseValue + controlDelta;
                break;
            case ControlValue.Noise:
                Grapher1._noise = Grapher1.orgNoiseValue + controlDelta;
                break;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            nearestValue = Mathf.Floor(transform.localEulerAngles.x / turnAngle) * turnAngle;
            transform.localEulerAngles = new Vector3(nearestValue, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        if (isDragging)
        {
            mousePos = Input.mousePosition;
            var dragDelta = (mousePos.x > startPos.x ? -1 : 1) * Vector3.Distance(mousePos, startPos);
            rotateValue = dragDelta * Time.deltaTime;
            transform.Rotate(Vector3.forward, rotateValue, Space.World);
        }
    }
}