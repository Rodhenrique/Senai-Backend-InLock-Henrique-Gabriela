using Senai.InLock.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface Iusuario
    {
        List<UsuariosDomain> Listar();

        UsuariosDomain BuscarPorId(int id);

        void AdicionarNovoUsuario(UsuariosDomain usuarios);

        void AtualizarIdCorpo(UsuariosDomain usuarios);

        void Deletar(int id);

        UsuariosDomain BuscarEmalSenha(string Email, string Senha);
    }
}
