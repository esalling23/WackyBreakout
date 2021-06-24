using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Fields

    static ConfigurationData configurationData;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the force of the ball
    /// </summary>
    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    /// <summary>
    /// Gets the length of time a ball should live for
    /// </summary>
    public static float BallDeathTime
    {
        get { return configurationData.BallDeathTime; }
    }

    /// <summary>
    /// Gets the min length of time between ball spawns
    /// </summary>
    public static float BallSpawnTimeMin
    {
        get { return configurationData.BallSpawnTimeMin; }
    }

    /// <summary>
    /// Gets the max length of time between ball spawns
    /// </summary>
    public static float BallSpawnTimeMax
    {
        get { return configurationData.BallSpawnTimeMax; }
    }

    /// <summary>
    /// Gets the points for destroying a standard block
    /// </summary>
    public static float StandardBlockPoints
    {
        get { return configurationData.StandardBlockPoints; }
    }

    /// <summary>
    /// Gets the points for destroying a bonus block
    /// </summary>
    public static float BonusBlockPoints
    {
        get { return configurationData.BonusBlockPoints; }
    }

    /// <summary>
    /// Gets the points for destroying a pickup block
    /// </summary>
    public static float PickupBlockPoints
    {
        get { return configurationData.PickupBlockPoints; }
    }

    /// <summary>
    /// Gets the length of time the freezer effect lasts
    /// </summary>
    public static float FreezerEffectTime
    {
        get { return configurationData.FreezerEffectTime; }
    }

    /// <summary>
    /// Gets the length of time the speedup effect lasts
    /// </summary>
    public static float SpeedupEffectTime
    {
        get { return configurationData.SpeedupEffectTime; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }

}
