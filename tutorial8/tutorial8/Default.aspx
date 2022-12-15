<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tutorial8._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <h1>Create a list of dogs</h1>
    <div>
        <asp:Label ID="NameLabel" runat="server" Text="Dog name"></asp:Label> <br />
        <asp:TextBox ID="NameCreate" runat="server" CssClass="form-control" ValidationGroup="create"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="create" runat="server" ControlToValidate="NameCreate" ErrorMessage="Required input field" ForeColor="Red" EnableClientScript="false"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="CheckingMinLength" ValidationGroup="create"  ControlToValidate="NameCreate" ValidationExpression="^[a-zA-Z]{3,100}" runat="server"  ForeColor="Red" ErrorMessage="Name must be at least in 3 lengths."></asp:RegularExpressionValidator>
        <span runat="server" ID="Max" style="color: red"></span>
        <div style="margin-bottom: 15px">
        <asp:Button ID="UpdateBtn" CssClass="btn btn-primary" style="margin-right:10px; display: none" ValidationGroup="create" runat="server" Text="Update" OnClick="Update_Btn"  UseSubmitBehavior="False"/>
        <asp:Button ID="CreateBtn" CssClass="btn btn-primary" style="margin-right:10px" runat="server" Text="Create" OnClick="Create_Btn" UseSubmitBehavior="False"/>
        <asp:Button ID="ClearBtn" CssClass="btn btn-danger" runat="server" Text="Clear" OnClick="Clear_Btn" />
        <asp:Button ID="CancelBtn" runat="server" style="display:none; margin-left:10px;" 
         Text="Cancel" CssClass="btn btn-secondary" OnClick="Cancel_Btn"  UseSubmitBehavior="False"/>
        </div>
    </div>
    <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="id"  OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing">  
            <Columns>  
                 <asp:TemplateField HeaderText="No">
                <ItemTemplate>    <%#Container.DataItemIndex+1 %>    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id" HeaderText="Dog Id" />  
                <asp:BoundField DataField="name" HeaderText="Name" /> 
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="EditBtn" runat="server"  CommandName="Edit" 
                        Text="Edit" CssClass="btn btn-warning editBtn"  UseSubmitBehavior="False"/>
                       <asp:Button ID="DeleteBtn" runat="server" CommandName="Delete" 
                        Text="Delete" CssClass="btn btn-danger delBtn"  OnClientClick="return confirm('Are you sure to delete?');" />
                    </ItemTemplate>
                </asp:TemplateField>            
            </Columns>  
             <EmptyDataTemplate>
                  <div align="center">No records Avaliable.</div>
             </EmptyDataTemplate>  
    </asp:GridView>  

</asp:Content>

