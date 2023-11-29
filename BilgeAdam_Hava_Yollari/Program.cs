namespace BilgeAdam_Hava_Yollari
{
    internal class Program
    {
        static string[] business = { "", "", "", "", "", "", "", "" };
        static string[] economy = { "", "", "", "", "", "", "", "", "", "", "", "" };
        static int koltukSecim, businessSayac = 0, economySayac = 0;
        static string isim, tus;
        static void Main(string[] args)
        {

            AnaMenu();
            KoltukKontrol();
            IsimAl();
            Rezervasyon();
            Main(null);
            Console.ReadLine();
        }
        /// <summary>
        /// Ekrana Hoşgeldin yazısı, eğer boş yer varsa classın seçeneğini, eğer tüm uçuş dolduysa dolduğunu yazar.
        /// </summary>
        static void AnaMenu()
        {
            Console.WriteLine("********** Bilge Adam Hava Yollarına Hoş Geldiniz **********");
            if (economySayac != economy.Length && businessSayac != business.Length)
            {
                Console.WriteLine("Business Class için 1'e basınız.");
                Console.WriteLine("Economy Class için 2'ye basınız.");
            }
            else if (economySayac == economy.Length && businessSayac != business.Length)
            {
                Console.WriteLine("Business Class için 1'e basınız.");
            }
            else if (economySayac != economy.Length && businessSayac == business.Length)
            {
                Console.WriteLine("Economy Class için 2'ye basınız.");
            }
            else
            {
                Console.WriteLine("Bütün koltuklar dolmuştur. İlginiz için teşekkür ederiz.");
                Cikis();
            }
            tus = Console.ReadLine();
            switch (tus)
            {
                case "1":
                case "2":
                    break;
                default:
                    Console.WriteLine("Lütfen geçerli bir seçim yapınız.");
                    AnaMenu();
                    break;
            }
        }
        /// <summary>
        /// Kullanıcıdan isim alır. Kelime içinde sayı varsa tekrar ister.
        /// </summary>
        static void IsimAl()
        {
            Console.WriteLine("İsminizi giriniz: ");
            isim = Console.ReadLine();
            for (int i = 0; i < isim.Length; i++)
            {
                if (char.IsDigit(isim[i]))
                {
                    Console.WriteLine("İsminizin içinde sayısal karakter girdiniz. Lütfen isminizi tekrar giriniz.");
                    IsimAl();
                }
            }
        }
        /// <summary>
        /// Business veya Economy Class için  koltuk yönlendirmesi.
        /// </summary>
        static void KoltukKontrol()
        {
            if (tus == "1")
            {
                BusinessKoltukKontrol();
            }
            else
            {
                EconomyKoltukKontrol();
            }
        }
        /// <summary>
        /// Business Class Koltukları için ekrana yazdırma. Dolu ise kim tarafından dolu olduğunu yazdırır.
        /// </summary>
        private static void BusinessKoltukKontrol()
        {
            for (int i = 0; i < business.Length; i++)
            {
                Console.WriteLine(business[i] == "" ? $"{i + 1}. koltuk boştur." : $"{i + 1}. koltuk {business[i]} tarafından doldurulmuştur.");
            }
            Console.WriteLine(businessSayac == business.Length ? "Business Class uçuşumuz dolmuştur!" : "Yerimiz mevcuttur.");
        }
        /// <summary>
        /// Economy Class Koltukları için ekrana yazdırma. Dolu ise kim tarafından dolu olduğunu yazdırır.
        /// </summary>
        static void EconomyKoltukKontrol()
        {
            for (int i = 0; i < economy.Length; i++)
            {
                Console.WriteLine(economy[i] == "" ? $"{i + 1}. koltuk boştur." : $"{i + 1}. koltuk {economy[i]} tarafından doldurulmuştur.");
            }
            Console.WriteLine(economySayac == economy.Length ? "Economy Class uçuşumuz dolmuştur!" : "Yerimiz mevcuttur.");
        }
        /// <summary>
        /// Kullanıcının isteğine göre uygulamadan çıkartır.
        /// </summary>
        static void Cikis()
        {
            Console.WriteLine("Seçilecek koltuk kalmamıştır. Uygulamadan çıkmak için exit yazınız.");
            string cikis = Console.ReadLine().ToLower();
            if (cikis == "exit") Environment.Exit(0);

        }
        /// <summary>
        /// Boş koltuklara Kişi yerleştirmesi yapar. Doluysa kim tarafından doldurulduğunun uyarısını yazar.
        /// </summary>
        static void Rezervasyon()
        {

            Console.WriteLine("Oturmak istediğiniz koltuğu seçiniz:");
            
            try
            {
                koltukSecim = int.Parse(Console.ReadLine()) - 1;

                if (tus == "1")
                {
                    if (business[koltukSecim] == "")
                    {
                        business[koltukSecim] = isim;
                        businessSayac++;
                    }
                    else
                    {
                        Console.WriteLine($"Seçtiğiniz koltuk {business[koltukSecim]} tarafından doludur. Lütfen başka bir koltuk seçiniz.");
                        Rezervasyon();
                    }
                }
                else
                {
                    if (economy[koltukSecim] == "")
                    {
                        economy[koltukSecim] = isim;
                        economySayac++;
                    }
                    else
                    {
                        Console.WriteLine($"Seçtiğiniz koltuk {economy[koltukSecim]} tarafından doludur. Lütfen başka bir koltuk seçiniz.");
                        Rezervasyon();
                    }
                }
                KoltukKontrol();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Bu numarada bir koltuk bulunmamaktadır. Lütfen başka bir koltuk numarası deneyiniz.");
                Rezervasyon();
            }
            catch (FormatException)
            {
                Console.WriteLine("Harf veya işaret kullandınız. Lütfen sayısal bir değer giriniz.");
                Rezervasyon();
            }
        }
    }
}
