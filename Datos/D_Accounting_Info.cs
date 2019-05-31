using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Accounting_Info : D_MySQL
    {
        public string Mensaje { get; set; }
        public List<E_Accounting_Info> Lista()
        {

            string query;
            MySqlCommand cmd;
            List<E_Accounting_Info> lista_accounting1 = new List<E_Accounting_Info>();

            query = "select * from tbl_accounting_info";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Accounting_Info accounting1;

                    while (reader.Read())
                    {
                        accounting1 = new E_Accounting_Info
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Address_1 = Convert.ToString(reader["address_1"]),
                            Address_2 = Convert.ToString(reader["address_2"]),
                            Email = Convert.ToString(reader["email"]),
                            Name = Convert.ToString(reader["name"]),
                            Telephone = Convert.ToString(reader["telephone"])
                        };
                        lista_accounting1.Add(accounting1);

                    }
                    Desconectar();
                    return lista_accounting1;
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

        public bool Agregar(E_Accounting_Info accounting1)
        {
            string query;
            MySqlCommand cmd;

            query = "insert into tbl_accounting_info(name,address_1,address_2,email,telephone) " +
                    "(@name,@address1,@address2,@email,@telephone)";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@name", accounting1.Name);
                    cmd.Parameters.AddWithValue("@address1", accounting1.Address_1);
                    cmd.Parameters.AddWithValue("@address2", accounting1.Address_2);
                    cmd.Parameters.AddWithValue("@email", accounting1.Email);
                    cmd.Parameters.AddWithValue("@telephone", accounting1.Telephone);

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

        public bool Modificar(E_Accounting_Info accounting1)
        {
            string query;
            MySqlCommand cmd;

            query = "update tbl_accounting_info set name=@name,address_1=@address1,address_2=@address2,email=@email,telephone=@telephone WHERE ID=@ID";

            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@ID", accounting1.ID);
                    cmd.Parameters.AddWithValue("@name", accounting1.Name);
                    cmd.Parameters.AddWithValue("@address1", accounting1.Address_1);
                    cmd.Parameters.AddWithValue("@address2", accounting1.Address_2);
                    cmd.Parameters.AddWithValue("@email", accounting1.Email);
                    cmd.Parameters.AddWithValue("@telephone", accounting1.Telephone);

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

        public bool Borrar(string ID)
        {
            string query;
            MySqlCommand cmd;

            query = "delete from tbl_accounting_info WHERE ID=@ID";

            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@ID", ID);

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

        public E_Accounting_Info Obtener_Accounting_Info(string ID)
        {

            string query;
            MySqlCommand cmd;

            query = "select * from tbl_accounting_info where id = @ID";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Accounting_Info accounting1;

                    if (reader.Read())
                    {
                        accounting1 = new E_Accounting_Info
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Address_1 = Convert.ToString(reader["address_1"]),
                            Address_2 = Convert.ToString(reader["address_2"]),
                            Email = Convert.ToString(reader["email"]),
                            Name = Convert.ToString(reader["name"]),
                            Telephone = Convert.ToString(reader["telephone"])
                        };

                        Desconectar();
                        return accounting1;
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
