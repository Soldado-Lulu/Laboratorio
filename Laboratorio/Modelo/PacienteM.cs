﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Modelo
{
    public class PacienteM
    {
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Medico { get; set; }
        public int Edad { get; set; }
        public int Telefono { get; set; }
        public int CI { get; set; }
        public string Sexo { get; set; }
        public string ExtencionCI { get; set; }
    }
}
