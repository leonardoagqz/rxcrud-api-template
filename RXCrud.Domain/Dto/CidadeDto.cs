using System;
using System.ComponentModel;
using RXCrud.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RXCrud.Domain.Dto
{
    [DisplayName("Cidade")]
    public class CidadeDto
    {
        public CidadeDto()
            => Id = Guid.NewGuid();

        public CidadeDto(Guid idEstado, string descricao)
        {
            Id = Guid.NewGuid();
            IdEstado = idEstado;
            Descricao = descricao;          
        }

        public Guid Id { get; set; }        

        [Required(ErrorMessage = "Campo 'Descrição' obrigatório.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo 'IdEstado' obrigatório.")]
        public Guid IdEstado { get; set; }

        public EstadoDto Estado { get; set; }
    }
}