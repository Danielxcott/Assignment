<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tutorial7._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mb-3">
            <asp:Label ID="lblErrorFeedback" runat="server" Text=""></asp:Label> <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email address"></asp:Label>
            <br />
            <asp:TextBox ID="txtEmail" ValidationGroup="loginForm"  CssClass="form-control" runat="server" PlaceHolder="Enter your email address."></asp:TextBox>
            <asp:RequiredFieldValidator ID="requireEmailValidate" ValidationGroup="loginForm" ControlToValidate="txtEmail" runat="server" ErrorMessage="Your email field is required! " ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="formatEmailValidate" ValidationGroup="loginForm" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format." ForeColor="Red"></asp:RegularExpressionValidator>
        </div>
         <div class="mb-3">
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="txtPassword" ValidationGroup="loginForm" CssClass="form-control" runat="server" PlaceHolder="Enter your password." TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requirePasswordValidate" ValidationGroup="loginForm" ControlToValidate="txtPassword" runat="server" ErrorMessage="Your password field is required! " ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="btnLogin" CssClass="btn btn-primary mt-3" runat="server" Text="Login" onClick="LoginBtn"/>

</asp:Content>
