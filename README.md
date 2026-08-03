<div align="center">

# Identity Chat & Mail

ASP.NET Core MVC ile geliştirilmiş, kullanıcıya özel mesaj yönetimi sunan modern bir mesajlaşma uygulaması.

![C#](https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=csharp&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity_Framework_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Microsoft SQL Server](https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)

[Türkçe](#-proje-hakkında) • [English](#-english)

</div>

---

## 📌 Proje Hakkında

**Identity Chat & Mail**, kullanıcıların güvenli biçimde kayıt olabildiği, giriş yapabildiği ve sistemdeki diğer kullanıcılara e-posta adresleri üzerinden mesaj gönderebildiği ASP.NET Core MVC tabanlı bir mesajlaşma uygulamasıdır.

Proje; ASP.NET Core Identity ile kimlik doğrulama, Entity Framework Core ile veri erişimi, Microsoft SQL Server ile veri saklama ve Razor Views ile kullanıcı arayüzü geliştirme konularını uygulamalı olarak pekiştirmek amacıyla geliştirilmiştir.

Uygulamada temel mesaj gönderme işlemlerine ek olarak okundu bilgisi, önemli mesajlar, taslaklar, arama, kullanıcıya özel çöp kutusu, geri yükleme ve kalıcı silme gibi gerçek bir mesajlaşma sisteminde ihtiyaç duyulan özellikler bulunmaktadır.

<p align="center">
  <img width="900" alt="Identity Chat & Mail" src="https://github.com/user-attachments/assets/1ba7177c-370a-427c-8a52-caa7650a1b42" />
</p>

## ✨ Özellikler

### 🔐 Kullanıcı ve Yetkilendirme

- ASP.NET Core Identity ile kullanıcı kaydı, giriş ve güvenli çıkış
- `[Authorize]` ile yetkisiz sayfa erişiminin engellenmesi
- Mesaj detaylarının yalnızca gönderen veya alıcı tarafından görüntülenebilmesi
- Giriş yapan kullanıcının ad, soyad, e-posta ve profil fotoğrafının gösterilmesi
- Profil fotoğrafı bulunmadığında varsayılan kullanıcı simgesi

### 📨 Mesajlaşma

- Kullanıcılara e-posta adresleri üzerinden mesaj gönderme
- Gelen kutusu ve gönderilen mesajlar
- Mesaj detaylarını görüntüleme
- Mesajı alıcı açtığında okundu bilgisinin güncellenmesi
- Gönderen, alıcı, konu, içerik, tarih ve saat bilgilerinin gösterilmesi

### ⭐ Önemli Mesajlar

- Gönderen ve alıcı için bağımsız önemli mesaj yönetimi
- Mesajı önemli yapma ve önemden çıkarma
- `SenderIsImportant` ve `ReceiverIsImportant` alanlarıyla kullanıcıya özel durum takibi

### 📝 Taslaklar ve Arama

- Mesajları taslak olarak kaydetme
- Taslak mesajları ayrı sayfada listeleme
- Taslakların gönderilen mesajlar arasında görünmesini engelleme
- Konu, mesaj içeriği ve gönderen adresinde LINQ `Contains()` ile arama

### 🗑️ Çöp Kutusu ve Kalıcı Silme

- Gönderen ve alıcı için bağımsız soft delete yapısı
- Mesajları çöp kutusuna taşıma
- Çöp kutusundaki mesajları geri yükleme
- Kullanıcı tarafında kalıcı silme
- Her iki kullanıcı da kalıcı sildiğinde fiziksel kaydı veritabanından kaldırma

### 🔔 Bildirimler ve Arayüz

- Model validation ile form doğrulama
- TempData ve SweetAlert2 ile başarı, hata, uyarı ve bilgi bildirimleri
- Tarihlerin Türkçe kültür bilgisiyle gösterilmesi
- Responsive ve modern mor-beyaz kullanıcı arayüzü
- Okunmuş ve okunmamış mesaj ayrımı
- Tüm mesaj sayfalarında ortak tasarım dili

## 🛠️ Kullanılan Teknolojiler

| Teknoloji | Kullanım amacı |
| --- | --- |
| C# | Uygulama ve iş mantığı |
| ASP.NET Core MVC | Web uygulaması mimarisi |
| ASP.NET Core Identity | Kayıt, giriş, çıkış ve kullanıcı yönetimi |
| Entity Framework Core | ORM ve veri erişimi |
| Microsoft SQL Server | İlişkisel veritabanı |
| LINQ | Sorgulama, filtreleme, arama ve sıralama |
| Razor Views | Dinamik, sunucu taraflı kullanıcı arayüzleri |
| HTML5 ve CSS3 | Sayfa yapısı ve özel tasarım |
| Bootstrap | Responsive grid, form ve buton bileşenleri |
| JavaScript | Kullanıcı etkileşimleri |
| SweetAlert2 | İşlem bildirimleri |
| Dependency Injection | Servis ve bağımlılık yönetimi |
| Async/Await | Asenkron veritabanı işlemleri |
| Code First Migrations | Veritabanı şemasının sürümlenmesi |

## 🧩 Uygulanan Teknik Yaklaşımlar

### Kimlik Doğrulama ve Yetkilendirme

- Kullanıcı işlemleri `UserManager<AppUser>` ve `SignInManager<AppUser>` ile yönetilir.
- Mesaj sayfaları `[Authorize]` ile korunur.
- Mesaj detayına yalnızca mesajın göndereni veya alıcısı erişebilir.
- Giriş yapan kullanıcı bilgileri `User.Identity` ve `UserManager` üzerinden alınır.

### Kullanıcıya Özel Önemli Mesaj Yönetimi

Gönderen ve alıcının aynı mesaj üzerindeki önemli işareti birbirinden bağımsız tutulur:

- `SenderIsImportant`
- `ReceiverIsImportant`

Bu sayede bir kullanıcının mesajı önemli yapması diğer kullanıcının hesabını etkilemez.

### Soft Delete ve Kalıcı Silme

Mesaj silme işlemi gönderen ve alıcı için bağımsız çalışır:

- `SenderIsDeleted`
- `ReceiverIsDeleted`
- `SenderIsPermanentlyDeleted`
- `ReceiverIsPermanentlyDeleted`

Bir kullanıcı mesajı sildiğinde diğer kullanıcının mesajı korunur. Fiziksel veritabanı kaydı yalnızca iki taraf da mesajı kalıcı olarak sildiğinde kaldırılır.

### Asenkron Veri Erişimi

Veritabanı işlemlerinde `ToListAsync()`, `FirstOrDefaultAsync()` ve `SaveChangesAsync()` kullanılarak asenkron programlama uygulanmıştır.

## 📁 Proje Yapısı

```text
IdentityChatMail/
├── Context/
│   └── MailContext.cs
├── Controllers/
│   ├── LoginController.cs
│   ├── MessageController.cs
│   ├── ProfileController.cs
│   └── RegisterController.cs
├── Entities/
│   ├── AppUser.cs
│   └── Message.cs
├── Migrations/
├── Models/
├── Views/
│   ├── Login/
│   ├── Message/
│   │   ├── CreateMessage.cshtml
│   │   ├── Drafts.cshtml
│   │   ├── Important.cshtml
│   │   ├── Inbox.cshtml
│   │   ├── MessageDetails.cshtml
│   │   ├── Sendbox.cshtml
│   │   └── Trash.cshtml
│   ├── Register/
│   └── Shared/
│       └── _MessageLayout.cshtml
├── wwwroot/
├── appsettings.json
└── Program.cs
```

## 🗄️ Veritabanı Yapısı

Projede ASP.NET Core Identity kullanıcı tabloları ile `Messages` tablosu kullanılmaktadır. `AppUser`, `IdentityUser` sınıfını genişletir ve ad, soyad, şehir ve profil fotoğrafı gibi ek alanlar içerir.

### MSSQL Veritabanı Diyagramı

<p align="center">
  <img width="900" alt="MSSQL veritabanı diyagramı" src="https://github.com/user-attachments/assets/a4bd2880-bf3c-4780-89e6-d1a3b152e2e5" />
</p>

## 🖼️ Ekran Görüntüleri

### Kayıt ve Giriş

| Kayıt Ol | Giriş Yap |
| --- | --- |
| <img alt="Kayıt ol" src="https://github.com/user-attachments/assets/eb3d1d21-cbd7-4534-90d4-f2625a2486b6" /> | <img alt="Giriş yap" src="https://github.com/user-attachments/assets/83aeed40-1d87-44ed-ba9f-0f50e9b3e7b5" /> |

<details>
<summary><strong>Tüm uygulama ekranlarını göster</strong></summary>

<br />

<p align="center">
  <img width="900" alt="Uygulama ekranı 1" src="https://github.com/user-attachments/assets/1ba7177c-370a-427c-8a52-caa7650a1b42" />
</p>

<p align="center">
  <img width="900" alt="Uygulama ekranı 2" src="https://github.com/user-attachments/assets/a4e79cfb-801e-4b95-8f12-ca6bae7a4e5c" />
</p>

<p align="center">
  <img width="900" alt="Uygulama ekranı 3" src="https://github.com/user-attachments/assets/daa4bb93-3783-4f7e-abc5-fab4f07b0a95" />
</p>

<p align="center">
  <img width="900" alt="Uygulama ekranı 4" src="https://github.com/user-attachments/assets/fd56c255-d6ee-4f0e-9a45-3d86903be356" />
</p>

<p align="center">
  <img width="900" alt="Uygulama ekranı 5" src="https://github.com/user-attachments/assets/f8f8e2b7-803b-4676-96a7-a998e94b3fb8" />
</p>

<p align="center">
  <img width="900" alt="Uygulama ekranı 6" src="https://github.com/user-attachments/assets/2be9bae7-657b-47a8-8002-dd548be5e59a" />
</p>

<p align="center">
  <img width="900" alt="Uygulama ekranı 7" src="https://github.com/user-attachments/assets/c6ca5fdd-5278-4aff-9d6b-bce0675bd4d6" />
</p>

<p align="center">
  <img width="900" alt="Uygulama ekranı 8" src="https://github.com/user-attachments/assets/067b3c58-6953-460f-aa94-e472b31ffbc7" />
</p>

<p align="center">
  <img width="900" alt="Uygulama ekranı 9" src="https://github.com/user-attachments/assets/23b99311-8a8a-46a8-b0cd-7591c2bbea6c" />
</p>

<p align="center">
  <img width="900" alt="Uygulama ekranı 10" src="https://github.com/user-attachments/assets/30c498ba-3845-4f92-b948-6bfd0d85734d" />
</p>

<p align="center">
  <img width="900" alt="Uygulama ekranı 11" src="https://github.com/user-attachments/assets/aad1d6a9-841f-4049-a135-406ecf957cf2" />
</p>

<p align="center">
  <img width="900" alt="Uygulama ekranı 12" src="https://github.com/user-attachments/assets/5c6906fd-babf-4099-b812-65a56eb0d70b" />
</p>

<p align="center">
  <img width="900" alt="Uygulama ekranı 13" src="https://github.com/user-attachments/assets/b19ed3b7-aebc-4230-a7f7-8ff7e5ac0a4a" />
</p>

</details>

## 🚀 Kurulum

### Gereksinimler

- .NET SDK
- Microsoft SQL Server
- Visual Studio veya Visual Studio Code
- Entity Framework Core CLI araçları

### Projeyi Çalıştırma

1. Repoyu klonlayın:

```bash
git clone https://github.com/DemhatYoldas/IdentityChatMail.git
cd IdentityChatMail
```

2. NuGet paketlerini geri yükleyin:

```bash
dotnet restore
```

3. `appsettings.json` dosyasındaki bağlantı dizesini kendi SQL Server ortamınıza göre düzenleyin:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=IdentityChatMailDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

> Bağlantı dizesinin projedeki gerçek adı farklıysa mevcut anahtar adını koruyun.

4. Migration'ları uygulayın:

```bash
dotnet ef database update
```

5. Uygulamayı çalıştırın:

```bash
dotnet run
```

## 🔒 Güvenlik Notları

- Gerçek veritabanı şifrelerini repoya göndermeyin.
- Hassas bilgileri User Secrets veya environment variable ile saklayın.
- `appsettings.Development.json` ve bağlantı dizesi dosyalarını paylaşmadan önce kontrol edin.
- Ekran görüntülerinde gerçek kullanıcı e-postaları veya kişisel bilgiler kullanmayın.

## 🗺️ Gelecekte Eklenebilecek Özellikler

- Taslak mesajları düzenleme
- Sayfalama ve okunmamış mesaj sayacı
- Toplu mesaj seçme ve silme
- Dosya ve görsel eki gönderme
- SignalR ile gerçek zamanlı bildirimler
- Mesaj yanıtlama ve yönlendirme
- Unit ve integration testleri
- Çoklu dil desteği

## 🙏 Teşekkür

Bu proje, **M&Y Yazılım Eğitim Akademi Danışmanlık** bünyesinde **Murat Yücedağ** hocamızdan aldığım eğitim kapsamında geliştirilmiştir. Bilgi ve deneyimleriyle gelişimime katkı sağlayan Murat Yücedağ hocama ve M&Y Yazılım Eğitim Akademi Danışmanlık ekibine teşekkür ederim.

## 🌍 English

### About

**Identity Chat & Mail** is an ASP.NET Core MVC messaging application that allows users to securely register, sign in, and exchange messages using registered email addresses.

The application includes inbox and sent messages, read-status tracking, user-specific important states, drafts, LINQ-based search, soft delete, trash, restore, permanent deletion, SweetAlert2 notifications, and a responsive interface.

### Technology Stack

C# • ASP.NET Core MVC • ASP.NET Core Identity • Entity Framework Core • Microsoft SQL Server • LINQ • Razor Views • HTML5 • CSS3 • Bootstrap • JavaScript • SweetAlert2 • Dependency Injection • Async/Await • Code First Migrations

### Installation

```bash
git clone https://github.com/DemhatYoldas/IdentityChatMail.git
cd IdentityChatMail
dotnet restore
dotnet ef database update
dotnet run
```

Update the connection string in `appsettings.json` before applying the migrations.

## 👨‍💻 Geliştirici / Developer

**Demhat Yoldaş**

- GitHub: [github.com/DemhatYoldas](https://github.com/DemhatYoldas)
- Website: [demhat.dev](https://demhat.dev)

---

<div align="center">
Bu proje eğitim ve portföy amacıyla geliştirilmiştir.<br />
Developed for educational and portfolio purposes.
</div>
