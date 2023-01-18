using System;
using System.Collections.Generic;

namespace RXCrud.Domain.Entities
{
    public class Estado : Entity
    {
        public Estado(string uf, string descricao)
        {
            Uf = uf;
            Id = Guid.NewGuid();
            Descricao = descricao;
        }

        public string Uf { get; set; }

        public string Descricao { get; set; }

        public ICollection<Cidade> Cidades { get; set; }
    }
}