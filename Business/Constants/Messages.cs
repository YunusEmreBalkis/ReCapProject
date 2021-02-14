using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarInvalid = "Araba tanımlanımız 2 karekterden fazla olması gerekiyor";
        public static string CarDailyPrice = "Günlük araba kirası 0 tl olamaz";
        public static string CarFindProblem = "Araç bulunamadı";
        public static string CarsListed = "Arabalar listelendi";
        public static string ReturnProblem = "Kiralanmak istenilen araç henüz teslim edilmemiştir.Bu yüzden bu araç kiralanamaz";
    }
}
