using Core.Utilities.Results;
using Core.Entities.Concrete;


namespace Business.Abstract
{
   public interface IPaymentService
    {
        IResult Pay(Card card);
    }
}
