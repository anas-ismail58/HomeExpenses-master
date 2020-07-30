<%@ Import Namespace="HomeExpenses.Data" %>

<%@ Page Title="جميع المدفوعات" Language="C#" MasterPageFile="~/MainMasterPage.master" Async="true" AutoEventWireup="true" CodeFile="AllExpenses.aspx.cs" Inherits="HomeExpenses.Web.AllExpenses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
      .background-section {
    background: url('https://image.freepik.com/free-vector/money-saving-concept_52683-8041.jpg');
    background-size:cover;
    background-attachment:fixed;
    background-repeat:no-repeat;
    margin-bottom:50px;
}
        .img-liner {
            background:rgba(0,0,0,.8);
            padding:100px 0 100px 0;

        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div class="background-section">
            <div class="img-liner">
    <h1 class="text-center" style="color:white; font-weight:800">المدفوعات</h1>
        </div>
            </div>
    <p>
        <a href="addExpense.aspx" class="btn btn-primary">اضافة مدفوع</a>
        <a href="ChangeCurrentMonth.aspx" class="btn btn-warning">تغيير الشهر الحالى</a>
    </p>
    

    <table class="table table-bordered text-center ">
        <thead >
            <tr class="bg-info" style="color:#fff">
                <th>اجمالى قيمة المدفوعات
                </th>
                <th>المبلغ المتبقى
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td style="color:forestgreen;font-weight:700;font-size:20px">
                    <label id="lblTotalPayed" runat="server"></label>
                    SAR
                </td>
                <td style="color:red;font-weight:700;font-size:20px">
                    <label id="lblRest" runat="server"></label>
                    SAR
                </td>
            </tr>
        </tbody>
    </table>
    <% foreach (var itemExpense in ItemExpensesList)
        { %>

    <div class="table-responsive-md table-sm">
    <table class="table table-bordered table-responsive-stack" style="border: 1px solid #ddd; margin-bottom: 10px;">
        <thead >
            <tr class="thead-dark">
                <th>اسم الصنف
                </th>
                <th>السعر الاقصى للصنف
                </th>
                <th >اجمالى قيمة المدفوع من الصنف
                </th>
                <th>المتبقى من رصيد الصنف
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><%= itemExpense.ItemName %>
                </td>
                <td style="color:blue; font-weight:700""><%= itemExpense.ItemPrice %> SAR
                </td>
                <td style="color:forestgreen; font-weight:700"><%= itemExpense.ExpensesPrices %> SAR
                </td>
                <td style="color:red; font-weight:700"><%= itemExpense.ItemPrice - itemExpense.ExpensesPrices %> SAR
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <div class="table-responsive-md">

                    <table class="table table-bordered table-striped table-responsive-stack" style="margin-bottom: 5px;">
                        <thead>
                            <tr >
                                <th >اسم المدفوع
                                </th>
                                <th>سعر المدفوع
                                </th>
                                <th>الشهر
                                </th>
                                <th>تاريخ التسجيل
                                </th>
                                <th>تاريخ اخر تعديل
                                </th>
                                <th>التفاصيل
                                </th>
                                <th>تم السداد
                                </th>
                                <th>خيارات
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <% foreach (var expense in itemExpense.ItemExpensesList)
                                { %>
                            <tr>
                                <td><%= expense.Name %>
                                </td>
                                <td style="color:forestgreen; font-weight:700"><%= expense.Price %> SAR
                                </td>
                                <td><%= expense.RelateToMonth.ToString("M/yyyy") %>
                                </td>
                                <td><%= expense.CreatedAt.ToString("d/M/yyyy") %>
                                </td>
                                <td><%= expense.UpdatedAt.ToString("d/M/yyyy") %>
                                </td>
                                <td><%= expense.Description %>
                                </td>
                                <td><%= expense.Payed == true ? "نعم" : "لا" %>
                                </td>
                                <td><a class="btn btn-primary"  href="addExpense.aspx?expenseId=<%: expense.ExpenseId %>">تعديل المدفوع</a>
                                </td>
                            </tr>
                            <%} %>
                        </tbody>
                    </table>
                        </div>
                </td>
            </tr>
        </tbody>
    </table>
        </div>


    <%} %>
</asp:Content>
