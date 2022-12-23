<%@ Page Title="MOON | Create Member" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberCreate.aspx.cs" Inherits="Cinema.Web.Views.Member.MemberCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hdnMemberId" runat="server" Value="0" />
    <div class="mt-3 row">
        <label for="<%= txtFullName.ClientID  %>" class="col-sm-2 col-form-label">Full Name</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtFullName" ValidationGroup="control"  runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="control" ControlToValidate="txtFullName" ID="requireFullNameValidator" runat="server" ForeColor="Red" ErrorMessage="Name input field required!"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="mt-3 row">
        <label for="<%= txtAddress.ClientID  %>" class="col-sm-2 col-form-label">Address</label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtAddress" ValidationGroup="control"  runat="server" CssClass="form-control" TextMode="MultiLine" required></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="control" ControlToValidate="txtAddress" ID="requireAddressValidator" runat="server" ForeColor="Red" ErrorMessage="Address input field required!"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="mt-3 row">
        <label for="<%= ddlMovie.ClientID  %>" class="col-sm-2 col-form-label">Movie Lists</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddlMovie" CssClass="form-control form-select" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="0" ID="requireMovieValidator" ControlToValidate="ddlMovie" runat="server" ValidationGroup="control" ForeColor="Red" ErrorMessage="Select a movie name from the dropdown list."></asp:RequiredFieldValidator>
        </div>
    </div>
     <div class="mt-3 row">
        <label for="<%= ddlSalutation.ClientID  %>" class="col-sm-2 col-form-label">Salutation</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="ddlSalutation" CssClass="form-control form-select" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="0" ID="requireSalutationValidator" ControlToValidate="ddlSalutation" runat="server" ValidationGroup="control" ForeColor="Red" ErrorMessage="Choose a salutation."></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="mt-3 row">
    <div class="col-md-6">
       <asp:Button ID="btnSave" ValidationGroup="control" runat="server" Text="Save" CssClass="btn btn-primary" onClick="SaveBtn"/>
       <asp:LinkButton ID="lnkBtnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" onClick="CancelBtn" />
    </div>
      </div>
</asp:Content>
