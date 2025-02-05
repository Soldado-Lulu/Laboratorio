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
    public class HematologiaLogica
    {

        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static HematologiaLogica _instancia = null;
        public HematologiaLogica()
        {

        }
        public static HematologiaLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new HematologiaLogica();
                }
                return _instancia;
            }
        }


        public bool Guardar(Hematologia obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "INSERT INTO Hematologia (Eritrocitos, Leucocitos, Hemoglobina, Hematocrito, Plaquetas, Mielocitos, Melamielocitos, Cayados, Segmentados, Linfocitos, Monocitos, Eosinofilos, Basofilos, VES1, VES2, Ik, GrupoSanguineo, Factor, TiempoSangria, TiempoCoagulacion, TiempoProtrombina, PorcentajeActividad, Aptt, SerieRoja, SerieBlanca, NombrePaciente, MedicoSolicitante, Edad) VALUES (@eritrocitos, @leucocitos, @hemoglobina, @hematocrito, @plaquetas, @mielocitos, @melamielocitos, @cayados, @segmentados, @linfocitos, @monocitos, @eosinofilos, @basofilos, @ves1, @ves2, @ik, @gruposanguineo, @factor, @tiemposangria, @tiempocoagulacion, @tiempoprotrombina, @porcentajeactividad, @aptt, @serieroja, @serieblanca, @nombrepaciente, @medicosolicitante, @edad)";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@eritrocitos", obj.Eritrocitos));
                cmd.Parameters.Add(new SQLiteParameter("@leucocitos", obj.Leucocitos));
                cmd.Parameters.Add(new SQLiteParameter("@hemoglobina", obj.Hemoglobina));
                cmd.Parameters.Add(new SQLiteParameter("@hematocrito", obj.Hematocrito));
                cmd.Parameters.Add(new SQLiteParameter("@plaquetas", obj.Plaquetas));
                cmd.Parameters.Add(new SQLiteParameter("@mielocitos", obj.Mielocitos));
                cmd.Parameters.Add(new SQLiteParameter("@melamielocitos", obj.Melamielocitos));
                cmd.Parameters.Add(new SQLiteParameter("@cayados", obj.Cayados));
                cmd.Parameters.Add(new SQLiteParameter("@segmentados", obj.Segmentados));
                cmd.Parameters.Add(new SQLiteParameter("@linfocitos", obj.Linfocitos));
                cmd.Parameters.Add(new SQLiteParameter("@monocitos", obj.Monocitos));
                cmd.Parameters.Add(new SQLiteParameter("@eosinofilos", obj.Eosinofilos));
                cmd.Parameters.Add(new SQLiteParameter("@basofilos", obj.Basofilos));
                cmd.Parameters.Add(new SQLiteParameter("@ves1", obj.VES1));
                cmd.Parameters.Add(new SQLiteParameter("@ves2", obj.VES2));
                cmd.Parameters.Add(new SQLiteParameter("@ik", obj.Ik));
                cmd.Parameters.Add(new SQLiteParameter("@gruposanguineo", obj.GrupoSanguineo));
                cmd.Parameters.Add(new SQLiteParameter("@factor", obj.Factor));
                cmd.Parameters.Add(new SQLiteParameter("@tiemposangria", obj.TiempoSangria));
                cmd.Parameters.Add(new SQLiteParameter("@tiempocoagulacion", obj.TiempoCoagulacion));
                cmd.Parameters.Add(new SQLiteParameter("@tiempoprotrombina", obj.TiempoProtrombina));
                cmd.Parameters.Add(new SQLiteParameter("@porcentajeactividad", obj.PorcentajeActividad));
                cmd.Parameters.Add(new SQLiteParameter("@aptt", obj.Aptt));
                cmd.Parameters.Add(new SQLiteParameter("@serieroja", obj.SerieRoja));
                cmd.Parameters.Add(new SQLiteParameter("@serieblanca", obj.SerieBlanca));
                cmd.Parameters.Add(new SQLiteParameter("@nombrepaciente", obj.NombrePaciente));
                cmd.Parameters.Add(new SQLiteParameter("@medicosolicitante", obj.MedicoSolicitante));
                cmd.Parameters.Add(new SQLiteParameter("@edad", obj.Edad));
                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;

                }
            }
            return respuesta;
        }
        public List<Hematologia> Listar()
        {
            List<Hematologia> oList = new List<Hematologia>();
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "SELECT Id, Eritrocitos, Leucocitos, Hemoglobina, Hematocrito, Plaquetas, Mielocitos, Melamielocitos, Cayados, Segmentados, Linfocitos, Monocitos, Eosinofilos, Basofilos, VES1, VES2, Ik, GrupoSanguineo, Factor, TiempoSangria, TiempoCoagulacion, TiempoProtrombina, PorcentajeActividad, Aptt, SerieRoja, SerieBlanca, NombrePaciente, MedicoSolicitante, Edad FROM Hematologia";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oList.Add(new Hematologia()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Eritrocitos = dr["Eritrocitos"].ToString(),
                            Leucocitos = dr["Leucocitos"].ToString(),
                            Hemoglobina = dr["Hemoglobina"].ToString(),
                            Hematocrito = dr["Hematocrito"].ToString(),
                            Plaquetas = dr["Plaquetas"].ToString(),
                            Mielocitos = dr["Mielocitos"].ToString(),
                            Melamielocitos = dr["Melamielocitos"].ToString(),
                            Cayados = dr["Cayados"].ToString(),
                            Segmentados = dr["Segmentados"].ToString(),
                            Linfocitos = dr["Linfocitos"].ToString(),
                            Monocitos = dr["Monocitos"].ToString(),
                            Eosinofilos = dr["Eosinofilos"].ToString(),
                            Basofilos = dr["Basofilos"].ToString(),
                            VES1 = dr["VES1"].ToString(),
                            VES2 = dr["VES2"].ToString(),
                            Ik = dr["Ik"].ToString(),
                            GrupoSanguineo = dr["GrupoSanguineo"].ToString(),
                            Factor = dr["Factor"].ToString(),
                            TiempoSangria = dr["TiempoSangria"].ToString(),
                            TiempoCoagulacion = dr["TiempoCoagulacion"].ToString(),
                            TiempoProtrombina = dr["TiempoProtrombina"].ToString(),
                            PorcentajeActividad = dr["PorcentajeActividad"].ToString(),
                            Aptt = dr["Aptt"].ToString(),
                            SerieRoja = dr["SerieRoja"].ToString(),
                            SerieBlanca = dr["SerieBlanca"].ToString(),
                            NombrePaciente = dr["NombrePaciente"].ToString(),
                            MedicoSolicitante = dr["MedicoSolicitante"].ToString(),
                            Edad = dr["Edad"].ToString()
                        });
                    }
                }
            }



            return oList;
        }

        public bool Editar(Hematologia obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "UPDATE Hematologia SET   Eritrocitos = @eritrocitos, Leucocitos = @leucocitos,  Hemoglobina = @hemoglobina,   Hematocrito = @hematocrito,  Plaquetas = @plaquetas,  Mielocitos = @mielocitos,    Melamielocitos = @melamielocitos,  Cayados = @cayados,    Segmentados = @segmentados, Linfocitos = @linfocitos,    Monocitos = @monocitos,    Eosinofilos = @eosinofilos,    Basofilos = @basofilos,  VES1 = @ves1,   VES2 = @ves2,   Ik = @ik,  GrupoSanguineo = @gruposanguineo,   Factor = @factor,  TiempoSangria = @tiemposangria,    TiempoCoagulacion = @tiempocoagulacion,   TiempoProtrombina = @tiempoprotrombina,  PorcentajeActividad = @porcentajeactividad,    Aptt = @aptt,   SerieRoja = @serieroja,    SerieBlanca = @serieblanca,    NombrePaciente = @nombrepaciente,    MedicoSolicitante = @medicosolicitante,  Edad = @edad WHERE Id = @id";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", obj.Id));
                cmd.Parameters.Add(new SQLiteParameter("@eritrocitos", obj.Eritrocitos));
                cmd.Parameters.Add(new SQLiteParameter("@leucocitos", obj.Leucocitos));
                cmd.Parameters.Add(new SQLiteParameter("@hemoglobina", obj.Hemoglobina));
                cmd.Parameters.Add(new SQLiteParameter("@hematocrito", obj.Hematocrito));
                cmd.Parameters.Add(new SQLiteParameter("@plaquetas", obj.Plaquetas));
                cmd.Parameters.Add(new SQLiteParameter("@mielocitos", obj.Mielocitos));
                cmd.Parameters.Add(new SQLiteParameter("@melamilocitos", obj.Melamielocitos));
                cmd.Parameters.Add(new SQLiteParameter("@cayados", obj.Cayados));
                cmd.Parameters.Add(new SQLiteParameter("@segmentados", obj.Segmentados));
                cmd.Parameters.Add(new SQLiteParameter("@linfocitos", obj.Linfocitos));
                cmd.Parameters.Add(new SQLiteParameter("@monocitos", obj.Monocitos));
                cmd.Parameters.Add(new SQLiteParameter("@eosinofilos", obj.Eosinofilos));
                cmd.Parameters.Add(new SQLiteParameter("@basofilos", obj.Basofilos));
                cmd.Parameters.Add(new SQLiteParameter("@ves1", obj.VES1));
                cmd.Parameters.Add(new SQLiteParameter("@ves2", obj.VES2));
                cmd.Parameters.Add(new SQLiteParameter("@ik", obj.Ik));
                cmd.Parameters.Add(new SQLiteParameter("@gruposanguineo", obj.GrupoSanguineo));
                cmd.Parameters.Add(new SQLiteParameter("@factor", obj.Factor));
                cmd.Parameters.Add(new SQLiteParameter("@tiemposangria", obj.TiempoSangria));
                cmd.Parameters.Add(new SQLiteParameter("@tiempocoagulacion", obj.TiempoCoagulacion));
                cmd.Parameters.Add(new SQLiteParameter("@tiempoprotrombina", obj.TiempoProtrombina));
                cmd.Parameters.Add(new SQLiteParameter("@porcentajeactividad", obj.PorcentajeActividad));
                cmd.Parameters.Add(new SQLiteParameter("@aptt", obj.Aptt));
                cmd.Parameters.Add(new SQLiteParameter("@serieroja", obj.SerieRoja));
                cmd.Parameters.Add(new SQLiteParameter("@serieblanca", obj.SerieBlanca));
                cmd.Parameters.Add(new SQLiteParameter("@nombrepaciente", obj.NombrePaciente));
                cmd.Parameters.Add(new SQLiteParameter("@medicosolicitante", obj.MedicoSolicitante));
                cmd.Parameters.Add(new SQLiteParameter("@edad", obj.Edad));
                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public bool Eliminar(int id)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "DELETE FROM Hematologia WHERE Id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", id);

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }






    }
}
