using Album.Api.Data;
using Album.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Api.Services
{
    public class AlbumService : IAlbumService<AlbumModel>
    {
        private readonly AlbumDBContext _context;

        public AlbumService(AlbumDBContext context)
        {
            _context = context;
        }
        public IEnumerable<AlbumModel> GetAll()
        {
            return _context.Albums.ToList();
        }
        public AlbumModel GetById(int Id)
        {
            return _context.Albums.Where(x => x.Id == Id).FirstOrDefault();
        }
        public AlbumModel Create(AlbumModel _object)
        {
            var obj = _context.Albums.Add(_object);
            _context.SaveChanges();

            return obj.Entity;
        }

        public void Update(int Id, AlbumModel _object)
        {
            var album = _context.Albums.Where(x => x.Id == Id).FirstOrDefault();


            album.Name = _object.Name;
            album.Artist = _object.Artist;
            album.ImageUrl = _object.ImageUrl;

            _context.Albums.Update(album);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var album = _context.Albums.Where(x => x.Id == Id).FirstOrDefault();

            _context.Albums.Remove(album);
            _context.SaveChanges();
        }
    }
}