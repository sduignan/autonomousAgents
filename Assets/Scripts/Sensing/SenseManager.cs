using UnityEngine;
using System;
using System.Collections.Generic;

public class SenseManager : MonoBehaviour {

    List<Signal> signals;
    aStar pathfinder;
    List<Sensor> sensors;
    List<Notification> notificationQueue;

	// Use this for initialization
	void Start () {
        signals = new List<Signal>();
        notificationQueue = new List<Notification>();
        pathfinder = FindObjectOfType<aStar>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(signals.Count > 0)
        {
            foreach (var signal in signals)
            {
                foreach (var sensor in sensors)
                {
                    if (!sensor.DetectsModality(signal.modality))
                    {
                        continue;
                    }

                    Vector3 difference = signal.position - sensor.position;

                    float distance = difference.magnitude;

                    if(signal.modality.maxRange < distance)
                    {
                        continue;
                    }

                    float intensity = signal.strength * Mathf.Pow(signal.modality.attenuation, distance);
                    if(intensity < sensor.threshold)
                    {
                        continue;
                    }

                    if(!signal.modality.extraChecks(signal, sensor))
                    {
                        continue;
                    }

                    long time = (DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond) + (long)(distance * signal.modality.inverseTransmissionSpeed);
                    Notification note = new Notification();
                    note.time = time;
                    note.sensor = sensor;
                    note.signal = signal;
                    notificationQueue.Add(note);
                }
            }
        }

        sendSignals();
	}

    public void sendSignals()
    {
        long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        foreach(var note in notificationQueue)
        {
            if(note.time <= currentTime)
            {
                note.sensor.notify(note.signal);
                notificationQueue.Remove(note);
            }
        }
    }
}
