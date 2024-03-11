using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BirthRepository:IBirthRepository
    {
        private readonly OcraContext _craContext = default;
        public BirthRepository(OcraContext ocraContext)
            {
            _craContext = ocraContext;
        }

        public void Create(Birth entity)
        {
            _craContext.Births.Add(entity);

        }

        public void Delete(Birth entity)
        {
            _craContext.Remove(entity);

        }

        public Birth Find(int id)
        {
            return _craContext.Births.FirstOrDefault(b => b.Id == id);
        }

        public IQueryable<Birth> FindAll(bool trackChanges)
        {
            return _craContext.Births;
        }

        public void Update(Birth entity)
        {
            _craContext.Update(entity);
        }
    }
}
