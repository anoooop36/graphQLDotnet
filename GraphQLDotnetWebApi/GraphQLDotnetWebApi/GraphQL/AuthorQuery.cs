﻿using GraphQL.Types;
using GraphQLDotnetWebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotnetWebApi.GraphQL
{
    public class AuthorQuery : ObjectGraphType
    {
        public AuthorQuery(ApplicationDbContext db)
        {
            Field<AuthorType>(
              "Author",
              arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the Author." }),
              resolve: context =>
              {
                  var id = context.GetArgument<int>("id");
                  var author = db
              .Authors
              .Include(a => a.Books)
              .FirstOrDefault(i => i.Id == id);
                  return author;
              });

            Field<ListGraphType<AuthorType>>(
              "Authors",
              resolve: context =>
              {
                  var authors = db.Authors.Include(a => a.Books);
                  return authors;
              });
        }
    }
}
