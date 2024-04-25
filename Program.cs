using ClassLibraryLabor10;

namespace laba12._1
{
    internal class Program
    {
        private static void PrintMenu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Сформировать двунаправленный список");
            Console.WriteLine("2. Распечатать полученный список");
            Console.WriteLine("3. Выполнить обработку списка в соответствии с заданием");
            Console.WriteLine("4. Распечатать полученный список");
            Console.WriteLine("5. Выполнить глубокое клонирование списка");
            Console.WriteLine("6. Удалить список из памяти");
            Console.WriteLine("Выберите действие (1-6):");
        }
        static void Main(string[] args)
        {
            MyList<Musicalinstrument>? list = null;
            int answer = 0;

            while (answer != 6)
            {
                try
                {
                    PrintMenu();
                    answer = int.Parse(Console.ReadLine());

                    switch (answer)
                    {
                        case 1:
                            Console.WriteLine("Введите размер коллекции:");
                            int size = int.Parse(Console.ReadLine());
                            list = new MyList<Musicalinstrument>(size);
                            Console.WriteLine("Список создан.");
                            break;
                        case 2:
                           
                            list.PrintList();
                            Console.WriteLine("Список распечатан");
                            break;
                        case 3:
                            Console.WriteLine("1. Удалить из списка последний элемент с заданным информационным полем");
                            Console.WriteLine("2. Добавить в список элемент после элемента с заданным информационным полем");
                            int choice = int.Parse(Console.ReadLine());

                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Введите имя музыкального инструмента для удаления:");
                                    string name = Console.ReadLine();

                                    Console.WriteLine("Введите ID музыкального инструмента для удаления:");
                                    int idNumber;
                                    while (!int.TryParse(Console.ReadLine(), out idNumber))
                                    {
                                        Console.WriteLine("Неверный формат ID. Пожалуйста, введите целое число:");
                                    }

                                    IdNumber id = new IdNumber(idNumber);
                                    Musicalinstrument itemToRemove = new Musicalinstrument(name, id.number);

                                    list.RemoveLastItemWithFieldValue(itemToRemove);
                                    Console.WriteLine("Элемент удален.");
                                    break;
                                case 2:
                                    Console.WriteLine("Введите значение элемента, после которого нужно добавить новый элемент:");

                                    Musicalinstrument afterValue = new Musicalinstrument();
                                    afterValue.Init(); 

                                    Console.WriteLine("Введите новое значение для добавления:");
                                    Musicalinstrument newValue = new Musicalinstrument();
                                    newValue.Init(); 

                                    list.AddAfterItem(afterValue, newValue);
                                    Console.WriteLine("Элемент добавлен.");
                                    break;
                                default:
                                    Console.WriteLine("Неверный выбор. Повторите попытку.");
                                    break;
                            }
                            break;
                        case 4:
                            list.PrintList();
                            break;
                        case 5:
                            MyList<Musicalinstrument> clonedList = list.Clone();
                            Console.WriteLine("Список склонирован.");
                            break;
                        case 6:
                            list = null;
                            Console.WriteLine("Список удален из памяти.");
                            break;
                        default:
                            Console.WriteLine("Неверный ввод. Повторите попытку.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
