using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Currency:D_MySQL
    {
        public string Mensaje { get; set; }
        public List<E_Currency> Lista()
        {

            string query;
            MySqlCommand cmd;
            List<E_Currency> lista_currency1 = new List<E_Currency>();

            query = "select * from tbl_currency";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Currency currency1;

                    while (reader.Read())
                    {
                        currency1 = new E_Currency
                        {
                            ID = Convert.ToString(reader["ID"]),
                            Clp_value = Convert.ToDouble(reader["clp_value"]),
                            Name = Convert.ToString(reader["name"]),
                            Prefix = Convert.ToString(reader["prefix"])
                        };
                        lista_currency1.Add(currency1);

                    }
                    Desconectar();
                    return lista_currency1;
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

        public bool Agregar(E_Currency currency1)
        {
            string query;
            MySqlCommand cmd;

            query = "insert into tbl_currency(name,prefix,clp_value) " +
                    "(@name,@prefix,@clp)";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@name", currency1.Name);
                    cmd.Parameters.AddWithValue("@prefix", currency1.Prefix);
                    cmd.Parameters.AddWithValue("@clp", currency1.Clp_value);

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

        public bool Modificar(E_Currency currency1)
        {
            string query;
            MySqlCommand cmd;

            query = "update tbl_currency set name=@name,prefix=@prefix,clp_value=@clp WHERE id=@id";

            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@id", currency1.ID);
                    cmd.Parameters.AddWithValue("@name", currency1.Name);
                    cmd.Parameters.AddWithValue("@prefix", currency1.Prefix);
                    cmd.Parameters.AddWithValue("@clp", currency1.Clp_value);

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

            query = "delete from tbl_currency WHERE id=@id";

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

        public E_Currency Obtener_Currency(string id)
        {

            string query;
            MySqlCommand cmd;

            query = "select * from tbl_currency where id = @id";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Currency currency1;

                    if (reader.Read())
                    {
                        currency1 = new E_Currency
                        {
                            ID = Convert.ToString(reader["ID"]),
                            Clp_value = Convert.ToDouble(reader["clp_value"]),
                            Name = Convert.ToString(reader["name"]),
                            Prefix = Convert.ToString(reader["prefix"])
                        };
                        Desconectar();
                        return currency1;
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
