using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        instance = this;
    }

    void Start() {
        UpdateGameState(GameState.PreRound);
    }

    void UpdateGameState(GameState newState)
    {
        this.State = newState;

        switch (newState)
        {
            case GameState.PreRound:
            Debug.Log("Estamos em Pre Round");
                break;
            case GameState.Round:
            Debug.Log("Estamos no Round");
                break;
            case GameState.Paused:
                break;
            case GameState.Victory:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, "Deu pau");
        }
        OnGameStateChanged?.Invoke(newState);
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
