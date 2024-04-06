using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficbook.Services;
using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class EditWriterListPage : ContentPage
{
    private EditWriterViewModel _editWriterViewModel;
    
    public EditWriterListPage(EditWriterViewModel editWriterViewModel)
    {
        BindingContext = _editWriterViewModel = editWriterViewModel;
        
        InitializeComponent();
    }
}