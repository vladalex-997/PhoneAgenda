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
    public partial class ModificareUtil : System.Web.UI.Page
    {
        int nummail;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btninserare_Click(object sender, EventArgs e)
        {

            try
            {
                nummail = 0;
                string Email = tbxinseraremail.Text;
                string Nume = tbxinserarenume.Text;
                string Numar = tbxinserarenumar.Text;
                string Functie = tbxinserarefunctie.Text;

                if (string.IsNullOrEmpty(Email)||string.IsNullOrEmpty(Nume)||string.IsNullOrEmpty(Numar)||string.IsNullOrEmpty(Functie))
                {
                    string script = "alert(\"Completati toate campurile inserare!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else
                {
                    Database databaseObject = new Database();
                    string querydup = "SELECT * from UseriAgenda where Email=@Email";
                    databaseObject.OpenConnection();

                    SqlCommand myCommanduserexistamail = new SqlCommand(querydup, databaseObject.myConnection);

                    myCommanduserexistamail.Parameters.AddWithValue("@Email",Email);

                 

                    SqlDataAdapter dauser = new SqlDataAdapter(myCommanduserexistamail);
                    DataTable dtuser = new DataTable();
                    dauser.Fill(dtuser);
                    foreach (DataRow row in dtuser.Rows)
                    {
                        nummail++;
                    }

                    if (nummail != 0)
                    {

                        string scriptnotiexistamail = "alert(\"Exista deja un utilizator cu acest mail!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptnotiexistamail, true);

                    }
                    else
                    {

                        string query = "INSERT INTO UseriAgenda(Nume,Functie,Email,Telefon) VALUES(@Nume,@Functie,@Emailins,@Numar)";
                        SqlCommand myCommand = new SqlCommand(query, databaseObject.myConnection);



                        myCommand.Parameters.AddWithValue("@Emailins", Email);
                        myCommand.Parameters.AddWithValue("@Nume", Nume);
                        myCommand.Parameters.AddWithValue("@Numar", Numar);
                        myCommand.Parameters.AddWithValue("@Functie", Functie);
           

                        var result = myCommand.ExecuteNonQuery();
                        string scriptnoti = "alert(\"Inserare inregistrare reusita!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptnoti, true);

                        tbxinseraremail.Text = "";
                         tbxinserarenumar.Text = "";
                        tbxinserarenume.Text = "";
                        tbxinserarefunctie.Text = "";

                    }

                    databaseObject.CloseConnection();
                }

            }
            catch (Exception)
            {
                string script = "alert(\"Eroare la inserare!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }



        }

        protected void btnstergere_Click(object sender, EventArgs e)
        {
            try
            {
                
                string Emailsters = tbxemailstergere.Text;

                if (string.IsNullOrEmpty(Emailsters))
                {
                    string script = "alert(\"Completati campul Email Stergere!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else
                {
                    Database databaseObject = new Database();
                    databaseObject.OpenConnection();

                    string querydel = "DELETE from UseriAgenda where Email=@Emailsters";

                    SqlCommand mycommanddel = new SqlCommand(querydel, databaseObject.myConnection);
                    mycommanddel.Parameters.AddWithValue("@Emailsters", Emailsters);

                    var result = mycommanddel.ExecuteNonQuery();

                    databaseObject.CloseConnection();

                    string script = "alert(\"Stergere inregistrare reusita!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                    tbxemailstergere.Text = "";

                }

                
            }
            catch (Exception)
            {
                string script = "alert(\"Eroare la stergere!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

        }

        protected void btnautocomplete_Click(object sender, EventArgs e)
        {
            try
            {
                string IdUser = tbxmodificareid.Text;
                if(int.TryParse(IdUser,out int docu))
                {
                    int nrIdUser = int.Parse(IdUser);
                    Database databaseObject = new Database();
                    databaseObject.OpenConnection();
                    string queryauto = "SELECT IdUser,Nume,Functie,Email,Telefon from UseriAgenda WHERE IdUser=@IdUser";

                    SqlCommand mycommandcomplete = new SqlCommand(queryauto, databaseObject.myConnection);

                    mycommandcomplete.Parameters.AddWithValue("@IdUser",nrIdUser);

                    string Numeread = "";
                    string Functieread = "";
                    string Emailread = "";
                    string Telefonread = "";

                    SqlDataReader re = mycommandcomplete.ExecuteReader();
                    if (re.HasRows)
                    {
                        while (re.Read())
                        {
                            Numeread = re[1].ToString();
                            Functieread = re[2].ToString();
                            Emailread = re[3].ToString();
                            Telefonread = re[4].ToString();
                        }
                        tbxmodificarenume.Text = Numeread;
                        tbxmodificarefunctie.Text = Functieread;
                        tbxmodificaremail.Text = Emailread;
                        tbxmodificarenumar.Text = Telefonread;
                    }
                    else
                    {
                        string script = "alert(\"Nu exista user cu acest Id User!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                    re.Close();

                    databaseObject.CloseConnection();
                }
                else
                {
                    string script = "alert(\"Completati corect Id User!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception)
            {
                string script = "alert(\"Eroare autocomplete!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        protected void btnmodificare_Click(object sender, EventArgs e)
        {
            try
            {
                string Nume = tbxmodificarenume.Text;
                string Mail = tbxmodificaremail.Text;
                string Telefon = tbxmodificarenumar.Text;
                string Functie = tbxmodificarefunctie.Text;
                string IdUser = tbxmodificareid.Text;
                if (string.IsNullOrEmpty(Nume)||string.IsNullOrEmpty(Mail)||string.IsNullOrEmpty(Telefon)||string.IsNullOrEmpty(Functie)||!int.TryParse(IdUser, out int docu))
                {
                    string script = "alert(\"Completati toate campurile corect pentru modificare!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else
                {
                    int nrIdUser = int.Parse(IdUser);
                    Database databaseobject = new Database();
                    databaseobject.OpenConnection();

                    string queryupdate = "UPDATE UseriAgenda SET Nume=@Nume,Functie=@Functie,Email=@Email,Telefon=@Telefon WHERE IdUser=@IdUser";

                    SqlCommand mysqlcommandup = new SqlCommand(queryupdate,databaseobject.myConnection);

                    mysqlcommandup.Parameters.AddWithValue("@Nume",Nume);
                    mysqlcommandup.Parameters.AddWithValue("@Functie",Functie);
                    mysqlcommandup.Parameters.AddWithValue("@Email",Mail);
                    mysqlcommandup.Parameters.AddWithValue("@Telefon",Telefon);
                    mysqlcommandup.Parameters.AddWithValue("@IdUser",nrIdUser);

                    var result = mysqlcommandup.ExecuteNonQuery();

                    string script = "alert(\"Modificare inregistrare reusita!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                    tbxmodificarefunctie.Text = "";
                    tbxmodificareid.Text = "";
                    tbxmodificaremail.Text = "";
                    tbxmodificarenumar.Text = "";
                    tbxmodificarenume.Text = "";

                    databaseobject.CloseConnection();

                }
            }
            catch (Exception)
            {
                string script = "alert(\"Eroare modificare!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
    }
}