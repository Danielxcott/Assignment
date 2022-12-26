<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="TEST.Web.Views.Category.CategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Scripts/sweetalert.min.js"></script>
    <div class="row mt-3">
           <div class="col-md-12">
               <asp:LinkButton ID="lnkBtnCreate" CssClass="btn btn-primary" OnClick="LnkBtnCreate" runat="server">Create</asp:LinkButton>
           </div>
     </div>
    <asp:GridView ID="gvCategory" runat="server" CssClass="table table-bordered table-striped mt-3" AutoGenerateColumns="false" OnRowCommand="gvCategoryRowCommand" OnRowDeleting="gvCategoryRowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                   <asp:Label ID="lblCategoryID" runat="server" Text='<%# Eval("CategoryId") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                   <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Slug">
                <ItemTemplate>
                   <asp:Label ID="lblSlug" runat="server" Text='<%# Eval("Slug") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Created At">
                <ItemTemplate>
                   <asp:Label ID="lblCreatedAt" runat="server" Text='<%# Convert.ToDateTime(Eval("CreatedAt")).ToString("yyyy-MM-dd") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                   <asp:LinkButton ID="lnkbtnEdit" runat="server" CssClass="btn btn-primary btn-sm" CommandName="Edit" CommandArgument='<%# Eval("CategoryId") %>'>
                       Edit
                   </asp:LinkButton>
                    <asp:Button ID="btnDelete" UseSubmitBehavior="false"  CssClass="btn btn-danger btn-sm" CommandName="Delete" OnClientClick="return delHandle(this)"  runat="server" Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
         <EmptyDataTemplate>
           <div align="center">No records Avaliable.</div>
         </EmptyDataTemplate>  
    </asp:GridView>
</asp:Content>
