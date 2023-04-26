﻿using Application_Core.Commons.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Core.Models
{
    public class Comment:IIdentity<int>
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public Post Post { get; set; }

        public string Text { get; set; }    
    }
}
