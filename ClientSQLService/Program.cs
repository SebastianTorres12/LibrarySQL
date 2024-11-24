using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSQLService.ServiceReference1;

namespace ClientSQLService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear el cliente del servicio SOAP
            var client = new Service1Client(); // Asegúrate de que este es el nombre correcto del cliente generado

            try
            {
                // Crear un nuevo libro
                var libro = new Libro
                {
                    Titulo = "C# Programming",
                    Autor = "John Doe",
                    Genero = "Programming",
                    Año = 2024
                };

                // Llamar a la operación CrearLibro
                client.CrearLibro(libro);
                Console.WriteLine("Libro añadido.");

                // Obtener el libro
                var fetchedBook = client.ObtenerLibroPorId(1);
                if (fetchedBook != null)
                {
                    Console.WriteLine($"Libro obtenido: {fetchedBook.Titulo}, {fetchedBook.Autor}");

                    // Actualizar el libro
                    fetchedBook.Titulo = "Advanced C# Programming";
                    client.ActualizarLibro(fetchedBook);
                    Console.WriteLine("Libro actualizado.");

                    // Eliminar el libro
                    client.EliminarLibro(fetchedBook.Id);
                    Console.WriteLine("Libro eliminado.");
                }
                else
                {
                    Console.WriteLine("Libro no encontrado.");
                }

                // Listar todos los libros
                var books = client.ObtenerLibros();
                Console.WriteLine("Libros disponibles:");
                foreach (var b in books)
                {
                    Console.WriteLine($"{b.Titulo} por {b.Autor}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Cerrar el cliente
                if (client.State == System.ServiceModel.CommunicationState.Faulted)
                {
                    client.Abort();
                }
                else
                {
                    client.Close();
                }
            }

            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
