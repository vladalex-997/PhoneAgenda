<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificareUtil.aspx.cs" Inherits="AgendaTelefonica.ModificareUtil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <link href="style.css" rel="stylesheet" type="text/css" />

    <div class="Modificare">

        </br>

        <h4>Modificare/Adaugare Inregistrari</h4>

        </br>

        <div class="partestanga">

            <h3>Sectiune inserare/stergere inregistrari</h3>

            </br>
       
        <asp:Label Text="* Email: " CssClass="inserarelabemail" runat="server" />
        <asp:TextBox Id="tbxinseraremail" runat="server" CssClass="tbxinserare" placeholder="Introduceti Email" />
        </br>
        </br>
        <asp:Label Text="* Nume: " CssClass="inserarelabnume" runat="server" />
        <asp:TextBox Id="tbxinserarenume" runat="server" CssClass="tbxinserare" placeholder="Introduceti Nume" />
           </br>
        </br>
        <asp:Label Text="* Functie: " CssClass="inserarelabfunctie" runat="server" />
        <asp:TextBox Id="tbxinserarefunctie" runat="server" CssClass="tbxinserare" placeholder="Introduceti Functie" />
           </br>
        </br>
        <asp:Label Text="* Telefon: " CssClass="inserarelabnumar" runat="server" />
        <asp:TextBox Id="tbxinserarenumar" runat="server" CssClass="tbxinserare" placeholder="Introduceti Telefon" />

            </br>
            </br>
            </br>
       <%-- <div class="spatiu" />--%>
        <asp:Label CssClass="spatiulabel1" runat="server" />
        <asp:Button ID="btninserare" runat="server" Text="Inserare" CssClass="btncautare" OnClick="btninserare_Click" />

            </br>
            </br>
             </br>
        <asp:Label CssClass="spatiulabel2" runat="server" />
        <asp:Label Text="* Email pentru Stergere: " CssClass="inserarelabemail" runat="server" />
            </br>
            </br>
        <asp:Label CssClass="spatiulabel1" runat="server" />
        <asp:TextBox Id="tbxemailstergere" runat="server" CssClass="tbxinserare" placeholder="Email Stergere" />

              </br>
            </br>
           
        <asp:Label CssClass="spatiulabel1" runat="server" />
        <asp:Button ID="btnstergere" runat="server" Text="Stergere" CssClass="btncautare" OnClick="btnstergere_Click" />

        </div>

        <div class="centru">



        </div>


        <div class="partedreapta">

            <h3>Sectiune modificare inregistrari</h3>

            </br>

             <asp:Label Text="* IdUser: " CssClass="modlabId" runat="server" />
        <asp:TextBox Id="tbxmodificareid" runat="server" CssClass="tbxinserare" placeholder="Id User pentru Autocomplete" />
        </br>
        </br>


            <asp:Label Text="* Email: " CssClass="modlabemail" runat="server" />
        <asp:TextBox Id="tbxmodificaremail" runat="server" CssClass="tbxinserare" placeholder="Introduceti Email" />
        </br>
        </br>
        <asp:Label Text="* Nume: " CssClass="modlabnume" runat="server" />
        <asp:TextBox Id="tbxmodificarenume" runat="server" CssClass="tbxinserare" placeholder="Introduceti Nume" />
           </br>
        </br>
        <asp:Label Text="* Functie: " CssClass="modlabfunctie" runat="server" />
        <asp:TextBox Id="tbxmodificarefunctie" runat="server" CssClass="tbxinserare" placeholder="Introduceti Functie" />
           </br>
        </br>
        <asp:Label Text="* Telefon: " CssClass="modlabnumar" runat="server" />
        <asp:TextBox Id="tbxmodificarenumar" runat="server" CssClass="tbxinserare" placeholder="Introduceti Telefon" />
            </br>
            </br>
            </br>
            <asp:Label CssClass="spatiulabel3" runat="server" />
        <asp:Button ID="btnautocomplete" CssClass="btncautare" runat="server" Text="Autocomplete" OnClick="btnautocomplete_Click" />
            </br>
            </br>
            
        <asp:Label CssClass="spatiulabel3" runat="server" />
        <asp:Button ID="btnmodificare" CssClass="btncautare" runat="server" Text="Modificare" OnClick="btnmodificare_Click" />
            </br>
            </br>
        </div>

    </div>



</asp:Content>
