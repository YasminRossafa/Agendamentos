﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Agendamentos.API.Map;

public partial class tb_paciente
{
    public int id_paciente { get; set; }

    public string dsc_nome { get; set; }

    public DateTime dat_nascimento { get; set; }

    public DateTime dat_criacao { get; set; }

    public virtual ICollection<tb_agendamento> tb_agendamentos { get; set; } = new List<tb_agendamento>();
}