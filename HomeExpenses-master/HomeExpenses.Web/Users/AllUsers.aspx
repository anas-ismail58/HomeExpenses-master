<%@ Import Namespace="HomeExpenses.Data" %>

<%@ Page Title="جميع المستخدمين" Language="C#" MasterPageFile="~/MainMasterPage.master" Async="true" AutoEventWireup="true" CodeFile="AllUsers.aspx.cs" Inherits="HomeExpenses.Web.AllUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>المستخدمين</h1>
    <p>
        <a href="addUser.aspx">اضافة مستخدم</a>
    </p>
    <table class="table">
        <thead>
            <tr>
                <th>اسم المستخدم
                </th>
                <th>اسم البريد الالكترونى
                </th>
                <th>خيارات
                </th>
            </tr>
        </thead>
        <tbody>
            <% foreach (var user in UsersList)
                { %>
            <tr>
                <td><%= user.Name %>
                </td>
                <td><%= user.Email %>
                </td>
                <td><a href="addUser.aspx?userId=<%: user.UserId %>">تعديل المستخدم</a>
                </td>
            </tr>
            <%} %>
        </tbody>
    </table>
</asp:Content>
