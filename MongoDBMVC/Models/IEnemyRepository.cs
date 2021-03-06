using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnrealDB.Models
{
    public interface IEnemyRepository
    {
        Task Add(Enemy enemy);
        Task Update(Enemy enemy);
        Task Delete(string id);
        Task<Enemy> GetEnemy(string id);
        Task<IEnumerable<Enemy>> GetEnemies();
    }
}
