using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

abstract public class Modality
{
    public float maxRange;
    public float attenuation;
    public float inverseTransmissionSpeed;

    public Modality(float range, float atten, float speed)
    {
        maxRange = range;
        attenuation = atten;
        inverseTransmissionSpeed = 1.0f / speed;
    }

    public abstract bool extraChecks(Signal signal, Sensor sensor);
}

public class Sound : Modality
{
    public Sound(float range, float atten, float speed) : base(range, atten, speed)
    {
    }

    public override bool extraChecks(Signal signal, Sensor sensor)
    {
        return !sensor.deaf;
    }
}