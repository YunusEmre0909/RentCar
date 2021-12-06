using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDescriptionInvalid = "Araba kritelere uygun değil";
        public static string MaintenanceTime="Sistem bakımda";
        public static string CarListed="Arabalar listelendi";
        internal static string CarUpdated="Araba güncellendi";
        internal static string CarDeleted="Araba silindi";


        public static string UserAdded="Kullanıcı eklendi";
        public static string UserDeleted="Kullanıcı silindi";
        public static string UserListed="Kullanıcılar Listelendi";
        public static string UserUpdate="Kullanıcı güncellendi";

        public static string CustomerAdded="Müşteri eklendi";
        public static string CustomerDeleted="Müşteri silindi";
        public static string CustomerListed="Müşteriler listelendi";
        public static string CustomerUpdated="Müşteri güncellendi";

        public static string InvalidRental= "Araba şu anda kullanılamıyor";
        public static string RentalAdded="Araba kiralandı";
        public static string RentalDeleted="Kiralama silindi";
        public static string RentalListed="Kiralamalar listelendi";
        public static string RentalUpdated="Kiralama güncellendi";

        public static string BrandAdded = "Yeni marka eklendi";
        public static string BrandDeleted="Marka silindi";
        public static string BrandListed="Markalar listelendi";
        public static string BrandUpdated="Marka güncellendi";

        public static string ColorAdded="Renk eklendi";
        public static string ColorDeleted="Renk silindi";
        public static string ColorListed="Renkler listelendi";
        public static string ColorUpdated="Renk güncellendi";

        public  static string CheckIfCarImageLimited="En fazla 5 resim  yüklenebilir";
        public static string CarImageAdded="Araba resmi eklendi";
        public static string CarImageDeleted="Araba resmi silindi";
        public static string AuthorizationDenied="Yetkiniz yok";

        public static string CarDetailsReceived = "Araç detayları getirildi";
    }
}
