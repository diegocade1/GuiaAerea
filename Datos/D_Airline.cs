using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Airline : D_MySQL
    {
        public string Mensaje { get; set; }
        public List<E_Airline> Lista()
        {

            string query;
            MySqlCommand cmd;
            List<E_Airline> lista_airline1 = new List<E_Airline>();

            query = "select * from tbl_airline";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Airline airline1;

                    while (reader.Read())
                    {
                        airline1 = new E_Airline
                        {
                            Code = Convert.ToString(reader["code"]),
                            Prefix_airline = Convert.ToString(reader["prefix_airline"]),
                            Rut = Convert.ToString(reader["rut"]),
                            Name = Convert.ToString(reader["name"]),
                            Telephone = Convert.ToString(reader["telephone"]),
                            Address = Convert.ToString(reader["address"]),
                            Fax = Convert.ToString(reader["fax"])
                        };
                        lista_airline1.Add(airline1);

                    }
                    Desconectar();
                    return lista_airline1;
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

        public bool Agregar(E_Airline airline1)
        {
            string query;
            MySqlCommand cmd;

            query = "insert into tbl_airline(code,prefix_airline,name,rut,address,telephone,fax) " +
                    "(@code,@prefix,@name,@rut,@address,@telephone,@fax)";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@name", airline1.Name);
                    cmd.Parameters.AddWithValue("@address", airline1.Address);
                    cmd.Parameters.AddWithValue("@code", airline1.Code);
                    cmd.Parameters.AddWithValue("@prefix", airline1.Prefix_airline);
                    cmd.Parameters.AddWithValue("@telephone", airline1.Telephone);
                    cmd.Parameters.AddWithValue("@rut", airline1.Rut);
                    cmd.Parameters.AddWithValue("@fax", airline1.Fax);

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

        public bool Modificar(E_Airline airline1)
        {
            string query;
            MySqlCommand cmd;

            query = "update tbl_airline set rut=@rut,name=@name,address=@address,prefix_airline=@prefix,fax=@fax,telephone=@telephone WHERE code=@code";

            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@name", airline1.Name);
                    cmd.Parameters.AddWithValue("@address", airline1.Address);
                    cmd.Parameters.AddWithValue("@code", airline1.Code);
                    cmd.Parameters.AddWithValue("@prefix", airline1.Prefix_airline);
                    cmd.Parameters.AddWithValue("@telephone", airline1.Telephone);
                    cmd.Parameters.AddWithValue("@rut", airline1.Rut);
                    cmd.Parameters.AddWithValue("@fax", airline1.Fax);

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

        public bool Borrar(string code)
        {
            string query;
            MySqlCommand cmd;

            query = "delete from tbl_airline WHERE code=@code";

            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@ID", code);

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

        public E_Airline Obtener_Airline(string code)
        {

            string query;
            MySqlCommand cmd;

            query = "select * from tbl_airline where code = @code";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@code", code);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Airline airline1;

                    if (reader.Read())
                    {
                        airline1 = new E_Airline
                        {
                            Code = Convert.ToString(reader["code"]),
                            Prefix_airline = Convert.ToString(reader["prefix_airline"]),
                            Rut = Convert.ToString(reader["rut"]),
                            Name = Convert.ToString(reader["name"]),
                            Telephone = Convert.ToString(reader["telephone"]),
                            Address = Convert.ToString(reader["address"]),
                            Fax = Convert.ToString(reader["fax"])
                        };
                        Desconectar();
                        return airline1;
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
