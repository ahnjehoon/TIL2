using System;
using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace UtilLibrary
{
    public class DBUtil : INotifyPropertyChanged
    {
        private String _SERVER_ADRESS;
        private String _USER_ID;
        private String _PASSWORD;
        
        public String ServerAdress
        {
            get
            {
                return _SERVER_ADRESS;
            }
            set
            {
                if(_SERVER_ADRESS != value)
                {
                    _SERVER_ADRESS = value;
                }
            }
        }

        private String _DATABASE;

        public String DataBaseName
        {
            get { return _DATABASE; }
            set { _DATABASE = value; }
        }


        public DBUtil()
        {
        }
        public bool connectTest()

        {
            String server = "127.0.0.1";
            String database = "develop";
            String uid = "root";
            String password = "1111";

            try
            {
                String strConn = $"" +
                        $"Server={server};" +
                        $"Database={database};" +
                        $"Uid={uid};" +
                        $"Pwd={password};";
                MySqlConnection conn = new MySqlConnection(strConn);
                conn.Open();
                System.Diagnostics.Debug.WriteLine("연결 완료");
                return true;
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine("연결실패: " + e.Message);
                return false;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
