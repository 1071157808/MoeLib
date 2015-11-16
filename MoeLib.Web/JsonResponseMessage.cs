using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Moe.Lib.Web
{
    /// <summary>
    ///     Class JsonResponseMessage.
    /// </summary>
    public class JsonResponseMessage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonResponseMessage" /> class.
        /// </summary>
        public JsonResponseMessage()
        {
            this.Headers = new Dictionary<string, string>();
        }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public int Code { get; set; }

        /// <summary>
        ///     Gets or sets the headers.
        /// </summary>
        /// <value>The headers.</value>
        [SuppressMessage("ReSharper", "CollectionNeverQueried.Global")]
        public Dictionary<string, string> Headers { get; private set; }
    }
}