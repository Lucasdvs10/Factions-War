using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public static GameState State;

    public static event Action<GameState> OnGameStateChanged;
    public UnityEvent PreRoundEvent;
    public UnityEvent RoundEvent;
    public UnityEvent PauseEvent;
    public UnityEvent VictoryEvent;
    public UnityEvent LoseEvent;

    void Awake()
    {
        instance = this;
    }

    void Start() {
        UpdateGameState(GameState.PreRound);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.PreRound:
            Debug.Log("Estamos em Pre Round");
            PreRoundEvent?.Invoke();
                break;
            case GameState.Round:
            Debug.Log("Estamos no Round");
            RoundEvent?.Invoke();
                break;
            case GameState.Paused:
                PauseEvent?.Invoke();
                break;
            case GameState.Victory:
                VictoryEvent?.Invoke();
                break;
            case GameState.Lose:
                LoseEvent?.Invoke();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, "Deu pau");
        }
        OnGameStateChanged?.Invoke(newState);
    }

    public void SetRoundState() {
        UpdateGameState(GameState.Round);
    } 
    public void SetPreRoundState() {
        UpdateGameState(GameState.PreRound);
    }
    
    public void SetPauseState() {
        UpdateGameState(GameState.Paused);
    }
    
    public void SetWinState() {
        UpdateGameState(GameState.Victory);
    }
    
    public void SetLoseState() {
        UpdateGameState(GameState.Lose);
    }

    public enum GameState
    {
        PreRound,
        Round,
        Paused,
        Victory,
        Lose
    }
}