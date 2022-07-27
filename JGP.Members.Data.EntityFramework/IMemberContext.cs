namespace JGP.Members.Data.EntityFramework
{
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    /// <summary>
    ///     Interface IMemberContext
    ///     Implements the <see cref="IDisposable" />
    /// </summary>
    /// <seealso cref="IDisposable" />
    public interface IMemberContext : IDisposable
    {
        /// <summary>
        ///     Gets or sets the members.
        /// </summary>
        /// <value>The members.</value>
        DbSet<Member> Members { get; set; }

        /// <summary>
        ///     Entries the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>EntityEntry&lt;TEntity&gt;.</returns>
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        ///     Entries the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>EntityEntry.</returns>
        EntityEntry Entry(object entity);

        /// <summary>
        ///     Saves the changes.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int SaveChanges();

        /// <summary>
        ///     Saves the changes.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">if set to <c>true</c> [accept all changes on success].</param>
        /// <returns>System.Int32.</returns>
        int SaveChanges(bool acceptAllChangesOnSuccess);

        /// <summary>
        ///     Saves the changes asynchronous.
        /// </summary>
        /// <param name="cancellationToken">
        ///     The cancellation token that can be used by other objects or threads to receive notice
        ///     of cancellation.
        /// </param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Saves the changes asynchronous.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">if set to <c>true</c> [accept all changes on success].</param>
        /// <param name="cancellationToken">
        ///     The cancellation token that can be used by other objects or threads to receive notice
        ///     of cancellation.
        /// </param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}