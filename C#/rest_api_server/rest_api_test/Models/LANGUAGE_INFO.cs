using System;
using System.ComponentModel.DataAnnotations;

namespace rest_api_test.Models
{
    public class LANGUAGE_INFO
    {
        // 언어코드 
        [Key]
        public String LANGUAGE_CODE { get; set; }

        // 한국어 
        public String LANGUAGE_VALUE1 { get; set; }

        // 영어 
        public String LANGUAGE_VALUE2 { get; set; }

        // 일본어 
        public String LANGUAGE_VALUE3 { get; set; }
    }
}
