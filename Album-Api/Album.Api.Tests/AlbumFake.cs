using Album.Api.Models;
using Album.Api.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Album.Api.Tests
{
    public class AlbumFake : IAlbumService<AlbumModel>
    {

        private readonly List<AlbumModel> _albummodels;
        public AlbumFake()
        {
            _albummodels = new List<AlbumModel>()
            {
                new AlbumModel{Id=1, Name="Dead or dead",
                    Artist="John Wick",ImageUrl="https://i.pinimg.com/originals/2b/27/a4/2b27a434b46a9d20b34e0711ef38d076.jpg"},
                new AlbumModel{Id=2, Name="Toss a coin to your witcher",
                    Artist="The Witcher",ImageUrl="https://i.pinimg.com/originals/e0/0b/a9/e00ba9feab4190ff90452a30c17ad55a.jpg"},
                new AlbumModel{Id=3, Name="Rings that ring",
                    Artist="Frodo Baggins",ImageUrl="https://i.pinimg.com/originals/7e/cc/17/7ecc171c6010bbe34b143018b7643e8c.png"}

            };
        }
        public IEnumerable<AlbumModel> GetAll()
        {
            return _albummodels;
        }
        public AlbumModel GetById(int Id)
        {
            return _albummodels.Where(a => a.Id == Id)
                .FirstOrDefault();
        }
        public AlbumModel Create(AlbumModel _object)
        {
            _albummodels.Add(_object);
            return _object;
        }
        public void Update(int Id, AlbumModel _object)
        {
            var index = _albummodels.FindIndex(a => a.Id == Id);

            if (_albummodels[index] != null)
            {
                _albummodels[index].Artist = _object.Artist;
                _albummodels[index].Name = _object.Name;
                _albummodels[index].ImageUrl = _object.ImageUrl;
            }

        }
        public void Delete(int Id)
        {
            var album = _albummodels.Where(a => a.Id == Id).FirstOrDefault();
            _albummodels.Remove(album);
        }
    }
}
