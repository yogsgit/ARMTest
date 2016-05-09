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
    public class SubscriptionController : Controller
    {
        public JsonResult Test()
        {
            var orgs = AzureResourceManagerUtil.GetUserOrganizations();
            Dictionary<Organization, List<Subscription>> dictionary = new Dictionary<Organization, List<Subscription>>();
            foreach (var item in orgs)
            {
                if (!dictionary.ContainsKey(item))
                {
                    var subscriptions = AzureResourceManagerUtil.GetUserSubscriptions(item.Id);
                    dictionary.Add(item, subscriptions);
                }
            }

            foreach (var subscriptions in dictionary.Values)
            {
                foreach (var subscription in subscriptions)
                {
                    UserSubscription userSubscription = new UserSubscription { RowKey = subscription.Id, PartitionKey = subscription.OrganizationId };
                    userSubscription.ConnectedBy = subscription.ConnectedBy;
                    subscription.ConnectedOn = DateTime.Now;

                    var repo = new EntityRepo<UserSubscription>();
                    repo.Insert(new List<UserSubscription> { userSubscription });
                }
            }
            return Json(dictionary.ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}