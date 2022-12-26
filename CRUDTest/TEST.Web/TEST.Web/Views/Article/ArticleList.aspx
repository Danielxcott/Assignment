<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleList.aspx.cs" Inherits="TEST.Web.Views.Article.ArticleList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Scripts/sweetalert.min.js"></script>
    <link href="../../Content/style.css" rel="stylesheet" />
    <div class="row mt-3">
           <div class="col-12 col-md-6">
               <asp:LinkButton ID="lnkBtnCreate" CssClass="btn btn-primary" OnClick="LnkBtnCreate" runat="server">Create</asp:LinkButton>
           </div>
     </div>
    <asp:GridView ID="gvArticles" runat="server" CssClass="table table-bordered table-striped mt-3" AutoGenerateColumns="false" OnRowCommand="gvArticleRowCommand" OnRowDeleting="gvArticleRowDeleting" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="8">
        <Columns>
            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                   <asp:Label ID="lblArticleID" runat="server" Text='<%# Eval("ArticleId") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category Name">
                <ItemTemplate>
                   <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("Name") %>' ></asp:Label>
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
                    <asp:Button ID="btnDelete" UseSubmitBehavior="false"  CssClass="btn btn-danger btn-sm" CommandName="Delete" OnClientClick="return delHandle(this)"  runat="server" Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
         <EmptyDataTemplate>
           <div align="center">No records Avaliable.</div>
         </EmptyDataTemplate>  
    </asp:GridView>
</asp:Content>
