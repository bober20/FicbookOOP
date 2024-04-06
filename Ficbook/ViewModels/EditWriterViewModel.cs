using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class EditWriterViewModel : ObservableObject
{
    [ObservableProperty] 
    private List<Writer> _writers;

    [ObservableProperty] private Writer _selectedWriter;

    //private IDbServices _dbService = new SQLiteService();
    
    private ApplicationDbContext _dbContext;

    public EditWriterViewModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        
        Writers = _dbContext.Writers.Where(writer => writer.IsAdmin == false).ToList();
        //SelectedWriter = Writers[0];
    }

    [RelayCommand]
    private void BanWriter()
    {
        foreach (var writer in Writers)
        {
            if (writer.Id == SelectedWriter.Id)
            {
                writer.IsBanned = true;
                _dbContext.Writers.Update(writer);
                _dbContext.SaveChanges();
                break;
            }
        }
        // _dbContext.Writers.Update()
        // _dbService.BanWriter(SelectedWriter.Id);
    }
    
    [RelayCommand]
    private void UnbanWriter()
    {
        foreach (var writer in Writers)
        {
            if (writer.Id == SelectedWriter.Id)
            {
                writer.IsBanned = false;
                _dbContext.Writers.Update(writer);
                _dbContext.SaveChanges();
                break;
            }
            
        }
        // _dbService.UnbanWriter(SelectedWriter.Id);
    }
}