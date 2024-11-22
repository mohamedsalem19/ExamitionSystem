using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using TaskExaminantionSystem.Models;

namespace TaskExaminantionSystem.Data.Repository
{
    public class GRepository<Entity> : IGRepository<Entity> where Entity : BaseEntity
    {

        Context _context;
        DbSet<Entity> _entities;
        public GRepository(Context context)
        {
            _context = context;
            _entities = _context.Set<Entity>();
        }

        public void Add(Entity entity)
        {
            entity.CreatedOn = DateTime.Now;
            // entity.CreatedBy = LoginUser; 
            _entities.Add(entity);
        }
        public void Update(Entity entity)
        {
            entity.UpdatedOn = DateTime.Now;
            // entity.UpdatedBy = LoginUser; 
            _entities.Update(entity);
        }

        public void SaveInclude(Entity entity, params string[] Properties)
        {
            var local = _entities.Local.FirstOrDefault(x => x.Id == entity.Id);
            EntityEntry entry = null;

            if (local == null)
            {
                entry = _context.Entry(entity);
            }
            else
            {
                entry = _context.ChangeTracker.Entries<Entity>()
                      .FirstOrDefault(x => x.Entity.Id == entity.Id);
            }

            foreach (var property in entry.Properties)
            {
                if (Properties.Contains(property.Metadata.Name))
                {

                    property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name).GetValue(entity);
                    property.IsModified = true;
                }
            }
            entity.UpdatedOn = DateTime.Now;


        }

        public void Delete(Entity entity)
        {
            entity.IsDeleted = true;
            SaveInclude(entity, nameof(BaseEntity.IsDeleted));
        }

        public IQueryable<Entity> GetAll()
        {
            return _entities.Where(x => x.IsDeleted == false);
        }

        public IQueryable<Entity> Get(Expression<Func<Entity, bool>> predicate)
        {
            return _entities.Where(x => x.IsDeleted == false).Where(predicate);
        }

        public Entity GetById(int id)
        {
            return Get(x => x.Id == id).FirstOrDefault();
        }

        public void HardDelete(Entity entity)
        {
            _entities.Remove(entity);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }


    }
}
