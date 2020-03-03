using Senai.InLock.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface ItipoUsuario
    {
        List<TipoUsuarioDomain> Listar();

        TipoUsuarioDomain BuscarPorId(int id);

        void AdicionarTipoUsuario(TipoUsuarioDomain tipo);

        void AtualizarIdCorpo(TipoUsuarioDomain tipo);

        void Deletar(int id);
    }
}
