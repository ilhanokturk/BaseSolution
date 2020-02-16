using System;

namespace BaseSolution.DTO.Pagination
{
    public class PaginationItem
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int PageCount { get; set; }
        public int RowCount { get; set; }
        public int LastPage => FinishedIndex;
        public int FistPage => 1;
        public int NextPage { get; set; }
        public int PreviousPage => CurrentPage - 1;
        public int LastRowOnPage => Math.Min(CurrentPage * PageSize, RowCount);
        public int FirstRowOnPage => (CurrentPage - 1) * PageSize + 1;
        public int StartIndex => Math.Max(CurrentPage - 5, 1);
        public int FinishedIndex => Math.Min(CurrentPage + 5, PageCount);
    }
}
