using System.Collections.Generic;
using UnityEngine;
public class Sensor
{
    public bool blind = false;
    public bool deaf = false;
    public bool anosmic = false;

    public float threshold;
    
    public Vector3 position;

    public Sensor()
    {
    }

    public bool DetectsModality(Modality mode)
    {
        if (mode.GetType() == typeof(Sound))
        {
            return !deaf;
        }
        else
        {
            return true;
        }
    }

    public void notify(Signal sig)
    {

    }
}
