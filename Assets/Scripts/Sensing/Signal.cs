using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Signal
{
    public float strength;
    public Vector3 position;
    public Modality modality;

    public Signal(float _strength, Vector3 _pos, Modality _mode)
    {
        strength = _strength;
        position = _pos;
        modality = _mode;
    }
}

