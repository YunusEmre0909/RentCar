using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // UserGetAllTest();
            // RentaladdedTest();
           // CarDeletedTest();
        }

        private static void CarDeletedTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                var result = carManager.Delete(car);
                Console.WriteLine(result.Massage);

            }
        }

        private static void RentaladdedTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 1004, CustomerId = 1, RentDate = DateTime.Now });
            Console.Write(result.Massage);
        }

        private static void UserGetAllTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName);
            }
        }
    }
}
