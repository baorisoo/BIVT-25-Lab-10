namespace Lab10
{
    public class Program
    {
        public static void Main()
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //путь до папки рабочего стола
            Console.WriteLine($"folderPath: {folderPath}");

            string fileName = "example.txt";
            string fullPath = Path.Combine( folderPath, fileName ); //берет все части пути и соединяет в полный путь до файла
            Console.WriteLine($"fullPath: {fullPath}");

            File.Create(fullPath).Close(); //close - закрыть поток
            File.WriteAllText(fullPath, "Hello!" + Environment.NewLine); //написать текст файла, удаляет старое содержимое
            File.AppendAllText(fullPath, "Im debil'."); //добавляем в конец текст

            string[] words = new string[] { "pen", "apple", "pineapple", "penpineappleapplepen" };

            File.WriteAllLines(fullPath, words); //автоматически ставит перенос строки после каждого элемента
            File.AppendAllLines(fullPath, words);

            string content = File.ReadAllText(fullPath); //одна переменная типа string
            string[] lines = File.ReadAllLines(fullPath);

            Console.WriteLine($"content: \n{content}");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            string folderPath2 = Path.Combine(folderPath, "ExampleFolder");
            string filePath = Path.Combine(folderPath2, "anotherExample.txt");

            if (Directory.Exists(folderPath2)) 
            {
                Directory.CreateDirectory(folderPath2); //создаем папку
            }

            string ext = "txt";

            if (File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            else
            {
                File.WriteAllText(filePath, ""); //очистить файл
            }

            //мы знаем только полный путь
            string folderPath3 = Path.GetDirectoryName(filePath); //оставляет только путь до папки (в Path можно выдлить и путь до файла и тд)
            Console.WriteLine($"folderPath3: {folderPath3}");


        }
    }
}
