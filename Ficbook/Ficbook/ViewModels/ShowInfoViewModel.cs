using CommunityToolkit.Mvvm.ComponentModel;
using Ficbook.ModelsEF;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class ShowInfoViewModel : ObservableObject
{
    [ObservableProperty]
    private Show _selectedShow;

    public ShowInfoViewModel(Show selectedShow, ApplicationDbContext dbContext)
    {
        SelectedShow = selectedShow;
    }
}