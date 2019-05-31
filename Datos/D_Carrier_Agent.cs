using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Carrier_Agent : D_MySQL
    {
        public string Mensaje { get; set; }
        public List<E_Carrier_Agent> Lista()
        {

            string query;
            MySqlCommand cmd;
            List<E_Carrier_Agent> lista_agent1 = new List<E_Carrier_Agent>();

            query = "select * from tbl_carrier_agent";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Carrier_Agent agent1;

                    while (reader.Read())
                    {
                        agent1 = new E_Carrier_Agent
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Account_Number = Convert.ToString(reader["account_number"]),
                            Address = Convert.ToString(reader["address"]),
                            Name = Convert.ToString(reader["name"]),
                            Representante = Convert.ToString(reader["representante"]),
                            Firma_Representante = Convert.ToString(reader["firma_representante"]),
                            Comuna = Convert.ToString(reader["comuna"]),
                            Email = Convert.ToString(reader["email"]),
                            IATA_Code = Convert.ToString(reader["IATA_code"]),
                            Rut = Convert.ToString(reader["rut"]),
                            Telephone = Convert.ToString(reader["telephone"])
                        };
                        lista_agent1.Add(agent1);

                    }
                    Desconectar();
                    return lista_agent1;
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

        public bool Agregar(E_Carrier_Agent agent1)
        {
            string query;
            MySqlCommand cmd;

            query = "insert into tbl_carrier_agent(account_number,rut,IATA_code,name,representante,firma_representante,address,comuna,telephone,email) " +
                    "(@account,@rut,@IATA,@name,@representante,@firma_representante,@address,@comuna,@telephone,@email)";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@account", agent1.Account_Number);
                    cmd.Parameters.AddWithValue("@rut", agent1.Rut);
                    cmd.Parameters.AddWithValue("@IATA", agent1.IATA_Code);
                    cmd.Parameters.AddWithValue("@name", agent1.Name);
                    cmd.Parameters.AddWithValue("@representante", agent1.Representante);
                    cmd.Parameters.AddWithValue("@firma_representante", agent1.Firma_Representante);
                    cmd.Parameters.AddWithValue("@address", agent1.Address);
                    cmd.Parameters.AddWithValue("@comuna", agent1.Comuna);
                    cmd.Parameters.AddWithValue("@telephone", agent1.Telephone);
                    cmd.Parameters.AddWithValue("@email", agent1.Email);

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

        public bool Modificar(E_Carrier_Agent agent1)
        {
            string query;
            MySqlCommand cmd;

            query = "update tbl_carrier_agent set account_number=@account,rut=@rut,IATA_code=@IATA,name=@name,representante=@representante,firma_representante=@firma_representante,address=@address,comuna=@comuna,telephone=@telephone,email=@email WHERE id=@id";

            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@id", agent1.ID);
                    cmd.Parameters.AddWithValue("@account", agent1.Account_Number);
                    cmd.Parameters.AddWithValue("@rut", agent1.Rut);
                    cmd.Parameters.AddWithValue("@IATA", agent1.IATA_Code);
                    cmd.Parameters.AddWithValue("@name", agent1.Name);
                    cmd.Parameters.AddWithValue("@representante", agent1.Representante);
                    cmd.Parameters.AddWithValue("@firma_representante", agent1.Firma_Representante);
                    cmd.Parameters.AddWithValue("@address", agent1.Address);
                    cmd.Parameters.AddWithValue("@comuna", agent1.Comuna);
                    cmd.Parameters.AddWithValue("@telephone", agent1.Telephone);
                    cmd.Parameters.AddWithValue("@email", agent1.Email);

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

            query = "delete from tbl_carrier_agent WHERE id=@id";

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

        public E_Carrier_Agent Obtener_Agent(string id)
        {

            string query;
            MySqlCommand cmd;

            query = "select * from tbl_carrier_agent where id = @id";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Carrier_Agent agent1;

                    if (reader.Read())
                    {
                        agent1 = new E_Carrier_Agent
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Account_Number = Convert.ToString(reader["account_number"]),
                            Address = Convert.ToString(reader["address"]),
                            Name = Convert.ToString(reader["name"]),
                            Representante = Convert.ToString(reader["representante"]),
                            Firma_Representante = Convert.ToString(reader["firma_representante"]),
                            Comuna = Convert.ToString(reader["comuna"]),
                            Email = Convert.ToString(reader["email"]),
                            IATA_Code = Convert.ToString(reader["IATA_code"]),
                            Rut = Convert.ToString(reader["rut"]),
                            Telephone = Convert.ToString(reader["telephone"])
                        };
                        Desconectar();
                        return agent1;
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
