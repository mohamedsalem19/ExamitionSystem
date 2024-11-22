using System.Linq.Expressions;
using TaskExaminantionSystem.Models;

namespace TaskExaminantionSystem.Data.Repository
{
    public interface IGRepository<Entity> where Entity : BaseEntity
    {
        void Add(Entity entity);

        void Update(Entity entity);

        void SaveInclude(Entity entity, params string[] Properties);

        void Delete(Entity entity);

        IQueryable<Entity> GetAll();

        IQueryable<Entity> Get(Expression<Func<Entity, bool>> predicate);

        Entity GetById(int id);

        void HardDelete(Entity entity);

        void SaveChange();
    }
}
