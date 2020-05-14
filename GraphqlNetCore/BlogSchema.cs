using GraphQL.Types;
using GraphqlNetCore.Querys;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlNetCore
{
    public class BlogSchema:Schema
    {
        public BlogSchema(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<BlogQuery>();
        }
    }
}
