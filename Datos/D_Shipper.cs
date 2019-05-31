using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Shipper:D_MySQL
    {
        public string Mensaje { get; set; }
        public List<E_Shipper> Lista()
        {

            string query;
            MySqlCommand cmd;
            List<E_Shipper> lista_guide1 = new List<E_Shipper>();

            query = "select * from tbl_shipper";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Shipper shipper1;

                    while (reader.Read())
                    {
                        shipper1 = new E_Shipper
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Account_Number = Convert.ToString(reader["account_number"]),
                            Address = Convert.ToString(reader["address"]),
                            Comuna = Convert.ToString(reader["comuna"]),
                            Email = Convert.ToString(reader["email"]),
                            Name = Convert.ToString(reader["name"]),
                            Telephone = Convert.ToString(reader["telephone"])
                        };
                        lista_guide1.Add(shipper1);

                    }
                    Desconectar();
                    return lista_guide1;
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

        public bool Agregar(E_Shipper shipper1)
        {
            string query;
            MySqlCommand cmd;

            query = "insert into tbl_shipper(account_number,name,address,comuna,telephone,email) " +
                    "(@account,@name,@address,@comuna,@telephone,@email)";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@account", shipper1.Account_Number);
                    cmd.Parameters.AddWithValue("@name", shipper1.Name);
                    cmd.Parameters.AddWithValue("@address", shipper1.Address);
                    cmd.Parameters.AddWithValue("@comuna", shipper1.Comuna);
                    cmd.Parameters.AddWithValue("@telephone", shipper1.Telephone);
                    cmd.Parameters.AddWithValue("@email", shipper1.Email);

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

        public bool Modificar(E_Shipper shipper1)
        {
            string query;
            MySqlCommand cmd;

            query = "update tbl_shipper set account_number=@account,name=@name,address=@address,comuna=@comuna,telephone=@telephone,email=@email WHERE id=@id";

            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@id", shipper1.ID);
                    cmd.Parameters.AddWithValue("@account", shipper1.Account_Number);
                    cmd.Parameters.AddWithValue("@name", shipper1.Name);
                    cmd.Parameters.AddWithValue("@address", shipper1.Address);
                    cmd.Parameters.AddWithValue("@comuna", shipper1.Comuna);
                    cmd.Parameters.AddWithValue("@telephone", shipper1.Telephone);
                    cmd.Parameters.AddWithValue("@email", shipper1.Email);

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

            query = "delete from tbl_shipper WHERE id=@id";

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

        public E_Shipper Obtener_Shipper(string id)
        {

            string query;
            MySqlCommand cmd;

            query = "select * from tbl_shipper where id=@id";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Shipper shipper1;

                    if (reader.Read())
                    {
                        shipper1 = new E_Shipper
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Account_Number = Convert.ToString(reader["account_number"]),
                            Address = Convert.ToString(reader["address"]),
                            Comuna = Convert.ToString(reader["comuna"]),
                            Email = Convert.ToString(reader["email"]),
                            Name = Convert.ToString(reader["name"]),
                            Telephone = Convert.ToString(reader["telephone"])
                        };
                        Desconectar();
                        return shipper1;
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
