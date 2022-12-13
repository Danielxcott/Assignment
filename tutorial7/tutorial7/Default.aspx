<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tutorial7._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mb-3">
            <asp:Label ID="ErrorFeedback" runat="server" Text=""></asp:Label> <br />
            <asp:Label ID="Label1" runat="server" Text="Email address"></asp:Label>
            <br />
            <asp:TextBox ID="email"  CssClass="form-control" runat="server" PlaceHolder="Enter your email address"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="email" runat="server" ErrorMessage="Your email field is required! " ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator>
        </div>
         <div class="mb-3">
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="password" CssClass="form-control" runat="server" PlaceHolder="Enter your password" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="password" runat="server" ErrorMessage="Your password field is required! " ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="Button1" CssClass="btn btn-primary mt-3" runat="server" Text="Login" onClick="Login_Btn"/>

</asp:Content>
