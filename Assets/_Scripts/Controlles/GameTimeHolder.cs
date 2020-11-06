using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeHolder : Singleton<GameTimeHolder>
{
    [SerializeField] private GameTime _startGameTime;

    [Header("Actions Cost")]
    [SerializeField] private GameTime _roomTimeCost;
    [SerializeField] private GameTime _dialogTimeCost;
    [SerializeField] private GameTime _objectInteractionTimeCost;

    private GameTime _currentTime;

    #region Properties

    public GameTime StartGameTime => _startGameTime;

    public GameTime RoomTimeCost => _roomTimeCost;

    public GameTime DialogTimeCost => _dialogTimeCost;

    public GameTime ObjectInteractionTimeCost => _objectInteractionTimeCost;

    public GameTime CurrentTime => _currentTime;

    #endregion

    protected override void Awake()
    {
        base.Awake();

        _currentTime = _startGameTime;
    }

    public void IncreaseTime(GameTime time)
    {
        _currentTime.Add(time);
        Debug.Log(_currentTime);
    }
}

[Serializable]
public class GameTime
{
    [SerializeField] private int _day;
    [SerializeField] private int _hours;
    [SerializeField] private int _minutes;

    public int Day
    {
        get => _day;
        set => _day = value;
    }

    public int Hours
    {
        get => _hours;
        set
        {
            _hours = value;

            while (_hours >= 24)
            {
                Day += 1;
                _hours -= 24;
            }
        }
    }

    public int Minutes
    {
        get => _minutes;
        set
        {
            _minutes = value;

            while (_minutes >= 60)
            {
                Hours += 1;
                _minutes -= 60;
            }
        }
    }

    public void Add(GameTime gameTime)
    {
        Minutes += gameTime.Minutes;
        Hours += gameTime.Hours;
        Day += gameTime.Day;
    }

    public override string ToString()
    {
        return $"{Day}:{Hours}:{Minutes}";
    }
}