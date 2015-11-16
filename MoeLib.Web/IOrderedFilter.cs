using System.Web.Http.Filters;

namespace Moe.Lib.Web
{
    /// <summary>
    ///     Interface IOrderedFilter
    /// </summary>
    public interface IOrderedFilter : IFilter
    {
        /// <summary>
        ///     Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        int Order { get; set; }
    }

    /// <summary>
    ///     Class OrderedActionFilterAttribute.
    /// </summary>
    public class OrderedActionFilterAttribute : ActionFilterAttribute, IOrderedFilter
    {
        #region IOrderedFilter Members

        /// <summary>
        ///     Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public int Order { get; set; }

        #endregion IOrderedFilter Members
    }

    /// <summary>
    ///     Class OrderedAuthorizationFilterAttribute.
    /// </summary>
    public class OrderedAuthorizationFilterAttribute : AuthorizationFilterAttribute, IOrderedFilter
    {
        #region IOrderedFilter Members

        /// <summary>
        ///     Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public int Order { get; set; }

        #endregion IOrderedFilter Members
    }

    /// <summary>
    ///     Class OrderedExceptionFilterAttribute.
    /// </summary>
    public class OrderedExceptionFilterAttribute : ExceptionFilterAttribute, IOrderedFilter
    {
        #region IOrderedFilter Members

        /// <summary>
        ///     Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public int Order { get; set; }

        #endregion IOrderedFilter Members
    }
}