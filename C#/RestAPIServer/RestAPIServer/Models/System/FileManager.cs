using System.ComponentModel.DataAnnotations;

namespace RestAPIServer.Models.System
{
    // 파일관리자 
    public class FileManager
    {
        // 파일고유값 
        [Key]
        public int FileCode { get; set; }

        // 원본파일명 
        public string OriginalFileName { get; set; }

        // 저장파일명 
        public string SaveFileName { get; set; }

        // 파일크기 
        public string FileSize { get; set; }

        // 파일타입 
        public string FileType { get; set; }

        // 파일확장자 
        public string FileExtension { get; set; }

        // 화면이름 
        public string WindowName { get; set; }

        // 등록자 
        public string RegDate { get; set; }

        // 화면별고유값 
        public string WindowUniqueCode { get; set; }

        // 등록일자 
        public string RegUser { get; set; }

        // FileManager 모델 복사
        public void CopyData(FileManager param)
        {
            this.FileCode = param.FileCode;
            this.OriginalFileName = param.OriginalFileName;
            this.SaveFileName = param.SaveFileName;
            this.FileSize = param.FileSize;
            this.FileType = param.FileType;
            this.FileExtension = param.FileExtension;
            this.WindowName = param.WindowName;
            this.RegDate = param.RegDate;
            this.WindowUniqueCode = param.WindowUniqueCode;
            this.RegUser = param.RegUser;
        }
    }
}
