using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
     public class D_Airport : D_MySQL
    {
        public string Mensaje { get; set; }
        public List<E_Airport> Lista()
        {

            string query;
            MySqlCommand cmd;
            List<E_Airport> lista_airport1 = new List<E_Airport>();

            query = "select * from tbl_airport";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Airport airport1;

                    while (reader.Read())
                    {
                        airport1 = new E_Airport
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            City = Convert.ToString(reader["city"]),
                            Country = Convert.ToString(reader["country"]),
                            Name = Convert.ToString(reader["name"]),
                            Prefix = Convert.ToString(reader["prefix"])
                        };
                        lista_airport1.Add(airport1);

                    }
                    Desconectar();
                    return lista_airport1;
                }
                else
                {
                    Desconectar();
                    return null;
                }

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                Desconectar();
                return null;
            }
        }

        public bool Agregar(E_Airport airport1)
        {
            string query;
            MySqlCommand cmd;

            query = "insert into tbl_airport(name,country,city,prefix) " +
                    "(@name,@country,@city,@prefix)";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@name", airport1.Name);
                    cmd.Parameters.AddWithValue("@prefix", airport1.Prefix);
                    cmd.Parameters.AddWithValue("@country", airport1.Country);
                    cmd.Parameters.AddWithValue("@city", airport1.City);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    Desconectar();
                    Mensaje = "Error de conexion";
                    return false;
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                Desconectar();
                return false;
            }
        }

        public bool Modificar(E_Airport airport1)
        {
            string query;
            MySqlCommand cmd;

            query = "update tbl_airport set name=@name,prefix=@prefix,country=@country,city=@city WHERE id=@id";

            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@id", airport1.ID);
                    cmd.Parameters.AddWithValue("@name", airport1.Name);
                    cmd.Parameters.AddWithValue("@prefix", airport1.Prefix);
                    cmd.Parameters.AddWithValue("@country", airport1.Country);
                    cmd.Parameters.AddWithValue("@city", airport1.City);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                Desconectar();
                return false;
            }

            Desconectar();
            return true;
        }

        public bool Borrar(string id)
        {
            string query;
            MySqlCommand cmd;

            query = "delete from tbl_airport WHERE id=@id";

            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                Desconectar();
                return false;
            }

            Desconectar();
            return true;
        }

        public E_Airport Obtener_Airport(string id)
        {

            string query;
            MySqlCommand cmd;

            query = "select * from tbl_airport where id = @id";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Airport airport1;

                    if (reader.Read())
                    {
                        airport1 = new E_Airport
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            City = Convert.ToString(reader["city"]),
                            Country = Convert.ToString(reader["country"]),
                            Name = Convert.ToString(reader["name"]),
                            Prefix = Convert.ToString(reader["prefix"])
                        };
                        Desconectar();
                        return airport1;
                    }
                    else
                    {
                        Desconectar();
                        return null;
                    }

                }
                else
                {
                    Desconectar();
                    return null;
                }

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                Desconectar();
                return null;
            }
        }
    }
}
