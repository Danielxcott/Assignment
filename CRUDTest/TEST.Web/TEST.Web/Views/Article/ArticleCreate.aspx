<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleCreate.aspx.cs" Inherits="TEST.Web.Views.Article.ArticleCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hdnPostId" runat="server" Value="0" />
    <div class="mt-3 row">
        <label for="<%= txtArticleTtl.ClientID  %>" class="col-sm-2 col-form-label">Title</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtArticleTtl" ValidationGroup="control"  runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="control" ControlToValidate="txtArticleTtl" ID="requireTitleValidator" runat="server" ForeColor="Red" ErrorMessage="Title input field required!"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="mt-3 row">
        <label for="<%= txtArticleSlug.ClientID  %>" class="col-sm-2 col-form-label">Slug</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtArticleSlug" ValidationGroup="control" runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="control" ControlToValidate="txtArticleSlug" ID="requireSlugValidator" runat="server" ForeColor="Red" ErrorMessage="Slug input field required!"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="mt-3 row">
        <label for="<%= txtArticleDescribe.ClientID  %>" class="col-sm-2 col-form-label">Description</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtArticleDescribe" ValidationGroup="control" runat="server" CssClass="form-control" TextMode="MultiLine" required></asp:TextBox>
           <asp:RequiredFieldValidator ValidationGroup="control" ControlToValidate="txtArticleDescribe" ID="requireDescriptionValidator" runat="server" ForeColor="Red" ErrorMessage="Description box field required!"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="mt-3 row">
        <label for="<%= ddlCategory.ClientID  %>" class="col-sm-2 col-form-label">Category</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddlCategory" CssClass="form-control form-select" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="0" ID="requireCategoryValidator" ControlToValidate="ddlCategory" runat="server" ValidationGroup="control" ForeColor="Red" ErrorMessage="Please, choose your category depends on your article."></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="mt-3 row">
        <label  for="<%= txtArticleCreated.ClientID  %>" class="col-sm-2 col-form-label">Created At</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtArticleCreated" ValidationGroup="control" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" required></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="control" ControlToValidate="txtArticleCreated" ID="requireDateValidator" runat="server" ForeColor="Red" ErrorMessage="Date input field required!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtArticleCreated" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
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
