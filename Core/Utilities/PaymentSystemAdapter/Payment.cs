using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Core.Utilities.PaymentSystemAdapter
{
    public class Payment
    {
        public static IResult Pay(Card card)
        {
            return new SuccessResult("Ödeme başarıyla yapıldı");
        }
    }
}
