using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    static List<PickupBlock> freezeInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> freezeListeners = new List<UnityAction<float>>();
    static List<PickupBlock> speedInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> speedListeners = new List<UnityAction<float>>();

    public static void AddFreezeInvoker(PickupBlock Invoker)
    {
        freezeInvokers.Add(Invoker);
        foreach(UnityAction<float> listener in freezeListeners)
        {
            Invoker.AddFreezerEffectListener(listener);
        }
    }

    public static void AddFreezeListener(UnityAction<float> Listener)
    {
        freezeListeners.Add(Listener);
        foreach(PickupBlock Invoker in freezeInvokers)
        {
            Invoker.AddFreezerEffectListener(Listener);
        }
    }

    public static void AddSpeedInvoker(PickupBlock Invoker)
    {
        speedInvokers.Add(Invoker);
        foreach(UnityAction<float> listener in speedListeners)
        {
            Invoker.AddSpeedEffectListener(listener);
        }
    }

    public static void AddSpeedListener(UnityAction<float> Listener)
    {
        speedListeners.Add(Listener);
        foreach (PickupBlock Invoker in speedInvokers)
        {
            Invoker.AddSpeedEffectListener(Listener);
        }
    }
}
