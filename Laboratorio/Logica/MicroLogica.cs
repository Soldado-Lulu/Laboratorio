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
    public class MicroLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static MicroLogica _instancia = null;
        public MicroLogica()
        {

        }
        public static MicroLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new MicroLogica();
                }
                return _instancia;
            }
        }
        public bool Guardar(MicroM obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "INSERT INTO Microbiologia (Nombre, NombreM,Edad, Muestra,Gram,M1, M2,M3,Cultivo,Colonia,Identificacion,Sensible,Resistentes) VALUES (@nombre, @nombreM, @edad, @muestra,@gram, @m1, @m2, @m3,@cultivo,@colonia,@identificacion,@sensible,@resistentes)";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@nombreM", obj.Nombre_Medico));
                cmd.Parameters.Add(new SQLiteParameter("edad", obj.Edad));
                cmd.Parameters.Add(new SQLiteParameter("@muestra", obj.Muestra));
                cmd.Parameters.Add(new SQLiteParameter("@gram", obj.Gram));
                cmd.Parameters.Add(new SQLiteParameter("@m1", obj.M1));
                cmd.Parameters.Add(new SQLiteParameter("@m2", obj.M2));
                cmd.Parameters.Add(new SQLiteParameter("@m3", obj.M3));
                cmd.Parameters.Add(new SQLiteParameter("@cultivo", obj.Cultivo));
                cmd.Parameters.Add(new SQLiteParameter("@colonia", obj.Colonia));

                cmd.Parameters.Add(new SQLiteParameter("@identificacion", obj.Identificacion));
                cmd.Parameters.Add(new SQLiteParameter("@sensible", obj.Sensible));
                cmd.Parameters.Add(new SQLiteParameter("@resistentes", obj.Resistencia));
                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public List<MicroM> Listar()
        {
            List<MicroM> oList = new List<MicroM>();
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "SELECT Id, Nombre FROM Microbiologia";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oList.Add(new MicroM()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }
            }
            return oList;
        }

        public bool Editar(MicroM obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "UPDATE Microbiologia SET   Nombre = @nombre,NombreM = @nombreM,Edad = @edad,Muestra = @muestra,Gram = @gram,M1 = @m1,M2 = @m2, M3=@m3,Cultivo=@cultivo,Colonia=@colonia, Identificacion=@identificacion, Sensible =@sensible, Resistentes=@resistentes WHERE Id = @id";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", obj.Id));
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@nombreM", obj.Nombre_Medico));
                cmd.Parameters.Add(new SQLiteParameter("@edad", obj.Edad));
                cmd.Parameters.Add(new SQLiteParameter("@muestra", obj.Muestra));
                cmd.Parameters.Add(new SQLiteParameter("@gram", obj.Gram));
                cmd.Parameters.Add(new SQLiteParameter("@m1", obj.M1));
                cmd.Parameters.Add(new SQLiteParameter("@m2", obj.M2));
                cmd.Parameters.Add(new SQLiteParameter("@m3", obj.M3));
                cmd.Parameters.Add(new SQLiteParameter("@cultivo", obj.Cultivo));
                cmd.Parameters.Add(new SQLiteParameter("@colonia", obj.Colonia));
                cmd.Parameters.Add(new SQLiteParameter("@identificacion", obj.Identificacion));
                cmd.Parameters.Add(new SQLiteParameter("@sensible", obj.Identificacion));
                cmd.Parameters.Add(new SQLiteParameter("@resistentes", obj.Resistencia));


                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool Eliminar(MicroM ob)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "DELETE FROM Microbiologia WHERE Id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", ob.Id);

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public MicroM BuscarPorNombre(int idpaciente)
        {
            MicroM paciente = null;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = @"SELECT * FROM Microbiologia WHERE Id = @id"; // Cambio aquí
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", idpaciente)); // Cambio aquí
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        paciente = new MicroM()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Nombre_Medico = dr["NombreM"].ToString(),
                            Edad = dr["Edad"].ToString(),
                            Muestra = dr["Muestra"].ToString(),
                            M1 = dr["M1"].ToString(),
                            M2 = dr["M2"].ToString(),
                            M3 = dr["M3"].ToString(),
                            Cultivo = dr["Cultivo"].ToString(),
                            Colonia = dr["Colonia"].ToString(),
                            Identificacion = dr["identificacion"].ToString(),
                            Sensible = dr["sensible"].ToString(),
                            Resistencia = dr["Resistentes"].ToString(),
                        };
                    }
                }
            }
            return paciente;
        }
    }
}
