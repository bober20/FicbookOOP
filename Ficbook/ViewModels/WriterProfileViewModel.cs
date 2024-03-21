using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.Models;

namespace Ficbook.ViewModels;

public partial class WriterProfileViewModel : ObservableObject
{
    [ObservableProperty]
    private Writer _writer;

    public WriterProfileViewModel(Writer writer)
    {
        Writer = writer;
    }

    public Writer GetWriter()
    {
        return Writer;
    }
}