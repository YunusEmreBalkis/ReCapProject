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
            ColorTest();
            //CarTest();

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //Color color1 = new Color() { ColorId=3 ,ColorName = "Purple" };
            //colorManager.Add(color1);
            var updatedColor = colorManager.GetById(3);
            updatedColor.ColorName = "Yellow";
            //colorManager.Update(updatedColor);7
            colorManager.Delete(updatedColor);
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            // Brand brand1 = new Brand() { BrandId=5, BrandName = "Tesla" };
            var updatedbrand = brandManager.GetById(5);
            updatedbrand.BrandName = "Ford";
            //brandManager.Add(brand1);
            //brandManager.Update(updatedbrand);
            brandManager.Delete(updatedbrand);
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //Car carer = new Car { CarId = 4, BrandId = 4, ColorId = 506, DailyPrice = 323, Description = "Nissan Qasqhai", ModelYear = 2018 };

            // carManager.Update(carer);
            //carManager.Add(carer);
            //carmanager.delete(carer);
            foreach (var car1 in carManager.GetCarDetails())
            {
                Console.WriteLine(car1.BrandName +" /" + car1.Description + "/" + car1.ColorName + "/" + car1.DailyPrice);
            }
        }
    }
}
