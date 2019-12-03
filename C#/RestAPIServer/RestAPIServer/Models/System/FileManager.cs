using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIServer.Models.System
{
    // 파일관리자 
    public class Filemanager
    {
        // 파일고유값 
        [Key]
        public int Filecode { get; set; }

        // 원본파일명 
        public string Originalfilename { get; set; }

        // 저장파일명 
        public string Savefilename { get; set; }

        // 파일크기 
        public string Filesize { get; set; }

        // 파일타입 
        public string Filetype { get; set; }

        // 파일확장자 
        public string Fileextension { get; set; }

        // 화면이름 
        public string Windowname { get; set; }

        // 등록자 
        public string Regdate { get; set; }

        // 화면별고유값 
        public string Windowuniquecode { get; set; }

        // 등록일자 
        public string Reguser { get; set; }

        // Filemanager 모델 복사
        public void CopyData(Filemanager param)
        {
            this.Filecode = param.Filecode;
            this.Originalfilename = param.Originalfilename;
            this.Savefilename = param.Savefilename;
            this.Filesize = param.Filesize;
            this.Filetype = param.Filetype;
            this.Fileextension = param.Fileextension;
            this.Windowname = param.Windowname;
            this.Regdate = param.Regdate;
            this.Windowuniquecode = param.Windowuniquecode;
            this.Reguser = param.Reguser;
        }
    }
}
