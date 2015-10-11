using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;

namespace Moe.Lib.Data
{
    /// <summary>
    ///     Class DbContextBase.
    /// </summary>
    public abstract class DbContextBase : DbContext
    {
        /// <summary>
        ///     The retry policy
        /// </summary>
        private readonly RetryPolicy retryPolicy;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DbContextBase" /> class.
        /// </summary>
        /// <param name="nameOrConnectionString">The name or connection string.</param>
        protected DbContextBase(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            this.retryPolicy = new RetryPolicy(new SqlDatabaseTransientErrorDetectionStrategy(), RetryStrategy.DefaultExponential);
        }

        /// <summary>
        ///     Adds the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Add<T>(T entity) where T : class
        {
            DbEntityEntry<T> entry = this.Entry(entity);

            if (entry.State == EntityState.Detached)
                this.Set<T>().Add(entity);

            this.ExecuteSaveChangesAsync();
        }

        /// <summary>
        ///     Adds the range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">The entities.</param>
        public void AddRange<T>(IEnumerable<T> entities) where T : class
        {
            foreach (T entity in from entity in entities let entry = this.Entry(entity) where entry.State == EntityState.Detached select entity)
            {
                this.Set<T>().Add(entity);
            }

            this.ExecuteSaveChangesAsync();
        }

        /// <summary>
        ///     Executes the save changes.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int ExecuteSaveChanges()
        {
            return this.ExecuteAction(this.SaveChanges);
        }

        /// <summary>
        ///     Executes the save changes asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public Task<int> ExecuteSaveChangesAsync(CancellationToken cancellationToken)
        {
            return this.ExecuteAsync(() => this.SaveChangesAsync(cancellationToken), cancellationToken);
        }

        /// <summary>
        ///     Executes the save changes asynchronous.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public Task<int> ExecuteSaveChangesAsync()
        {
            return this.ExecuteAsync(this.SaveChangesAsync);
        }

        /// <summary>
        ///     Queries this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> Query<T>() where T : class
        {
            return this.Set<T>();
        }

        /// <summary>
        ///     Readonlies the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> ReadonlyQuery<T>() where T : class
        {
            return this.Set<T>().AsNoTracking();
        }

        /// <summary>
        ///     Removes the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Remove<T>(T entity) where T : class
        {
            this.Entry(entity).State = EntityState.Deleted;

            this.retryPolicy.ExecuteAction(() => this.SaveChanges());
        }

        /// <summary>
        ///     Removes the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public Task<int> RemoveAsync<T>(T entity) where T : class
        {
            this.Entry(entity).State = EntityState.Deleted;

            return this.retryPolicy.ExecuteAsync(this.SaveChangesAsync);
        }

        /// <summary>
        ///     Saves the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Int32.</returns>
        public int Save<T>(T entity) where T : class
        {
            DbEntityEntry<T> entry = this.Entry(entity);

            if (entry.State == EntityState.Detached)
                this.Set<T>().Add(entity);

            return this.ExecuteSaveChanges();
        }

        /// <summary>
        ///     Saves the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public Task<int> SaveAsync<T>(T entity) where T : class
        {
            DbEntityEntry<T> entry = this.Entry(entity);

            if (entry.State == EntityState.Detached)
                this.Set<T>().Add(entity);

            return this.ExecuteSaveChangesAsync();
        }

        /// <summary>
        ///     Saves the or update.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="identifierExpression">The identifier expression.</param>
        /// <returns>System.Int32.</returns>
        public int SaveOrUpdate<T>(T entity, Expression<Func<T, bool>> identifierExpression) where T : class
        {
            DbEntityEntry<T> entry = this.Entry(entity);

            if (entry.State == EntityState.Detached)
                this.Set<T>().Add(entity);

            if (this.Set<T>().Any(identifierExpression))
            {
                entry.State = EntityState.Modified;
            }

            return this.ExecuteSaveChanges();
        }

        /// <summary>
        ///     Saves the or update asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="identifierExpression">The identifier expression.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public Task<int> SaveOrUpdateAsync<T>(T entity, Expression<Func<T, bool>> identifierExpression) where T : class
        {
            DbEntityEntry<T> entry = this.Entry(entity);

            if (entry.State == EntityState.Detached)
                this.Set<T>().Add(entity);

            if (this.Set<T>().Any(identifierExpression))
            {
                entry.State = EntityState.Modified;
            }

            return this.ExecuteSaveChangesAsync();
        }

        /// <summary>
        ///     Executes the action.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="func">The function.</param>
        /// <returns>TResult.</returns>
        private TResult ExecuteAction<TResult>(Func<TResult> func)
        {
            return this.retryPolicy.ExecuteAction(func);
        }

        /// <summary>
        ///     Executes the asynchronous.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="taskFunc">The task function.</param>
        /// <returns>Task&lt;TResult&gt;.</returns>
        private Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> taskFunc)
        {
            return this.retryPolicy.ExecuteAsync(taskFunc);
        }

        /// <summary>
        ///     Executes the asynchronous.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="taskFunc">The task function.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;TResult&gt;.</returns>
        private Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> taskFunc, CancellationToken cancellationToken)
        {
            return this.retryPolicy.ExecuteAsync(taskFunc, cancellationToken);
        }
    }
}