﻿using Odonto.Domain.Entities;
using System.Collections.Generic;

namespace Odonto.Domain.Interfaces.Service
{
    public interface IFuncionarioService
    {
        IEnumerable<Funcionario> GetAll();
    }
}