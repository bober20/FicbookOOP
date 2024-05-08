using Ficbook.Services;
using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class WriterProfilePage : ContentPage
{
    public WriterProfilePage(WriterProfileViewModel writerProfileViewModel)
    {
        BindingContext = writerProfileViewModel;
        
        InitializeComponent();
    }
}