using Michaelvsk.GameDb.Models;

namespace Michaelvsk.GameDb.ViewModels;

internal class GameItemViewModel : BaseViewModel
{
    
    public Game game { get; set; }

    public GameItemViewModel()
    {
        game = new Game();
    }

    public GameItemViewModel(Game game)
    {
        this.game = game;
    }
}
