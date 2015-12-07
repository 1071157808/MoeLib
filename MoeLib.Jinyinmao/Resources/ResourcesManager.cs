using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Moe.Lib;

namespace MoeLib.Jinyinmao.Resources
{
    /// <summary>
    ///     ResourcesManager.
    /// </summary>
    public class ResourcesManager
    {
        private readonly object _lock = new object();
        private readonly IResourcesProvider resourcesProvider;
        private bool isResourcesRefreshing;

        internal ResourcesManager(IResourcesProvider resourcesProvider)
        {
            this.resourcesProvider = resourcesProvider;
            this.RefreshInterval = 20.Minutes();
        }

        internal ResourcesManager(IResourcesProvider resourcesProvider, TimeSpan refreshInterval)
        {
            this.resourcesProvider = resourcesProvider;
            this.RefreshInterval = refreshInterval;
        }

        /// <summary>
        ///     Gets or sets the refresh interval.
        /// </summary>
        /// <value>The refresh interval.</value>
        public TimeSpan RefreshInterval { get; }

        /// <summary>
        ///     Gets or sets the resources refresh time.
        /// </summary>
        /// <value>The resources refresh time.</value>
        [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
        public DateTime ResourcesRefreshTime { get; protected set; }

        private IDictionary<string, string> Resources { get; set; }

        /// <summary>
        ///     Gets the resources.
        /// </summary>
        /// <returns>IDictionary&lt;System.String, System.String&gt;.</returns>
        public IDictionary<string, string> GetResources()
        {
            if (this.Resources == null)
            {
                this.RefreshResources();
            }

            if (this.IsResourcesNeedRefresh())
            {
                Task.Run(() => this.RefreshResources());
            }

            return this.Resources;
        }

        /// <summary>
        ///     Gets the resource string.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns>System.String.</returns>
        public string GetResourceString(string resourceName)
        {
            return this.Resources.GetOrDefault(resourceName);
        }

        /// <summary>
        ///     Determines whether [is resources need refresh].
        /// </summary>
        /// <returns><c>true</c> if [is resources need refresh]; otherwise, <c>false</c>.</returns>
        protected bool IsResourcesNeedRefresh()
        {
            return this.ResourcesRefreshTime.Add(this.RefreshInterval) < DateTime.UtcNow;
        }

        private void RefreshResources()
        {
            if (!this.isResourcesRefreshing)
            {
                try
                {
                    lock (this._lock)
                    {
                        if (!this.isResourcesRefreshing)
                        {
                            this.isResourcesRefreshing = true;
                            this.Resources = this.resourcesProvider.GetResources();
                            this.ResourcesRefreshTime = DateTime.UtcNow;
                        }
                    }
                }
                finally
                {
                    this.isResourcesRefreshing = false;
                }
            }
        }
    }
}