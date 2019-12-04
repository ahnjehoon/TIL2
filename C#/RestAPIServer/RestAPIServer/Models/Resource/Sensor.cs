using System;
using System.ComponentModel.DataAnnotations;

namespace RestAPIServer.Models
{
    public class Sensor
    {
        // 센서고유값 
        public string SensorCode { get; set; }

        // 센서이름 
        public string SensorName { get; set; }

        // 센서타입(공통코드) 
        public string SensorType { get; set; }

        // 비고 
        public string Comment { get; set; }

        // 통계사용여부 
        public string SummaryYn { get; set; }

        // 사용여부 
        public string UseYn { get; set; }

        // 등록일 
        public DateTime? RegDate { get; set; }

        // 등록자 
        public string RegUser { get; set; }

        // 수정일 
        public DateTime? UpDate { get; set; }

        // 수정자 
        public string UpUser { get; set; }

        // Sensor 모델 복사
        public void CopyData(Sensor param)
        {
            this.SensorCode = param.SensorCode;
            this.SensorName = param.SensorName;
            this.SensorType = param.SensorType;
            this.Comment = param.Comment;
            this.SummaryYn = param.SummaryYn;
            this.UseYn = param.UseYn;
            this.RegDate = param.RegDate;
            this.RegUser = param.RegUser;
            this.UpDate = param.UpDate;
            this.UpUser = param.UpUser;
        }
    }
}
