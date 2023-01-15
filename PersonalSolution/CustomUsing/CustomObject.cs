using System;
using MySql.Data.MySqlClient;

namespace CustomUsing
{
    class CustomObject : IDisposable
    {
        private readonly MySqlConnection conn;

        private int? num;
        public int? Num
        {
            get => num;
            set => num = value;
        }

        private string text;
        public string Text
        {
            get => text;
            set => text = value;
        }

        public CustomObject(int num, string text)
        {
            this.num = num;
            this.text = text;

            conn = new(new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                UserID = "root",
                Password = "dbadmin",
                Database = "test_db",
                ConvertZeroDateTime = true,
                SslMode = MySqlSslMode.None
            }.ToString());

            conn.Open();
        }

        public void Dispose()
        {
            conn.Dispose();
        }
    }
}