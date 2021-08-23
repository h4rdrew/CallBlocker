using Simple.DatabaseWrapper.Attributes;

namespace CallBlocker.DA.Models.DadosNumeros
{
    public class WhiteList_Model_DA
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Number { get; set; }
        //public string Name { get; set; }
    }
}
