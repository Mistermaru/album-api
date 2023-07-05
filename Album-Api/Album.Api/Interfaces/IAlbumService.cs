using System.Collections.Generic;

namespace Album.Api.Services
{
    public interface IAlbumService<T>
    {
        public IEnumerable<T> GetAll();
        public T GetById(int Id);
        public T Create(T _object);
        public void Update(int Id, T _object);
        public void Delete(int Id);
    }
}