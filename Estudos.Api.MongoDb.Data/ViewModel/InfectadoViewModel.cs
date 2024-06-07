using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Api.MongoDb.Data.ViewModel
{
    public class InfectadoViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
