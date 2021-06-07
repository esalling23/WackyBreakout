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
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the force of the ball
    /// </summary>
    /// <value>ball force</value>
    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    /// <summary>
    /// Gets the length of time a ball should live for
    /// </summary>
    /// <value>ball death time</value>
    public static float BallDeathTime
    {
        get { return configurationData.BallDeathTime; }
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
