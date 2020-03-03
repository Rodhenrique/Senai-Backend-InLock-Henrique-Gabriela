using Senai.InLock.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface Iestudios
    {
        List<EstudiosDomain> Listar();

        EstudiosDomain BuscarPorId(int id);

        void AdicionarEstudio(EstudiosDomain estudios);

        void AtualizarIdCorpo(EstudiosDomain estudios);

        void Deletar(int id);

    }
}
