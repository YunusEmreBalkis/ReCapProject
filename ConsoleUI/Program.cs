using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandTest();
            //ColorTest();
            //CarTest();
            RentTest();
            //CustomerTest();
            //UserTest();

        }

        private static void UserTest()
        {
            User user1 = new User() { UserId=1, FirstName="Ahmet", LastName="Katan", Email="ertan@gmail.com", Password="adsa" };
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(user1);
            var result = userManager.GetAll();
            //var selecteduser = userManager.GetById(1);
            //selecteduser.Data.FirstName = "Turas";
            //userManager.Update(selecteduser.Data);
            //userManager.Delete(user1);
            if (result.Success==true)
            {
                foreach (var res in result.Data)
                {
                    Console.WriteLine(res.FirstName);
                }
            }
        }
            private static void CustomerTest()
        {
            Customer customer1 = new Customer() { CustomerId = 1, CompanyName = "Terak", UserId = 1 };
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(customer1);
            //var selectedcustomer = customerManager.GetById(1);
            //selectedcustomer.Data.CompanyName = "Versoy";
            //customerManager.Update(selectedcustomer.Data);
            //customerManager.Delete(customer1);
            var result = customerManager.GetCustomerDetails();
            if (result.Success==true)
            {
                foreach (var res in result.Data)
                {
                    Console.WriteLine(res.CustomerId +" /"+ res.FirstName);
                }
            }
        }
            private static void RentTest()
        {
            Rental rental = new Rental()
            {
                RentId = 1,
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Now,
                ReturnDate = new DateTime(2021, 4, 1)
            };
            Rental rental1 = new Rental()
            {
                RentId = 2,
                CarId = 3,
                CustomerId = 2,
                RentDate = DateTime.Now,
                ReturnDate = new DateTime(2021, 6, 2)
            };
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.Add(rental1);
            var result = rentalManager.GetAll();
           // var selectedresult = rentalManager.GetById(1);
           // selectedresult.Data.CarId = 2;
            //rentalManager.Update(selectedresult.Data);
            rentalManager.Delete(rental);
            if (result.Success== true)
            {
                foreach (var res in result.Data)
                {
                    Console.WriteLine(res.RentDate+"/ "+res.ReturnDate);
                }
            }
            
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //Color color1 = new Color() { ColorId=3 ,ColorName = "Purple" };
            Color color2 = new Color() { ColorId = 3, ColorName = "Blue" };
            //colorManager.Add(color2);
            var updatedColor = colorManager.GetById(3);
            // updatedColor.Data.ColorName = "Yellow";
            //colorManager.Update(updatedColor);7
            //colorManager.Delete(updatedColor.Data);
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            // Brand brand1 = new Brand() { BrandId=5, BrandName = "Tesla" };
            var updatedbrand = brandManager.GetById(5);
            //updatedbrand.Data.BrandName = "Ford";
            //brandManager.Add(brand1);
            //brandManager.Update(updatedbrand);
            //brandManager.Delete(updatedbrand.Data);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car carer = new Car { CarId = 4, BrandId = 4, ColorId = 506, DailyPrice = 0, Description = "qewd asd", ModelYear = 2018 };
            Car car2 = new Car {  BrandId = 1, ColorId = 2, DailyPrice = 21, Description = "Tesla x", ModelYear = 2018 };
            // carManager.Update(carer);
            carManager.Add(car2);
            //if (ader.Success==false)
            //{
            //    Console.WriteLine(ader.Message);
            //}
            //carmanager.delete(carer);

            var result = carManager.GetCarDetails();

            if (result.Success==true)
            {
                foreach (var car1 in result.Data)
                {
                    Console.WriteLine(car1.BrandName + " /" + car1.Description + "/" + car1.ColorName + "/" + car1.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }
    }
}
