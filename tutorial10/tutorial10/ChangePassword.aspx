<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="tutorial10.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Change Passowrd</h2>
    <span runat="server" ID="ErrorMsg" style="display:none"></span><br />
    <asp:Label ID="lblNewPassword" runat="server" Text="New Password"></asp:Label> <br />
    <asp:TextBox ID="txtNPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox> <br />
    <asp:RequiredFieldValidator ControlToValidate="txtNPassword" ID="requirePasswordValidator" runat="server"  ForeColor="Red" ErrorMessage="New password required!"></asp:RequiredFieldValidator> <br />
    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label> <br />
    <asp:TextBox ID="txtCPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox> <br />
    <asp:RequiredFieldValidator ControlToValidate="txtCPassword" ID="requireConfirmPasswordValidator" ForeColor="Red" runat="server" ErrorMessage="Confirm password field required!"></asp:RequiredFieldValidator> <br />
    <asp:Button ID="btnChangePw" runat="server" Text="Change Password" CssClass="btn btn-primary" OnClick="Change_Password"/>
</asp:Content>
