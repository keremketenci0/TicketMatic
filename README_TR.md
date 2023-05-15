# TicketMatic

# Biletmatik Uygulaması

Bu, C# ve Visual Studio kullanılarak geliştirilmiş bir biletmatik uygulamasıdır. Bu uygulama, kullanıcının bir film seansı için bilet satın almasını sağlar.

## Kullanım

Uygulamayı çalıştırmak için aşağıdaki adımları takip edin:

1. Projeyi Visual Studio'da açın.
2. Program.cs dosyasını bulun ve çalıştırın.
3. Konsol ekranında uygulamanın başlamasını bekleyin.

Uygulama başladığında, aşağıdaki adımları takip ederek bilet satın alabilirsiniz:

1. İlk olarak, adınızı girin. Konsolda size bir mesaj gösterilecektir.
2. Ardından, bilet almak istediğiniz tarihi girin. Konsolda mevcut tarihler listelenecektir ve sizden bir seçim yapmanız istenecektir.
3. Devamında, bilet almak istediğiniz filmi seçin. Konsolda mevcut filmler listelenecektir ve sizden bir seçim yapmanız istenecektir.
4. Sonraki adımda, bilet almak istediğiniz seansı seçin. Konsolda mevcut seanslar listelenecektir ve bir seçim yapmanız istenecektir.
5. Kaç bilet almak istediğinizi belirtmek için bir sayı girin. Konsolda size bir mesaj gösterilecektir.
6. Koltuk seçim ekranı görüntülenecektir. Boş olan koltuklar numaralandırılmış şekilde listelenecektir ve size bir koltuk numarası seçmeniz istenecektir.
7. Ödeme seçim ekranı görüntülenecektir. Konsolda mevcut ödeme yöntemleri listelenecektir ve bir seçim yapmanız istenecektir.

Bütün adımları tamamladıktan sonra, biletlerinizin detayları ekranda görüntülenecektir ve biletinizi onaylamanız istenecektir.

## Sınıflar

Bu proje aşağıdaki sınıflardan oluşmaktadır:

- Program.cs: Ana uygulama dosyasıdır ve kullanıcıyla etkileşim sağlar.
- Movie.cs: Filmleri temsil eden sınıfı içerir.
- Session.cs: Film seanslarını temsil eden sınıfı içerir.
- Hall.cs: Sinema salonlarını temsil eden sınıfı içerir.
- Reservation.cs: Bilet rezervasyonlarını temsil eden sınıfı içerir.

## Önemli Notlar

- Bu uygulama sadece temsili bir amaç taşımaktadır ve gerçek bir bilet rezervasyon sistemi olarak kullanılamaz.
- Uygulamanın veri tabanı veya dosya sistemi üzerinde veri depolama işlemi gerçekleştirmez. Tüm veriler runtime sırasında oluşturulmuş örneklerle temsil edilir.
- Bu uygulama, kullanıcıların doğru girişler yapmasını sağlamak için try-catch yöntemini kullanır. Hatalı girişlerde uygulama çökmez, bunun yerine hata mesajı gösterir ve kullanıcıyı tekrar giriş yapmaya yönlendirir.
- Uygulama, kullanıcının eski seçimlere geri dönebilmesi için while döngüsü kullanır. Kullanıcı istediği zaman geri dönüp farklı bir seçim yapabilir ve bilet işlemlerini yeniden başlatabilir.
- Bu değişiklikler, kullanıcı deneyimini iyileştirmek ve hata yönetimini güçlendirmek için yapılmıştır.
