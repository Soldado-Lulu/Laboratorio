using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorio.Modelo;

using System.Configuration;
using System.Data.SQLite;
namespace Laboratorio.Logica
{
    public class CoprosLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static CoprosLogica _instancia = null;
        public CoprosLogica()
        {

        }
        public static CoprosLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CoprosLogica();
                }
                return _instancia;
            }
        }

        public bool Guardar(CoprosM obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "INSERT INTO Copros (Nombre, NombreMedico,Edad,Consistencia,Color, ExamenM,Observaciones) VALUES (@nombre, @nombreMedico, @edad, @consistencia, @color, @examenM, @observaciones)";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@nombreMedico", obj.Nombre_Medico));
                cmd.Parameters.Add(new SQLiteParameter("edad", obj.Edad));
                cmd.Parameters.Add(new SQLiteParameter("@consistencia", obj.Consistencia));
                cmd.Parameters.Add(new SQLiteParameter("@color", obj.Color));
                cmd.Parameters.Add(new SQLiteParameter("@examenM", obj.ExamenM));
                cmd.Parameters.Add(new SQLiteParameter("@observaciones", obj.Observaciones));
                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;

                }
            }
            return respuesta;
        }

        public List<CoprosM> Listar()
        {
            List<CoprosM> oList = new List<CoprosM>();
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "SELECT Id, Nombre FROM Copros";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oList.Add(new CoprosM()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }
            }
            return oList;
        }

        public bool Editar(CoprosM obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "UPDATE Copros SET   Nombre = @nombre,NombreMedico = @nombreMedico,Edad = @edad,Consistencia = @consistencia,Color = @color,ExamenM = @examenM,Observaciones = @observaciones WHERE Id = @id";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", obj.Id));
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@nombreMedico", obj.Nombre_Medico));
                cmd.Parameters.Add(new SQLiteParameter("@edad", obj.Edad));
                cmd.Parameters.Add(new SQLiteParameter("@consistencia", obj.Consistencia));
                cmd.Parameters.Add(new SQLiteParameter("@color", obj.Color));
                cmd.Parameters.Add(new SQLiteParameter("@examenM", obj.ExamenM));
                cmd.Parameters.Add(new SQLiteParameter("@observaciones", obj.Observaciones));
                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }


        public bool Eliminar(CoprosM ob)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "DELETE FROM Copros WHERE Id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", ob.Id);

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public CoprosM BuscarPorNombre(int idpaciente)
        {
            CoprosM paciente = null;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = @"SELECT * FROM Copros WHERE Id = @id"; // Cambio aquí
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", idpaciente)); // Cambio aquí
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        paciente = new CoprosM()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Nombre_Medico = dr["NombreMedico"].ToString(),
                            Edad = dr["Edad"].ToString(),
                            Consistencia = dr["Consistencia"].ToString(),
                            Color = dr["Color"].ToString(),
                            ExamenM = dr["ExamenM"].ToString(),
                            Observaciones = dr["Observaciones"].ToString(),
                        };
                    }
                }
            }
            return paciente;
        }







    }
}
