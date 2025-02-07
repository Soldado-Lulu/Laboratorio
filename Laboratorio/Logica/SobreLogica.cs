using Laboratorio.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.Logica
{
    public class SobreLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static SobreLogica _instancia = null;
        public SobreLogica()
        {

        }
        public static SobreLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new SobreLogica();
                }
                return _instancia;
            }
        }

        public bool Guardar(SobreM obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "INSERT INTO Sobre (Nombre,Doctor,Presente, Paciente) VALUES (@nombre, @doctor, @presente, @paciente)";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@doctor", obj.Doctor));
                cmd.Parameters.Add(new SQLiteParameter("presente", obj.Presente));
                cmd.Parameters.Add(new SQLiteParameter("@paciente", obj.Paciente));
                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;

                }
            }
            return respuesta;
        }
        public List<SobreM> Listar()
        {
            List<SobreM> oList = new List<SobreM>();
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "SELECT Id, Nombre FROM Sobre";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oList.Add(new SobreM()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }
            }
            return oList;
        }

        public bool Editar(SobreM obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "UPDATE SobreM SET   Nombre = @nombre,Doctor = @doctor,Presente = @presente,Paciente = @paciente WHERE Id = @id";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", obj.Id));
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@doctor", obj.Doctor));
                cmd.Parameters.Add(new SQLiteParameter("@presente", obj.Presente));
                cmd.Parameters.Add(new SQLiteParameter("@paciente", obj.Paciente));
                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public bool Eliminar(SobreM ob)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "DELETE FROM Sobre WHERE Id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", ob.Id);

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public SobreM BuscarPorNombre(int idpaciente)
        {
            SobreM paciente = null;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = @"SELECT * FROM Sobre WHERE Id = @id"; // Cambio aquí
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", idpaciente)); // Cambio aquí
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        paciente = new SobreM()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Doctor = dr["Doctor"].ToString(),
                            Presente = dr["Presente"].ToString(),
                            Paciente = dr["Paciente"].ToString(),
                       
                        };
                    }
                }
            }
            return paciente;
        }
    }
}
