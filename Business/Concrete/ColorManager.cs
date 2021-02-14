using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colordal;

        public ColorManager(IColorDal colordal)
        {
            _colordal = colordal;
        }

        public IResult Add(Color color)
        {
            _colordal.Add(color);
            return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
            var colorToDelete = _colordal.Get(co => co.ColorId == color.ColorId);
            if(colorToDelete==null) return new ErrorResult(Messages.CarFindProblem);
            _colordal.Delete(colorToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
           return new SuccessDataResult<List<Color>>(_colordal.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colordal.Get(c => c.ColorId == colorId));
        }

        public IResult Update(Color color)
        {
            _colordal.Update(color);
            return new SuccessResult();
        }
    }
}
