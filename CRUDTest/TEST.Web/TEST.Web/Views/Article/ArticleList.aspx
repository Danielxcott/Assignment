﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleList.aspx.cs" Inherits="TEST.Web.Views.Article.ArticleList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Scripts/sweetalert.min.js"></script>
    <div class="row mt-3">
           <div class="col-md-12">
               <asp:LinkButton ID="LnkBtnCreate" CssClass="btn btn-primary" OnClick="LnkBtn_Create" runat="server">Create</asp:LinkButton>
           </div>
     </div>
    <asp:GridView ID="GVArticles" runat="server" CssClass="table table-bordered table-striped mt-3" AutoGenerateColumns="false" OnRowCommand="gvArticle_RowCommand" OnRowDeleting="gvArticle_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                   <asp:Label ID="lblArticleID" runat="server" Text='<%# Eval("ArticleId") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                   <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Slug">
                <ItemTemplate>
                   <asp:Label ID="lblSlug" runat="server" Text='<%# Eval("Slug") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                   <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Excerpt">
                <ItemTemplate>
                   <asp:Label ID="lblExcerpt" runat="server" Text='<%# Eval("Excerpt") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Created At">
                <ItemTemplate>
                   <asp:Label ID="lblCreatedAt" runat="server" Text='<%# Convert.ToDateTime(Eval("CreatedAt")).ToString("yyyy-MM-dd") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                   <asp:LinkButton ID="lnkbtnEdit" runat="server" CssClass="btn btn-primary btn-sm" CommandName="Edit" CommandArgument='<%# Eval("ArticleId") %>'>
                       Edit
                   </asp:LinkButton>
                    <asp:Button ID="lnkbtnDelete" UseSubmitBehavior="false"  CssClass="btn btn-danger btn-sm" CommandName="Delete" OnClientClick="return delHandle(this)"  runat="server" Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
         <EmptyDataTemplate>
           <div align="center">No records Avaliable.</div>
         </EmptyDataTemplate>  
    </asp:GridView>
</asp:Content>