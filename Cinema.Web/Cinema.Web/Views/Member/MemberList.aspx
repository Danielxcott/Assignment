<%@ Page Title="MOON | Members" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="Cinema.Web.Views.Member.MemberList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Scripts/sweetalert.min.js"></script>
    <link href="../../Content/style.css" rel="stylesheet" />
     <div class="row mt-3">
           <div class="col-md-9">
               <div class="row">
                    <div class="col-3">
                    <asp:LinkButton ID="lnkBtnCreate" CssClass="btn btn-primary" OnClick="LnkBtnCreate" runat="server">Create</asp:LinkButton>
                    </div>
               <div class="col-6">
                    <div class="input-group">
                     <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server" TextMode="Search"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-outline-secondary" Text="Search" onClick="SearchBtn"/>
                    </div>
                </div>
               </div>
           </div>
     </div>
    <asp:GridView ID="gvMember" runat="server" CssClass="table table-bordered table-striped mt-3" AutoGenerateColumns="false" OnRowCommand="gvMemberRowCommand" OnRowDeleting="gvMemberRowDeleting"  AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="8">
        <Columns>
             <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                   <asp:Label ID="lblMemberID" runat="server" Text='<%# Eval("MemberId") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Full Name">
                <ItemTemplate>
                   <asp:Label ID="lblFullName" runat="server" Text='<%# Eval("FullName") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Address">
                <ItemTemplate>
                   <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Movies Rented">
                <ItemTemplate>
                   <asp:Label ID="lblMovieName" runat="server" Text='<%# Eval("MoviesRented") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Salutation">
                <ItemTemplate>
                   <asp:Label ID="lblSalutation" runat="server" Text='<%# Eval("Salutation") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                   <asp:LinkButton ID="lnkBtnEdit" runat="server" CssClass="btn btn-primary btn-sm" CommandName="Edit" CommandArgument='<%# Eval("MemberId") %>'>
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
