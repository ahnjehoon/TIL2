using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIServer.Models
{
    public class SensorStatisticsMinute
    {
        public string Sensorcode { get; set; }
        public string Value { get; set; }
        public long? Starttime { get; set; }
        public long? Endtime { get; set; }

        public void CopyData(SensorStatisticsMinute param)
        {
            this.Sensorcode = param.Sensorcode;
            this.Value = param.Value;
            this.Starttime = param.Starttime;
            this.Endtime = param.Endtime;
        }
    }
}
