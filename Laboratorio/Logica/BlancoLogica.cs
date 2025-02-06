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
    public class BlancoLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static BlancoLogica _instancia = null;
        public BlancoLogica()
        {

        }
        public static BlancoLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new BlancoLogica();
                }
                return _instancia;
            }
        }

        public bool Guardar(BlancoM obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "INSERT INTO Blanco (Nombre, NombreMedico,Edad, Muestra,Examen, Datos,Otros) VALUES (@nombre, @nombreMedico, @edad, @muestra, @examen, @datos, @otros)";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@nombreMedico", obj.Nombre_Medico));
                cmd.Parameters.Add(new SQLiteParameter("edad", obj.Edad));
                cmd.Parameters.Add(new SQLiteParameter("@muestra", obj.Muestra));
                cmd.Parameters.Add(new SQLiteParameter("@examen", obj.Examen));
                cmd.Parameters.Add(new SQLiteParameter("@datos", obj.Datos));
                cmd.Parameters.Add(new SQLiteParameter("@otros", obj.Otros));
                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;

                }
            }
            return respuesta;
        }
        public List<BlancoM> Listar()
        {
            List<BlancoM> oList = new List<BlancoM>();
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "SELECT Id, Nombre FROM Blanco";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oList.Add(new BlancoM()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre= dr["Nombre"].ToString()
                        });
                    }
                }
            }
            return oList;
        }

        public bool Editar(BlancoM obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "UPDATE Blanco SET   Nombre = @nombre,NombreMedico = @nombreMedico,Edad = @edad,Muestra = @muestra,Examen = @examen,Datos = @datos,Otros = @otros WHERE Id = @id";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", obj.Id));
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@nombreMedico", obj.Nombre_Medico));
                cmd.Parameters.Add(new SQLiteParameter("@edad", obj.Edad));
                cmd.Parameters.Add(new SQLiteParameter("@muestra", obj.Muestra));
                cmd.Parameters.Add(new SQLiteParameter("@examen", obj.Examen));
                cmd.Parameters.Add(new SQLiteParameter("@datos", obj.Datos));
                cmd.Parameters.Add(new SQLiteParameter("@otros", obj.Otros));       
                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public bool Eliminar(BlancoM ob)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "DELETE FROM Blanco WHERE Id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", ob.Id);

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public BlancoM BuscarPorNombre(int idpaciente)
        {
            BlancoM paciente = null;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = @"SELECT * FROM Blanco WHERE Id = @id"; // Cambio aquí
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", idpaciente)); // Cambio aquí
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        paciente = new BlancoM()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Nombre_Medico = dr["NombreMedico"].ToString(),
                            Edad = dr["Edad"].ToString(),
                            Examen = dr["Examen"].ToString(),
                            Muestra = dr["Muestra"].ToString(),
                            Datos = dr["Datos"].ToString(),
                            Otros = dr["Otros"].ToString(),
                        };
                    }
                }
            }
            return paciente;
        }
    }
}
