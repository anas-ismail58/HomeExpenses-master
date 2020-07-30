<%@ Page Title="صفحة الدخول" Language="C#" MasterPageFile="~/MainMasterPage.master" Async="true" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="HomeExpenses.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>صفحة الدخول</h1>
    <hr />
    <div class="row">
        <div class="col-md-4">
            <span id="errorMessage" runat="server" class="text-danger"></span>
            <div class="form-group">
                <label class="control-label">اسم البريد الالكترونى</label>
                <input id="txtEmail" runat="server" class="form-control" />
            </div>
            <div class="form-group">
                <label class="control-label">كلمة السر</label>
                <input id="txtPassword" type="password" runat="server" class="form-control" />
            </div>
            <div class="form-group">
                <asp:Button id="btnSave" runat="server" Text="الدخول" OnClick="BtnSave_Click" />
            </div>            
        </div>
    </div>
</asp:Content>
