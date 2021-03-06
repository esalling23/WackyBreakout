﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "configData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 200;
    static float ballDeathTime = 15;
    static float ballSpawnTimeMin = 5;
    static float ballSpawnTimeMax = 10;
    static float standardBlockPoints = 50;
    static float bonusBlockPoints = 150;
    static float pickupBlockPoints = 10;
    static float freezerEffectTime = 2;
    static float speedupEffectTime = 4;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
        set { paddleMoveUnitsPerSecond = value; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }
        set { ballImpulseForce = value; }
    }

    /// <summary>
    /// Gets the ball's life time length
    /// </summary>
    /// <value>ball death time</value>
    public float BallDeathTime
    {
        get { return ballDeathTime; }
        set { ballDeathTime = value; }
    }

    /// <summary>
    /// Gets the minimum time between ball spawns
    /// </summary>
    /// <value>ball spawn time</value>
    public float BallSpawnTimeMin
    {
        get { return ballSpawnTimeMin; }
        set { ballSpawnTimeMin = value; }
    }

    /// <summary>
    /// Gets the maximum time between ball spawns
    /// </summary>
    /// <value>ball spawn time</value>
    public float BallSpawnTimeMax
    {
        get { return ballSpawnTimeMax; }
        set { ballSpawnTimeMax = value; }
    }

    /// <summary>
    /// Gets the point value for standard blocks
    /// </summary>
    /// <value>point value</value>
    public float StandardBlockPoints
    {
        get { return standardBlockPoints; }
        set { standardBlockPoints = value; }
    }

    /// <summary>
    /// Point value for bonus blocks
    /// </summary>
    /// <value>point value</value>
    public float BonusBlockPoints
    {
        get { return bonusBlockPoints; }
        set { bonusBlockPoints = value; }
    }

    /// <summary>
    /// Point value for pickup blocks
    /// </summary>
    /// <value>point value</value>
    public float PickupBlockPoints
    {
        get { return pickupBlockPoints; }
        set { pickupBlockPoints = value; }
    }

    /// <summary>
    /// Length in seconds of the freezer block effect
    /// </summary>
    /// <value>time in seconds</value>
    public float FreezerEffectTime
    {
        get { return freezerEffectTime; }
        set { freezerEffectTime = value; }
    }

    /// <summary>
    /// Length in seconds of the speedup block effect
    /// </summary>
    /// <value>time in seconds</value>
    public float SpeedupEffectTime
    {
        get { return speedupEffectTime; }
        set { speedupEffectTime = value; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;

        try
        {

            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            string names = input.ReadLine();
            string values = input.ReadLine();

            SetConfigurationData(names.Split(','), values.Split(','));
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    #endregion

    #region Methods

    void SetConfigurationData(string[] names, string[] values)
    {
        for (int i = 0; i < names.Length; i++)
        {
            // Get the property setter on this class & set the value
            this.GetType().GetProperty(names[i]).SetValue(this, float.Parse(values[i]));
            // Debug.Log(this.GetType().GetProperty(names[i]).GetValue(this));
        }
    }

    #endregion
}
