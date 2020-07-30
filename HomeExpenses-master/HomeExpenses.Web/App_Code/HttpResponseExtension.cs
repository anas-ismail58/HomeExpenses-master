using System;
using System.Web;

/// <summary>
/// Summary description for HttpResponseExtension
/// </summary>
/// 

namespace HomeExpenses
{
    public static class HttpResponseExtension
    {
        public static void RedirectPermanent(this HttpResponse httpResponse, HttpRequest httpRequest, string url)
        {
            httpResponse.Cookies.Clear();
            httpResponse.Cookies.Add(new System.Web.HttpCookie("UserId", httpRequest.Cookies["UserId"].Value));
            httpResponse.Cookies["UserId"].Expires = DateTime.Now.AddDays(3);
            httpResponse.Cookies.Add(new System.Web.HttpCookie("ClientId", httpRequest.Cookies["ClientId"].Value));
            httpResponse.Cookies["ClientId"].Expires = DateTime.Now.AddDays(3);
            httpResponse.Cookies.Add(new System.Web.HttpCookie("MonthlyBudget", httpRequest.Cookies["MonthlyBudget"].Value));
            httpResponse.Cookies["MonthlyBudget"].Expires = DateTime.Now.AddDays(3);
            httpResponse.RedirectPermanent(url, true);
        }
    }
}