
using BiBuddy.DataAccess.Core.DataAccess;
using BiBuddy.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bibuddy.DataAccess.Abstract
{
    public interface IArticleDal:IRepository<article>
    {
    }
}
