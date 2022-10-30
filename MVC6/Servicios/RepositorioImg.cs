using System;
using Dapper;
using MVC6.Models;
using Npgsql;

namespace MVC6.Servicios
{
    public interface IRepositorioImg
    {
        void Crear(ImgViewModel imagen);
    }

    public class RepositorioImg: IRepositorioImg
    {
        private readonly string connectionString;

        public RepositorioImg(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Crear(ImgViewModel imagen)
        {
            using var connection = new NpgsqlConnection(connectionString);
            var id = connection.QuerySingle<int>(
                                            @"INSERT INTO imagenes(link)
                                            VALUES(@link) returning Id;", imagen);

            imagen.Id = id;
        }


    }

    
}

