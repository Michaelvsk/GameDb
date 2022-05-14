using Michaelvsk.GameDb.Models;

namespace Michaelvsk.GameDb.ViewModels;

internal class GameItemViewModel : BaseViewModel
{
    
    public GameItem game { get; set; }

    public GameItemViewModel()
    {
        game = new GameItem();
    }

    public GameItemViewModel(GameItem game)
    {
        this.game = game;
    }
}
