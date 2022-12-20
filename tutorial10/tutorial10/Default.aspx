<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tutorial10._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="mb-3">
            <asp:Label ID="lblErrorFeedback" runat="server" Text=""></asp:Label> <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email address"></asp:Label>
            <br />
            <asp:TextBox ID="txtEmail" ValidationGroup="login"  CssClass="form-control" runat="server" PlaceHolder="Enter your email address"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requireEmailValidator"  ValidationGroup="login" ControlToValidate="txtEmail" runat="server" ErrorMessage="Your email field is required! " ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="checkingEmailFormat"  ValidationGroup="login"  runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator>
        </div>
         <div class="mb-3">
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="txtPassword"  ValidationGroup="login"  CssClass="form-control" runat="server" PlaceHolder="Enter your password" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator  ValidationGroup="login" ID="requirePasswordValidator" ControlToValidate="txtPassword" runat="server" ErrorMessage="Your password field is required! " ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="btnLogin" CssClass="btn btn-primary"  ValidationGroup="login"  style="margin:10px 0" runat="server" Text="Login" onClick="Login_Btn"/>
        <asp:Button ID="btnForgot" CssClass="btn btn-secondary" runat="server" Text="Forgot password" onClick="Forget_Btn"/>

</asp:Content>
