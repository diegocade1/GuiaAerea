using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Guide_Type :D_MySQL
    {
        public string Mensaje { get; set; }
        public List<E_Guide_Type> Lista()
        {

            string query;
            MySqlCommand cmd;
            List<E_Guide_Type> lista_guide1 = new List<E_Guide_Type>();

            query = "select * from tbl_guide_type";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Guide_Type type1;

                    while (reader.Read())
                    {
                        type1 = new E_Guide_Type
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Description = Convert.ToString(reader["descripcion"])
                        };
                        lista_guide1.Add(type1);

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

        public bool Agregar(E_Guide_Type type1)
        {
            string query;
            MySqlCommand cmd;

            query = "insert into tbl_guide_type(description) " +
                    "(@desc)";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@desc", type1.Description);

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

        public bool Modificar(E_Guide_Type type1)
        {
            string query;
            MySqlCommand cmd;

            query = "update tbl_guide_type set description=@desc WHERE id=@id";

            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@id", type1.ID);
                    cmd.Parameters.AddWithValue("@desc", type1.Description);

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

            query = "delete from tbl_guide_type WHERE id=@id";

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

        public E_Guide_Type Obtener_Type(string id)
        {

            string query;
            MySqlCommand cmd;

            query = "select * from tbl_guide_type where id=@id";
            try
            {
                if (Conectar() == true)
                {
                    cmd = new MySqlCommand(query, MySQLConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    E_Guide_Type type1;

                    if (reader.Read())
                    {
                        type1 = new E_Guide_Type
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Description = Convert.ToString(reader["descripcion"])
                        };
                        Desconectar();
                        return type1;
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
