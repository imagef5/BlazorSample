using Blazor.Corona.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor.Corona.Domain.Entity
{
    [Table("Coronavirus_info")]
    public class CoronaStatusInfo : DomainObject
    {
        /// <summary>
        /// 확진자의 접촉자 자가격리
        /// </summary>
        [Column("contacted_self_isolation")]
        public int ContactedSelfIsolation { get; set; }
        /// <summary>
        /// 확진자의 접촉자 관리해제
        /// </summary>
        [Column("clear_contacted_self_isolation")]
        public int ClearContactedSelfIsonation { get; set; }

        /// <summary>
        /// 의사 환자 검사중
        /// </summary>
        [Column("isolation_cnt")]
        public int SuspectedCase { get; set; }
        /// <summary>
        /// 의사환자 결과 음성
        /// </summary>
        [Column("clear_isolation_cnt")]
        public int NegativeResult { get; set; }
        /// <summary>
        /// 자가 격리
        /// </summary>
        [Column("self_isolation")]
        public int SelfIsolation { get; set; }
        /// <summary>
        /// 자가격리 해제
        /// </summary>
        [Column("clear_self_isolation")]
        public int ClearSelfIsolation { get; set; }
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
