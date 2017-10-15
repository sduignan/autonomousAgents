using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public delegate void Robbery();
    public static event Robbery OnRobbery;
    public static void Rob()
    {
        if(OnRobbery!= null)
        {
            OnRobbery();
        }
    }

    public delegate void LookAround(Tiles loc);
    public static event LookAround OnLooking;

    public static void Look(Tiles location)
    {
        if(OnLooking != null)
        {
            OnLooking(location);
        }
    }

    public delegate void Seeing(AgentTypes type);
    public static event Seeing OnSeeing;

    public static void Seen(AgentTypes type)
    {
        if(OnSeeing != null)
        {
            OnSeeing(type);
        }
    }

    public delegate void Shooting(Tiles loc);
    public static event Shooting OnShooting;

    public static void Shoot(Tiles loc)
    {
        if (OnShooting != null)
        {
            OnShooting(loc);
        }
    }

    public delegate void CorpseCollection();
    public static event CorpseCollection OnCorpseCollection;

    public static void CollectCorpse()
    {
        if (OnCorpseCollection != null)
        {
            OnCorpseCollection();
        }
    }
}