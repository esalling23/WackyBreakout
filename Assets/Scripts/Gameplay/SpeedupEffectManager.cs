using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffectManager : MonoBehaviour
{
    Timer fastTimer;
    bool speedupActive;
    float speedupFactor = 5.0f;

    public bool SpeedupActive
    {
        get { return speedupActive; }
    }

    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }

    public float SpeedupTimeLeft
    {
        get { return fastTimer.TimeRemaining; }
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening(EventName.SpeedupEffectActivated, StartFastTimer);

        fastTimer = gameObject.AddComponent<Timer>();

        speedupActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fastTimer.Finished)
        {
            fastTimer.Stop();
            speedupActive = false;
            EventManager.TriggerEvent(EventName.SpeedupEffectEnded, null);
        }
    }

    void StartFastTimer(Dictionary<string, object> msg)
    {
        fastTimer.Run();
        speedupActive = true;
    }
}
