using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class InstagramUserFollowing
    {
        public int Id { get; set; }
        public string UserPK { get; set; }

        public string UserName { get; set; }
        public string ProfilePicture { get; set; }

        public bool Fallower { get; set; }
        public bool Fallowing { get; set; }

        public override string ToString()
        {
            return UserName;
        }


    }
}
