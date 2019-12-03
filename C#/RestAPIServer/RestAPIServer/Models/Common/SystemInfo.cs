using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIServer.Models.Common
{
    public class SystemInfo
    {
        // 시스템 정보 
        public class Systeminfo
        {
            // 시스템 아이디 
            [Key]
            public string Systemcode { get; set; }

            // 시스템명 
            public string Systemname { get; set; }

            // 회사명 
            public string Corpname { get; set; }

            // 비고 
            public string Comment { get; set; }

            // 사용유무 
            public string Useyn { get; set; }

            // 수정일자 
            public DateTime Update { get; set; }

            // 수정자 
            public string Upuser { get; set; }

            // 등록일자 
            public DateTime Reguser { get; set; }

            // 등록자 
            public string Regdate { get; set; }

            // Systeminfo 모델 복사
            public void CopyData(Systeminfo param)
            {
                this.Systemcode = param.Systemcode;
                this.Systemname = param.Systemname;
                this.Corpname = param.Corpname;
                this.Comment = param.Comment;
                this.Useyn = param.Useyn;
                this.Update = param.Update;
                this.Upuser = param.Upuser;
                this.Reguser = param.Reguser;
                this.Regdate = param.Regdate;
            }
        }
    }
}
