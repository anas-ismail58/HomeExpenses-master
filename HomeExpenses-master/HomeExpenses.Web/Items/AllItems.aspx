<%@ Import Namespace="HomeExpenses.Data" %>

<%@ Page Title="جميع الاصناف" Language="C#" MasterPageFile="~/MainMasterPage.master" Async="true" AutoEventWireup="true" CodeFile="AllItems.aspx.cs" Inherits="HomeExpenses.Web.AllItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>الاصناف</h1>
    <p>
        <a href="addItem.aspx">اضافة صنف</a>
    </p>
    <table class="table">
        <thead>
            <tr>
                <th>اسم الصنف
                </th>
                <th>نوع الصنف
                </th>
                <th>سعر الصنف
                </th>
                <th>صنف افتراضى
                </th>
                <th>مدة الشهور
                </th>
                <th>خيارات
                </th>
            </tr>
        </thead>
        <tbody>
            <% foreach (var item in ItemsList)
                { %>
            <tr>
                <td><%= item.Name %>
                </td>
                <td><%= item.ItemTypeId %>
                </td>
                <td><%= item.Price %>
                </td>
                <td><%= item.DefaultIncluded ? "نعم" : "لا" %>
                </td>
                <td><%= item.MonthsPeriod %>
                </td>
                <td><a href="addItem.aspx?itemId=<%: item.ItemId %>">تعديل الصنف</a>
                </td>
            </tr>
            <%} %>
        </tbody>
    </table>
</asp:Content>
