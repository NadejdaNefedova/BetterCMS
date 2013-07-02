﻿using System.Runtime.Serialization;

using ServiceStack.ServiceHost;

namespace BetterCms.Module.Api.Operations.Pages.Redirects.Redirect
{
    [Route("/redirects/{RedirectId}", Verbs = "GET")]
    public class GetRedirectRequest : RequestBase, IReturn<GetRedirectResponse>
    {
        /// <summary>
        /// Gets or sets the redirect id.
        /// </summary>
        /// <value>
        /// The redirect id.
        /// </value>
        [DataMember(Order = 10, Name = "redirectId")]
        public System.Guid RedirectId { get; set; }
    }
}