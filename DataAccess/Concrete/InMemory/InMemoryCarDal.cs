using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId= 1, BrandId=2, ColorId=3, DailyPrice=3000, ModelYear=2018, Description="Mercedes c180" },
                new Car{CarId= 1, BrandId=1, ColorId=5, DailyPrice=4000, ModelYear=2021, Description="Bmw M4 Coupe" },
                new Car{CarId= 2, BrandId=3, ColorId=2, DailyPrice=500, ModelYear=2017, Description="Nissan Qashqai" },
                new Car{CarId= 3, BrandId=2, ColorId=7, DailyPrice=1000, ModelYear=2018, Description="Ford F-150" },
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
