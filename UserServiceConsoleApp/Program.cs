// See https://aka.ms/new-console-template for more information
using RestSharp;
using UserServiceConsoleApp.Service;

UserCollectionService service = new UserCollectionService();
while (true)
{
    Console.Write("\n1 - Создать пользователя\n2 - Удалить пользователя\n3 - Изменить статус пользователя\n4 - Получить данные о пользователе\nВведите номер действия:");
    string actionNumber = Console.ReadLine();
    RestResponse response;
    switch (actionNumber)
    {
        case "1":
            Console.Write("Введите имя пользователя: ");
            string name = Console.ReadLine();
            Console.Write("\n1 - New\n2 - Acive\n3 - Blocked\n4 - Deleted\nВыберите статус пользователя: ");
            string status = Console.ReadLine();
            response = service.CreateUser(name, status);
            Console.WriteLine($"\n{response.Content}\n");
            break;
        case "2":
            Console.Write("Введите ID пользователя для удаления: ");
            string id = Console.ReadLine();
            response = service.RemoveUser(id);
            Console.WriteLine($"\n{response.Content}\n");
            break;
        case "3":
            Console.Write("Введите ID пользователя для изменения статуса: ");
            string userId = Console.ReadLine();
            Console.Write("\n1 - New\n2 - Acive\n3 - Blocked\n4 - Deleted\nВыберите новый статус пользователя: ");
            string newStatus = Console.ReadLine();
            response = service.SetStatus(userId, newStatus);
            Console.WriteLine($"\n{response.Content}\n");
            break;
        case "4":
            Console.Write("Введите ID пользователя: ");
            userId = Console.ReadLine();
            response = service.UserInfo(userId);
            Console.WriteLine($"\n{response.Content}\n");
            break;

    }
}



