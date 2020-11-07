using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeHolder : Singleton<GameTimeHolder>
{
    public Action<GameTime> OnGameTimeChanged = (time => { }); 

    [SerializeField] private GameTime _startGameTime;
    [SerializeField] private GameTime _endGameTime;

    [Header("Actions Cost")]
    [SerializeField] private GameTime _roomTimeCost;
    [SerializeField] private GameTime _dialogTimeCost;
    [SerializeField] private GameTime _objectInteractionTimeCost;
    [SerializeField] private GameTime _timeToDie;

    private GameTime _currentTime;

    #region Properties

    public GameTime StartGameTime => _startGameTime;

    public GameTime RoomTimeCost => _roomTimeCost;

    public GameTime DialogTimeCost => _dialogTimeCost;

    public GameTime ObjectInteractionTimeCost => _objectInteractionTimeCost;

    public GameTime EndGameTime => _endGameTime;

    public GameTime TimeToDie => _timeToDie;

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
        OnGameTimeChanged.Invoke(_currentTime);
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

    public float GetTotalMinutes()
    {
        float result = Day * 24 * 60;
        result += Hours * 60;
        result += Minutes;

        return result;
    }

    public static bool operator <(GameTime a, GameTime b)
    {
        return a.GetTotalMinutes() < b.GetTotalMinutes();
    }

    public static bool operator >(GameTime a, GameTime b)
    {
        return a.GetTotalMinutes() > b.GetTotalMinutes();
    }

    public static GameTime operator +(GameTime a, GameTime b)
    {
         a.Add(b);

         return a;
    }

    public GameTime(int day, int hours, int minutes)
    {
        _day = day;
        _hours = hours;
        _minutes = minutes;
    }

    public GameTime(GameTime time)
    {
        _day = time.Day;
        _hours = time.Hours;
        _minutes = time.Minutes;
    }

    public override string ToString()
    {
        return $"{Day}:{Hours}:{Minutes}";
    }
}