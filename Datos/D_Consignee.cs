using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Consignee:D_MySQL
    {
        public string Mensaje { get; set; }
        public List<E_Consignee> Lista()
        {

            string query;
            MySqlCommand cmd;
            List<E_Consignee> lista_consignee1 = new List<E_Consignee>();

            query = "select * from tbl_consignee";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Consignee consignee1;

                    while (reader.Read())
                    {
                        consignee1 = new E_Consignee
                        {
                            ID = Convert.ToString(reader["ID"]),
                            Account_Number = Convert.ToString(reader["account_number"]),
                            Address = Convert.ToString(reader["address"]),
                            Name = Convert.ToString(reader["name"]),
                            Email = Convert.ToString(reader["email"]),
                            Telephone = Convert.ToString(reader["telephone"])
                        };
                        lista_consignee1.Add(consignee1);

                    }
                    Desconectar();
                    return lista_consignee1;
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

        public bool Agregar(E_Consignee consignee1)
        {
            string query;
            MySqlCommand cmd;

            query = "insert into tbl_consignee(account_number,name,address,telephone,email) " +
                    "(@account,@name,@address,@telephone,@email)";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@account", consignee1.Account_Number);
                    cmd.Parameters.AddWithValue("@name", consignee1.Name);
                    cmd.Parameters.AddWithValue("@address", consignee1.Address);
                    cmd.Parameters.AddWithValue("@telephone", consignee1.Telephone);
                    cmd.Parameters.AddWithValue("@email", consignee1.Email);

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

        public bool Modificar(E_Consignee consignee1)
        {
            string query;
            MySqlCommand cmd;

            query = "update tbl_consignee set account_number=@account,name=@name,address=@address,telephone=@telephone,email=@email WHERE id=@id";

            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@id", consignee1.ID);
                    cmd.Parameters.AddWithValue("@account", consignee1.Account_Number);
                    cmd.Parameters.AddWithValue("@name", consignee1.Name);
                    cmd.Parameters.AddWithValue("@address", consignee1.Address);
                    cmd.Parameters.AddWithValue("@telephone", consignee1.Telephone);
                    cmd.Parameters.AddWithValue("@email", consignee1.Email);

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

            query = "delete from tbl_consignee WHERE id=@id";

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

        public E_Consignee Obtener_Consignee(string id)
        {

            string query;
            MySqlCommand cmd;

            query = "select * from tbl_consignee where id = @id";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Consignee consignee1;

                    if (reader.Read())
                    {
                        consignee1 = new E_Consignee
                        {
                            ID = Convert.ToString(reader["ID"]),
                            Account_Number = Convert.ToString(reader["account_number"]),
                            Address = Convert.ToString(reader["address"]),
                            Name = Convert.ToString(reader["name"]),
                            Email = Convert.ToString(reader["email"]),
                            Telephone = Convert.ToString(reader["telephone"])
                        };
                        Desconectar();
                        return consignee1;
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
