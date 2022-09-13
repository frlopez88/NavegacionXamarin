using System;
using System.Collections.Generic;
using System.Text;

namespace NavTest.Models
{
    public class persona
    {
        public int id_persona { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string genero { get; set; }

        public string toJson()
        {

            return "{\"nombre\":\"" + nombre + " \",\"apellido\": \"" + apellido + "\" , \"genero\":\"" + genero + "\"  }";
        }
    }
}
