using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_vendas.model
{
    public class Funcionario : Cliente
    {
        // atributos e getter / setter
        public string senha { get; set; }
        public string cargo { get; set; }
        public string nivel_acesso { get; set; }



    }
}
