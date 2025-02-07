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
    public class SerologiaLogica
    {

        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static SerologiaLogica _instancia = null;
        public SerologiaLogica()
        {

        }
        public static SerologiaLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new SerologiaLogica();
                }
                return _instancia;
            }
        }

        public bool Guardar(SerologiaM obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "INSERT INTO Serologia (Nombre, NombreM,Edad, Reaccion,Campo11,Campo12,Campo13,Campo14,Campo15,Campo21,Campo22,Campo23,Campo24,Campo25,Campo31,Campo32,Campo33,Campo34,Campo35,Campo41,Campo42,Campo43,Campo44,Campo45,Observaciones) VALUES (@nombre, @nombreM,@edad, @reaccion,@campo11,@campo12,@campo13,@campo14,@campo15,@campo21,@campo22,@campo23,@campo24,@campo25,@campo31,@campo32,@campo33,@campo34,@campo35,@campo41,@campo42,@campo43,@campo44,@campo45,@observaciones)";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@nombreM", obj.NombreM));
                cmd.Parameters.Add(new SQLiteParameter("@edad", obj.Edad));
                cmd.Parameters.Add(new SQLiteParameter("@reaccion", obj.Reaccion));
                cmd.Parameters.Add(new SQLiteParameter("@campo11", obj.Campo11));
                cmd.Parameters.Add(new SQLiteParameter("@campo12", obj.Campo12));
                cmd.Parameters.Add(new SQLiteParameter("@campo13", obj.Campo13));
                cmd.Parameters.Add(new SQLiteParameter("@campo14", obj.Campo14));
                cmd.Parameters.Add(new SQLiteParameter("@campo15", obj.Campo15));
                cmd.Parameters.Add(new SQLiteParameter("@campo21", obj.Campo21));
                cmd.Parameters.Add(new SQLiteParameter("@campo22", obj.Campo22));
                cmd.Parameters.Add(new SQLiteParameter("@campo23", obj.Campo23));
                cmd.Parameters.Add(new SQLiteParameter("@campo24", obj.Campo24));
                cmd.Parameters.Add(new SQLiteParameter("@campo25", obj.Campo25));
                cmd.Parameters.Add(new SQLiteParameter("@campo31", obj.Campo31));
                cmd.Parameters.Add(new SQLiteParameter("@campo32", obj.Campo32));
                cmd.Parameters.Add(new SQLiteParameter("@campo33", obj.Campo33));
                cmd.Parameters.Add(new SQLiteParameter("@campo34", obj.Campo34));
                cmd.Parameters.Add(new SQLiteParameter("@campo35", obj.Campo35));
                cmd.Parameters.Add(new SQLiteParameter("@campo41", obj.Campo41));
                cmd.Parameters.Add(new SQLiteParameter("@campo42", obj.Campo42));
                cmd.Parameters.Add(new SQLiteParameter("@campo43", obj.Campo43));
                cmd.Parameters.Add(new SQLiteParameter("@campo44", obj.Campo44));
                cmd.Parameters.Add(new SQLiteParameter("@campo45", obj.Campo45));
                cmd.Parameters.Add(new SQLiteParameter("@observaciones", obj.Observaciones));
             
                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;

                }
            }
            return respuesta;
        }
        public List<SerologiaM> Listar()
        {
            List<SerologiaM> oList = new List<SerologiaM>();
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "SELECT Id, Nombre FROM Serologia";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oList.Add(new SerologiaM()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }
            }
            return oList;
        }

        public bool Editar(SerologiaM obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "UPDATE Serologia SET   Nombre = @nombre,NombreM = @nombreM,Edad = @edad,Campo11 = @campo11,Campo12 = @campo12,Campo13 = @campo13,Campo14 = @campo14,Campo15 = @campo15,Campo21 = @campo21,Campo22 = @campo22,Campo23 = @campo23,Campo24 = @campo24,Campo25 = @campo25,Campo31 = @campo31,Campo32 = @campo32,Campo33 = @campo33,Campo34 = @campo34,Campo35 = @campo35,Campo41 = @campo41,Campo42 = @campo42,Campo43 = @campo43,Campo44 = @campo44,Campo45 = @campo45,Observaciones = @observaciones WHERE Id = @id";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", obj.Id));
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@nombreM", obj.NombreM));
                cmd.Parameters.Add(new SQLiteParameter("@edad", obj.Edad));
                cmd.Parameters.Add(new SQLiteParameter("@campo11", obj.Campo11));
                cmd.Parameters.Add(new SQLiteParameter("@campo12", obj.Campo12));
                cmd.Parameters.Add(new SQLiteParameter("@campo13", obj.Campo13));
                cmd.Parameters.Add(new SQLiteParameter("@campo14", obj.Campo14));
                cmd.Parameters.Add(new SQLiteParameter("@campo15", obj.Campo15));
                cmd.Parameters.Add(new SQLiteParameter("@campo21", obj.Campo21));
                cmd.Parameters.Add(new SQLiteParameter("@campo22", obj.Campo22));
                cmd.Parameters.Add(new SQLiteParameter("@campo23", obj.Campo23));
                cmd.Parameters.Add(new SQLiteParameter("@campo24", obj.Campo24));
                cmd.Parameters.Add(new SQLiteParameter("@campo25", obj.Campo25));
                cmd.Parameters.Add(new SQLiteParameter("@campo31", obj.Campo31));
                cmd.Parameters.Add(new SQLiteParameter("@campo32", obj.Campo32));
                cmd.Parameters.Add(new SQLiteParameter("@campo33", obj.Campo33));
                cmd.Parameters.Add(new SQLiteParameter("@campo34", obj.Campo34));
                cmd.Parameters.Add(new SQLiteParameter("@campo35", obj.Campo35));
                cmd.Parameters.Add(new SQLiteParameter("@campo41", obj.Campo41));
                cmd.Parameters.Add(new SQLiteParameter("@campo42", obj.Campo42));
                cmd.Parameters.Add(new SQLiteParameter("@campo43", obj.Campo43));
                cmd.Parameters.Add(new SQLiteParameter("@campo44", obj.Campo44));
                cmd.Parameters.Add(new SQLiteParameter("@campo45", obj.Campo45));
                cmd.Parameters.Add(new SQLiteParameter("@observaciones", obj.Observaciones));

                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public bool Eliminar(SerologiaM ob)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "DELETE FROM Serologia WHERE Id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", ob.Id);

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public SerologiaM BuscarPorNombre(int idpaciente)
        {
            SerologiaM paciente = null;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = @"SELECT * FROM Serologia WHERE Id = @id"; // Cambio aquí
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", idpaciente)); // Cambio aquí
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        paciente = new SerologiaM()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            NombreM = dr["NombreM"].ToString(),
                            Edad = dr["Edad"].ToString(),
                            Campo11 = dr["Campo11"].ToString(),
                            Campo12 = dr["Campo12"].ToString(),
                            Campo13 = dr["Campo13"].ToString(),
                            Campo14 = dr["Campo14"].ToString(),
                            Campo15 = dr["Campo15"].ToString(),
                            Campo21 = dr["Campo21"].ToString(),
                            Campo22 = dr["Campo22"].ToString(),
                            Campo23 = dr["Campo23"].ToString(),
                            Campo24 = dr["Campo24"].ToString(),
                            Campo25 = dr["Campo25"].ToString(),
                            Campo31 = dr["Campo31"].ToString(),
                            Campo32 = dr["Campo32"].ToString(),
                            Campo33 = dr["Campo33"].ToString(),
                            Campo34 = dr["Campo34"].ToString(),
                            Campo35 = dr["Campo35"].ToString(),
                            Campo41 = dr["Campo41"].ToString(),
                            Campo42 = dr["Campo42"].ToString(),
                            Campo43 = dr["Campo43"].ToString(),
                            Campo44 = dr["Campo44"].ToString(),
                            Campo45 = dr["Campo45"].ToString(),
                            Observaciones = dr["Observaciones"].ToString(),
                        };
                    }
                }
            }
            return paciente;
        }










    }
}
