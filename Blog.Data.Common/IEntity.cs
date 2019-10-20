namespace Blog.Data.Common
{
    /// <summary>
    ///     A custom entity contract.
    ///     All the custom entities having composite primary keys (for example: link tables) should implement it.
    /// </summary>
    public interface IEntity
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets value indicating if entity has not been saved
        /// </summary>
        bool IsNew { get; }

        #endregion
    }

    /// <summary>
    ///     Generic entity contract
    /// </summary>
    /// <typeparam name="T">
    ///     An entity unique identified type
    /// </typeparam>
    public interface IEntity<T> : IEntity
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets an entity unique identifier
        /// </summary>
        T Id { get; set; }

        #endregion
    }
}