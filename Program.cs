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
        }

        static void Main(string[] args)
        {
            MyList<Musicalinstrument>? list = null;
            int answer = 0;
            
            while (answer != 3)
            {
                PrintMenu();
                answer = int.Parse(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        if (list == null)
                        {
                            Console.WriteLine("Введите размер коллекции:");
                            int size = int.Parse(Console.ReadLine());
                            list = new MyList<Musicalinstrument>(size);
                            Console.WriteLine("Список создан.");
                        }
                        else
                        {
                            Console.WriteLine("Список уже существует. Пожалуйста, выберите другую опцию.");
                        }
                        break;

                    case 2:
                        if (list == null)
                        {
                            Console.WriteLine("Список не существует. Пожалуйста, выберите пункт 1 для создания списка.");
                        }
                        else if (list.Count == 0)
                        {
                            Console.WriteLine("Список пустой.");
                        }
                        else
                        {
                            list.PrintList();
                            Console.WriteLine("Список распечатан");
                            int subAnswer = 0;
                            while (subAnswer != 5)
                            {
                                Console.WriteLine("1. Удалить из списка последний элемент с заданным информационным полем");
                                Console.WriteLine("2. Добавить в список элемент после элемента с заданным информационным полем");
                                Console.WriteLine("3. Выполнить глубокое клонирование списка");
                                Console.WriteLine("4. Распечатать полученный список");
                                Console.WriteLine("5. Удалить список из памяти");
                                Console.WriteLine("6. Вернуться в главное меню");
                                subAnswer = int.Parse(Console.ReadLine());

                                switch (subAnswer)
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

                                    case 3:
                                        if (list != null && list.Count > 0)
                                        {
                                            MyList<Musicalinstrument> clonedList = list.Clone();
                                            Console.WriteLine("Список склонирован.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Список пустой или не создан. Пожалуйста, создайте список сначала.");
                                        }
                                        break;

                                    case 4:
                                        list.PrintList();
                                        Console.WriteLine("Список распечатан");
                                        break;

                                    case 5:
                                        try
                                        {
                                            MyList<Musicalinstrument>.lists.Remove(list);
                                            list = null;
                                            Console.WriteLine("Удаление произведено");
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                        break;
                                    case 6:
                                        break;

                                    default:
                                        Console.WriteLine("Неверный ввод. Повторите попытку.");
                                        break;
                                }
                            }
                        }
                        break;

                    

                    default:
                        Console.WriteLine("Неверный ввод. Повторите попытку.");
                        break;
                }
            }
        }
    }
}