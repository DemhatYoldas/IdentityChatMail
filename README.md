# Identity Chat & Mail

![C#](https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=csharp&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity_Framework_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Microsoft SQL Server](https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)



Identity Chat & Mail

---


### Proje Hakkında

Identity Chat & Mail; kullanıcıların güvenli biçimde kayıt olabildiği, giriş yapabildiği ve sistemdeki diğer kullanıcılara mesaj gönderebildiği ASP.NET Core MVC tabanlı bir mesajlaşma uygulamasıdır.

Proje; ASP.NET Core Identity ile kimlik doğrulama, Entity Framework Core ile veri erişimi, Microsoft SQL Server ile veri saklama ve Razor Views ile kullanıcı arayüzü geliştirme konularını uygulamalı olarak pekiştirmek amacıyla geliştirilmiştir.

Uygulamada yalnızca temel mesaj gönderme işlemleri değil; okundu bilgisi, önemli mesajlar, taslaklar, arama, kullanıcıya özel çöp kutusu, geri yükleme ve kalıcı silme gibi gerçek bir mesajlaşma uygulamasında ihtiyaç duyulan özellikler de bulunmaktadır.

### Özellikler

- Kullanıcı kaydı
- Kullanıcı girişi ve güvenli çıkış
- ASP.NET Core Identity tabanlı kimlik doğrulama
- Yetkisiz sayfa ve mesaj erişiminin engellenmesi
- Giriş yapan kullanıcının profil bilgilerinin ve fotoğrafının gösterilmesi
- Kullanıcılara e-posta adresleri üzerinden mesaj gönderme
- Gelen kutusu
- Gönderilen mesajlar
- Mesaj detaylarını görüntüleme
- Mesajı alıcı açtığında okundu bilgisinin güncellenmesi
- Gönderen ve alıcı için bağımsız önemli mesaj yönetimi
- Mesajları önemli yapma ve önemden çıkarma
- Mesajları taslak olarak kaydetme
- Taslak mesajları listeleme
- Konu, mesaj içeriği ve gönderen adresinde `Contains()` ile arama
- Gönderen ve alıcı için bağımsız soft delete yapısı
- Mesajları çöp kutusuna taşıma
- Çöp kutusundaki mesajları geri yükleme
- Kullanıcı tarafında kalıcı silme
- Her iki kullanıcı da kalıcı olarak sildiğinde fiziksel kaydı veritabanından kaldırma
- TempData ve SweetAlert2 ile kullanıcı bildirimleri
- Model doğrulama mesajları
- Tarihlerin Türkçe kültür bilgisiyle gösterilmesi
- Responsive ve modern mor-beyaz kullanıcı arayüzü
- Profil fotoğrafı yoksa varsayılan kullanıcı simgesi gösterimi

### Kullanılan Teknolojiler

| Teknoloji | Kullanım amacı |
| --- | --- |
| C# | Uygulama ve iş mantığı |
| ASP.NET Core MVC | Web uygulaması mimarisi |
| ASP.NET Core Identity | Kayıt, giriş, çıkış ve kullanıcı yönetimi |
| Entity Framework Core | ORM ve veri erişimi |
| Microsoft SQL Server | İlişkisel veritabanı |
| LINQ | Mesaj sorguları, filtreleme ve sıralama |
| Razor Views | Dinamik kullanıcı arayüzleri |
| HTML5 ve CSS3 | Sayfa yapısı ve özel tasarım |
| Bootstrap | Grid sistemi, form ve buton bileşenleri |
| JavaScript | Kullanıcı etkileşimleri |
| SweetAlert2 | Başarı, hata, uyarı ve bilgi bildirimleri |
| Dependency Injection | Servis ve bağımlılık yönetimi |
| Async/Await | Asenkron veritabanı işlemleri |
| Code First Migrations | Veritabanı şemasının sürümlenmesi |

### Uygulanan Teknik Yaklaşımlar

#### Kimlik Doğrulama ve Yetkilendirme

- Kullanıcı işlemleri `UserManager<AppUser>` ve `SignInManager<AppUser>` ile yönetilir.
- Mesaj sayfaları `[Authorize]` ile korunur.
- Bir mesajın detayını yalnızca mesajın göndereni veya alıcısı görüntüleyebilir.
- Giriş yapan kullanıcının bilgileri `User.Identity` ve `UserManager` üzerinden alınır.

#### Kullanıcıya Özel Önemli Mesaj Yönetimi

Gönderen ve alıcının aynı mesaj üzerindeki önemli işareti birbirinden bağımsız tutulur:

- `SenderIsImportant`
- `ReceiverIsImportant`

Bu sayede bir kullanıcının mesajı önemli yapması diğer kullanıcının hesabını etkilemez.

#### Soft Delete ve Kalıcı Silme

Mesaj silme işlemi gönderen ve alıcı için bağımsız çalışır:

- `SenderIsDeleted`
- `ReceiverIsDeleted`
- `SenderIsPermanentlyDeleted`
- `ReceiverIsPermanentlyDeleted`

Bir kullanıcı mesajı sildiğinde mesaj diğer kullanıcının kutusundan kaybolmaz. Fiziksel veritabanı kaydı yalnızca iki taraf da mesajı kalıcı olarak sildiğinde kaldırılır.

#### Arama

Gelen kutusunda aşağıdaki alanlar Entity Framework Core ve LINQ `Contains()` metodu kullanılarak aranabilir:

- Mesaj konusu
- Mesaj içeriği
- Gönderen e-posta adresi

#### Asenkron Veri Erişimi

Veritabanı işlemlerinde `ToListAsync()`, `FirstOrDefaultAsync()` ve `SaveChangesAsync()` kullanılarak asenkron programlama uygulanmıştır.

### Proje Yapısı

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

### Veritabanı Yapısı

Projede temel olarak Identity kullanıcı tabloları ile `Messages` tablosu kullanılmaktadır. `AppUser`, ASP.NET Core Identity'nin `IdentityUser` sınıfını genişletir ve ad, soyad, şehir ve profil fotoğrafı gibi ek alanları içerir.

#### MSSQL Veritabanı Diyagramı

![MSSQL Database Diagram](docs/screenshots/database-diagram.png)

### Ekran Görüntüleri

Ekran görüntülerini `docs/screenshots` klasörüne aşağıdaki isimlerle ekleyebilirsiniz.

#### Kayıt ve Giriş

| Kayıt Ol | Giriş Yap |
| --- | --- |
| ![Kayıt Ol](docs/screenshots/register.png) | ![Giriş Yap](docs/screenshots/login.png) |

#### Mesaj Kutuları

| Gelen Kutusu | Gönderilenler |
| --- | --- |
| ![Gelen Kutusu](docs/screenshots/inbox.png) | ![Gönderilenler](docs/screenshots/sendbox.png) |

#### Mesaj İşlemleri

| Yeni Mesaj | Mesaj Detayı |
| --- | --- |
| ![Yeni Mesaj](docs/screenshots/create-message.png) | ![Mesaj Detayı](docs/screenshots/message-details.png) |

#### Önemli Mesajlar ve Taslaklar

| Önemli Mesajlar | Taslaklar |
| --- | --- |
| ![Önemli Mesajlar](docs/screenshots/important.png) | ![Taslaklar](docs/screenshots/drafts.png) |

#### Çöp Kutusu ve Arama

| Çöp Kutusu | Mesaj Arama |
| --- | --- |
| ![Çöp Kutusu](docs/screenshots/trash.png) | ![Mesaj Arama](docs/screenshots/search.png) |

### Kurulum

#### Gereksinimler

- .NET SDK
- Microsoft SQL Server
- Visual Studio veya Visual Studio Code
- Entity Framework Core CLI araçları

#### Projeyi Çalıştırma

1. Repoyu klonlayın:

```bash
git clone <repository-url>
cd IdentityChatMail
```

2. NuGet paketlerini geri yükleyin:

```bash
dotnet restore
```

3. `appsettings.json` dosyasındaki bağlantı dizesini kendi SQL Server ortamınıza göre düzenleyin.

Örnek:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=IdentityChatMailDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

> Bağlantı dizesinin projedeki gerçek adı farklıysa mevcut anahtar adını koruyun.

4. Veritabanını oluşturun ve migration'ları uygulayın:

```bash
dotnet ef database update
```

5. Uygulamayı çalıştırın:

```bash
dotnet run
```

### Güvenlik Notları

- Gerçek veritabanı şifrelerini repoya göndermeyin.
- Üretim ortamında hassas bilgileri User Secrets veya environment variable ile saklayın.
- `appsettings.Development.json` ve bağlantı dizesi dosyalarını paylaşmadan önce kontrol edin.
- Ekran görüntülerinde gerçek kullanıcı e-postaları veya kişisel bilgiler kullanmayın.

### Gelecekte Eklenebilecek Özellikler

- Taslak mesajları düzenleme
- Sayfalama
- Okunmamış mesaj sayacı
- Toplu mesaj seçme ve silme
- Dosya ve görsel eki gönderme
- Gerçek zamanlı bildirimler ve SignalR
- Kullanıcı engelleme
- Mesaj yanıtlama ve yönlendirme
- Unit ve integration testleri
- Çoklu dil desteği

### Geliştirici

**Demhat Yoldaş**

- GitHub: [github.com/DemhatYoldas](https://github.com/DemhatYoldas)
- Web: [demhat.dev](https://demhat.dev)

---

