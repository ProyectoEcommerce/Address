using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TopChoiceHardware.AdressService.Domain.Commands;
using TopChoiceHardware.AdressService.Domain.Entities;

namespace TopChoiceHardware.AdressService.AccessData.Commands
{
    public class GenericRepository: IGenericRepository
    {
        private readonly DomicilioContext _context;
        public GenericRepository(DomicilioContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Attach(entity);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteById<T>(int id) where T : class
        {
            T entity = GetById<T>(id);
            Delete<T>(entity);
        }

        public List<T> GetAll<T>() where T : class
        {
            List<T> query = _context.Set<T>().ToList();
            return query;
        }

        public T GetById<T>(int id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
