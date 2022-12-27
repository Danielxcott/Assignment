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
                   <div class="col-3">
                       <div class="dropdown">
                          <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                            Export & Import
                          </button>
                          <ul class="dropdown-menu">
                            <li><asp:LinkButton ID="lnkExportBtn" CssClass="dropdown-item" OnClick="LnkExportBtn"   runat="server">Export as xlsx</asp:LinkButton></li>
                            <li><asp:LinkButton ID="lnkImportBtn" CssClass="dropdown-item" data-bs-toggle="modal" data-bs-target="#importModal"  runat="server">Import as xlsx</asp:LinkButton></li>
                          </ul>
                        </div>
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
             <asp:TemplateField HeaderText="No">
                <ItemTemplate>    
                    <%#Container.DataItemIndex+1 %>  
                    <asp:Label Visible="false" ID="lblMemberID" runat="server" Text='<%# Eval("MemberId") %>' ></asp:Label>
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
     <!-- Modal import box -->
    <div class="modal fade" id="importModal" tabindex="-1" aria-labelledby="importModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="importModalLabel">Import excel (only support xlsx)</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body m-auto">
          <asp:RequiredFieldValidator ValidationGroup="importValidate" ID="requiredFileValidation" ControlToValidate="fuldImport" runat="server" ForeColor="Red" ErrorMessage="File input field required!"></asp:RequiredFieldValidator>
          <asp:FileUpload ID="fuldImport" ValidationGroup="importValidate" CssClass="form-control" runat="server" />
          <asp:RegularExpressionValidator 
     ID="regexFileValidation" ValidationGroup="importValidate" ForeColor="Red" runat="server" ControlToValidate="fuldImport" 
     ErrorMessage="File type does not support." 
     ValidationExpression="^([0-9a-zA-Z_\-~ :\\])+(.xlsx|.xls)$"></asp:RegularExpressionValidator>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
         <asp:Button ID="btnImport" ValidationGroup="importValidate" cssClass="btn btn-primary" runat="server" Text="Import" OnClick="LnkImportBtn" />
      </div>
    </div>
  </div>
 </div>
</asp:Content>
   
