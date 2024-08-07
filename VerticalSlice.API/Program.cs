using Carter;
using VerticalSlice.Queries.API.DatabaseSeed;

namespace VerticalSlice.Queries.API;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        //----------------------------------------------------
        builder.Services.AddApi();
        //----------------------------------------------------

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        //------------------------------------------------------
        app.MapCarter(); // Carter will take care of mapping all API routes that are specified in Services
        DatabaseCreation.CreateDatabase(builder.Configuration);
        //------------------------------------------------------

        app.Run();
    }
}
