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
    private readonly IDisplayService _displayService;

    public Application(
      IWorldFactory worldFactory,
      IParserService parserService,
      IDisplayService displayService)
    {
      _worldFactory = worldFactory;
      _parserService = parserService;
      _displayService = displayService;
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
        var playerInput = Console.ReadLine();
        if(string.IsNullOrEmpty(playerInput) == false)
        {
          var result = await _parserService.ParseInput(playerInput, gameState);
          gameState.TurnCounter++;
          _displayService.UpdateDisplay(gameState, result);
        }
      }
    }

    private void Introduction(GameState gameState)
    {
      Console.Clear();
      _displayService.UpdateDisplay(gameState);
    }
  }
}
