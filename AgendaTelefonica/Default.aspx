<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AgendaTelefonica._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="style.css" rel="stylesheet" />
    
    

                        <div class="loginbox">

        <img src="userblk.jpg" class="user" />

        <h2>Autentificare</h2>

        

            <asp:Label Text="Username: " CssClass="lblemail" runat="server" />
            <asp:TextBox ID="tbxmail" runat="server" CssClass="txtmail" placeholder="Username din domain: prenume.nume" />
            <asp:Label Text="Parola: " CssClass="lblepass" runat="server" />
            <asp:TextBox runat="server" ID="tbxpass" TextMode="Password" CssClass="txtpass"  placeholder="Parola din domain"/>
            <asp:Button Text="Login" runat="server" CssClass="btnsubmit" OnClick="Unnamed5_Click" />

        

    </div>

 


    

</asp:Content>
