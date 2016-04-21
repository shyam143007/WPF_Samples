using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Entities
{
    [DataContract]
    public class Permissions
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public PermissionType Permission { get; set; }
    }
    public enum PermissionType
    {
        [EnumMember]
        Anonymous = 0,

        [EnumMember]
        User = 1,

        [EnumMember]
        Admin = 2
    }
}
