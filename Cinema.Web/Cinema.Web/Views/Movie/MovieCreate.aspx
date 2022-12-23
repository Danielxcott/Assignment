<%@ Page Title="MOON | Create Movie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieCreate.aspx.cs" Inherits="Cinema.Web.Views.Movie.MovieCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:HiddenField ID="hdnMovieId" runat="server" Value="0" />
    <div class="mt-3 row">
        <label for="<%= txtName.ClientID  %>" class="col-sm-2 col-form-label">Movies Rented</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtName" ValidationGroup="control"  runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="control" ControlToValidate="txtName" ID="requireNameValidator" runat="server" ForeColor="Red" ErrorMessage="Name input field required!"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="mt-3 row">
    <div class="col-md-6">
       <asp:Button ID="btnSave" ValidationGroup="control" runat="server" Text="Save" CssClass="btn btn-primary" onClick="SaveBtn"/>
       <asp:LinkButton ID="lnkBtnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" onClick="CancelBtn" />
    </div>
      </div>
</asp:Content>
