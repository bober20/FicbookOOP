using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class EditWriterListPage : ContentPage
{
    private EditWriterViewModel _editWriterViewModel;
    
    public EditWriterListPage()
    {
        BindingContext = _editWriterViewModel = new EditWriterViewModel();
        
        InitializeComponent();
    }
}