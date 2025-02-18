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
    public class PacienteLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static PacienteLogica _instancia = null;
        public PacienteLogica()
        {

        }
        public static PacienteLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new PacienteLogica();
                }
                return _instancia;
            }
        }

        public bool Guardar(PacienteM obj, List<int> examenesSeleccionados)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                using (SQLiteTransaction transaccion = conexion.BeginTransaction()) // Inicia una transacción para garantizar la integridad de los datos
                {
                    try
                    {
                        // 1. Guardar el paciente y obtener su ID
                        string queryPaciente = @"INSERT INTO Paciente (Nombre, Apellido, Telefono, CI, Edad, Sexo, Medico, ExtencionCI) 
                                        VALUES (@nombre, @apellido, @telefono, @cI, @edad, @sexo, @medico, @extencionCI);
                                        SELECT last_insert_rowid();"; // Obtiene el ID generado

                        SQLiteCommand cmdPaciente = new SQLiteCommand(queryPaciente, conexion);
                        cmdPaciente.Parameters.AddWithValue("@nombre", obj.Nombre);
                        cmdPaciente.Parameters.AddWithValue("@apellido", obj.Apellido);
                        cmdPaciente.Parameters.AddWithValue("@telefono", obj.Telefono);
                        cmdPaciente.Parameters.AddWithValue("@cI", obj.CI);
                        cmdPaciente.Parameters.AddWithValue("@edad", obj.Edad);
                        cmdPaciente.Parameters.AddWithValue("@sexo", obj.Sexo);
                        cmdPaciente.Parameters.AddWithValue("@medico", obj.Medico);
                        cmdPaciente.Parameters.AddWithValue("@extencionCI", obj.ExtencionCI);

                        cmdPaciente.Transaction = transaccion;
                        int idPaciente = Convert.ToInt32(cmdPaciente.ExecuteScalar()); // Obtiene el ID del paciente insertado

                        // 2. Guardar los exámenes seleccionados
                        string queryExamen = "INSERT INTO Examen (IdPaciente, NombreExamen) VALUES (@idPaciente, @nombreExamen)";

                        foreach (int idExamen in examenesSeleccionados)
                        {
                            SQLiteCommand cmdExamen = new SQLiteCommand(queryExamen, conexion);
                            cmdExamen.Parameters.AddWithValue("@idPaciente", idPaciente);
                            cmdExamen.Parameters.AddWithValue("@nombreExamen",(idExamen)); // Convierte ID a nombre
                            cmdExamen.Transaction = transaccion;
                            cmdExamen.ExecuteNonQuery();
                        }

                        transaccion.Commit(); // Guarda los cambios
                    }
                    catch (Exception)
                    {
                        transaccion.Rollback(); // Revierte si hay error
                        respuesta = false;
                    }
                }
            }
            return respuesta;
        }

        /*public List<PacienteM> Listar()
        {
            List<PacienteM> oList = new List<PacienteM>();
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "SELECT Id, Nombre FROM Paciente";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oList.Add(new PacienteM()
                        {
                            IdPaciente = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }
            }
            return oList;
        }
        */



        /*******************************************************************************************************************/
        /*
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
        */


    }
}
