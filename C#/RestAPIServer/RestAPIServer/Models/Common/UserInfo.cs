using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPIServer.Models.Common
{
    // 사용자 정보 
    public class UserInfo
    {
        // 사용자고유값 
        [Key, Column(Order = 2)]
        public int UserCode { get; set; }

        // 사용자계정
        [Key, Column(Order = 1)]
        public string UserAccount { get; set; }

        // 패스워드 
        public string UserPassword { get; set; }

        // 회사코드 
        public string CorpCode { get; set; }

        // 사용자메일 
        public string UserMail { get; set; }

        // 메일수신여부 
        public string MailRecieve { get; set; }

        // 사용자이름 
        public string UserName { get; set; }

        // 사용자권한 
        public string UserGrant { get; set; }

        // 사원번호 
        public string EmploeeNumber { get; set; }

        // 사용자부서코드 
        public string UserDepartmentCode { get; set; }

        // 사용자직책코드 
        public string UserJobCode { get; set; }

        // 전화번호 
        public string UserPhone { get; set; }

        // 내선번호 
        public string UserTel { get; set; }

        // 팩스번호 
        public string UserFax { get; set; }

        // 입사일 
        public DateTime UserJoinDate { get; set; }

        // 퇴사일 
        public DateTime UserRetireDate { get; set; }

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

        // UserInfo 모델 복사
        public void CopyData(UserInfo param)
        {
            this.UserCode = param.UserCode;
            this.UserAccount = param.UserAccount;
            this.UserPassword = param.UserPassword;
            this.CorpCode = param.CorpCode;
            this.UserMail = param.UserMail;
            this.MailRecieve = param.MailRecieve;
            this.UserName = param.UserName;
            this.UserGrant = param.UserGrant;
            this.EmploeeNumber = param.EmploeeNumber;
            this.UserDepartmentCode = param.UserDepartmentCode;
            this.UserJobCode = param.UserJobCode;
            this.UserPhone = param.UserPhone;
            this.UserTel = param.UserTel;
            this.UserFax = param.UserFax;
            this.UserJoinDate = param.UserJoinDate;
            this.UserRetireDate = param.UserRetireDate;
            this.Comment = param.Comment;
            this.UseYn = param.UseYn;
            this.UpDate = param.UpDate;
            this.UpUser = param.UpUser;
            this.RegDate = param.RegDate;
            this.RegUser = param.RegUser;
        }
    }
}
