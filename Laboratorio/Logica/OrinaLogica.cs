﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorio.Modelo;

using System.Configuration;
using System.Data.SQLite;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
namespace Laboratorio.Logica
{
    public class OrinaLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static OrinaLogica _instancia = null;
        public OrinaLogica()
        {

        }
        public static OrinaLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new OrinaLogica();
                }
                return _instancia;
            }
        }

        public bool Guardar(OrinaM obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
               // string query = "INSERT INTO Blanco (Nombre, NombreMedico,Edad, Muestra,Examen, Datos,Otros) VALUES (@nombre, @nombreMedico, @edad, @muestra, @examen, @datos, @otros)";
                string query = "INSERT INTO Orina( Nombre, NombreM, Edad, Aspecto, Color, Olor, Densidad, Reaccion, Glucosa, Bilirrubina, Cetonas, Sangre, Proteina, Urobiliogeno, Nitrito, Leucocito1, Eritrocito, Leucocito2, CED, Redonda, Embarazo, Otros, Observaciones, Flora, Piocito, Cristale, Cilindro) VALUES(@nombre,@nombreM,@edad,@aspecto,@color,@olor,@densidad,  @reaccion,     @glucosa,@bilirrubina,   @cetonas,    @sangre,     @proteina,     @urobiliogeno,    @nitrito,     @leucocito1,   @eritrocito,@leucocito2,@ced,@redonda,@embarazo,@otros,@observaciones,@flora,@piocito, @cristale, @cilindro)";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@nombreM", obj.Nombre_Medico));
                cmd.Parameters.Add(new SQLiteParameter("edad", obj.Edad));
                cmd.Parameters.Add(new SQLiteParameter("@aspecto", obj.Aspecto));
                cmd.Parameters.Add(new SQLiteParameter("@color", obj.Color));
                cmd.Parameters.Add(new SQLiteParameter("@olor", obj.Olor));
                cmd.Parameters.Add(new SQLiteParameter("@densidad", obj.Densidad));
                cmd.Parameters.Add(new SQLiteParameter("@reaccion", obj.Reaccion));
                cmd.Parameters.Add(new SQLiteParameter("@glucosa", obj.Glucosa));
                cmd.Parameters.Add(new SQLiteParameter("@bilirrubina", obj.Bilirrubina));
                cmd.Parameters.Add(new SQLiteParameter("@cetonas", obj.Cetonas));
                cmd.Parameters.Add(new SQLiteParameter("@sangre", obj.Sangre));
                cmd.Parameters.Add(new SQLiteParameter("@proteina", obj.Proteina));
                cmd.Parameters.Add(new SQLiteParameter("@urobiliogeno", value: obj.Urobiliogeno));
                cmd.Parameters.Add(new SQLiteParameter("@nitrito", obj.Nitrito));
                cmd.Parameters.Add(new SQLiteParameter("@leucocito1", obj.Leucocito1));
                cmd.Parameters.Add(new SQLiteParameter("@eritrocito", obj.Eritrocito));
                cmd.Parameters.Add(new SQLiteParameter("@leucocito2", obj.Leucocito2));
                cmd.Parameters.Add(new SQLiteParameter("@ced", obj.CED));
                cmd.Parameters.Add(new SQLiteParameter("@redonda", obj.Redonda));
                cmd.Parameters.Add(new SQLiteParameter("@embarazo", obj.Embarazo));
                cmd.Parameters.Add(new SQLiteParameter("@otros", obj.Otros));
                cmd.Parameters.Add(new SQLiteParameter("@observaciones", obj.Observaciones));
                cmd.Parameters.Add(new SQLiteParameter("@flora", obj.Flora));
                cmd.Parameters.Add(new SQLiteParameter("@piocito", obj.Piocito));
                cmd.Parameters.Add(new SQLiteParameter("@cristale", obj.Cristale));
                cmd.Parameters.Add(new SQLiteParameter("@cilindro", obj.Cilindro));

                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;

                }
            }
            return respuesta;
        }
        public List<OrinaM> Listar()
        {
            List<OrinaM> oList = new List<OrinaM>();
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "SELECT Id, Nombre FROM Orina";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oList.Add(new OrinaM()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }
            }
            return oList;
        }

        public bool Editar(OrinaM obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "UPDATE Orina SET Nombre = @nombre, NombreM = @nombreM, Edad = @edad, Aspecto = @aspecto, Color = @color, Olor = @olor, Densidad = @densidad, Reaccion = @reaccion, Glucosa = @glucosa, Bilirrubina = @bilirrubina, Cetonas = @cetonas, Sangre = @sangre, Proteina = @proteina, Urobiliogeno = @urobiliogeno, Nitrito = @nitrito, Leucocito1 = @leucocito1, Eritrocito = @eritrocito, Leucocito2 = @leucocito2, CED = @ced, Redonda = @redonda, Embarazo = @embarazo, Otros = @otros, Observaciones = @observaciones, Flora = @flora, Piocito = @piocito, Cristale = @cristale, Cilindro = @cilindro WHERE Id = @id";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", obj.Id));
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@nombreM", obj.Nombre_Medico));
                cmd.Parameters.Add(new SQLiteParameter("@edad", obj.Edad));
                cmd.Parameters.Add(new SQLiteParameter("@aspecto", obj.Aspecto));
                cmd.Parameters.Add(new SQLiteParameter("@color", obj.Color));
                cmd.Parameters.Add(new SQLiteParameter("@olor", obj.Olor));
                cmd.Parameters.Add(new SQLiteParameter("@densidad", obj.Densidad));
                cmd.Parameters.Add(new SQLiteParameter("@reaccion", obj.Reaccion));
                cmd.Parameters.Add(new SQLiteParameter("@glucosa", obj.Glucosa));
                cmd.Parameters.Add(new SQLiteParameter("@bilirrubina", obj.Bilirrubina));
                cmd.Parameters.Add(new SQLiteParameter("@cetonas", obj.Cetonas));
                cmd.Parameters.Add(new SQLiteParameter("@sangre", obj.Sangre));
                cmd.Parameters.Add(new SQLiteParameter("@proteina", obj.Proteina));
                cmd.Parameters.Add(new SQLiteParameter("@urobiliogeno", obj.Urobiliogeno));
                cmd.Parameters.Add(new SQLiteParameter("@nitrito", obj.Nitrito));
                cmd.Parameters.Add(new SQLiteParameter("@leucocito1", obj.Leucocito1));
                cmd.Parameters.Add(new SQLiteParameter("@eritrocito", obj.Eritrocito));
                cmd.Parameters.Add(new SQLiteParameter("@leucocito2", obj.Leucocito2));
                cmd.Parameters.Add(new SQLiteParameter("@ced", obj.CED));
                cmd.Parameters.Add(new SQLiteParameter("@redonda", obj.Redonda));
                cmd.Parameters.Add(new SQLiteParameter("@embarazo", obj.Embarazo));
                cmd.Parameters.Add(new SQLiteParameter("@otros", obj.Otros));
                cmd.Parameters.Add(new SQLiteParameter("@observaciones", obj.Observaciones));
                cmd.Parameters.Add(new SQLiteParameter("@flora", obj.Flora));
                cmd.Parameters.Add(new SQLiteParameter("@piocito", obj.Piocito));
                cmd.Parameters.Add(new SQLiteParameter("@cristale", obj.Cristale));
                cmd.Parameters.Add(new SQLiteParameter("@cilindro", obj.Cilindro));

                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public bool Eliminar(OrinaM ob)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "DELETE FROM Orina WHERE Id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", ob.Id);

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public OrinaM BuscarPorNombre(int idpaciente)
        {
            OrinaM paciente = null;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = @"SELECT * FROM Orina WHERE Id = @id"; // Cambio aquí
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", idpaciente)); // Cambio aquí
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        paciente = new OrinaM()
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Nombre_Medico = dr["NombreM"].ToString(),
                            Edad = dr["Edad"].ToString(),
                            Aspecto = dr["Aspecto"].ToString(),
                            Color = dr["Color"].ToString(),
                            Olor = dr["Olor"].ToString(),
                            Densidad = dr["Densidad"].ToString(),
                            Reaccion = dr["Reaccion"].ToString(),
                            Glucosa = dr["Glucosa"].ToString(),
                            Bilirrubina = dr["Bilirrubina"].ToString(),
                            Cetonas = dr["Cetonas"].ToString(),
                            Sangre = dr["Sangre"].ToString(),
                            Proteina = dr["Proteina"].ToString(),
                            Urobiliogeno = dr["Urobiliogeno"].ToString(),
                            Nitrito = dr["Nitrito"].ToString(),
                            Leucocito1 = dr["Leucocito1"].ToString(),
                            Eritrocito = dr["Eritrocito"].ToString(),
                            Leucocito2 = dr["Leucocito2"].ToString(),
                            CED = dr["CED"].ToString(),
                            Redonda = dr["Redonda"].ToString(),
                            Embarazo = dr["Embarazo"].ToString(),
                            Otros = dr["Otros"].ToString(),
                            Observaciones = dr["Observaciones"].ToString(),
                            Flora = dr["Flora"].ToString(),
                            Piocito = dr["Piocito"].ToString(),
                            Cristale = dr["Cristale"].ToString(),
                            Cilindro = dr["Cilindro"].ToString()

                        };
                    }
                }
            }
            return paciente;
        }

    }
}
