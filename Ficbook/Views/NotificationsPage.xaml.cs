using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficbook.ViewModels;

namespace Ficbook.Views;

public partial class NotificationsPage : ContentPage
{
    public NotificationsPage(NotificationsViewModel notificationsViewModel)
    {
        BindingContext = notificationsViewModel;
        
        InitializeComponent();
    }
}