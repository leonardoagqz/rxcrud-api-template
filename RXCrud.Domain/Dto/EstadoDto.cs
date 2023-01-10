﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RXCrud.Domain.Dto
{
    [DisplayName("Estado")]
    public class EstadoDto
    {
        public EstadoDto()
            => Id = Guid.NewGuid();

        public EstadoDto(Guid id, string uf, string descricao)
        {
            Id = id;
            Uf = uf;
            Descricao = descricao;
            
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo 'Uf' obrigatório.")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "Campo 'Uf' obrigatório.")]
        public string Descricao { get; set; }      
        
    }
}