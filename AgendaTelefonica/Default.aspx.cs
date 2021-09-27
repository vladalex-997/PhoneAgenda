using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.DirectoryServices.AccountManagement;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Input;

namespace AgendaTelefonica
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            try
            {
                string Username = tbxmail.Text;
                string Pass = tbxpass.Text;

                Response.Cookies["dateutilizator"].Expires = DateTime.Now.AddDays(-1);

                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Pass))
                {
                    string script = "alert(\"Completati toate campurile!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else
                {
                    AutentificareLdap auth = new AutentificareLdap();
                    var statusauten = auth.LDAPautentification(Username, Pass);
                    if (statusauten == true)
                    {

                        HttpCookie cooku = new HttpCookie("dateutilizator");
                        cooku.Expires = DateTime.Now.AddDays(1);
                        cooku.Value = Username;
                        Response.Cookies.Add(cooku);

                        Session["login"] = Username;



                        Response.Redirect("~/Contacte.aspx");
                    }
                    else if(statusauten == false)
                    {
                        string script = "alert(\"Eroare autentificare!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                    else
                    {
                        string script = "alert(\"Eroare autentificare!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                }
                
            }
            catch (Exception)
            {
                string script = "alert(\"Eroare pagina!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
    }
}