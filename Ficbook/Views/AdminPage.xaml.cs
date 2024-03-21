using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficbook.Models;
using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class AdminPage : ContentPage
{
    private AdminViewModel _adminViewModel;
    
    public AdminPage()
    {
        BindingContext = _adminViewModel = new AdminViewModel();
        
        InitializeComponent();
    }

    private void WriterSelected(object sender, EventArgs e)
    {
        var collectionView = sender as CollectionView;

        if (collectionView?.SelectedItem is null) return;
        var selectedWriter = collectionView.SelectedItem as Writer;
            
        collectionView.SelectedItem = null;
            
        Navigation.PushAsync(new WriterProfilePage(new WriterProfileViewModel(selectedWriter)));
    }

    private void RemoveWriterTapped(object sender, TappedEventArgs e)
    {
        //throw new NotImplementedException();
    }

    private void EditUserListButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditWriterListPage());
    }
}