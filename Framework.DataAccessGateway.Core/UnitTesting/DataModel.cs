using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class DataModel
    {
        public Guid Id { get; set; }
        public long BigInt { get; set; }
        public byte[] Binary { get; set; }
        public bool Bit { get; set; }
        public string Char { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime DateTime2 { get; set; }
        public DateTime SmallDateTime { get; set; }
        public DateTimeOffset DateTimeOffset { get; set; }
        public decimal Decimal { get; set; }
        public double Float { get; set; }
        public byte[] Image { get; set; }
        public int Int { get; set; }
        public decimal Money { get; set; }
        public string NChar { get; set; }
        public string NText { get; set; }
        public string NVarChar { get; set; }
        public float Real { get; set; }        
        public decimal SmallMoney { get; set; }
        public string Text { get; set; }
        public byte[] VarBinary { get; set; }
        public string VarChar { get; set; }       
    }
}
