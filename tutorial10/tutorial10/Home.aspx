<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="tutorial10.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <    <h2>Welcome, this is <%: Title %> page.</h2>
    <h3 ID="name" runat="server"></h3>
    <span>Your email is: </span>
    <asp:Label ID="email" runat="server" CssClass="mb-3" Text=""></asp:Label> <br />
    <span>Your password is: </span>
    <asp:Label ID="password" runat="server" CssClass="mb-3" Text=""></asp:Label> <br />
    <asp:Button ID="Logout" CssClass="mt-3 btn btn-danger" runat="server" Text="Logout" OnClick="Logout_Btn" />
</asp:Content>
