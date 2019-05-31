using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Guide : D_MySQL
    {
        public string Mensaje { get; set; }
        public List<E_Guide> Lista()
        {

            string query;
            MySqlCommand cmd;
            List<E_Guide> lista_guide1 = new List<E_Guide>();

            query = "select * from tbl_guide";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Guide guide1;

                    while (reader.Read())
                    {
                        guide1 = new E_Guide
                        {
                            Aerial_guide = Convert.ToString(reader["aerial_guide"]),
                            Airline_Code = Convert.ToString(reader["airline_code"]),
                            ID_Guide_Type = Convert.ToString(reader["id_guide_type"])
                        };
                        lista_guide1.Add(guide1);

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

        public bool Agregar(E_Guide guide1)
        {
            string query;
            MySqlCommand cmd;

            query = "insert into tbl_guide(aerial_guide,id_guide_type,airline_code) " +
                    "(@guide,@type,@code)";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@guide", guide1.Aerial_guide);
                    cmd.Parameters.AddWithValue("@type", guide1.ID_Guide_Type);
                    cmd.Parameters.AddWithValue("@code", guide1.Airline_Code);
                    
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

        public bool Modificar(E_Guide guide1)
        {
            string query;
            MySqlCommand cmd;

            query = "update tbl_guide set id_guide_type=@type,airline_code=@code WHERE aerial_guide=@guide";

            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@guide", guide1.Aerial_guide);
                    cmd.Parameters.AddWithValue("@type", guide1.ID_Guide_Type);
                    cmd.Parameters.AddWithValue("@code", guide1.Airline_Code);

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

        public bool Borrar(string guide)
        {
            string query;
            MySqlCommand cmd;

            query = "delete from tbl_guide WHERE aerial_guide=@guide";

            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@guide", guide);

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

        public E_Guide Obtener_Guide(string guide)
        {

            string query;
            MySqlCommand cmd;

            query = "select * from tbl_guide where aerial_guide=@guide";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@guide", guide);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Guide guide1;

                    if (reader.Read())
                    {
                        guide1 = new E_Guide
                        {
                            Aerial_guide = Convert.ToString(reader["aerial_guide"]),
                            Airline_Code = Convert.ToString(reader["airline_code"]),
                            ID_Guide_Type = Convert.ToString(reader["id_guide_type"])
                        };
                        Desconectar();
                        return guide1;
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
