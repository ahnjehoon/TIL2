using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIServer.Models.Common
{
    // 회사 정보 
    public class Companyinfo
    {
        // 거래처코드 
        public string Companycode { get; set; }

        // 거래처구분 
        public string Companytype { get; set; }

        // 거래처명칭 
        public string Companyname { get; set; }

        // 거래처별칭 
        public string Companyalias { get; set; }

        // 개업년월일 
        public DateTime Vendopendate { get; set; }

        // 전화번호 
        public string Vendtel { get; set; }

        // 팩스번호 
        public string Vendfax { get; set; }

        // 이메일 
        public string Vendemail { get; set; }

        // 비고 
        public string Comment { get; set; }

        // 사용유무 
        public string Useyn { get; set; }

        // 수정일자 
        public DateTime Update { get; set; }

        // 수정자 
        public string Upuser { get; set; }

        // 등록일자 
        public DateTime Regdate { get; set; }

        // 등록자 
        public string Reguser { get; set; }

        // Companyinfo 모델 복사
        public void CopyData(Companyinfo param)
        {
            this.Companycode = param.Companycode;
            this.Companytype = param.Companytype;
            this.Companyname = param.Companyname;
            this.Companyalias = param.Companyalias;
            this.Vendopendate = param.Vendopendate;
            this.Vendtel = param.Vendtel;
            this.Vendfax = param.Vendfax;
            this.Vendemail = param.Vendemail;
            this.Comment = param.Comment;
            this.Useyn = param.Useyn;
            this.Update = param.Update;
            this.Upuser = param.Upuser;
            this.Regdate = param.Regdate;
            this.Reguser = param.Reguser;
        }
    }
}
