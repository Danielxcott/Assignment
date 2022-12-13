<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tutorial8._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Create list of dogs</h1>
    <div>
        <asp:Label ID="NameLabel" runat="server" Text="Dog name"></asp:Label> <br />
        <asp:TextBox ID="NameCreate" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NameCreate" ErrorMessage="Required input field" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="CheckingMinLength" ControlToValidate="NameCreate" ValidationExpression="\[a-zA-Z]{3}" runat="server"  ForeColor="Red" ErrorMessage="Name must be at least in 3 lengths."></asp:RegularExpressionValidator>
        <span runat="server" ID="Max" style="color: red"></span>
        <div style="margin: 15px 0px">
        <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Update" style="display:none" OnClick="Update_Btn" />
        <asp:Button ID="CreateBtn" CssClass="btn btn-primary" style="margin-right:10px" runat="server" Text="Create" OnClick="Create_Btn"/>
        <asp:Button ID="ClearBtn" CssClass="btn btn-danger" runat="server" Text="Clear" OnClick="Clear_Btn" />
         
        </div>
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="id" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting">  
            <Columns>  
                <asp:BoundField DataField="id" HeaderText="No." />  
                <asp:BoundField DataField="name" HeaderText="Name" /> 
                <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-warning" />  
                <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" /> 
            </Columns>  
    </asp:GridView>  
</asp:Content>
