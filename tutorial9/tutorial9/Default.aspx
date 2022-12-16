<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tutorial9._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <label class="file">
            <asp:FileUpload ID="FileUpload1" runat="server" cssClass="form-input"/>
             <span runat="server" class="file-custom"></span>
    </label>
        <asp:Button ID="UploadBtn" runat="server" Text="Upload" CssClass="btn btn-primary mt-10" OnClick="Upload_Btn" />
     <asp:Label ID="ErrorMsg" runat="server" style="display:none" ForeColor="Red" Text=""></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="FileUpload1" runat="server" ForeColor="Red" ErrorMessage="File needs to be required!"></asp:RequiredFieldValidator>
    <asp:GridView ID="GridView1" CssClass="table" runat="server" style="margin-top:15px;"></asp:GridView>
</asp:Content>
