using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginMVC_ActV.capamodelo
{
    public class Usuariomodel
    {

        public string IdUsuario { get; set; }

        public string NombreUsuario { get; set; }
        public string ApelldoUsuario { get; set; }
        public int codigoempleado { get; set; }
        public string RolUsuario { get; set; }

        public DateTime FechaApertura { get; set; }
        public string clave { get; set; }

        public string Activo { get; set; }

        public int intentoLogueos { get; set; }

        public DateTime FechaCambioclave { get; set; }

        public int PeriodoCambio { get; set; }
        public static DataTable ListarUusario { get; set; }

        public Usuariomodel() { }

    }
}
