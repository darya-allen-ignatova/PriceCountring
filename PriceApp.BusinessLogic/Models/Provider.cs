
using System;
using PriceApp.BusinessLogic.FileService;

namespace PriceApp.BusinessLogic
{
    public class Provider : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public PaymentType PaymentType { get; set; }

        public int FirstDayAmount { get; set; }

        public int? FirstPercenge { get; set; }

        public int SecondDayAmount { get; set; }

        public int? SecondPercenge { get; set; }

        public decimal ResultPrice { get; set; }

        public string Place { get; set; }

        public int CompareTo(object obj)
        {
            if(obj is Provider)
            {
                return this.ResultPrice.CompareTo((obj as Provider).ResultPrice);
            }
            return -1;
        }
    }
}
