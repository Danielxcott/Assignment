<%@ Page Title="MOON | Create Salutation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalutationCreate.aspx.cs" Inherits="Cinema.Web.Views.Salutation.SalutationCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <asp:HiddenField ID="hdnSalutationId" runat="server" Value="0" />
    <div class="mt-3 row">
        <label for="<%= txtSalutation.ClientID  %>" class="col-sm-2 col-form-label">Title</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtSalutation" ValidationGroup="control"  runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="control" ControlToValidate="txtSalutation" ID="requireNameValidator" runat="server" ForeColor="Red" ErrorMessage="Salutation input field required!"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="mt-3 row">
    <div class="col-md-6">
       <asp:Button ID="btnSave" ValidationGroup="control" runat="server" Text="Save" CssClass="btn btn-primary" onClick="SaveBtn"/>
       <asp:LinkButton ID="lnkBtnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" onClick="CancelBtn" />
    </div>
      </div>
</asp:Content>
