using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LibrarySQL
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int Año { get; set; }
    }

    public class BibliotecaDb
    {
        private string connectionString = "Server=localhost,1433;Database=Biblioteca;User Id=sa;Password=yourStrong!Passw0rd;";

        public List<Libro> ObtenerLibros()
        {
            List<Libro> libros = new List<Libro>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, titulo, autor, genero, año FROM libros";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    libros.Add(new Libro
                    {
                        Id = reader.GetInt32(0),
                        Titulo = reader.GetString(1),
                        Autor = reader.GetString(2),
                        Genero = reader.GetString(3),
                        Año = reader.GetInt32(4)
                    });
                }
            }
            return libros;
        }

        public Libro ObtenerLibroPorId(int id)
        {
            Libro libro = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, titulo, autor, genero, año FROM libros WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    libro = new Libro
                    {
                        Id = reader.GetInt32(0),
                        Titulo = reader.GetString(1),
                        Autor = reader.GetString(2),
                        Genero = reader.GetString(3),
                        Año = reader.GetInt32(4)
                    };
                }
            }
            return libro;
        }

        public void CrearLibro(Libro libro)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO libros (titulo, autor, genero, año) VALUES (@titulo, @autor, @genero, @año)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@titulo", libro.Titulo);
                cmd.Parameters.AddWithValue("@autor", libro.Autor);
                cmd.Parameters.AddWithValue("@genero", libro.Genero);
                cmd.Parameters.AddWithValue("@año", libro.Año);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarLibro(Libro libro)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE libros SET titulo = @titulo, autor = @autor, genero = @genero, año = @año WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", libro.Id);
                cmd.Parameters.AddWithValue("@titulo", libro.Titulo);
                cmd.Parameters.AddWithValue("@autor", libro.Autor);
                cmd.Parameters.AddWithValue("@genero", libro.Genero);
                cmd.Parameters.AddWithValue("@año", libro.Año);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarLibro(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM libros WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}