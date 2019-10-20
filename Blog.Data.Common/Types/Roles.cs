using System.Runtime.Serialization;

namespace Blog.Data.Common.Types
{
    [DataContract]
    public enum Roles
    {
        [EnumMember] Admin = 1,
        [EnumMember] Contributor = 2,
        [EnumMember] User = 3
    }
}