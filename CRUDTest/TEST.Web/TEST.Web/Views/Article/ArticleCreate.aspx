<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleCreate.aspx.cs" Inherits="TEST.Web.Views.Article.ArticleCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="HiddenPostId" runat="server" Value="0" />
    <div class="mt-3 row">
        <label class="col-sm-2 col-form-label">Title</label>
        <div class="col-sm-6">
            <asp:TextBox ID="articleTtl" ValidationGroup="control"  runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="control" ControlToValidate="articleTtl" ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Title input field required!"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="mt-3 row">
        <label class="col-sm-2 col-form-label">Slug</label>
        <div class="col-sm-6">
            <asp:TextBox ID="articleSlug" ValidationGroup="control" runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="control" ControlToValidate="articleSlug" ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Slug input field required!"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="mt-3 row">
        <label class="col-sm-2 col-form-label">Description</label>
        <div class="col-sm-6">
            <asp:TextBox ID="articleDescribe" ValidationGroup="control" runat="server" CssClass="form-control" TextMode="MultiLine" required></asp:TextBox>
           <asp:RequiredFieldValidator ValidationGroup="control" ControlToValidate="articleDescribe" ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="Description box field required!"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="mt-3 row">
        <label class="col-sm-2 col-form-label">Created At</label>
        <div class="col-sm-6">
            <asp:TextBox ID="articleCreated" ValidationGroup="control" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" required></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="control" ControlToValidate="articleCreated" ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="Date input field required!"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="mt-3 row">
    <div class="col-md-6">
       <asp:Button ID="btnSave" ValidationGroup="control" runat="server" Text="Save" CssClass="btn btn-primary" onClick="SaveBtn_Click"/>
       <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" onClick="CancelBtn_Click" />
    </div>
      </div>
</asp:Content>
