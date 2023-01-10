using System;

namespace RXCrud.Domain.Entities
{
    public class Estado : Entity
    {
        
        public Estado(Guid id, string uf, string descricao)
        {
            Id = id;
            Uf = uf;
            Descricao = descricao;
        }

        public Estado(string uf, string descricao)
        {
           
            Uf = uf;
            Descricao = descricao;
        }

        public string Uf { get; set; }

        public string Descricao { get; set; }
       
    }
}