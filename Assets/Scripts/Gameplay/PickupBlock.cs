using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct PickupBlockSprites
{
    public PickupType type;
    public Sprite sprite;
}

/// <summary>
/// Block that provides pickup effects
/// </summary>
public class PickupBlock : Block
{
    #region Fields
    [SerializeField]
    PickupBlockSprites[] pickupBlockSprites;
    PickupType effect;

    float effectTime;
    #endregion

    #region Properties
    public PickupType Effect
    {
        set {
            effect = value;

            int spriteIndex = Array.FindIndex(pickupBlockSprites, row => row.type == effect);
            
            spriteRenderer.sprite = pickupBlockSprites[spriteIndex].sprite;

            switch (effect)
            {
                case PickupType.Freezer:
                    effectTime = ConfigurationUtils.FreezerEffectTime;
                    break;

                case PickupType.Speedup:
                    effectTime = ConfigurationUtils.SpeedupEffectTime;
                    break;
            }
        }
    }
    #endregion

    #region Methods
    new void Start()
    {
        health = 50;
        points = (int)ConfigurationUtils.PickupBlockPoints;

        // Base start should be invoked before setting the Effect
        // since the base Start sets the spriteRenderer field value
        base.Start();

        int ran = UnityEngine.Random.Range(0, pickupBlockSprites.Length);
        Effect = pickupBlockSprites[ran].type;
    }

    new void OnCollisionEnter2D(Collision2D collision)
    {
        // If the game object we collided w/ has a tag "Ball"
        if (collision.gameObject.tag == "Ball")
        {
            Dictionary<string, object> eventData = new Dictionary<string, object> { { "time", effectTime } };

            print(effect);
            switch (effect)
            {
                case PickupType.Freezer:
                    EventManager.TriggerEvent(EventName.FreezerEffectActivated, eventData);
                    break;

                case PickupType.Speedup:
                    EventManager.TriggerEvent(EventName.SpeedupEffectActivated, eventData);
                    break;
            }

            Destroy(gameObject);
        }
    }

    #endregion
}
