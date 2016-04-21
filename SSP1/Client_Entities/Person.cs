using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Client_Entities
{
    [DataContract]
    public class Person
    {
        private string name;
        [DataMember]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private Guid id;
        [DataMember]
        public Guid Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private PermissionType permission;
        [DataMember]
        public PermissionType Permission
        {
            get
            {
                return permission;
            }
            set
            {
                permission = value;
            }
        }
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
