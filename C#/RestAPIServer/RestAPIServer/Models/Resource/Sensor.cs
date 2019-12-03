using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIServer.Models
{
    public class Sensor
    {
        // 센서고유값 
        [Key]
        public string Sensorcode { get; set; }

        // 센서이름 
        public string Sensorname { get; set; }

        // 센서타입(공통코드) 
        public string Sensortype { get; set; }

        // 비고 
        public string Comment { get; set; }

        // 통계사용여부 
        public string Summaryyn { get; set; }

        // 사용여부 
        public string Useyn { get; set; }

        // 등록일 
        public DateTime? Regdate { get; set; }

        // 등록자 
        public string Reguser { get; set; }

        // 수정일 
        public DateTime? Update { get; set; }

        // 수정자 
        public string Upuser { get; set; }

        // Sensor 모델 복사
        public void CopyData(Sensor param)
        {
            this.Sensorcode = param.Sensorcode;
            this.Sensorname = param.Sensorname;
            this.Sensortype = param.Sensortype;
            this.Comment = param.Comment;
            this.Summaryyn = param.Summaryyn;
            this.Useyn = param.Useyn;
            this.Regdate = param.Regdate;
            this.Reguser = param.Reguser;
            this.Update = param.Update;
            this.Upuser = param.Upuser;
        }
    }
}
