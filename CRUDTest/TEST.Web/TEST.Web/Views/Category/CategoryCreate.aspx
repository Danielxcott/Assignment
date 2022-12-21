<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryCreate.aspx.cs" Inherits="TEST.Web.Views.Category.CategoryCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hdnCategoryId" runat="server" Value="0" />
    <div class="mt-3 row">
        <label for="<%= txtName.ClientID  %>" class="col-sm-2 col-form-label">Title</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtName" ValidationGroup="control"  runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="control" ControlToValidate="txtName" ID="requireNameValidator" runat="server" ForeColor="Red" ErrorMessage="Name input field required!"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="mt-3 row">
        <label for="<%= txtSlug.ClientID  %>" class="col-sm-2 col-form-label">Slug</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtSlug" ValidationGroup="control" runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="control" ControlToValidate="txtSlug" ID="requireSlugValidator" runat="server" ForeColor="Red" ErrorMessage="Slug input field required!"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="mt-3 row">
        <label for="<%= txtCreatedAt.ClientID  %>" class="col-sm-2 col-form-label">Created At</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtCreatedAt" ValidationGroup="control" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" required></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="control" ControlToValidate="txtCreatedAt" ID="requireDateValidator" runat="server" ForeColor="Red" ErrorMessage="Date input field required!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCreatedAt" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
    ErrorMessage="Date format is invalid!" ValidationGroup="control" ID="validateDate" ForeColor="Red" />
        </div>
    </div>
    <div class="mt-3 row">
    <div class="col-md-6">
       <asp:Button ID="btnSave" ValidationGroup="control" runat="server" Text="Save" CssClass="btn btn-primary" onClick="SaveBtn_Click"/>
       <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" onClick="CancelBtn_Click" />
    </div>
      </div>
</asp:Content>
