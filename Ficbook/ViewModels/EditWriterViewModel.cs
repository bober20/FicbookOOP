using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.Models;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class EditWriterViewModel : ObservableObject
{
    [ObservableProperty] private List<Writer> _writers;

    [ObservableProperty] private Writer _selectedWriter;

    private IDbServices _dbService = new SQLiteService();

    public EditWriterViewModel()
    {
        Writers = _dbService.GetAllWriters().ToList();
        SelectedWriter = Writers[0];
    }

    [RelayCommand]
    private void BanWriter()
    {
        _dbService.BanWriter(SelectedWriter.Id);
    }
    
    [RelayCommand]
    private void UnbanWriter()
    {
        _dbService.UnbanWriter(SelectedWriter.Id);
    }
}