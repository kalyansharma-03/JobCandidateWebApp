using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Infrastructure.Repository
{
    public class ServiceRepository<T> : IServiceRepository<T>, IDisposable where T : class
    {
        private readonly JobCandidateDBContext _db;
        private readonly DbSet<T> _entity;

        public ServiceRepository(JobCandidateDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _entity = _db.Set<T>();
        }

        public async Task<T> AddAsync(T model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            try
            {
                var newEntity = await _entity.AddAsync(model);
                await _db.SaveChangesAsync();

                return newEntity.Entity;
            }
            catch (DbUpdateException exception)
            {
                // Handle exception (log it, wrap it, rethrow it, etc.)
                throw;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<T> FindAsync(string email)
        {
            var entity = await _entity.FindAsync(email);
            return entity;
        }

        public async Task<T> UpdateAsync(T model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            try
            {
                _db.ChangeTracker.Clear();
                var updatedEntity = _entity.Update(model);
                await _db.SaveChangesAsync();

                return updatedEntity.Entity;
            }
            catch (DbUpdateException exception)
            {
                // Handle exception (log it, wrap it, rethrow it, etc.)
                throw;
            }
        }
    }
    public class ServiceFactory : IDisposable, IServiceFactory
    {
        private readonly JobCandidateDBContext db;
        private readonly bool _isforTest;

        public ServiceFactory()
        {
            db = new JobCandidateDBContext();
            _isforTest = false;
        }

        public ServiceFactory(JobCandidateDBContext db, bool isforTest)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this._isforTest = isforTest;
        }

        public void Dispose()
        {
            if (!_isforTest)
            {
                db.Dispose();
            }
        }

        public IServiceRepository<T> GetInstance<T>() where T : class
        {
            return new ServiceRepository<T>(db);
        }
    }
}
