namespace RestAPIServer.Models
{
    public class SensorStatisticsMinute
    {
        public string SensorCode { get; set; }
        public string Value { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }

        public void CopyData(SensorStatisticsMinute param)
        {
            this.SensorCode = param.SensorCode;
            this.Value = param.Value;
            this.StartTime = param.StartTime;
            this.EndTime = param.EndTime;
        }
    }
}
