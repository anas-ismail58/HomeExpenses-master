<%@ Page Title="اضافة مستخدم" Language="C#" MasterPageFile="~/MainMasterPage.master" Async="true" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="HomeExpenses.Web.AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>اضافة مستخدم</h1>
    <hr />
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label">اسم المستخدم</label>
                <input id="txtName" runat="server" class="form-control" />
            </div>
            <div class="form-group">
                <label class="control-label">اسم البريد الالكترونى</label>
                <input id="txtEmail" runat="server" class="form-control" />
            </div>
            <div class="form-group">
                <label class="control-label">كلمة السر</label>
                <input id="txtPassword" type="password" runat="server" class="form-control" />
            </div>
            <div class="form-group">
                <asp:Button id="btnSave" runat="server" Text="حفظ" OnClick="BtnSave_Click" />
                <a href="AllItems.aspx">العودة</a>
            </div>            
        </div>
    </div>
</asp:Content>
