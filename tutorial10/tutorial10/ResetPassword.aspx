<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="tutorial10.ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2>Forgot Password</h2>
    <asp:Label ID="LblEmail" runat="server" Text="Your Email"></asp:Label>
    <asp:TextBox ID="EmailBox0" CssClass="form-control" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="EmailBox0" ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Input field required!"></asp:RequiredFieldValidator> <br />
     <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EmailBox0" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator> <br />
    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" style="display:block;" Text="Send" OnClick="Reset_Btn"/>
</asp:Content>
