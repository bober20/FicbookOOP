using CommunityToolkit.Mvvm.ComponentModel;
using Ficbook.Models;

namespace Ficbook.ViewModels;

public partial class ShowInfoViewModel : ObservableObject
{
    [ObservableProperty]
    private Show _selectedShow;

    public ShowInfoViewModel(Show selectedShow)
    {
        _selectedShow = selectedShow;
    }
}