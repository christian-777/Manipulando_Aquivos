using Manipulando_Aquivos;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        string file;


        Person person = CreatePerson();
        Person person2 = CreatePerson();

        WriteFile(person);
        WriteFile(person2);

        Console.Clear();

        Console.WriteLine("Informe o nome do arquivo: ");
        file= Console.ReadLine();

        var texto = ReadFile(file);

        Console.WriteLine(texto);








        Person CreatePerson()
        {
            Console.Write("informe o nome da pessoa: ");
            var name = Console.ReadLine();

            Console.Write("\ninforme o genero da pessoa: ");
            var gender = char.Parse(Console.ReadLine());


            return  new Person(name, gender);
        }

        void WriteFile(Person person)
        {
            try
            {
                var texto = ReadFile("backup.txt");
                StreamWriter sw = new StreamWriter("backup.txt");
                sw.WriteLine(texto+person.ToString());
                sw.Close();
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                Console.WriteLine("Registro gravado com sucesso!!");
                Thread.Sleep(1000);
            }

        }

        string ReadFile(string file)
        {
            try
            {
                StreamReader sr = new StreamReader(file);
                var text=sr.ReadToEnd();
                sr.Close();
                return text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("arquivo nao encontrado");
            }
            return "";
        }
    }
}