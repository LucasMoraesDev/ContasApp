using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasApp.Data.Entities
{
    public class Categoria
    {
        #region Atributos
        private Guid _id;
        private string? _descrição;
        #endregion

        #region Propriedades
        public Guid Id { get => _id; set => _id = value; }
        public string? Descrição { get => _descrição; set => _descrição = value; }
        #endregion
    }
}
