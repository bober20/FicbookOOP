using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ficbook.Models;
using Ficbook.Services;

namespace Ficbook.ViewModels;

public partial class WriterStoriesViewModel : ObservableObject
{
    [ObservableProperty]
    private Writer _writer;
    
    [ObservableProperty]
    private List<Story> _publishedStories;

    private IDbServices _dbService;

    public WriterStoriesViewModel(Writer writer)
    {
        _writer = writer;
        _dbService = new SQLiteService();

        _publishedStories = _dbService.GetStoriesByWriterId(Writer.Id).ToList();
    }
}