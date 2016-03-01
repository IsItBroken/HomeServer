using System.Collections.Generic;
using TestApi.Models;

namespace TestApi.Repository
{
    public interface IContactsRepository
    {
        void Add(Contacts item);
        IEnumerable<Contacts> GetAll();
        Contacts Find(string key);
        void Remove(string id);
        void Update(Contacts item);
    }
}