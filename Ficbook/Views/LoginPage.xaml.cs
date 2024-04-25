using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficbook.Services;
using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class LoginPage : ContentPage
{
    private LoginViewModel _loginView;
    
    public LoginPage()
    {
        BindingContext = _loginView = new LoginViewModel(new ApplicationDbContext());
        
        InitializeComponent();
    }
}