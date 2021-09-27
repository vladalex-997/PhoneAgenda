<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacte.aspx.cs" Inherits="AgendaTelefonica.Contacte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="style.css" rel="stylesheet" type="text/css" />

    <div class="cautare">

        </br>

        <h4>Lista Contacte</h4>

        </br>
        

       

        </br>
        </br>

       
        <asp:Label Text="Email: " CssClass="cautaremail" runat="server" />
        <asp:TextBox Id="tbxcautaremail" runat="server" CssClass="tbxcautaremail" placeholder="Introduceti Email" />
        <asp:Label Text="Nume: " CssClass="cautarenume" runat="server" />
        <asp:TextBox Id="tbxcautarenume" runat="server" CssClass="tbxcautarenume" placeholder="Introduceti Nume" />
            </br>
            </br>
            </br>
        <asp:Label Text="Telefon: " CssClass="cautarefunctie" runat="server" />
        <asp:TextBox Id="tbxcautarefunctie" runat="server" CssClass="tbxcautarefunctie" placeholder="Introduceti Telefon" />
            <div class="divider">
            </div>
                 <asp:Button ID="btncautare" Text="Filtrare" runat="server" CssClass="btncautare" OnClick="btncautare_Click" />


           </br>
        </br>
        </br>
       
         <h3>Numere prezente in baza de date: </h3>

        </br>
            

     

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table table-bordered table-striped" Width="100px">
            <AlternatingRowStyle Backcolor="#000099" />

            <Columns>

                <asp:BoundField DataField="IdUser" HeaderText="IdUser" />
                <asp:BoundField DataField="Nume" HeaderText="Nume si Prenume" />
               
                <asp:BoundField DataField="Functie" HeaderText="Functie" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Telefon" HeaderText="Telefon" />
              
                
            </Columns>

                <PagerSettings FirstPageText="Prima Pagina" LastPageText="Ultima Pagina" Mode="NumericFirstLast" />

            </asp:GridView>

          

    </div>

</asp:Content>
