using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpartanClash.Models.ClashDB;
using Notification;

namespace UserBehaviorTracking
{
    public class UserBehaviorTracker
    {
        clashdbContext _clashdbContext;

        public UserBehaviorTracker (clashdbContext context)
        {
            _clashdbContext = context;
        }

        public void LogCompanySearch(string companyName)
        {
            TCompanies companyRecord = null;

            if (companyName != null && companyName != "")
            {
                companyRecord = _clashdbContext.TCompanies.Find(companyName);
            }

            if (companyRecord != null)
            {
                /* ------------ [Dec 8th 2017]
                    Choosing to leave this simple for the MVP, but this will underestimate searches duing high traffic loads because it is not thread safe.
                    We can rely on Google Analytics data for a sanity check on the level of underestimation.  Diff of >5% is probably worth fixing.
                    Consider moving to a worker queue if we decide to add more user behavior tracking or need to guarantee thread safefy.*/
                companyRecord.TimesSearched++;
                //------------

                _clashdbContext.SaveChanges();
            }
            else
            {
                string webhookString = Environment.GetEnvironmentVariable("SPARTANCLASH_SLACKWEBHOOKURL");
                var webhookUrl = new Uri(webhookString);

                var slackClient = new SlackClient(webhookUrl);

                try
                {
                    slackClient.SendMessageAsync("Failed search for '" + companyName + "'").Wait();
                }
                catch(Exception e)
                {
                    //TODO: What kind of errors do we experience?
                }
            }

        }

    }
}
