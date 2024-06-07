using Estudos.Api.Mongo.Infra.Context;
using Estudos.Api.MongoDb.Data.ViewModel;
using Estudos.Api.MongoDb.Infra.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Api.Mongo.Infra.Services
{
    public class InfectadoService
    {
        MongoDbContext _db;
        IMongoCollection<Infectado> _infectadosColletion;

        public InfectadoService(MongoDbContext mongoDbContext)
        {
            _db = mongoDbContext;
            _infectadosColletion = _db.database.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        public async Task<List<Infectado>> ListarTodos()
        { 
           return await _infectadosColletion.Find(x => true).ToListAsync();
        }

        public async Task<Infectado?> Buscar(string id)
        {
            return await _infectadosColletion.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Salvar(InfectadoViewModel infectadoViewModel)
        {
            var infectado = new Infectado(infectadoViewModel.Nome,
                                          infectadoViewModel.DataNascimento,
                                          infectadoViewModel.Sexo,
                                          infectadoViewModel.Latitude,
                                          infectadoViewModel.Longitude);

            await _infectadosColletion.InsertOneAsync(infectado);
        }

        public async Task Atualizar(string Id, InfectadoViewModel infectadoViewModel)
        {
            
            var infectado = new Infectado(infectadoViewModel.Nome,
                                          infectadoViewModel.DataNascimento,
                                          infectadoViewModel.Sexo,
                                          infectadoViewModel.Latitude,
                                          infectadoViewModel.Longitude);

            infectado.Id = Id;

            await _infectadosColletion.ReplaceOneAsync(x => x.Id == Id, infectado);
        }

        public async Task Deletar(string Id)
        {
            await _infectadosColletion.DeleteOneAsync(x => x.Id == Id);
        }
    }
}
