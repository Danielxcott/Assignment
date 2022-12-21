<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="tutorial10.ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2>Forgot Password</h2>
    <asp:Label ID="LblEmail" runat="server" Text="Your Email"></asp:Label>
    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="txtEmail" ID="requireEmailValidator" runat="server" ForeColor="Red" ErrorMessage="Input field required!"></asp:RequiredFieldValidator> <br />
     <asp:RegularExpressionValidator ID="checkingEmailFormat" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator> <br />
    <asp:Button ID="btnRestPw" runat="server" CssClass="btn btn-primary" style="display:block;" Text="Send" OnClick="ResetBtn"/>
</asp:Content>
