using Ficbook.Services;
using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class WriterProfilePage : ContentPage
{
    private WriterProfileViewModel _writerProfileViewModel;

    public WriterProfilePage(WriterProfileViewModel writerProfileViewModel)
    {
        InitializeComponent();

        BindingContext = _writerProfileViewModel = writerProfileViewModel;
    }
}