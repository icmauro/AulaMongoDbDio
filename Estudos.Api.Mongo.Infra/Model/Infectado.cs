using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Core.Operations;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Api.MongoDb.Infra.Model
{
    public class Infectado
    {
        public Infectado(string nome, DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Localizacao  = new GeoJson2DGeographicCoordinates(latitude, longitude);
            
        }

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }

        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}
