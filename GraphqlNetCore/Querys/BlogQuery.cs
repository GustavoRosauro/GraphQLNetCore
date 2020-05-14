using GraphQL.Types;
using GraphqlNetCore.Data;
using GraphqlNetCore.Data.Repositorio;
using GraphqlNetCore.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlNetCore.Querys
{
    public class BlogQuery:ObjectGraphType<object>
    {
        public BlogQuery(UsuarioRepositorio repositorio)
        {
            Field<ListGraphType<UsuarioType>>("usuario",
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<IdGraphType>{Name="id"},
                    new QueryArgument<StringGraphType>{Name="nome"}
                }),
                resolve: contexto =>
                {
                    var filtro = new UsuarioFiltro()
                    {
                        Id = contexto.GetArgument<int>("id"),
                        Nome = contexto.GetArgument<string>("nome")
                    };
                    return repositorio.ObterUsuarios(filtro);
                });
        }
    }
}
