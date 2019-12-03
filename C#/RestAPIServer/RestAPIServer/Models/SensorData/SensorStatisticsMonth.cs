using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIServer.Models
{
    public class SensorStatisticsMonth
    {
        // 센서고유값 
        public string Sensorcode { get; set; }

        // 값 
        public string Value { get; set; }

        // 수집시작시간 
        public long? Starttime { get; set; }

        // 수집종료시간 
        public long? Endtime { get; set; }

        // Sensorstatisticsmonth 모델 복사
        public void CopyData(SensorStatisticsMonth param)
        {
            this.Sensorcode = param.Sensorcode;
            this.Value = param.Value;
            this.Starttime = param.Starttime;
            this.Endtime = param.Endtime;
        }
    }
}
