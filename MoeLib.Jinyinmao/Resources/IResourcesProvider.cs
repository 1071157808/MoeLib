using System.Collections.Generic;

namespace MoeLib.Jinyinmao.Resources
{
    /// <summary>
    ///     Interface IResourcesProvider
    /// </summary>
    public interface IResourcesProvider
    {
        /// <summary>
        ///     Gets the resources.
        /// </summary>
        /// <returns>IDictionary&lt;System.String, System.String&gt;.</returns>
        IDictionary<string, string> GetResources();
    }
}