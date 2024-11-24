using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LibrarySQL
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Libro> ObtenerLibros();

        [OperationContract]
        Libro ObtenerLibroPorId(int id);

        [OperationContract]
        void CrearLibro(Libro libro);

        [OperationContract]
        void ActualizarLibro(Libro libro);

        [OperationContract]
        void EliminarLibro(int id);
    }
}
