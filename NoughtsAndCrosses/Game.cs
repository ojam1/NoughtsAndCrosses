﻿using System;
using System.Linq;

namespace NoughtsAndCrosses
{
    public class Game
    {
        private static IWriter _iWriter;
        private Player _playerOne;
        private Player _playerTwo;
        private ComputerPlayer _computer;
        private readonly Grid _grid;
        private bool _isPlayerOneTurn;
        private string _winner;


        public Game(IWriter iWriter)
        {
            _iWriter = iWriter;

            _iWriter.WriteLine("Enter Grid Size");
            _grid = new Grid(_iWriter, int.Parse(_iWriter.ReadLine()));
            _iWriter.WriteLine("Enter 'Computer1' for computer player one if required");
            if (_iWriter.ReadLine() == "Computer1")
            {
                _computer = new ComputerPlayer("ComputerPlayer1", "X");
                _playerOne = _computer;
                WritePlayerName(_playerOne.Name);
            }
        
        }

        public void Start()
        {
            if (string.IsNullOrWhiteSpace(_playerOne?.Name))
                    _playerOne = PlayerInitialisation("one", "X");

            _playerTwo = PlayerInitialisation("two", "O");
            _grid.DisplayGrid();
            _isPlayerOneTurn = true;
            while (!_grid.WinCondition)
            {
                AttemptPlayerTurn(_isPlayerOneTurn ? _playerOne : _playerTwo);

                if (_grid.WinCondition)
                {
                    WriteWinner(_winner);
                    break;
                }

                if (!_grid.IsFull) continue;
                WriteNoWinner();
                break;
            }
        }

        private static Player PlayerInitialisation(string playerNumber, string playerSymbol)
        {
            WriteWelcome(playerNumber);
            var playerName = _iWriter.ReadLine();
            WritePlayerName(playerName);
            return new Player(playerName, playerSymbol);
        }

        private void AttemptPlayerTurn(Player player)
        {
            WriteTurn(player.Name);
            if (player.Name == "ComputerPlayer1")
                player.MakeMove();

            try
            {
                _grid.SetNoughtOrCross(_iWriter.ReadLine(), player.NoughtCross);
                if (_grid.WinCondition)
                    _winner = player.Name;

                ChangeCurrentPlayer();
            }
            catch (Grid.IncorrectGridPostionException e)
            {
                _iWriter.WriteLine(e.Message);
            }

            _grid.DisplayGrid();
        }

        private void ChangeCurrentPlayer()
        {
            _isPlayerOneTurn = !_isPlayerOneTurn;
        }

        private static void WriteWelcome(string playerNumber)
        {
            _iWriter.WriteLine($"Enter player {playerNumber} name");
        }

        private static void WritePlayerName(string name)
        {
            _iWriter.WriteLine($"Hello {name}");
        }

        private static void WriteTurn(string player)
        {
            _iWriter.WriteLine($"{player}, please enter your move");
        }

        private static void WriteWinner(string player)
        {
            _iWriter.WriteLine($"Winner {player}!");
        }

        private static void WriteNoWinner()
        {
            _iWriter.WriteLine("No Winner");
        }
    }
}