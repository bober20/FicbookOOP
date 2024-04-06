using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.ModelsEF;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class WriterProfileViewModel : ObservableObject
{
    [ObservableProperty]
    private Writer _writer;

    public WriterProfileViewModel(Writer writer, ApplicationDbContext dbContext)
    {
        Writer = writer;
    }

    public Writer GetWriter()
    {
        return Writer;
    }
}