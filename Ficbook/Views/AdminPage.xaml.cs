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
    private AdminViewModel _adminViewModel;
    
    public AdminPage(AdminViewModel adminViewModel)
    {
        BindingContext = _adminViewModel = adminViewModel;
        
        InitializeComponent();
    }

    private void WriterSelected(object sender, EventArgs e)
    {
        var collectionView = sender as CollectionView;

        if (collectionView?.SelectedItem is null) return;
        var selectedWriter = collectionView.SelectedItem as Writer;
            
        collectionView.SelectedItem = null;
            
        Navigation.PushAsync(new WriterProfilePage(new WriterProfileViewModel(selectedWriter, new ApplicationDbContext())));
    }

    private void RemoveWriterTapped(object sender, TappedEventArgs e)
    {
        //throw new NotImplementedException();
    }

    private void EditUserListButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditWriterListPage(new EditWriterViewModel(new ApplicationDbContext())));
    }
}