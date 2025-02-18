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
    public class QuimicaLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static QuimicaLogica _instancia = null;
        public QuimicaLogica()
        {

        }
        public static QuimicaLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new QuimicaLogica();
                }
                return _instancia;
            }
        }
        /*
        public bool Guardar(QuimicaM obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = @"INSERT INTO Quimica ( Glucosa, Urea, Creatina, BUN, Urico, Colesterol, 
                         HDL, LDL, Triglicerido, Bilirrubina, Directa, Indirecta, Total, GOT, GPT, FosfatasaAlcalina, 
                         Amilasa, Proteina, Albumina, Globulina, Relacion, FofatasaAcida, FosfatasaAcidaProtastica, 
                         CKMB, CPK, Hemogloblina, Sodio, Potasio, Cloro, Calcio) 
                         VALUES ( @glucosa, @urea, @creatina, @bun, @urico, @colesterol, 
                         @hdl, @ldl, @triglicerido, @bilirrubina, @directa, @indirecta, @total, @got, @gpt, 
                         @fosfatasaAlcalina, @amilasa, @proteina, @albumina, @globulina, @relacion, 
                         @fofatasaAcida, @fosfatasaAcidaProtastica, @ckmb, @cpk, @hemogloblina, @sodio, 
                         @potasio, @cloro, @calcio)";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
              //  cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                //cmd.Parameters.AddWithValue("@nombreM", obj.NombreM);
                //cmd.Parameters.AddWithValue("@edad", obj.Edad);
                cmd.Parameters.AddWithValue("@glucosa", obj.Glucosa);
                cmd.Parameters.AddWithValue("@urea", obj.Urea);
                cmd.Parameters.AddWithValue("@creatina", obj.Creatina);
                cmd.Parameters.AddWithValue("@bun", obj.BUN);
                cmd.Parameters.AddWithValue("@urico", obj.Urico);
                cmd.Parameters.AddWithValue("@colesterol", obj.Colesterol);
                cmd.Parameters.AddWithValue("@hdl", obj.HDL);
                cmd.Parameters.AddWithValue("@ldl", obj.LDL);
                cmd.Parameters.AddWithValue("@triglicerido", obj.Triglicerido);
                cmd.Parameters.AddWithValue("@bilirrubina", obj.Bilirrubina);
                cmd.Parameters.AddWithValue("@directa", obj.Directa);
                cmd.Parameters.AddWithValue("@indirecta", obj.Indirecta);
                cmd.Parameters.AddWithValue("@total", obj.Total);
                cmd.Parameters.AddWithValue("@got", obj.GOT);
                cmd.Parameters.AddWithValue("@gpt", obj.GPT);
                cmd.Parameters.AddWithValue("@fosfatasaAlcalina", obj.FosfatasaAlcalina);
                cmd.Parameters.AddWithValue("@amilasa", obj.Amilasa);
                cmd.Parameters.AddWithValue("@proteina", obj.Proteina);
                cmd.Parameters.AddWithValue("@albumina", obj.Albumina);
                cmd.Parameters.AddWithValue("@globulina", obj.Globulina);
                cmd.Parameters.AddWithValue("@relacion", obj.Relacion);
                cmd.Parameters.AddWithValue("@fofatasaAcida", obj.FosfatasaAcida);
                cmd.Parameters.AddWithValue("@fosfatasaAcidaProtastica", obj.FosfatasaAcidaProstatica);
                cmd.Parameters.AddWithValue("@ckmb", obj.CKMB);
                cmd.Parameters.AddWithValue("@cpk", obj.CPK);
                cmd.Parameters.AddWithValue("@hemogloblina", obj.Hemoglobina);
              //  cmd.Parameters.AddWithValue("@lipasa", obj.Lipasa);
                cmd.Parameters.AddWithValue("@sodio", obj.Sodio);
                cmd.Parameters.AddWithValue("@potasio", obj.Potasio);
                cmd.Parameters.AddWithValue("@cloro", obj.Cloro);
                cmd.Parameters.AddWithValue("@calcio", obj.Calcio);

                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        */
        public bool Guardar(QuimicaM obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = @"INSERT INTO Quimica (IdPaciente, IdPacienteExamen, Glucosa, Urea, Creatina, BUN, Urico, Colesterol, 
                         HDL, LDL, Triglicerido, Bilirrubina, Directa, Indirecta, Total, GOT, GPT, FosfatasaAlcalina, 
                         Amilasa, Proteina, Albumina, Globulina, Relacion, FosfatasaAcida, FosfatasaAcidaProstatica, 
                         CKMB, CPK, Hemoglobina, Sodio, Potasio, Cloro, Calcio) 
                         VALUES (@idPaciente, @idExamen, @glucosa, @urea, @creatina, @bun, @urico, @colesterol, 
                         @hdl, @ldl, @triglicerido, @bilirrubina, @directa, @indirecta, @total, @got, @gpt, 
                         @fosfatasaAlcalina, @amilasa, @proteina, @albumina, @globulina, @relacion, 
                         @fosfatasaAcida, @fosfatasaAcidaProstatica, @ckmb, @cpk, @hemoglobina, @sodio, 
                         @potasio, @cloro, @calcio)";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.AddWithValue("@idPacienteExamen", obj.IdPaciente);
                cmd.Parameters.AddWithValue("@idExamen", obj.IdPacienteExamen);
                cmd.Parameters.AddWithValue("@glucosa", obj.Glucosa);
                cmd.Parameters.AddWithValue("@urea", obj.Urea);
                cmd.Parameters.AddWithValue("@creatina", obj.Creatina);
                cmd.Parameters.AddWithValue("@bun", obj.BUN);
                cmd.Parameters.AddWithValue("@urico", obj.Urico);
                cmd.Parameters.AddWithValue("@colesterol", obj.Colesterol);
                cmd.Parameters.AddWithValue("@hdl", obj.HDL);
                cmd.Parameters.AddWithValue("@ldl", obj.LDL);
                cmd.Parameters.AddWithValue("@triglicerido", obj.Triglicerido);
                cmd.Parameters.AddWithValue("@bilirrubina", obj.Bilirrubina);
                cmd.Parameters.AddWithValue("@directa", obj.Directa);
                cmd.Parameters.AddWithValue("@indirecta", obj.Indirecta);
                cmd.Parameters.AddWithValue("@total", obj.Total);
                cmd.Parameters.AddWithValue("@got", obj.GOT);
                cmd.Parameters.AddWithValue("@gpt", obj.GPT);
                cmd.Parameters.AddWithValue("@fosfatasaAlcalina", obj.FosfatasaAlcalina);
                cmd.Parameters.AddWithValue("@amilasa", obj.Amilasa);
                cmd.Parameters.AddWithValue("@proteina", obj.Proteina);
                cmd.Parameters.AddWithValue("@albumina", obj.Albumina);
                cmd.Parameters.AddWithValue("@globulina", obj.Globulina);
                cmd.Parameters.AddWithValue("@relacion", obj.Relacion);
                cmd.Parameters.AddWithValue("@fosfatasaAcida", obj.FosfatasaAcida);
                cmd.Parameters.AddWithValue("@fosfatasaAcidaProstatica", obj.FosfatasaAcidaProstatica);
                cmd.Parameters.AddWithValue("@ckmb", obj.CKMB);
                cmd.Parameters.AddWithValue("@cpk", obj.CPK);
                cmd.Parameters.AddWithValue("@hemoglobina", obj.Hemoglobina);
                cmd.Parameters.AddWithValue("@sodio", obj.Sodio);
                cmd.Parameters.AddWithValue("@potasio", obj.Potasio);
                cmd.Parameters.AddWithValue("@cloro", obj.Cloro);
                cmd.Parameters.AddWithValue("@calcio", obj.Calcio);

                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        /*public List<QuimicaM> Listar()
        {
            List<QuimicaM> oList = new List<QuimicaM>();
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "SELECT Id, Nombre FROM Quimica";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oList.Add(new QuimicaM()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }
            }
            return oList;
        }
        */
        public bool Editar(QuimicaM obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = @"UPDATE Quimica SET  Glucosa = @glucosa, 
                         Urea = @urea, Creatina = @creatina, BUN = @bun, Urico = @urico, Colesterol = @colesterol, 
                         HDL = @hdl, LDL = @ldl, Triglicerido = @triglicerido, Bilirrubina = @bilirrubina, 
                         Directa = @directa, Indirecta = @indirecta, Total = @total, GOT = @got, GPT = @gpt, 
                         FosfatasaAlcalina = @fosfatasaAlcalina, Amilasa = @amilasa, Proteina = @proteina, 
                         Albumina = @albumina, Globulina = @globulina, Relacion = @relacion, FofatasaAcida = @fofatasaAcida, 
                         FosfatasaAcidaProtastica = @fosfatasaAcidaProtastica, CKMB = @ckmb, CPK = @cpk, Hemogloblina = @hemogloblina, 
                         Sodio = @sodio, Potasio = @potasio, Cloro = @cloro, Calcio = @calcio 
                         WHERE Id = @id";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", obj.Id);
              //  cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
               // cmd.Parameters.AddWithValue("@nombreM", obj.NombreM);
               // cmd.Parameters.AddWithValue("@edad", obj.Edad);
                cmd.Parameters.AddWithValue("@glucosa", obj.Glucosa);
                cmd.Parameters.AddWithValue("@urea", obj.Urea);
                cmd.Parameters.AddWithValue("@creatina", obj.Creatina);
                cmd.Parameters.AddWithValue("@bun", obj.BUN);
                cmd.Parameters.AddWithValue("@urico", obj.Urico);
                cmd.Parameters.AddWithValue("@colesterol", obj.Colesterol);
                cmd.Parameters.AddWithValue("@hdl", obj.HDL);
                cmd.Parameters.AddWithValue("@ldl", obj.LDL);
                cmd.Parameters.AddWithValue("@triglicerido", obj.Triglicerido);
                cmd.Parameters.AddWithValue("@bilirrubina", obj.Bilirrubina);
                cmd.Parameters.AddWithValue("@directa", obj.Directa);
                cmd.Parameters.AddWithValue("@indirecta", obj.Indirecta);
                cmd.Parameters.AddWithValue("@total", obj.Total);
                cmd.Parameters.AddWithValue("@got", obj.GOT);
                cmd.Parameters.AddWithValue("@gpt", obj.GPT);
                cmd.Parameters.AddWithValue("@fosfatasaAlcalina", obj.FosfatasaAlcalina);
                cmd.Parameters.AddWithValue("@amilasa", obj.Amilasa);
                cmd.Parameters.AddWithValue("@proteina", obj.Proteina);
                cmd.Parameters.AddWithValue("@albumina", obj.Albumina);
                cmd.Parameters.AddWithValue("@globulina", obj.Globulina);
                cmd.Parameters.AddWithValue("@relacion", obj.Relacion);
                cmd.Parameters.AddWithValue("@fofatasaAcida", obj.FosfatasaAcida);
                cmd.Parameters.AddWithValue("@fosfatasaAcidaProtastica", obj.FosfatasaAcidaProstatica);
                cmd.Parameters.AddWithValue("@ckmb", obj.CKMB);
                cmd.Parameters.AddWithValue("@cpk", obj.CPK);
                cmd.Parameters.AddWithValue("@hemogloblina", obj.Hemoglobina);
               // cmd.Parameters.AddWithValue("@lipasa", obj.Lipasa);
                cmd.Parameters.AddWithValue("@sodio", obj.Sodio);
                cmd.Parameters.AddWithValue("@potasio", obj.Potasio);
                cmd.Parameters.AddWithValue("@cloro", obj.Cloro);
                cmd.Parameters.AddWithValue("@calcio", obj.Calcio);

                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool Eliminar(QuimicaM ob)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "DELETE FROM Quimica WHERE Id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", ob.Id);

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        /*
        public QuimicaM BuscarPorId(int idPaciente)
        {
            QuimicaM paciente = null;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = @"SELECT * FROM Quimica WHERE Id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", idPaciente));
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        paciente = new QuimicaM()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            //Nombre = dr["Nombre"].ToString(),
                            //NombreM = dr["NombreM"].ToString(),
                            //Edad = dr["Edad"].ToString(),
                            Glucosa = dr["Glucosa"].ToString(),
                            Urea = dr["Urea"].ToString(),
                            Creatina = dr["Creatina"].ToString(),
                            BUN = dr["BUN"].ToString(),
                            Urico = dr["Urico"].ToString(),
                            Colesterol = dr["Colesterol"].ToString(),
                            HDL = dr["HDL"].ToString(),
                            LDL = dr["LDL"].ToString(),
                            Triglicerido = dr["Triglicerido"].ToString(),
                            Bilirrubina = dr["Bilirrubina"].ToString(),
                            Directa = dr["Directa"].ToString(),
                            Indirecta = dr["Indirecta"].ToString(),
                            Total = dr["Total"].ToString(),
                            GOT = dr["GOT"].ToString(),
                            GPT = dr["GPT"].ToString(),
                            FosfatasaAlcalina = dr["FosfatasaAlcalina"].ToString(),
                            Amilasa = dr["Amilasa"].ToString(),
                            Proteina = dr["Proteina"].ToString(),
                            Albumina = dr["Albumina"].ToString(),
                            Globulina = dr["Globulina"].ToString(),
                            Relacion = dr["Relacion"].ToString(),
                            FosfatasaAcida = dr["FofatasaAcida"].ToString(),
                            FosfatasaAcidaProstatica = dr["FosfatasaAcidaProtastica"].ToString(),
                            CKMB = dr["CKMB"].ToString(),
                            CPK = dr["CPK"].ToString(),
                            Hemoglobina = dr["Hemogloblina"].ToString(),
                          //  Lipasa = dr["Lipasa"].ToString(),
                            Sodio = dr["Sodio"].ToString(),
                            Potasio = dr["Potasio"].ToString(),
                            Cloro = dr["Cloro"].ToString(),
                            Calcio = dr["Calcio"].ToString()
                        };
                    }
                }
            }
            return paciente;
        }
        */
        public List<QuimicaM> BuscarPorPaciente(int idPaciente)
        {
            List<QuimicaM> lista = new List<QuimicaM>();
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = @"SELECT * FROM Quimica WHERE IdPaciente = @idPaciente";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@idPaciente", idPaciente));
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new QuimicaM()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            IdPaciente = int.Parse(dr["IdPaciente"].ToString()),
                            IdPacienteExamen = int.Parse(dr["IdExamen"].ToString()),
                            Glucosa = dr["Glucosa"].ToString(),
                            Urea = dr["Urea"].ToString(),
                            Creatina = dr["Creatina"].ToString(),
                            BUN = dr["BUN"].ToString(),
                            Urico = dr["Urico"].ToString(),
                            Colesterol = dr["Colesterol"].ToString(),
                            HDL = dr["HDL"].ToString(),
                            LDL = dr["LDL"].ToString(),
                            Triglicerido = dr["Triglicerido"].ToString(),
                            Bilirrubina = dr["Bilirrubina"].ToString(),
                            Directa = dr["Directa"].ToString(),
                            Indirecta = dr["Indirecta"].ToString(),
                            Total = dr["Total"].ToString(),
                            GOT = dr["GOT"].ToString(),
                            GPT = dr["GPT"].ToString(),
                            FosfatasaAlcalina = dr["FosfatasaAlcalina"].ToString(),
                            Amilasa = dr["Amilasa"].ToString(),
                            Proteina = dr["Proteina"].ToString(),
                            Albumina = dr["Albumina"].ToString(),
                            Globulina = dr["Globulina"].ToString(),
                            Relacion = dr["Relacion"].ToString(),
                            FosfatasaAcida = dr["FosfatasaAcida"].ToString(),
                            FosfatasaAcidaProstatica = dr["FosfatasaAcidaProstatica"].ToString(),
                            CKMB = dr["CKMB"].ToString(),
                            CPK = dr["CPK"].ToString(),
                            Hemoglobina = dr["Hemoglobina"].ToString(),
                            Sodio = dr["Sodio"].ToString(),
                            Potasio = dr["Potasio"].ToString(),
                            Cloro = dr["Cloro"].ToString(),
                            Calcio = dr["Calcio"].ToString()
                        });
                    }
                }
            }
            return lista;
        }



    }
}
