using System;
using Ficbook.Models;
namespace Ficbook.Services
{
	public interface IDbServices
	{
		IEnumerable<Story> GetAllStories();
        IEnumerable<Genre> GetAllGenres();
        IEnumerable<Show> GetAllShows();
        IEnumerable<Writer> GetAllWriters();
        IEnumerable<Comment> GetAllComments(int id);
        IEnumerable<Story> GetStoriesByWriterId(int id);
        IEnumerable<Story> GetStoriesByGenreId(int id);
        Genre GetGenreById(int id);
        Show GetShowById(int id);
        Writer GetWriterById(int id);
        IEnumerable<BannedWriters> GetAllBannedWriters();
        void BanWriter(int id);
        void UnbanWriter(int id);
        void AddComment(Comment comment);
        void AddStory(Story story);
        void RemoveStory(int id);
        void RemoveCommentsByStoryId(int id);
        void Init();
	}
}

