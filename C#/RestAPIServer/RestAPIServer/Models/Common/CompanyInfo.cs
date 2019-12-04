using System;
using System.ComponentModel.DataAnnotations;

namespace RestAPIServer.Models.Common
{
    // 회사 정보 
    public class CompanyInfo
    {
        // 거래처코드 
        [Key]
        public string CompanyCode { get; set; }

        // 거래처구분 
        public string CompanyType { get; set; }

        // 거래처명칭 
        public string CompanyName { get; set; }

        // 거래처별칭 
        public string CompanyAlias { get; set; }

        // 개업년월일 
        public DateTime VendOpenDate { get; set; }

        // 전화번호 
        public string VendTel { get; set; }

        // 팩스번호 
        public string VendFax { get; set; }

        // 이메일 
        public string VendEmail { get; set; }

        // 비고 
        public string Comment { get; set; }

        // 사용유무 
        public string UseYn { get; set; }

        // 수정일자 
        public DateTime UpDate { get; set; }

        // 수정자 
        public string UpUser { get; set; }

        // 등록일자 
        public DateTime RegDate { get; set; }

        // 등록자 
        public string RegUser { get; set; }

        // CompanyInfo 모델 복사
        public void CopyData(CompanyInfo param)
        {
            this.CompanyCode = param.CompanyCode;
            this.CompanyType = param.CompanyType;
            this.CompanyName = param.CompanyName;
            this.CompanyAlias = param.CompanyAlias;
            this.VendOpenDate = param.VendOpenDate;
            this.VendTel = param.VendTel;
            this.VendFax = param.VendFax;
            this.VendEmail = param.VendEmail;
            this.Comment = param.Comment;
            this.UseYn = param.UseYn;
            this.UpDate = param.UpDate;
            this.UpUser = param.UpUser;
            this.RegDate = param.RegDate;
            this.RegUser = param.RegUser;
        }
    }
}
