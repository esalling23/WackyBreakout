using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class EffectUtils
{
    #region Fields

    // For Speedup Effect support
    static SpeedupEffectManager speedupEffectManager;

    #endregion

    #region Properties

    /// <summary>
    /// Gets whether or not the speedup effect is active
    /// </summary>
    public static bool SpeedupActive
    {
        get { return speedupEffectManager.SpeedupActive; }
    }

    /// <summary>
    /// Gets the speed increase balls should have during the speedup effect
    /// </summary>
    public static float SpeedupFactor
    {
        get { return speedupEffectManager.SpeedupFactor; }
    }

    /// <summary>
    /// Gets the time remaining in the active speedup effect timer
    /// </summary>
    /// <value></value>
    public static float SpeedupTimeLeft
    {
        get { return speedupEffectManager.SpeedupTimeLeft; }
    }

    #endregion

    #region Methods

    public static void Initialize()
    {
        speedupEffectManager = GameObject.Find("GameManager").GetComponent<SpeedupEffectManager>();
    }

    #endregion
}
