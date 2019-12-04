using System;
using System.ComponentModel.DataAnnotations;

namespace RestAPIServer.Models.Common
{
    // 시스템 정보 
    public class SystemInfo
    {
        // 시스템 아이디
        [Key]
        public string SystemCode { get; set; }

        // 시스템명 
        public string SystemName { get; set; }

        // 회사명 
        public string CorpName { get; set; }

        // 비고 
        public string Comment { get; set; }

        // 사용유무 
        public string UseYn { get; set; }

        // 수정일자 
        public DateTime UpDate { get; set; }

        // 수정자 
        public string UpUser { get; set; }

        // 등록일자 
        public DateTime RegUser { get; set; }

        // 등록자 
        public string RegDate { get; set; }

        // SystemInfo 모델 복사
        public void CopyData(SystemInfo param)
        {
            this.SystemCode = param.SystemCode;
            this.SystemName = param.SystemName;
            this.CorpName = param.CorpName;
            this.Comment = param.Comment;
            this.UseYn = param.UseYn;
            this.UpDate = param.UpDate;
            this.UpUser = param.UpUser;
            this.RegUser = param.RegUser;
            this.RegDate = param.RegDate;
        }
    }
}
