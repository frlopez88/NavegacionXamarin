using System;
using System.Collections.Generic;
using System.Text;

namespace NavTest.Models
{
    public class pais
    {
        public int idPais { get; set; }
        public string nombre_pais { get; set; }
        public string codigo_de_area { get; set; }

        public string toJson()
        {
            return "{\"idPais\":\"" + idPais + " \",\"nombre_pais\": \"" + nombre_pais + "\" , \"codigo_de_area\":\"" + codigo_de_area + "\"  }";
        }
    }
}
