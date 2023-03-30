using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        public struct UserRegister
        {
            public string Name;
            public DateTime Birthday;
            public string StreetName;
            public UInt32 AddressNumber;
        }
        public enum Resultado_e
        {
            Success = 0,
            Exit = 1,
            Exception = 2,
        }
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Pree any key to continue");
            Console.ReadKey(true);
            Console.Clear();
        }
        public static Resultado_e CatchString(ref string MyString, string message)
        {
            Resultado_e retorno;
            Console.WriteLine(message);
            string temp = Console.ReadLine();
            if (temp == "s" || temp == "S")
                retorno = Resultado_e.Exit;
            else
            {
                MyString = temp;
                retorno  = Resultado_e.Success;
            }
            Console.Clear();
            return retorno;
        }
        public static Resultado_e CatchDate(ref DateTime data, string message)
        {
            Resultado_e retorno;
            do
            {
                try
                {
                    Console.WriteLine(message);
                    string temp = Console.ReadLine();
                    if (temp == "s" || temp == "S")
                        retorno = Resultado_e.Exit;
                    else
                    {
                        data = Convert.ToDateTime(temp);
                        retorno = Resultado_e.Success;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("EXCEÇÃO: " + e.Message);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    retorno = Resultado_e.Exception;
                }
            } while (retorno == Resultado_e.Exception);
            Console.Clear();
            return retorno;
        }
        public static Resultado_e CatchInt(ref UInt32 data, string message)
        {
            Resultado_e retorno;
            do
            {
                try
                {
                    Console.WriteLine(message);
                    string temp = Console.ReadLine();
                    if (temp == "s" || temp == "S")
                        retorno = Resultado_e.Exit;
                    else
                    {
                        data = Convert.ToUInt32(temp);
                        retorno = Resultado_e.Success;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("EXCEÇÃO: " + e.Message);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    retorno = Resultado_e.Exception;
                }
            } while (retorno == Resultado_e.Exception);
            Console.Clear();
            return retorno;
        }
        public static void RegisterUser(ref List<UserRegister> Users)
        {
            UserRegister regUser;
            regUser.Name = "";
            regUser.Birthday = new DateTime();
            regUser.StreetName = "";
            regUser.AddressNumber = 0;
            if (CatchString(ref regUser.Name, "Digite o nome completo ou S para sair") != Resultado_e.Success)
                return;
            if (CatchDate(ref regUser.Birthday, "Digite a data de nascimento (MM/DD/AAAA) ou S para sair") != Resultado_e.Success)
                return;
            if (CatchString(ref regUser.StreetName, "Digite o nome da rua ou S para sair") != Resultado_e.Success)
                return;
            if (CatchInt(ref regUser.AddressNumber, "Digite o número da casa ou S para sair") != Resultado_e.Success)
                return;
            Users.Add(regUser);
        }
        static void Main(string[] args)
        {
            List<UserRegister> Users = new List<UserRegister>();
            string option = "";
            do
            {
                Console.Write("Type R to register or E to exit");
                option = Console.ReadKey(true).KeyChar.ToString().ToLower();
                if (option == "r")
                {
                    Console.Clear();
                    RegisterUser(ref Users);
                }
                else if (option == "e")
                {
                    ShowMessage(" = EXITING ==========");
                }
                else
                {
                    ShowMessage(" = INCORRECT OPTION =");
                }
            } while (option != "e");
        }
    }
}