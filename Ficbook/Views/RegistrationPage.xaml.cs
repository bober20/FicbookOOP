using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficbook.Services;
using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class RegistrationPage : ContentPage
{
    private RegistrationViewModel _registrationViewModel;
    
    public RegistrationPage(RegistrationViewModel registrationViewModel)
    {
        BindingContext = _registrationViewModel = registrationViewModel;
        
        InitializeComponent();
    }

}