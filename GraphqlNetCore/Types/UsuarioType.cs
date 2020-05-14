using GraphQL.Types;
using GraphqlNetCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlNetCore.Types
{
    public class UsuarioType: ObjectGraphType<Usuario>
    {
        public UsuarioType()
        {
            Name = "Usuario";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id Usuário");
            Field(x => x.Idade).Description("Idade do Usuário");
            Field(x => x.Nome).Description("Nome do Usuário");
            Field(x => x.DataCriacao).Description("Data de Criação");
            Field(x => x.DataAlteracao).Description("Data Alteração do Usuário");
        }
    }
}
