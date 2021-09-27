using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace AgendaTelefonica
{
    public partial class Contacte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                Database databaseObject = new Database();
                databaseObject.OpenConnection();


                string queryp = "SELECT IdUser,Nume,Functie,Email,Telefon from UseriAgenda";
                SqlCommand myquerytab = new SqlCommand(queryp, databaseObject.myConnection);

                SqlDataAdapter daquery = new SqlDataAdapter(myquerytab);
                DataTable dttab = new DataTable();
                DataSet ds = new DataSet();
                daquery.Fill(dttab);
                daquery.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();




                //myCommand.Dispose();
                databaseObject.CloseConnection();
            }
            catch (Exception)
            {
                string script = "alert(\"Eroare la incarcare rezultate!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

        }

        protected void btncautare_Click(object sender, EventArgs e)
        {
            try
            {
                Database databaseObject = new Database();
                string Mail = tbxcautaremail.Text;
                string Nume = tbxcautarenume.Text;
                string Telefon = tbxcautarefunctie.Text;

                var v1 = (Mail == "" && Nume == "" && Telefon == "");
                var v2 = (Mail == "" && Nume == "" && Telefon != "");
                var v3 = (Mail == "" && Nume != "" && Telefon == "");
                var v4 = (Mail == "" && Nume != "" && Telefon != "");
                var v5 = (Mail != "" && Nume == "" && Telefon == "");
                var v6 = (Mail != "" && Nume == "" && Telefon != "");
                var v7 = (Mail != "" && Nume != "" && Telefon == "");
                var v8 = (Mail != "" && Nume != "" && Telefon != "");
               

                string queryfin = "";

                if (v1)
                {
                    queryfin = "SELECT IdUser,Nume,Functie,Email,Telefon from UseriAgenda";
                }
                else if (v2)
                {
                    queryfin = "SELECT IdUser,Nume,Functie,Email,Telefon from UseriAgenda " +
                        "WHERE Telefon LIKE '%" + Telefon + "%'";
                }
                else if (v3)
                {
                    queryfin = "SELECT IdUser,Nume,Functie,Email,Telefon from UseriAgenda " +
                        "WHERE Nume LIKE '%" + Nume + "%'";
                }
                else if (v4)
                {
                    queryfin = "SELECT IdUser,Nume,Functie,Email,Telefon from UseriAgenda " +
                        "WHERE Telefon LIKE '%" + Telefon + "%' " +
                        "AND Nume LIKE '%" + Nume + "%'";
                }
                else if (v5)
                {
                    queryfin = "SELECT IdUser,Nume,Functie,Email,Telefon from UseriAgenda " +
                        "WHERE Email LIKE '%" + Mail + "%'";
                }
                else if (v6)
                {
                    queryfin = "SELECT IdUser,Nume,Functie,Email,Telefon from UseriAgenda " +
                        "WHERE Email LIKE '%" + Mail + "%' " +
                        "AND Telefon LIKE '%" + Telefon + "%'";
                }
                else if (v7)
                {
                    queryfin = "SELECT IdUser,Nume,Functie,Email,Telefon from UseriAgenda " +
                        "WHERE Email LIKE '%" + Mail + "%' " +
                        "AND Nume LIKE '%" + Nume + "%'";
                }
                else if (v8)
                {
                    queryfin = "SELECT IdUser,Nume,Functie,Email,Telefon from UseriAgenda " +
                        "WHERE Email LIKE '%" + Mail + "%' " +
                        "AND Nume LIKE '%" + Nume + "%' " +
                        "AND Telefon LIKE '%" + Telefon + "%'";
                }
                else
                {
                    queryfin = "SELECT IdUser,Nume,Functie,Email,Telefon from UseriAgenda";
                }


                databaseObject.OpenConnection();

                SqlCommand myquerytab = new SqlCommand(queryfin, databaseObject.myConnection);

                SqlDataAdapter daquery = new SqlDataAdapter(myquerytab);
                DataTable dttab = new DataTable();
                DataSet ds = new DataSet();
                daquery.Fill(dttab);
                daquery.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();


                databaseObject.CloseConnection();


            }
            catch (Exception)
            {
                string script = "alert(\"Eroare la incarcare rezultate!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
    }
}