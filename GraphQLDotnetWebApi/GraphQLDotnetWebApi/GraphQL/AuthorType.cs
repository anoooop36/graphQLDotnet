﻿using GraphQL.Types;
using GraphQLDotnetWebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotnetWebApi.GraphQL
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Name = "Author";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("Author's ID.");
            Field(x => x.Name).Description("The name of the Author");
            Field(x => x.Books, type: typeof(ListGraphType<BookType>)).Description("Author's books");
        }
    }
}
