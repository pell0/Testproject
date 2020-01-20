using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common;

namespace TestProject.DataAccess
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ApplicationDbContext _db;
        private GenericRepository<Person> _personRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _db = context;
        }

        public GenericRepository<Person> PersonRepository
        {
            get
            {

                if (this._personRepository == null)
                {
                    this._personRepository = new GenericRepository<Person>(_db);
                }
                return _personRepository;
            }
        }

        public void EnsureDataStoreAsync()
        {
            _db.Database.EnsureCreated();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
