using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIClient.Model
{
    public class LanguageInfo
    {
        // 언어코드 
        public string LanguageCode { get; set; }

        // 한국어 
        public string LanguageValue1 { get; set; }

        // 영어 
        public string LanguageValue2 { get; set; }

        // 일본어 
        public string LanguageValue3 { get; set; }

        // 비고 
        public string Comment { get; set; }

        // LanguageInfo 모델 복사
        public void CopyData(LanguageInfo param)
        {
            this.LanguageCode = param.LanguageCode;
            this.LanguageValue1 = param.LanguageValue1;
            this.LanguageValue2 = param.LanguageValue2;
            this.LanguageValue3 = param.LanguageValue3;
            this.Comment = param.Comment;
        }
    }
}
