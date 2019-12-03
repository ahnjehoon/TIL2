using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIServer.Models.Common
{
    // 사용자 정보 
    public class Userinfo
    {
        // 사용자고유값 
        [Key, Column(Order = 2)]
        public int Usercode { get; set; }

        // 사용자계정
        [Key, Column(Order = 1)]
        public string Useraccount { get; set; }

        // 패스워드 
        public string Userpassword { get; set; }

        // 회사코드 
        public string Corpcode { get; set; }

        // 사용자메일 
        public string Usermail { get; set; }

        // 메일수신여부 
        public string Mailrecieve { get; set; }

        // 사용자이름 
        public string Username { get; set; }

        // 사용자권한 
        public string Usergrant { get; set; }

        // 사원번호 
        public string Emploeenumber { get; set; }

        // 사용자부서코드 
        public string Userdepartmentcode { get; set; }

        // 사용자직책코드 
        public string Userjobcode { get; set; }

        // 전화번호 
        public string Userphone { get; set; }

        // 내선번호 
        public string Usertel { get; set; }

        // 팩스번호 
        public string Userfax { get; set; }

        // 입사일 
        public DateTime Userjoindate { get; set; }

        // 퇴사일 
        public DateTime Userretiredate { get; set; }

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

        // Userinfo 모델 복사
        public void CopyData(Userinfo param)
        {
            this.Usercode = param.Usercode;
            this.Useraccount = param.Useraccount;
            this.Userpassword = param.Userpassword;
            this.Corpcode = param.Corpcode;
            this.Usermail = param.Usermail;
            this.Mailrecieve = param.Mailrecieve;
            this.Username = param.Username;
            this.Usergrant = param.Usergrant;
            this.Emploeenumber = param.Emploeenumber;
            this.Userdepartmentcode = param.Userdepartmentcode;
            this.Userjobcode = param.Userjobcode;
            this.Userphone = param.Userphone;
            this.Usertel = param.Usertel;
            this.Userfax = param.Userfax;
            this.Userjoindate = param.Userjoindate;
            this.Userretiredate = param.Userretiredate;
            this.Comment = param.Comment;
            this.Useyn = param.Useyn;
            this.Update = param.Update;
            this.Upuser = param.Upuser;
            this.Regdate = param.Regdate;
            this.Reguser = param.Reguser;
        }
    }
}
