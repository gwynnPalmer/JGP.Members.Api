namespace JGP.Members.Data.EntityFramework
{
    using Core;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    ///     Class MemberContext.
    ///     Implements the <see cref="DbContext" />
    ///     Implements the <see cref="IMemberContext" />
    /// </summary>
    /// <seealso cref="DbContext" />
    /// <seealso cref="IMemberContext" />
    public class MemberContext : DbContext, IMemberContext
    {
        /// <summary>
        ///     The local connection string
        /// </summary>
        private readonly string _localConnectionString =
            @"Server=.;Database=jgp-members;Trusted_Connection=True;TrustServerCertificate=True;";

        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberContext" /> class.
        /// </summary>
        /// <remarks>
        ///     See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
        ///     for more information.
        /// </remarks>
        public MemberContext()
        {
            base.Database.SetCommandTimeout(1000);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public MemberContext(DbContextOptions<MemberContext> options)
            : base(options)
        {
        }

        #region DBSETS

        /// <summary>
        ///     Gets or sets the members.
        /// </summary>
        /// <value>The members.</value>
        public DbSet<Member> Members { get; set; }

        #endregion

        /// <summary>
        ///     <para>
        ///         Override this method to configure the database (and other options) to be used for this context.
        ///         This method is called for each instance of the context that is created.
        ///         The base implementation does nothing.
        ///     </para>
        ///     <para>
        ///         In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may
        ///         not have been passed
        ///         to the constructor, you can use
        ///         <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        ///         the options have already been set, and skip some or all of the logic in
        ///         <see
        ///             cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />
        ///         .
        ///     </para>
        /// </summary>
        /// <param name="optionsBuilder">
        ///     A builder used to create or modify options for this context. Databases (and other extensions)
        ///     typically define extension methods on this object that allow you to configure the context.
        /// </param>
        /// <remarks>
        ///     See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
        ///     for more information.
        /// </remarks>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_localConnectionString);
            }
        }

        /// <summary>
        ///     Override this method to further configure the model that was discovered by convention from the entity types
        ///     exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting
        ///     model may be cached
        ///     and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">
        ///     The builder being used to construct the model for this context. Databases (and other extensions) typically
        ///     define extension methods on this object that allow you to configure aspects of the model that are specific
        ///     to a given database.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         If a model is explicitly set on the options for this context (via
        ///         <see
        ///             cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />
        ///         )
        ///         then this method will not be run.
        ///     </para>
        ///     <para>
        ///         See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more
        ///         information.
        ///     </para>
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemberMap());
        }
    }
}