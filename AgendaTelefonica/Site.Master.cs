using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgendaTelefonica
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            menuusercurent.Visible = false;
            if (Session["login"] != null)
            {

                menulogin.Visible = false;
                string tempnume;
                tempnume = Request.Cookies["dateutilizator"].Value;
                if (tempnume == "vlad.arsene"||tempnume=="ovidiu.gionea"||tempnume=="andrei.rusu"||tempnume=="ioana.ungureanu")
                {
                    menuusercurent.Visible = true;
                    menuusercurent.InnerText = "Bun venit, " + tempnume;
                    menulogin.Visible = false;
                    menucontacte.Visible = true;
                    menulogout.Visible = true;
                    menumodifutil.Visible = true;
                    
                }
                else
                {
                    menuusercurent.Visible = true;
                    menuusercurent.InnerText = "Bun venit, " + tempnume;
                    menulogin.Visible = false;
                    menucontacte.Visible = true;
                    menulogout.Visible = true;
                    menumodifutil.Visible = false;

                }

            }
            else
            {
                menuusercurent.Visible = false;
                menulogin.Visible = true;
                menucontacte.Visible = false;
                menulogout.Visible = false;
                menumodifutil.Visible = false;
            }
        }
    }
}