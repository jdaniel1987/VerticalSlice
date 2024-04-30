﻿using Dapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace VerticalSlice.Features.Games.Commands.UpdateGame;

public class UpdateGameHandler : IRequestHandler<UpdateGameCommand, IResult>
{
    private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VerticalSliceExample;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public async Task<IResult> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        string sql = @"UPDATE [Games]
                          SET
                              [Name] = @name,
                              [Publisher] = @publisher,
                              [Price] = @price,
                              [GamesConsoleId] = @gamesConsoleId
                        WHERE 
                              [Id] = @id";
        var db = new SqlConnection(_connectionString);
        await db.QueryAsync(sql, new
        {
            id = request.Id,
            name = request.Name,
            publisher = request.Publisher,
            price = request.Price,
            gamesConsoleId = request.GamesConsoleId,
        });

        return Results.Ok();
    }
}