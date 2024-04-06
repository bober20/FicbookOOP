using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficbook.Services;
using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class ShowInfoPage : ContentPage
{
    private ShowInfoViewModel _showInfoViewModel;
    public ShowInfoPage(ShowInfoViewModel showInfoViewModel)
    {
        BindingContext = _showInfoViewModel = showInfoViewModel;

        InitializeComponent();
    }
}