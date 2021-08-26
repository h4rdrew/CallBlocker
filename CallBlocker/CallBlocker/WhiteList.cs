using SQLite;

namespace CallBlocker
{
    public class WhiteList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Number { get; set; }
    }
}
