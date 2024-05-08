using Ficbook.ViewModels;
using Ficbook.Services;

namespace Ficbook.Views;

public partial class AddStoryPage : ContentPage
{
    public AddStoryPage(AddStoryViewModel addStoryViewModel)
    {
        BindingContext = addStoryViewModel;
        
        InitializeComponent();
    }
}