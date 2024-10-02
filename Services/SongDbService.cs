using Microsoft.EntityFrameworkCore;

public class SongDbService : ISongService {
  private readonly CancionitoContext _context;
  public SongDbService(CancionitoContext context) {
    _context = context;
  }
    public Song Create(Song s) {
        Song NewSong = new Song(s.Title);
        _context.Songs.Add(NewSong);
        _context.SaveChanges();
        return NewSong;
    }
    public void Delete(int id) {
        var s = _context.Songs.Find(id);
        _context.Songs.Remove(s);
        _context.SaveChanges();
    }
    public IEnumerable<Song> GetAll() {
        return _context.Songs; 
    }
    public Song? GetById(int id) {
        return _context.Songs.Find(id);
    }
    public Song? Update(int id, Song s) {
        _context.Entry(s).State = EntityState.Modified;
        _context.SaveChanges();
        return s;
    }
    public IEnumerable<Image> GetImages(int id) {
        Song s = _context.Songs.Include(i => i.Images).FirstOrDefault(x => x.Id == id);
        return s.Images;
    }
}
