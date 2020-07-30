<%@ Page Title="اضافة صنف" Language="C#" MasterPageFile="~/MainMasterPage.master" Async="true" AutoEventWireup="true" CodeFile="AddItem.aspx.cs" Inherits="HomeExpenses.Web.AddItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>اضافة صنف</h1>
    <hr />
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label">اسم الصنف</label>
                <input id="txtName" runat="server" class="form-control" />
            </div>
            <div class="form-group">
                <label class="control-label">سعر الصنف</label>
                <input id="txtPrice" runat="server" class="form-control" />
            </div>
            <div class="form-group">
                <label class="control-label">نوع الصنف</label>
                <select id="slcItemType" runat="server" class="form-control">
                    <option value="1">شهرية</option>
                    <option value="2">سنوية</option>
                    <option value="3">يتكرر يعد شهور</option>
                </select>
            </div>
            <div class="form-group">
                <label class="control-label">صنف افتراضى</label>
                <input id="chkDefaultIncluded" runat="server" type="checkbox" class="form-control" />
            </div>
            <div class="form-group">
                <label class="control-label">مدة الشهور</label>
                <input id="txtMonthsPeriod" runat="server" class="form-control" />
            </div>
            <div class="form-group">
                <asp:Button id="btnSave" runat="server" Text="حفظ" OnClick="BtnSave_Click" />
                <a href="AllItems.aspx">العودة</a>
            </div>            
        </div>
    </div>
</asp:Content>
