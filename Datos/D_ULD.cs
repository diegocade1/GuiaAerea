using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_ULD:D_MySQL
    {
        public string Mensaje { get; set; }
        public List<E_ULD> Lista()
        {

            string query;
            MySqlCommand cmd;
            List<E_ULD> lista_guide1 = new List<E_ULD>();

            query = "select * from tbl_uld";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_ULD uld1;

                    while (reader.Read())
                    {
                        uld1 = new E_ULD
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Code = Convert.ToString(reader["code"])
                        };
                        lista_guide1.Add(uld1);

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

        public bool Agregar(E_ULD uld1)
        {
            string query;
            MySqlCommand cmd;

            query = "insert into tbl_ULD(code) " +
                    "(@code)";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@code", uld1.Code);

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

        public bool Modificar(E_ULD uld1)
        {
            string query;
            MySqlCommand cmd;

            query = "update tbl_uld set code=@code WHERE id=@id";

            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@id", uld1.ID);
                    cmd.Parameters.AddWithValue("@code", uld1.Code);

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

            query = "delete from tbl_uld WHERE id=@id";

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

        public E_ULD Obtener_ULD(string id)
        {

            string query;
            MySqlCommand cmd;

            query = "select * from tbl_uld where id=@id";
            query = "select * from tbl_uld where code=@id";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_ULD uld1;

                    if (reader.Read())
                    {
                        uld1 = new E_ULD
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Code = Convert.ToString(reader["code"])
                        };
                        Desconectar();
                        return uld1;
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
