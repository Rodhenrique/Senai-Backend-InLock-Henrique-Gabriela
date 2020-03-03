using Senai.InLock.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface Ijogos
    {
        List<JogosDomain> Listar();

        JogosDomain BuscarPorId(int id);

        void AdicionarJogo(JogosDomain jogos);

        void AtualizarIdCorpo(JogosDomain jogos);

        void Deletar(int id);

    }
}
