<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tutorial8._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <h1>Create a list of dogs</h1>
    <div>
        <asp:Label ID="lblName" runat="server" Text="Dog name"></asp:Label> <br />
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" ValidationGroup="create"></asp:TextBox>
        <asp:RequiredFieldValidator ID="requireNameValidate" ValidationGroup="create" runat="server" ControlToValidate="txtName" ErrorMessage="Required input field" ForeColor="Red" EnableClientScript="false"></asp:RequiredFieldValidator>
        <asp:Label ID="lblMax" runat="server" ForeColor="Red" ></asp:Label>
        <div style="margin-bottom: 15px">
        <asp:Button ID="btnUpdate" CssClass="btn btn-primary" style="margin-right:10px; display: none" ValidationGroup="create" runat="server" Text="Update" OnClick="UpdateBtn"  UseSubmitBehavior="False"/>
        <asp:Button ID="btnCreate" CssClass="btn btn-primary" style="margin-right:10px" runat="server" Text="Create" OnClick="CreateBtn" UseSubmitBehavior="False"/>
        <asp:Button ID="btnClear" CssClass="btn btn-danger" runat="server" Text="Clear" OnClick="ClearBtn" />
        <asp:Button ID="btnCancel" runat="server" style="display:none; margin-left:10px;" 
         Text="Cancel" CssClass="btn btn-secondary" OnClick="CancelBtn"  UseSubmitBehavior="False"/>
        </div>
    </div>
    <asp:GridView ID="gvDogLists" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="id"  OnRowDeleting="gvDogsRowDeleting" OnRowEditing="gvDogsRowEditing">  
            <Columns>  
                 <asp:TemplateField HeaderText="No">
                <ItemTemplate>    
                    <%#Container.DataItemIndex+1 %>    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id" HeaderText="Dog Id" />  
                <asp:BoundField DataField="name" HeaderText="Name" /> 
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server"  CommandName="Edit" 
                        Text="Edit" CssClass="btn btn-warning editBtn"  UseSubmitBehavior="False"/>
                       <asp:Button ID="btnDelete" runat="server" CommandName="Delete" 
                        Text="Delete" CssClass="btn btn-danger delBtn"  OnClientClick="return confirm('Are you sure to delete?');" />
                    </ItemTemplate>
                </asp:TemplateField>            
            </Columns>  
             <EmptyDataTemplate>
                  <div align="center">No records Avaliable.</div>
             </EmptyDataTemplate>  
    </asp:GridView>  

</asp:Content>

