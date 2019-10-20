using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Blog.Data.Common;

namespace Blog.Data
{
    /// <summary>
    ///     Generic entity basic implementation
    /// </summary>
    /// <typeparam name="T">
    ///     An entity unique identified type
    /// </typeparam>
    [Serializable]
    [DataContract(IsReference = true)]
    public abstract class EntityBase<T> : IEntity<T>
    {
        #region IEntity<T> Members

        /// <summary>
        ///     Gets or sets an entity unique identifier
        /// </summary>
        [DataMember]
        public T Id { get; set; }

        [IgnoreDataMember] [NotMapped] public bool IsNew => Equals(Id, default(T));

        #endregion
    }
}