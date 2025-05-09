using NUnit.Framework;
using System;
using UnityEngine;
using Unity.Netcode;

public enum SquareState
{
    None,
    Cross,
    Circle
}


public enum GameOverState
{

    NotOver,
    Cross,
    Circle,
    Tie
}



public class GameManager : NetworkBehaviour
{

    //보드
    private SquareState[,] _board = new SquareState[3, 3];

    public event Action<int, int, SquareState> OnBoardChanged;
    public event Action<GameOverState> OnGameDone;
    public event Action<SquareState> OnTurnChanged;

    private SquareState _currentTurnState = SquareState.Cross;
    private GameOverState _gameOverState = GameOverState.NotOver;

    public static GameManager Instance
    {
        get;
        private set;
    }

    public void ProcessInput(int x, int y)
    {
        if (_gameOverState != GameOverState.NotOver)
        {
            return;
        }

        if (_board[y, x] != SquareState.None)
        {
            return;
        }
        _board[y, x] = _currentTurnState;

        OnBoardChanged?.Invoke(x, y, _currentTurnState);


        _gameOverState = TestGameOver();
        if (_gameOverState != GameOverState.NotOver) {
            OnGameDone?.Invoke(_gameOverState);
            return;
        }

        if (_currentTurnState == SquareState.Cross)
        {
            _currentTurnState = SquareState.Circle;
        }
        else if (_currentTurnState == SquareState.Circle)
        {
            _currentTurnState = SquareState.Cross;
        }
        OnTurnChanged?.Invoke(_currentTurnState);
    }

    GameOverState TestGameOver()
    {
        for (int y = 0; y < 3; y++)
        {
            if (_board[y, 0] != SquareState.None && _board[y, 0] == _board[y, 1] && _board[y, 1] == _board[y, 2])
            {
                if (_board[y, 0] == SquareState.Circle)
                {
                    return GameOverState.Circle;
                }
                else if (_board[y, 0] == SquareState.Cross)
                {
                    return GameOverState.Cross;
                }
            }
        }
        for (int x = 0; x < 3; x++)
        {
            if (_board[0, x] != SquareState.None && _board[0, x] == _board[1, x] && _board[1, x] == _board[2, x])
            {
                if (_board[0, x] == SquareState.Circle)
                {
                    return GameOverState.Circle;
                }
                else if (_board[0, x] == SquareState.Cross)
                {
                    return GameOverState.Cross;
                }

            }
        }

        //대각선
        if (_board[0, 0] != SquareState.None && _board[0, 0] == _board[1, 1] && _board[1, 1] == _board[2, 2])
        {
            if (_board[1, 1] == SquareState.Circle)
            {
                return GameOverState.Circle;
            }
            else if (_board[1, 1] == SquareState.Cross)
            {
                return GameOverState.Cross;
            }
        }

        if (_board[0, 2] != SquareState.None && _board[0, 2] == _board[1, 1] && _board[1, 1] == _board[2, 0])
        {
            if (_board[1, 1] == SquareState.Circle)
            {
                return GameOverState.Circle;
            }
            else if (_board[1, 1] == SquareState.Cross)
            {
                return GameOverState.Cross;
            }
        }


        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (_board[y, x] == SquareState.None) { 
                    return GameOverState.NotOver;
                }
            }
        }

        return GameOverState.Tie;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Start()
    {
        NetworkManager.Singleton.OnConnectionEvent += (networkManager, ConnectionEventData) =>
        {
            Logger.Info($"OnConntection : {ConnectionEventData.EventType}");
        };
    }


}
