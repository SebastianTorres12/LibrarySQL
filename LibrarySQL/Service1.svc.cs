using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LibrarySQL
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        private BibliotecaDb db = new BibliotecaDb();

        public List<Libro> ObtenerLibros()
        {
            return db.ObtenerLibros();
        }

        public Libro ObtenerLibroPorId(int id)
        {
            return db.ObtenerLibroPorId(id);
        }

        public void CrearLibro(Libro libro)
        {
            db.CrearLibro(libro);
        }

        public void ActualizarLibro(Libro libro)
        {
            db.ActualizarLibro(libro);
        }

        public void EliminarLibro(int id)
        {
            db.EliminarLibro(id);
        }
    }
}
