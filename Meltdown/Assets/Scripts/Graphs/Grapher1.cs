﻿using UnityEngine;

public class Grapher1 : MonoBehaviour
{
    //public float amplitude;
    //public float frequency;
    //public float phase;
    public static float _amplitude;
    public static float _frequency;
    public static float _phase;
    public bool isPitchShift;
    public float randomMaxShift;
    public static float _randomMaxShift;
    public const float phaseExtension = 0;
    [HideInInspector]
    public static float orgAmplitudeValue;
    [HideInInspector]
    public static float orgFrequencyValue;
    [HideInInspector]
    public static float orgPhaseValue;
    public enum FunctionOption
    {
        Sine,
        SinePitch
    }
    private delegate float FunctionDelegate(float x);
    private FunctionDelegate[] functionDelegates = 
    {
		Sine,
        SinePitch
	};
    public FunctionOption function;
    [Range(10, 900)]
    public int resolution = 10;
    private ParticleSystem particleSystem;
    private int currentResolution;
    private ParticleSystem.Particle[] points;

    void Start()
    {
        _randomMaxShift = randomMaxShift;
        particleSystem = GetComponent<ParticleSystem>();
        orgAmplitudeValue = _amplitude;
        orgFrequencyValue = _frequency;
        orgPhaseValue = _phase;
    }
    private void CreatePoints()
    {
        currentResolution = resolution;
        points = new ParticleSystem.Particle[resolution];
        float increment = 1f / (resolution - 1);
        for (int i = 0; i < resolution; i++)
        {
            float x = i * increment;
            points[i].position = new Vector3(x, 0f, 0f);
            points[i].color = new Color(1f, 1f, 1f);
            points[i].size = 0.1f;
        }
    }

    void Update()
    {
        if (currentResolution != resolution || points == null)
        {
            CreatePoints();
        }
        if (isPitchShift)
        {
            function = FunctionOption.SinePitch;
        }
        FunctionDelegate f = functionDelegates[(int)function];
        for (int i = 0; i < resolution; i++)
        {
            Vector3 p = points[i].position;
            p.y = f(p.x);
            points[i].position = p;
            //Color c = points[i].color;
            //c.g = p.y;
            //points[i].color = c;
        }
        particleSystem.SetParticles(points, points.Length);
    }
    //private static float Linear(float x)
    //{
    //    return x;
    //}

    //private static float Exponential(float x)
    //{
    //    return x * x;
    //}

    //private static float Parabola(float x)
    //{
    //    x = 2f * x - 1f;
    //    return x * x;
    //}

    private static float Sine(float x)
    {
        return _amplitude * Mathf.Sin(2 * Mathf.PI * x * _frequency + _phase) + Random.Range(0f, _randomMaxShift);
        //return 0.5f + 0.5f * Mathf.Sin(2 * Mathf.PI * x + Time.timeSinceLevelLoad);
    }
    private static float SinePitch(float x)
    {
        return _amplitude * Mathf.Sin(2 * Mathf.PI * x * _frequency + _phase + Mathf.PI / 2) + Random.Range(0f, _randomMaxShift);
        //return 0.5f + 0.5f * Mathf.Sin(2 * Mathf.PI * x + Time.timeSinceLevelLoad);
    }
    private static float SquareWave(float x)
    {
        if (x > 0)
        {

        }
        else if (x == 0)
        {

        }
        else
        {
            
        }

        return 0f;
    }
}