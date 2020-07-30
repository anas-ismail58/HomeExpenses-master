<%@ Page Title="اضافة مدفوع" Language="C#" MasterPageFile="~/MainMasterPage.master" Async="true" AutoEventWireup="true" CodeFile="AddExpense.aspx.cs" Inherits="HomeExpenses.Web.AddExpense" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>اضافة مدفوع</h1>
    <hr />
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label">الصنف</label>
                <select id="slcItemId" name="slcItemId" runat="server" class="form-control" onchange="changeItem()">
                </select>
            </div>
            <div class="form-group">
                <label class="control-label">اسم المدفوع</label>
                <input id="txtName" name="txtName" runat="server" class="form-control" />
            </div>
            <div class="form-group">
                <label class="control-label">سعر المدفوع</label>
                <input id="txtPrice" name="txtPrice" runat="server" class="form-control" />
            </div>
            <div class="form-group">
                <label class="control-label">شهر المدفوع</label>
                <select id="slcRelatedMonth" name="slcRelatedMonth" runat="server" class="form-control">
                    <option value="1-7-2020">7 / 2020</option>
                    <option value="1-8-2020">8 / 2020</option>
                    <option value="1-9-2020">9 / 2020</option>
                    <option value="1-10-2020">10 / 2020</option>
                    <option value="1-11-2020">11 / 2020</option>
                    <option value="1-12-2020">12 / 2020</option>
                    <option value="1-1-2021">1 / 2021</option>
                    <option value="1-2-2021">2 / 2021</option>
                    <option value="1-3-2021">3 / 2021</option>
                    <option value="1-4-2021">4 / 2021</option>
                    <option value="1-5-2021">5 / 2021</option>
                    <option value="1-6-2021">6 / 2021</option>
                    <option value="1-7-2021">7 / 2021</option>
                    <option value="1-8-2021">8 / 2021</option>
                    <option value="1-9-2021">9 / 2021</option>
                    <option value="1-10-2021">10 / 2021</option>
                    <option value="1-11-2021">11 / 2021</option>
                    <option value="1-12-2021">12 / 2021</option>
                </select>
            </div>
            <div class="form-group">
                <label class="control-label">التفاصيل</label>
                <textarea id="txtDescription" name="txtDescription" runat="server" class="form-control" />
            </div>
            <div class="form-group">
                <label class="control-label">تم السداد</label>
                <input id="chkPayed" runat="server" type="checkbox" class="form-control" />
            </div>
            <div class="form-group">
                <asp:Button id="btnSave" runat="server" Text="حفظ" OnClick="BtnSave_Click" />
                <a href="AllExpenses.aspx">العودة</a>
            </div>
        </div>
    </div>
    <script>
        function changeItem() {
            var e = document.getElementById('<%: slcItemId.ClientID %>');
            document.getElementById('<%: txtName.ClientID %>').value = e.selectedOptions[0].attributes["name"].value;
            document.getElementById('<%: txtPrice.ClientID %>').value = e.selectedOptions[0].attributes["price"].value;
        }
        changeItem();
    </script>
</asp:Content>
