using Core.Entites;
using System;


namespace Core.Entities.Concrete
{
   public  class Card :IEntity
    {
        public int UserId { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Cvv { get; set; }

    }
}
