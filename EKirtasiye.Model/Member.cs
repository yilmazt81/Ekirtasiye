﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class Member
    {
        public int MemberId { get; set; }
        public Guid MemberGUID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }

        public string MailAdress { get; set; }

    }
}
