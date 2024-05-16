using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Library.DAL.Model;

namespace Library.BLL.Specifications
{
    public class BaseSpcifications<T> : ISpecification<T> where T : BaseModel
    {
        public Expression<Func<T, bool>> Criteria { get ; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public int Skip { get; set ; }
        public int Take { get ; set ; }

        public bool isPaginationEnabled { get; set; }


        public BaseSpcifications()
        {
            
        }

        public BaseSpcifications(Expression<Func<T, bool>> criteriaExpression)
        {
            Criteria = criteriaExpression;
             
        }
        public void orderBy(Expression<Func<T, object>> OrderByExpression)
        {
            OrderBy = OrderByExpression;
        }

        public void ApplyPagination (int skip , int take)
        {
            isPaginationEnabled = true;
            Skip=skip;
            Take=take;
        }
    }
}
