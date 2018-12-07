using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Simple_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            string parsedUser = null;

            while (true)
            {
                // prompt the user for their email address so we can get genuine userNames
                Console.Write("Please enter your Carthage email address: ");
                string username = Console.ReadLine();

                // prompt the user again to ensure they entered the correct email address
                Console.Write("\nPlease re-enter your Carthage email address: ");
                string username2 = Console.ReadLine();

                if (username != username2)
                {
                    Console.WriteLine("\nEmail addresses did not match, please enter them again.");
                    continue;
                }
                else if (!username.Contains("@"))
                {
                    Console.WriteLine("\nPlease enter an email address.");
                    continue;
                }
                else
                {
                    // The email addresses matched, so we can parse the email address to get the username

                    for (int i = 0; i < username.Length; i++)
                    {
                        if (username[i] == '@')
                        {
                            // we no longer need to add to the parsedUser
                            break;
                        }
                        parsedUser += username[i];
                    }

                    // just write to project directory
                    System.IO.File.WriteAllText("username.txt", parsedUser);
                    break;
                }
            }

            while (true)
            {
                // Have the user enter a password, but hide the input for security reasons
                Console.Write("\nPlease create a password: ");
                string password = null;
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    password += key.KeyChar;
                }
                // if you'd like to ensure that the password was captured correctly, uncomment the line below
                //Console.WriteLine("\n" + password);

                Console.Write("\nPlease re-enter your password: ");
                string password2 = null;
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    password2 += key.KeyChar;
                }

                if (password != password2)
                {
                    Console.WriteLine("\n\nPassword did not match, please re-enter them.\n");
                    continue;
                }
                else
                {
                    // the passwords matched, so now we can output the password to a txt file
                    System.IO.File.WriteAllText("password.txt", password);
                    break;
                }
            }

            // execute batch script to automate adding a user to linux server

            ProcessStartInfo sshKey = new ProcessStartInfo();
            sshKey.FileName = @"C:\windows\system32\cmd.exe";
            sshKey.Arguments = @"/c sendFiles.bat";
            Process.Start(sshKey);
        }
    }
}
