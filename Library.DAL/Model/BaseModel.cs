﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Model
{
    public class BaseModel
    {
      public  int Id { get; set; }
       public bool IsDeleted { get; set; }  = false;
    }
}