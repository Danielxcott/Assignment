<%@ Page Title="MOON | Movies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieList.aspx.cs" Inherits="Cinema.Web.Views.Movie.MovieList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <script src="../../Scripts/sweetalert.min.js"></script>
    <link href="../../Content/style.css" rel="stylesheet" />
    <div class="row mt-3">
           <div class="col-md-12">
               <asp:LinkButton ID="lnkBtnCreate" CssClass="btn btn-primary" OnClick="LnkBtnCreate" runat="server">Create</asp:LinkButton>
           </div>
     </div>
    <asp:GridView ID="gvMovie" runat="server" CssClass="table table-bordered table-striped mt-3" AutoGenerateColumns="false" OnRowCommand="gvMovieRowCommand" OnRowDeleting="gvMovieRowDeleting" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="8">
        <Columns>
            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                   <asp:Label ID="lblMovieID" runat="server" Text='<%# Eval("MovieId") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Salutation">
                <ItemTemplate>
                   <asp:Label ID="lblMovieName" runat="server" Text='<%# Eval("MoviesRented") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                   <asp:LinkButton ID="lnkBtnEdit" runat="server" CssClass="btn btn-primary btn-sm" CommandName="Edit" CommandArgument='<%# Eval("MovieId") %>'>
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
