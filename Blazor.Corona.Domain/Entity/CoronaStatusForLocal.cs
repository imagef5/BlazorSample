using Blazor.Corona.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor.Corona.Domain.Entity
{
    [Table("Coronavirus_local")]
    public class CoronaStatusForLocal : DomainObject
    {
        /// <summary>
        /// 전국 확진자
        /// </summary>
        [Column("whole_confirmed_cnt")]
        public int WholeConfirmedCount { get; set; }
        /// <summary>
        /// 전국 사망자 수
        /// </summary>
        [Column("death_cnt")]
        public int DeadCount { get; set; }
        /// <summary>
        /// 검사중
        /// </summary>
        [Column("checkup_cnt")]
        public int CheckupCount { get; set; }
        /// <summary>
        /// 결과 음성
        /// </summary>
        [Column("negative_cnt")]
        public int NegativeCount { get; set; }
        /// <summary>
        /// 지역 확진자
        /// </summary>
        [Column("local_confirmed_cnt")]
        public int ConfirmedCount { get; set; }
        /// <summary>
        /// 지역 확진자 증가수
        /// </summary>
        [Column("confirmd_increase_cnt")]
        public int IncreaseConfirmedCount { get; set; }
        /// <summary>
        /// 지역 접촉자 수
        /// </summary>
        [Column("local_contacted_cnt")]
        public int ContactedCount { get; set; }
        /// <summary>
        /// 지역 접촉자 증가수
        /// </summary>
        [Column("contacted_increase_cnt")]
        public int IncreaseContactedCount { get; set; }
        /// <summary>
        /// 지역 유증상자
        /// </summary>
        [Column("local_similar_cnt")]
        public int SuspectedCount { get; set; }
        /// <summary>
        /// 지역 유증상자 증가수
        /// </summary>
        [Column("similar_increase_cnt")]
        public int IncreaseSuspectedCount { get; set; }
        /// <summary>
        /// 지역 자가격리 수
        /// </summary>
        [Column("local_self_isolation_cnt")]
        public int SelfIsolationCount { get; set; }
        /// <summary>
        /// 지역 자가격리 증가수
        /// </summary>
        [Column("self_isolation_increase_cnt")]
        public int IncreaseSelfIsolationCount { get; set; }
        /// <summary>
        /// 지역 우한 방문자 수
        /// </summary>
        [Column("from_wuhan_cnt")]
        public int VisitWuhanCount { get; set; }
        /// <summary>
        /// 지역 우한 방문자 증가수
        /// </summary>
        [Column("wuhan_increase_cnt")]
        public int IncreaseVisitWuhanCount { get; set; }
        /// <summary>
        /// 생성일
        /// </summary>
        [Column("created")]
        public DateTime Created { get; set; }
        /// <summary>
        /// 수정일
        /// </summary>
        [Column("modified")]
        public DateTime Modified { get; set; }
        /// <summary>
        /// 정보 제공 기준일
        /// </summary>
        [Column("offered")]
        public DateTime Offered { get; set; }
    }
}
