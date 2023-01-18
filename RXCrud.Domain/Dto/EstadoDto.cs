using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RXCrud.Domain.Dto
{
    [DisplayName("Estado")]
    public class EstadoDto
    {
        public EstadoDto()
            => Id = Guid.NewGuid();

        public EstadoDto(string uf, string descricao)
        {
            Uf = uf;
            Id = Guid.NewGuid();
            Descricao = descricao;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo 'Uf' obrigatório.")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "Campo 'Descrição' obrigatório.")]
        public string Descricao { get; set; }
    }
}