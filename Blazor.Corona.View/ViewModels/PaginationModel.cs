using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Corona.View.ViewModels
{
    public class PaginationModel
    {
        /// <summary>
        /// 현재 페이지 넘버
        /// </summary>
        public int CurrentPage { get; set; } = 1;
        /// <summary>
        /// 페이지당 리스트수
        /// </summary>
        public int RowsPerPage { get; set; } = 5;
        /// <summary>
        /// 전체 개수
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 페이지 사이즈
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// 전체 페이지 수
        /// </summary>
        public int TotalPage
        {
            get
            {
                if (RowsPerPage > 0)
                    return (int)Math.Ceiling(TotalCount * 1.0d / RowsPerPage);
                return 0;
            }
        }
        /// <summary>
        /// 시작 페이지
        /// </summary>
        public int StartPage
        {
            get
            {
                int prev = (CurrentPage - 1) / PageSize;
                return prev * PageSize + 1;
            }
        }
        /// <summary>
        /// 이전 블퍽 페이지
        /// </summary>
        public int PrevPage
        {
            get
            {
                return StartPage - PageSize; ;
            }
        }
        /// <summary>
        /// 다음 블럭 페이지
        /// </summary>
        public int NextPage
        {
            get
            {
                return StartPage + PageSize;
            }
        }
    }
}
