using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Library.BLL.Specifications
{
    public class SpecificationEvalor<T> where T : BaseModel
    {
        public static IQueryable<T> GetQuery(IQueryable<T> input , ISpecification<T> Spec)
        {
            var query = input;

            if (Spec.Criteria is not null) 
                query = query.Where(Spec.Criteria);
            if (Spec.OrderBy is not null)
            {
                query = query.OrderBy(Spec.OrderBy);
            }
            if(Spec.isPaginationEnabled == true)
                query = query.Skip(Spec.Skip).Take(Spec.Take);  


            query = Spec.Includes.Aggregate(query, (CurrentQuery, IncludeExpression)
                => CurrentQuery.Include(IncludeExpression));



            return query;

        }
    }
}
