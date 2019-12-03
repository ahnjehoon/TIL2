using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIServer.Models
{
    public class SensorCurrentData
    {
        // 센서고유값 
        public string Sensorcode { get; set; }

        // 발생시간 
        public long Valueoccurtime { get; set; }

        // 저장시간 
        public long Valuesavetime { get; set; }

        // 센서값 
        public string Value { get; set; }

        // Sensorcurrentdata 모델 복사
        public void CopyData(SensorCurrentData param)
        {
            this.Sensorcode = param.Sensorcode;
            this.Valueoccurtime = param.Valueoccurtime;
            this.Valuesavetime = param.Valuesavetime;
            this.Value = param.Value;
        }
    }
}
