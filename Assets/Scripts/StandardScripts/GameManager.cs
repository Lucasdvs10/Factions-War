using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public static GameState state;

    public static event Action<GameState> OnGameStateChanged;
    public UnityEvent PreRoundEvent;
    public UnityEvent RoundEvent;
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
        state = newState;

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
            case GameState.Victory:
            Debug.Log("Vencemos!");
                VictoryEvent?.Invoke();
                break;
            case GameState.Lose:
            Debug.Log("Voce perdeu...");
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
        Decide,
        Victory,
        Lose
    }
}
