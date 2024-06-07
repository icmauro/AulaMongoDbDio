using Amazon.Runtime.Internal;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using MongoDB.Bson.Serialization;
using Estudos.Api.MongoDb.Infra.Model;

namespace Estudos.Api.Mongo.Infra.Context
{
    public class MongoDbContext
    {
        public IMongoDatabase database;

        public MongoDbContext(IConfiguration configuration)
        {
            try 
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration.GetConnectionString("Default")));
                var client = new MongoClient(settings);
                database = client.GetDatabase(configuration["NomeBanco"]);
                Map();
            }
            catch (Exception ex)
            {
                throw new MongoException($" Problemas ao conectar base Mongo {ex.Message}" );
            }

        }

        private void Map()
        {

            if (!BsonClassMap.IsClassMapRegistered(typeof(Infectado)))
            {
                BsonClassMap.RegisterClassMap<Infectado>(classMap => {

                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(true);

                });
            }
                
        }
    }
}
