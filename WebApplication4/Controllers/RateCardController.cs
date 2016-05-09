using AzureBillingAPI.Data;
using AzureBillingAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureBillingAPI.Web.Controllers
{
    public class RateCardController : Controller
    {
        public JsonResult GetUsageData(string subscriptionId= "ea2939ff-05e6-4818-9a45-6cb7a2902695",string organizationId = "600d2dee-f5ea-4019-b95b-4dfb587455e0",string startDate="",string endDate="")
        {
            // get subscription detail from the table storage
            // make call to Rate card API
            // return the response
            var jsonString = AzureResourceManagerUtil.GetUsage(subscriptionId, organizationId, startDate, endDate);
            return Json(jsonString, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetBillingData(string subscriptionId= "ea2939ff-05e6-4818-9a45-6cb7a2902695", string organizationId= "600d2dee-f5ea-4019-b95b-4dfb587455e0", string offerId= "MS-AZR-0063P", string currency="USD", string language="en-US", string regionInfo="IN")
        {
            // get subscription detail from the table storage
            // make call to Rate card API
            // return the response
            var jsonString = AzureResourceManagerUtil.GetBilling(subscriptionId, organizationId, offerId, currency, language, regionInfo);
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
    }
}