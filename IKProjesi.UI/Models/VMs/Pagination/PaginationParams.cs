namespace IKProjesi.UI.Models.VMs.Pagination
{
    public class PaginationParams
    {
        public int TotalItems { get; private set; }//toplam kaç tane manager var
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }

        public PaginationParams()
        {
            
        }

        public PaginationParams(int totalItems, int page, int pageSize=12)
        {
            int totalPages= (int)Math.Ceiling((decimal)totalItems/(decimal)pageSize);
            int currentPage = page;
            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if (endPage >totalPages)
            {
                endPage = totalPages;
                if (endPage>20)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems=totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage; 
            EndPage = endPage;
        }
    }
}
