using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace M200
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb+srv://test:test@mflix.bm3x8.mongodb.net/sample_mflix?retryWrites=true&w=majority");
            var db = client.GetDatabase("sample_mflix");
            var collection = db.GetCollection<BsonDocument>("movies");

            var result = collection.Find("{title:'The Princess Bride'}").FirstOrDefault();
            Console.WriteLine(result);

            // Note that we are generating a list of BsonDocuments when we query the database. As you will see in the remaining labs 
            // and lectures in this course, we will map the documents in the movies collection to C# classes, which simplifies querying
            // the collection.

            var result2 = collection.Find(new BsonDocument())
                .SortByDescending(m => m["runtime"])
                .Limit(10)
                .ToList();
            foreach (var r in result2)
            {
                Console.WriteLine(r.GetValue("title"));
            }


        }
    }
}
