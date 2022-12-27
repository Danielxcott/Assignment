<%@ Page Title="MOON | Salutations" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalutationList.aspx.cs" Inherits="Cinema.Web.Views.Salutation.SalutationList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script src="../../Scripts/sweetalert.min.js"></script>
    <link href="../../Content/style.css" rel="stylesheet" />
    <div class="row mt-3">
           <div class="col-md-12">
               <asp:LinkButton ID="btnCreate" CssClass="btn btn-primary" OnClick="LnkBtnCreate" runat="server">Create</asp:LinkButton>
           </div>
     </div>
    <asp:GridView ID="gvSalutation" runat="server" CssClass="table table-bordered table-striped mt-3" AutoGenerateColumns="false" OnRowCommand="gvSalutationRowCommand" OnRowDeleting="gvSalutationRowDeleting" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="8">
        <Columns>
            <asp:TemplateField HeaderText="No">
                <ItemTemplate>
                  <%#Container.DataItemIndex+1 %>  
                   <asp:Label Visible="false" ID="lblSalutationID" runat="server" Text='<%# Eval("SalutationId") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Salutation">
                <ItemTemplate>
                   <asp:Label ID="lblSalutation" runat="server" Text='<%# Eval("Salutation") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                   <asp:LinkButton ID="lnkbtnEdit" runat="server" CssClass="btn btn-primary btn-sm" CommandName="Edit" CommandArgument='<%# Eval("SalutationId") %>'>
                       Edit
                   </asp:LinkButton>
                    <asp:Button ID="lnkbtnDelete" UseSubmitBehavior="false"  CssClass="btn btn-danger btn-sm" CommandName="Delete" OnClientClick="return delHandle(this)"  runat="server" Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
         <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
         <EmptyDataTemplate>
           <div align="center">No records Avaliable.</div>
         </EmptyDataTemplate>  
    </asp:GridView>
</asp:Content>
