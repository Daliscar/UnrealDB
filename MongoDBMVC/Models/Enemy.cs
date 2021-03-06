using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UnrealDB.Models
{
    public class Enemy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string enemy_name { get; set; }
        public string title { get; set; }
        public string cursorIconName { get; set; }
        public int gossip_menu_id { get; set; }
        public int minLevel { get; set; }
        public int maxLevel { get; set; }

    }
}