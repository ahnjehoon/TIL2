using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIServer.Models
{
    public class CommonCode
    {
        // 공통코드 
        public class Commoncode
        {
            // 코드 
            [Key, Column(Order = 1)]
            public string Code { get; set; }

            // 코드구분 
            [Key, Column(Order = 2)]
            public string Codetype { get; set; }

            // 정렬 
            public string Dspseq { get; set; }

            // 코드명 
            public string Codename { get; set; }

            // 코드설명 
            public string Codedescription { get; set; }

            // 비고 
            public string Comment { get; set; }

            // 사용유무 
            public string Useyn { get; set; }

            // 수정일자 
            public DateTime? Update { get; set; }

            // 수정자 
            public string Upuser { get; set; }

            // 등록일자 
            public DateTime? Regdate { get; set; }

            // 등록자 
            public string Reguser { get; set; }

            // Commoncode 모델 복사
            public void CopyData(Commoncode param)
            {
                this.Code = param.Code;
                this.Codetype = param.Codetype;
                this.Dspseq = param.Dspseq;
                this.Codename = param.Codename;
                this.Codedescription = param.Codedescription;
                this.Comment = param.Comment;
                this.Useyn = param.Useyn;
                this.Update = param.Update;
                this.Upuser = param.Upuser;
                this.Regdate = param.Regdate;
                this.Reguser = param.Reguser;
            }
        }
    }
}
