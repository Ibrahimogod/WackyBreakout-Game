using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils
{
    
    public static bool SpeedActivated { get => Camera.main.GetComponent<SpeedupEffectMonitor>().SpeedUpActivated; }
    public static float TimeLeft { get => Camera.main.GetComponent<SpeedupEffectMonitor>().SpeedTimeLeft; }
}
