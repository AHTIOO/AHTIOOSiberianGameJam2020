using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTriggerController : Singleton<TimeTriggerController>
{
    [Serializable]
    public class TimeTrigger
    {
        public GameTime Time;
        public List<GameTrigger> Triggers = new List<GameTrigger>();

        public TimeTrigger(GameTime time, List<GameTrigger> triggers)
        {
            Time = time;
            Triggers = triggers;
        }
    }

    [SerializeField] private List<TimeTrigger> _initialTimeTriggers = new List<TimeTrigger>();

    private void Awake()
    {
        GameTimeHolder.Instance.OnGameTimeChanged += ActivateTimeTriggers;
    }

    private void ActivateTimeTriggers(GameTime time)
    {
        List<TimeTrigger> triggersToActivate = new List<TimeTrigger>();

        _initialTimeTriggers.ForEach((x) =>
        {
            if (x.Time < time)
            {
                foreach (var trigger in x.Triggers)
                {
                    trigger.ActivateTrigger();
                }
                triggersToActivate.Add(x);
            }
        });

        foreach (var timeTrigger in triggersToActivate)
        {
            _initialTimeTriggers.Remove(timeTrigger);
        }
    }

    public void AddTimeTrigger(TimeTrigger timeTrigger)
    {
        _initialTimeTriggers.Add(timeTrigger);
    }
}
