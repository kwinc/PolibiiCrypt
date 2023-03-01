#region Служебные массивы

char[,] arrMy = new char[,] { { 'а', 'б', 'в', 'г', 'д', 'е', 'ё' },
                              { 'ж', 'з', 'и', 'й', 'к', 'л', 'м' },
                              { 'н', 'о', 'п', 'р', 'с', 'т', 'у' },
                              { 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ' },
                              { 'ы', 'ь', 'э', 'ю', 'я', '.', ',' },
                              { '-', ' ', '!', '?', ':', '(', ')' },
                              { '[', ']', '{', '}', ';', '@', '*' }};

char[] resMy = new char[]     { 'а', 'б', 'в', 'г', 'д', 'е', 'ё' };
 

char[,] arrMur = new char[,] { { 'а', 'б', 'в', 'г', 'д', 'е' },
                            { 'ж', 'з', 'и', 'й', 'к', 'л' },
                            { 'м', 'н', 'о', 'п', 'р', 'с' },
                            { 'т', 'у', 'ф', 'х', 'ц', 'ч' },
                            { 'ш', 'щ', 'ъ', 'ы', 'ь', 'э' },
                            { 'ю', 'я', '.', ',', '?', ' ' }};

char[] resMur = new char[]   { 'а', 'б', 'в', 'г', 'д', 'е' };

#endregion

while (true)
{
    //Шифратор-дешифратор, написанный на коленке. Прогу написать быстрее, чем шифровать всё это самому...

    Console.Write("1 - Шифровать\n2 - Расшифровать\n3 - Завершить работу\nВыбор:");
    byte a = 0;
    try {
        a = Convert.ToByte(Console.ReadLine());
    }
    catch {
        Console.WriteLine("Введите число от 1 до 3\n------------------------------------");
        continue;
    }

    switch (a) {
        case 1:     Console.Write("Шифратор by Паштет - Текст: ");               string textC = Console.ReadLine().ToLower(); Console.WriteLine("Результат по-Муртазински: " + crypt(textC, arrMur, resMur)   + "\nРезультат по-Павлентиски: " + crypt(textC, arrMy, resMy)   + "\n----------------------");   break;
        case 2:     Console.Write("Дешифратор by Ильфат - Шифрованный текст: "); string textD = Console.ReadLine().ToLower(); Console.WriteLine("Результат по-Муртазински: " + decrypt(textD, arrMur, resMur) + "\nРезультат по-Павлентиски: " + decrypt(textD, arrMy, resMy) + "\n----------------------");   break;
        case 3:     Console.WriteLine("Спасибо что пользуетесь надежным ПО!(пожалуйста, не смотрите исходники)");       Environment.Exit(1);                                                        break;
        default:    Console.WriteLine("Нет такой команды");                                                                                                      break;
    }
}


string crypt(string fr, char[,] kek, char[] first) {  
    string res = "";

    double l = Math.Pow(kek.Length, 0.5);

    foreach (char c in fr)
    {
        for (int i = 0; i < l; i++)
        {
            for (int j = 0; j < l; j++)
            {
                if (c == kek[i, j])
                {
                    res += first[i].ToString() + first[j].ToString();
                }
            }
        }
    }
    return res.ToUpper();
}
string decrypt(string fraza, char[,] kek, char[] first) {
    bool flag = true;
    string tek = "";
    string res = "";

    double l = Math.Pow(kek.Length, 0.5);

    foreach (char c in fraza)
    {
        if (flag)
        {
            tek += c;
            flag = false;
            continue;
        }
        else
        {
            tek += c;
            int[] res1 = { 0, 0 };
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < l; i++)
                {
                    if (tek[j] == first[i])
                    {
                        res1[j] = i;
                    }
                }
            }
            res += kek[res1[0], res1[1]];
            flag = true;
            tek = "";
        }
    }
    return res;
}