// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Subscriptions;
using Microsoft.WindowsAzure.Subscriptions.Models;

namespace Microsoft.WindowsAzure.Subscriptions
{
    internal partial class SubscriptionOperations : IServiceOperations<SubscriptionClient>, Microsoft.WindowsAzure.Subscriptions.ISubscriptionOperations
    {
        /// <summary>
        /// Initializes a new instance of the SubscriptionOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal SubscriptionOperations(SubscriptionClient client)
        {
            this._client = client;
        }
        
        private SubscriptionClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.WindowsAzure.Subscriptions.SubscriptionClient.
        /// </summary>
        public SubscriptionClient Client
        {
            get { return this._client; }
        }
        
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Subscriptions.Models.SubscriptionListOperationResponse> ListAsync(CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                Tracing.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            string url = "/subscriptions";
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-08-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    SubscriptionListOperationResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new SubscriptionListOperationResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement subscriptionsElement = responseDoc.Element(XName.Get("Subscriptions", "http://schemas.microsoft.com/windowsazure"));
                    if (subscriptionsElement != null)
                    {
                        if (subscriptionsElement != null)
                        {
                            foreach (XElement subscriptionsElement2 in subscriptionsElement.Elements(XName.Get("Subscription", "http://schemas.microsoft.com/windowsazure")))
                            {
                                SubscriptionListOperationResponse.Subscription subscriptionInstance = new SubscriptionListOperationResponse.Subscription();
                                result.Subscriptions.Add(subscriptionInstance);
                                
                                XElement subscriptionIDElement = subscriptionsElement2.Element(XName.Get("SubscriptionID", "http://schemas.microsoft.com/windowsazure"));
                                if (subscriptionIDElement != null)
                                {
                                    string subscriptionIDInstance = subscriptionIDElement.Value;
                                    subscriptionInstance.SubscriptionId = subscriptionIDInstance;
                                }
                                
                                XElement subscriptionNameElement = subscriptionsElement2.Element(XName.Get("SubscriptionName", "http://schemas.microsoft.com/windowsazure"));
                                if (subscriptionNameElement != null)
                                {
                                    string subscriptionNameInstance = subscriptionNameElement.Value;
                                    subscriptionInstance.SubscriptionName = subscriptionNameInstance;
                                }
                                
                                XElement subscriptionStatusElement = subscriptionsElement2.Element(XName.Get("SubscriptionStatus", "http://schemas.microsoft.com/windowsazure"));
                                if (subscriptionStatusElement != null)
                                {
                                    SubscriptionStatus subscriptionStatusInstance = ((SubscriptionStatus)Enum.Parse(typeof(SubscriptionStatus), subscriptionStatusElement.Value, true));
                                    subscriptionInstance.SubscriptionStatus = subscriptionStatusInstance;
                                }
                                
                                XElement accountAdminLiveEmailIdElement = subscriptionsElement2.Element(XName.Get("AccountAdminLiveEmailId", "http://schemas.microsoft.com/windowsazure"));
                                if (accountAdminLiveEmailIdElement != null)
                                {
                                    string accountAdminLiveEmailIdInstance = accountAdminLiveEmailIdElement.Value;
                                    subscriptionInstance.AccountAdminLiveEmailId = accountAdminLiveEmailIdInstance;
                                }
                                
                                XElement serviceAdminLiveEmailIdElement = subscriptionsElement2.Element(XName.Get("ServiceAdminLiveEmailId", "http://schemas.microsoft.com/windowsazure"));
                                if (serviceAdminLiveEmailIdElement != null)
                                {
                                    string serviceAdminLiveEmailIdInstance = serviceAdminLiveEmailIdElement.Value;
                                    subscriptionInstance.ServiceAdminLiveEmailId = serviceAdminLiveEmailIdInstance;
                                }
                                
                                XElement maxCoreCountElement = subscriptionsElement2.Element(XName.Get("MaxCoreCount", "http://schemas.microsoft.com/windowsazure"));
                                if (maxCoreCountElement != null)
                                {
                                    int maxCoreCountInstance = int.Parse(maxCoreCountElement.Value, CultureInfo.InvariantCulture);
                                    subscriptionInstance.MaximumCoreCount = maxCoreCountInstance;
                                }
                                
                                XElement maxStorageAccountsElement = subscriptionsElement2.Element(XName.Get("MaxStorageAccounts", "http://schemas.microsoft.com/windowsazure"));
                                if (maxStorageAccountsElement != null)
                                {
                                    int maxStorageAccountsInstance = int.Parse(maxStorageAccountsElement.Value, CultureInfo.InvariantCulture);
                                    subscriptionInstance.MaximumStorageAccounts = maxStorageAccountsInstance;
                                }
                                
                                XElement maxHostedServicesElement = subscriptionsElement2.Element(XName.Get("MaxHostedServices", "http://schemas.microsoft.com/windowsazure"));
                                if (maxHostedServicesElement != null)
                                {
                                    int maxHostedServicesInstance = int.Parse(maxHostedServicesElement.Value, CultureInfo.InvariantCulture);
                                    subscriptionInstance.MaximumHostedServices = maxHostedServicesInstance;
                                }
                                
                                XElement currentCoreCountElement = subscriptionsElement2.Element(XName.Get("CurrentCoreCount", "http://schemas.microsoft.com/windowsazure"));
                                if (currentCoreCountElement != null)
                                {
                                    int currentCoreCountInstance = int.Parse(currentCoreCountElement.Value, CultureInfo.InvariantCulture);
                                    subscriptionInstance.CurrentCoreCount = currentCoreCountInstance;
                                }
                                
                                XElement currentStorageAccountsElement = subscriptionsElement2.Element(XName.Get("CurrentStorageAccounts", "http://schemas.microsoft.com/windowsazure"));
                                if (currentStorageAccountsElement != null)
                                {
                                    int currentStorageAccountsInstance = int.Parse(currentStorageAccountsElement.Value, CultureInfo.InvariantCulture);
                                    subscriptionInstance.CurrentStorageAccounts = currentStorageAccountsInstance;
                                }
                                
                                XElement currentHostedServicesElement = subscriptionsElement2.Element(XName.Get("CurrentHostedServices", "http://schemas.microsoft.com/windowsazure"));
                                if (currentHostedServicesElement != null)
                                {
                                    int currentHostedServicesInstance = int.Parse(currentHostedServicesElement.Value, CultureInfo.InvariantCulture);
                                    subscriptionInstance.CurrentHostedServices = currentHostedServicesInstance;
                                }
                                
                                XElement maxVirtualNetworkSitesElement = subscriptionsElement2.Element(XName.Get("MaxVirtualNetworkSites", "http://schemas.microsoft.com/windowsazure"));
                                if (maxVirtualNetworkSitesElement != null)
                                {
                                    int maxVirtualNetworkSitesInstance = int.Parse(maxVirtualNetworkSitesElement.Value, CultureInfo.InvariantCulture);
                                    subscriptionInstance.MaximumVirtualNetworkSites = maxVirtualNetworkSitesInstance;
                                }
                                
                                XElement maxLocalNetworkSitesElement = subscriptionsElement2.Element(XName.Get("MaxLocalNetworkSites", "http://schemas.microsoft.com/windowsazure"));
                                if (maxLocalNetworkSitesElement != null)
                                {
                                    int maxLocalNetworkSitesInstance = int.Parse(maxLocalNetworkSitesElement.Value, CultureInfo.InvariantCulture);
                                    subscriptionInstance.MaximumLocalNetworkSites = maxLocalNetworkSitesInstance;
                                }
                                
                                XElement maxDnsServersElement = subscriptionsElement2.Element(XName.Get("MaxDnsServers", "http://schemas.microsoft.com/windowsazure"));
                                if (maxDnsServersElement != null)
                                {
                                    int maxDnsServersInstance = int.Parse(maxDnsServersElement.Value, CultureInfo.InvariantCulture);
                                    subscriptionInstance.MaximumDnsServers = maxDnsServersInstance;
                                }
                                
                                XElement maxExtraVIPCountElement = subscriptionsElement2.Element(XName.Get("MaxExtraVIPCount", "http://schemas.microsoft.com/windowsazure"));
                                if (maxExtraVIPCountElement != null)
                                {
                                    int maxExtraVIPCountInstance = int.Parse(maxExtraVIPCountElement.Value, CultureInfo.InvariantCulture);
                                    subscriptionInstance.MaximumExtraVirtualIPCount = maxExtraVIPCountInstance;
                                }
                                
                                XElement aADTenantIDElement = subscriptionsElement2.Element(XName.Get("AADTenantID", "http://schemas.microsoft.com/windowsazure"));
                                if (aADTenantIDElement != null)
                                {
                                    string aADTenantIDInstance = aADTenantIDElement.Value;
                                    subscriptionInstance.ActiveDirectoryTenantId = aADTenantIDInstance;
                                }
                                
                                XElement createdTimeElement = subscriptionsElement2.Element(XName.Get("CreatedTime", "http://schemas.microsoft.com/windowsazure"));
                                if (createdTimeElement != null)
                                {
                                    DateTime createdTimeInstance = DateTime.Parse(createdTimeElement.Value, CultureInfo.InvariantCulture);
                                    subscriptionInstance.Created = createdTimeInstance;
                                }
                            }
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
