﻿namespace Agendamentos.Entidade.Entidades
{
    public abstract class IdEntidade<T> : IEntidade
    {
        public T Id { get; set; }
    }
}
