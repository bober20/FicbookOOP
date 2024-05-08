using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficbook.ModelsEF;
using Ficbook.Services;
using Ficbook.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Ficbook.Views;

public partial class AdminPage : ContentPage
{
    public AdminPage(AdminViewModel adminViewModel)
    {
        BindingContext = adminViewModel;
        
        InitializeComponent();
    }
    
    // private void SearchBarTextChanged(object? sender, TextChangedEventArgs e)
    // {
    //     _adminViewModel.Search();
    // }

    // private void SelectableItemsView_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    // {
    //     var collectionView = sender as CollectionView;
    //
    //     if (collectionView?.SelectedItem is null) return;
    //     Writer? selectedWriter = collectionView.SelectedItem as Writer;
    //
    //     _adminViewModel.SelectedWriter = selectedWriter;
    // }
}