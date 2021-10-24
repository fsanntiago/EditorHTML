using System;
using System.IO;
using System.Text;

namespace EditorHTML
{
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("-----------");
        }

        public static void WriteFile(string? text)
        {
            Show();
            if (text != null)
                Console.Write(text);

            var file = new StringBuilder(text);

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Viewer.Show(file.ToString());
            Save(file);
        }

        public static void Save(StringBuilder file)
        {
            Console.WriteLine("Deseja salvar o arquivo?");
            Console.WriteLine("[S]Sim - [N]Não");

            var res = char.Parse(Console.ReadLine().ToUpper());

            if (res != 'S')
            {
                Console.Clear();
                Menu.Show();
            }
            Console.Clear();
            Console.WriteLine("Salvar em qual caminho?");
            var path = Console.ReadLine();

            using (var filewriter = new StreamWriter(path))
            {
                filewriter.Write(file);
            }

            Console.WriteLine("");
            Console.WriteLine($"Arquivo {path} salvo com sucesso!");

            Console.ReadKey();
            Menu.Show();
        }

        public static void EditFile(string path)
        {
            Console.WriteLine("Deseja editar esse arquivo?");
            Console.WriteLine("[S]Sim - [N]Não");

            var res = char.Parse(Console.ReadLine().ToUpper());
            if (res != 'S')
            {
                Console.Clear();
                Menu.Show();
            }

            using var file = new StreamReader(path);
            var text = new StringBuilder(file.ReadToEnd());
            WriteFile(text.ToString());
        }

        public static void OpenFile()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            var path = Console.ReadLine();

            Console.WriteLine($"VISUALIZANDO ARQUIVO O {path}. . .");
            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine("");
                Console.WriteLine(text);
            }
            Console.WriteLine("");

            EditFile(path);
        }
    }
}