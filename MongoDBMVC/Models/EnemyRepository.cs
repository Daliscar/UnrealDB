using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnrealDB.Models
{
    public class EnemyRepository : IEnemyRepository
    {
        MongoDbContext db = new MongoDbContext();
        public async Task Add(Enemy enemy)
        {
            try
            {
                await db.Enemy.InsertOneAsync(enemy);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Enemy> GetEnemy(string id)
        {
            try
            {
                FilterDefinition<Enemy> filter = Builders<Enemy>.Filter.Eq("Id", id);
                return await db.Enemy.Find(filter).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Enemy>> GetEnemies()
        {
            try
            {
                return await db.Enemy.Find(_ => true).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(Enemy enemy)
        {
            try
            {
                await db.Enemy.ReplaceOneAsync(filter: g => g.Id == enemy.Id, replacement: enemy);
            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(string id)
        {
            try
            {
                FilterDefinition<Enemy> data = Builders<Enemy>.Filter.Eq("Id", id);
                await db.Enemy.DeleteOneAsync(data);
            }
            catch
            {
                throw;
            }
        }
    }
}