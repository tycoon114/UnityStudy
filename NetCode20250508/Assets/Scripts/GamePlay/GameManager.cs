using NUnit.Framework;
using System;
using UnityEngine;
using Unity.Netcode;
using Unity.VisualScripting;

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

    private NetworkVariable<SquareState> _currentTurnState = new();
    private NetworkVariable<GameOverState> _gameOverState = new();
    private SquareState _localPlayerType = SquareState.None;



    public static GameManager Instance
    {
        get;
        private set;
    }


    private bool CanPlayMarker(int x, int y, SquareState localPlayerType)
    {
        return  _gameOverState.Value == GameOverState.NotOver &&
                _localPlayerType == _currentTurnState.Value &&
                _board[y, x] == SquareState.None;
    }


    [Rpc(SendTo.Server)]
    public void ReqValidatekRpc(int x, int y, SquareState localPlayerType)
    {
        //입력이 유효한가?
        Logger.Info($"{nameof(ReqValidatekRpc)}  {x}  ,{y}, {localPlayerType}");

        if (false == CanPlayMarker(x,y,localPlayerType))
        {
            return;
        }

        ChangeBoardStateRpc(x,y,localPlayerType);

        if (_currentTurnState.Value == SquareState.Cross)
        {
            _currentTurnState.Value = SquareState.Circle;
        }
        else if (_currentTurnState.Value == SquareState.Circle)
        {
            _currentTurnState.Value = SquareState.Cross;
        }
    }

    [Rpc(SendTo.Everyone)]
    public void ChangeBoardStateRpc(int x, int y, SquareState state)
    {
        _board[y, x] = state;
        OnBoardChanged?.Invoke(x, y, state);

    }


    public void ProcessInput(int x, int y)
    {

        if (CanPlayMarker(x,y,_localPlayerType))
        {
            ReqValidatekRpc(x, y, _localPlayerType);
        }


        //OnBoardChanged?.Invoke(x, y, _currentTurnState);


        //_gameOverState = TestGameOver();
        //if (_gameOverState != GameOverState.NotOver)
        //{
        //    OnGameDone?.Invoke(_gameOverState);
        //    return;
        //}

        //if (_currentTurnState == SquareState.Cross)
        //{
        //    _currentTurnState = SquareState.Circle;
        //}
        //else if (_currentTurnState == SquareState.Circle)
        //{
        //    _currentTurnState = SquareState.Cross;
        //}
        //OnTurnChanged?.Invoke(_currentTurnState);
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
                if (_board[y, x] == SquareState.None)
                {
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
            Logger.Info($" ID : {ConnectionEventData.ClientId}  , OnConntection : {ConnectionEventData.EventType}");

            if (networkManager.ConnectedClients.Count == 2)
            {
                if (IsHost)
                {
                    _localPlayerType = SquareState.Cross;
                    _currentTurnState.Value = SquareState.Cross;
                }
                else if (IsClient)
                {
                    _localPlayerType = SquareState.Circle;

                }
                _currentTurnState.OnValueChanged += (previous, newState) =>
                {
                    Logger.Info($"{previous.ToString()} -> {newState.ToString()}");
                };
            }
        };
    }


}
