using System;

namespace RXCrud.Domain.Entities
{
    public class Cidade : Entity
    {
        public Cidade(Guid idEstado, string descricao)
        {
            Id = Guid.NewGuid();
            IdEstado = idEstado;
            Descricao = descricao;
        }

        public string Descricao { get; set; }

        public Guid IdEstado { get; set; }

        public Estado Estado { get; set; }
    }
}