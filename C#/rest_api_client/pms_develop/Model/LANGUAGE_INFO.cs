using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace pms_develop.Model
{
    class LANGUAGE_INFO
    {
        // 언어코드 
        [Key]
        public string LANGUAGE_CODE { get; set; }

        // 한국어 
        public string LANGUAGE_VALUE1 { get; set; }

        // 영어 
        public string LANGUAGE_VALUE2 { get; set; }

        // 일본어 
        public string LANGUAGE_VALUE3 { get; set; }
    }
}
