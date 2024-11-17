using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAppEvento.Models
{
    internal class Participantes
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int NumerParticipantes { get; set; }
        public string Local {  get; set; }
        public double Custo { get; set; }
        public int Duracao 
        {
            get => DataFim.Subtract(DataInicio).Days;
        } 
    }
}
