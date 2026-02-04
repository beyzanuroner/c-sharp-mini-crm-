using System;
using MiniCrm.Services;

class Program
{
    static void Main(string[] args)
    {
        var customerService = new CustomerService();
        bool running = true;

        while (running)
        {
            Console.Clear();
            ShowMenu();

            Console.Write("Seçimin: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddCustomer(customerService);
                    break;
                case "2":
                    ListCustomers(customerService);
                    break;
                case "3":
                    UpdateCustomer(customerService);
                    break;
                case "4":
                    DeleteCustomer(customerService);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    Pause();
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("=== MINI CRM ===");
        Console.WriteLine("1 - Müşteri Ekle");
        Console.WriteLine("2 - Müşterileri Listele");
        Console.WriteLine("3 - Müşteri Güncelle");
        Console.WriteLine("4 - Müşteri Sil");
        Console.WriteLine("5 - Çıkış");
        Console.WriteLine();
    }

    static void AddCustomer(CustomerService service)
    {
        Console.Clear();
        Console.Write("Ad Soyad: ");
        string name = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Telefon: ");
        string phone = Console.ReadLine();

        Console.Write("Notlar: ");
        string notes = Console.ReadLine();

        bool success = service.Add(name, email, phone, notes);

        Console.WriteLine(success
            ? "Müşteri eklendi."
            : "Müşteri eklenemedi. Bilgileri kontrol edin.");

        Pause();
    }

    static void ListCustomers(CustomerService service)
    {
        Console.Clear();
        var customers = service.GetAll();

        if (customers.Count == 0)
        {
            Console.WriteLine("Henüz müşteri yok.");
        }
        else
        {
            foreach (var c in customers)
            {
                Console.WriteLine($"{c.Id}. {c.FullName} | {c.Email} | {c.Phone}");
            }
        }

        Pause();
    }

    static void UpdateCustomer(CustomerService service)
    {
        Console.Clear();
        Console.Write("Güncellenecek müşteri ID: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Pause();
            return;
        }

        Console.Write("Yeni Ad Soyad: ");
        string name = Console.ReadLine();

        Console.Write("Yeni Email: ");
        string email = Console.ReadLine();

        Console.Write("Yeni Telefon: ");
        string phone = Console.ReadLine();

        Console.Write("Yeni Notlar: ");
        string notes = Console.ReadLine();

        bool success = service.Update(id, name, email, phone, notes);

        Console.WriteLine(success
            ? "Müşteri güncellendi."
            : "Müşteri güncellenemedi.");

        Pause();
    }

    static void DeleteCustomer(CustomerService service)
    {
        Console.Clear();
        Console.Write("Silinecek müşteri ID: ");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            bool success = service.Delete(id);

            Console.WriteLine(success
                ? "Müşteri silindi."
                : "Müşteri bulunamadı.");
        }

        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("\nDevam etmek için bir tuşa bas...");
        Console.ReadKey();
    }
}
