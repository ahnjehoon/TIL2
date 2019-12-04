using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPIServer.Models
{
    // 공통코드 
    public class CommonCode
    {
        // 코드 
        [Key, Column(Order = 1)]
        [MaxLength(20)]
        public string Code { get; set; }

        // 코드구분 
        [Key, Column(Order = 2)]
        public string CodeType { get; set; }

        // 정렬 
        public string DspSeq { get; set; }

        // 코드명 
        public string CodeName { get; set; }

        // 코드설명 
        public string CodeDescription { get; set; }

        // 비고 
        public string Comment { get; set; }

        // 사용유무 
        public string UseYn { get; set; }

        // 수정일자 
        public DateTime? UpDate { get; set; }

        // 수정자 
        public string UpUser { get; set; }

        // 등록일자 
        public DateTime? RegDate { get; set; }

        // 등록자 
        public string RegUser { get; set; }

        // CommonCode 모델 복사
        public void CopyData(CommonCode param)
        {
            this.Code = param.Code;
            this.CodeType = param.CodeType;
            this.DspSeq = param.DspSeq;
            this.CodeName = param.CodeName;
            this.CodeDescription = param.CodeDescription;
            this.Comment = param.Comment;
            this.UseYn = param.UseYn;
            this.UpDate = param.UpDate;
            this.UpUser = param.UpUser;
            this.RegDate = param.RegDate;
            this.RegUser = param.RegUser;
        }
    }
}
