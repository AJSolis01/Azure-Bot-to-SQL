using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bot.Models1;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Linq;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class EchoBot : ActivityHandler
    {
        cloudcomputedbContext context;
        public cloudcomputedbContext Context { get { return context; } }
        public EchoBot()
        {
            context = new cloudcomputedbContext();
        }

        public Tracking FetchTrackingNumber(string no)
        {
            Tracking tracking;
            try
            {
                tracking = (from e in Context.Tracking
                            where e.TrackingId == no
                            select e).FirstOrDefault();//Query for employee details with id
            }
            catch (Exception)
            {
                throw;
            }
            return tracking;
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var TrackingNumber = turnContext.Activity.Text;
            Tracking tracking = FetchTrackingNumber(TrackingNumber);
            var replyText = "Your package is currently located in" + " " + tracking.TrackingId + " " + tracking.FirstName + " " + tracking.LastName + " " + tracking.City + " " + tracking.State;
            await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Hello and Welcome. Please enter your Tracking Number!!"; //welcome message
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }
    }
}
