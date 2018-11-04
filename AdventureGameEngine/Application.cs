using AdventureGameEngine.Interfaces;
using AdventureGameEngine.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureGameEngine
{
  internal class Application : IApplication
  {
    private readonly IWorldFactory _worldFactory;
    private readonly IParserService _parserService;

    public Application(
      IWorldFactory worldFactory,
      IParserService parserService)
    {
      _worldFactory = worldFactory;
      _parserService = parserService;
    }

    public async Task Run(IList<ICommand> commands)
    {
      _parserService.Commands = commands;

      var gameState = new GameState
      {
        GameRunning = true,
        World = await _worldFactory.Get()
      };

      this.Introduction(gameState);

      while(gameState.GameRunning)
      {
        Console.Write("> ");
        var playerInput = Console.ReadLine();
        if(string.IsNullOrEmpty(playerInput) == false)
        {
          await _parserService.ParseInput(playerInput, gameState);
        }
        
        gameState.TurnCounter++;
        Console.WriteLine();
      }
    }

    private void Introduction(GameState gameState)
    {
      Console.WriteLine(gameState.World.Player.CurrentLocation.Description);
    }
  }
}
