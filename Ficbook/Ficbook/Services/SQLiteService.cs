using SQLite;
using Ficbook.Models;

namespace Ficbook.Services;

public class SQLiteService : IDbServices
{
    const string DatabaseFileName = "ficbook.db3";
    static string _dbPath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
    SQLiteConnection _db;

    public SQLiteService()
    {
        //File.Delete(_dbPath);
        bool dbExists = File.Exists(_dbPath);
        _db = new SQLiteConnection(_dbPath);

        if (dbExists)
        {
            return;
        }

        Init();
    }

    public void BanWriter(int id)
    {
        _db.Insert(new BannedWriters
        {
            WriterId = id,
        });
    }

    public void UnbanWriter(int id)
    {
        string sqlExpression = $"DELETE FROM BannedWriters WHERE WriterId = {id}";

        SQLiteCommand command = new SQLiteCommand(_db);
        command.CommandText = sqlExpression;

        command.ExecuteNonQuery();
    }

    public IEnumerable<Comment> GetAllComments(int id)
    {
        IEnumerable<Comment> comments = _db.Table<Comment>().Where(comment => comment.StoryId == id);

        return comments;
    }

    public IEnumerable<BannedWriters> GetAllBannedWriters()
    {
        IEnumerable<BannedWriters> bannedWriters = _db.Table<BannedWriters>();

        return bannedWriters;
    }

    public IEnumerable<Story> GetAllStories()
    {
        IEnumerable<Story> stories = _db.Table<Story>();

        return stories;
    }

    public IEnumerable<Story> GetStoriesByWriterId(int id)
    {
        IEnumerable<Story> stories = _db.Table<Story>().Where(story => story.WriterId == id);

        return stories;
    }

    public IEnumerable<Story> GetStoriesByGenreId(int id)
    {
        IEnumerable<Story> stories = _db.Table<Story>().Where(story => story.GenreId == id);

        return stories;
    }

    public IEnumerable<Genre> GetAllGenres()
    {
        IEnumerable<Genre> genres = _db.Table<Genre>();

        return genres;
    }

    public IEnumerable<Show> GetAllShows()
    {
        IEnumerable<Show> shows = _db.Table<Show>();

        return shows;
    }

    public IEnumerable<Writer> GetAllWriters()
    {
        IEnumerable<Writer> writers = _db.Table<Writer>();

        return writers;
    }

    public void AddStory(Story story)
    {
        _db.Insert(story);
    }

    public void AddComment(Comment comment)
    {
        _db.Insert(comment);
    }

    public void RemoveStory(int id)
    {
        string sqlExpression = $"DELETE FROM Stories WHERE id = {id}";

        SQLiteCommand command = new SQLiteCommand(_db);
        command.CommandText = sqlExpression;

        command.ExecuteNonQuery();
    }

    public void RemoveCommentsByStoryId(int id)
    {
        string sqlExpression = $"DELETE FROM Comments WHERE StoryId = {id}";

        SQLiteCommand command = new SQLiteCommand(_db);
        command.CommandText = sqlExpression;

        command.ExecuteNonQuery();
    }

    public Genre GetGenreById(int id)
    {
        Genre genre = _db.Table<Genre>().FirstOrDefault(genre => genre.Id == id);

        return genre;
    }

    public Show GetShowById(int id)
    {
        Show show = _db.Table<Show>().FirstOrDefault(show => show.Id == id);

        return show;
    }

    public Writer GetWriterById(int id)
    {
        Writer writer = _db.Table<Writer>().FirstOrDefault(writer => writer.Id == id);

        return writer;
    }

    public void Init()
    {
        _db.CreateTable<Genre>();
        _db.CreateTable<Show>();
        _db.CreateTable<Writer>();
        _db.CreateTable<Story>();
        _db.CreateTable<BannedWriters>();
        _db.CreateTable<Comment>();

        AddShows();
        AddGenres();
        AddWriters();
        AddStories();
    }
    
    private void AddGenres()
    {
        for (int i = 0; i < 2; i++)
        {
            _db.Insert(new Genre
            {
                Name = "genre" + i,
                AgeLimit = 18 + i
            });
        }
    }

    private void AddStories()
    {
        for (int i = 0; i < 4; i++)
        {
            _db.Insert(new Story
            {
                Title = "story" + i,
                Content = "content" + i,
                GenreId = i % 2 + 1,
                ShowId = i + 1,
                WriterId = i % 2 + 1,
            });
        }
    }

    private void AddShows()
    {
        for (int i = 0; i < 4; i++)
        {
            _db.Insert(new Show
            {
                Name = "show" + i,
                MoreInformation = "moreInfo" + i,
            });
        }
    }

    private void AddWriters()
    {
        for (int i = 0; i < 2; i++)
        {
            _db.Insert(new Writer
            {
                Name = "writer" + i,
            });
        }
    }
}