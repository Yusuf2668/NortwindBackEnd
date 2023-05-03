using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Business.Constans
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi!";
        public static string ProductNameInvalid = "Ürün ismi Geçersiz!";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductNameAlreadyExists = "İsim kullanımda";
        public static string CategoryLimitedExceded = "Kategori Limiti Aşıldı";
        public static string AuthorizationDenied = "Yetkiniz bulunmamaktadır";
        public static string UserRegistered = "Kayıt Oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatası";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Giriş Yapıldı";
    }
}
