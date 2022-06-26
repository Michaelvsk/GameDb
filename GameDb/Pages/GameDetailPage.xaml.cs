using Michaelvsk.GameDb.Models.DataAccess;
using Michaelvsk.GameDb.ViewModels;

namespace Michaelvsk.GameDb.Pages;


public partial class GameDetailPage : ContentPage
{
    GameItemViewModel _viewModel;

    public GameDetailPage(GameItemViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}
