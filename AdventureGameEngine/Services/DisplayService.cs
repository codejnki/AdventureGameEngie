using AdventureGameEngine.Interfaces;
using AdventureGameEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGameEngine.Services
{
  public class DisplayService : IDisplayService
  {

    private int _currentCursorTop;
    private int _currentCursorLeft;
    private List<string> _gameHistory = new List<string>();


    public void UpdateDisplay(GameState gameState)
    {
      this.UpdateTitleBar(gameState);
      this.DisplayInputLine();
    }

    public void UpdateDisplay(GameState gameState, CommandResult commandResult)
    {
      this.UpdateGameHistory(gameState, commandResult);
      this.WriteGameHistory();
      this.UpdateTitleBar(gameState);
      this.DisplayInputLine();
    }

    private void UpdateGameHistory(GameState gameState, CommandResult commandResult)
    {
      _gameHistory.AddRange(commandResult.CommandResultText);
      if (commandResult.PlayerLocationChanged && gameState.World.Player.CurrentLocation.TimesPlayerInRoom < 5)
      {
        _gameHistory.Add(gameState.World.Player.CurrentLocation.Description);
      }
    }

    private void WriteGameHistory()
    {
      var screenHight = Console.WindowHeight;
      for(int i = 2; i<screenHight; i++)
      {
        Console.SetCursorPosition(0, i);
        this.ClearCurrentConsoleLine();
      }

      Console.SetCursorPosition(0, 2);
      var startingLine = _gameHistory.Count - (screenHight - 5);

      if (startingLine < 0)
      {
        startingLine = 0;
      }

      for(int i = startingLine; i < _gameHistory.Count; i++)
      {
        Console.WriteLine(_gameHistory[i]);
      }
    }

    private void UpdateTitleBar(GameState gameState)
    {
      // this.SetCurrentLocation();
      Console.SetCursorPosition(0, 0);
      this.ClearCurrentConsoleLine();
      Console.BackgroundColor = ConsoleColor.White;
      Console.ForegroundColor = ConsoleColor.Black;
      Console.Write($"Turn: {gameState.TurnCounter} Current Room: {gameState.World.Player.CurrentLocation.RoomName}");
      Console.BackgroundColor = ConsoleColor.Black;
      Console.ForegroundColor = ConsoleColor.White;
      // this.ReturnCurrentLocation();
    }

    private void SetCurrentLocation()
    {
      _currentCursorLeft = Console.CursorLeft;
      _currentCursorTop = Console.CursorTop;
    }

    private void ReturnCurrentLocation()
    {
      Console.SetCursorPosition(_currentCursorLeft, _currentCursorTop);
    }

    private void ClearCurrentConsoleLine()
    {
      int currentLinseCursor = Console.CursorTop;
      Console.SetCursorPosition(0, Console.CursorTop);
      Console.Write(new string(' ', Console.WindowWidth));
      Console.SetCursorPosition(0, currentLinseCursor);
    }

    private void DisplayInputLine()
    {
      var numberOfRows = Console.WindowHeight;
      Console.SetCursorPosition(0, numberOfRows-2);
      this.ClearCurrentConsoleLine();
      Console.Write("> ");
    }
  }
}
