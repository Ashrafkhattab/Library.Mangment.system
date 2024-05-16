using Library.DAL.Model;

namespace Library.System.Helpers
{
    public class Pagination <T>
    {
        

        public Pagination(int pageIndex, int pagesize, IReadOnlyList<T> data , int count)
        {
            PageIndex = pageIndex;
            PageSize = pagesize;
            Data= data;
            Count = count;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<T> Data { get; set; }

    }
}
