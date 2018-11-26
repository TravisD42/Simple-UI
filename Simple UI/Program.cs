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
                    Console.WriteLine("Email addresses did not match, please enter them again.");
                    continue;
                }
                else if (!username.Contains("@"))
                {
                    Console.WriteLine("Please enter an email address.");
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
                    // to print out the parsed username uncomment the line below
                    //Console.WriteLine(parsedUser);

                    // now that we have the username, we can output it to a txt file for the bash script to read

                    string currentUser = Environment.UserName;
                    string partialPath = @"C:\\Users\\" + currentUser;
                    string halfPath = "Desktop\\Thesis\\username.txt";
                    string filePath = Path.Combine(partialPath, halfPath);
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
                    Console.WriteLine("\nPassword did not match, please re-enter them.\n");
                    continue;
                }
                else
                {
                    // the passwords matched, so now we can output the password to a txt file for the bash script to read
                    string currentUser = Environment.UserName;
                    string partialPath = @"C:\\Users\\" + currentUser;
                    string halfPath = "Desktop\\Thesis\\password.txt";
                    string filePath = Path.Combine(partialPath, halfPath);
                    // just write to project directory
                    System.IO.File.WriteAllText("password.txt", password);
                    break;
                }
            }

            // get the file path where the scripts are found!

            string userName = Environment.UserName;
            string getToUser = @"C:\\Users\\" + userName;
            string getToBatch = "Desktop\\Thesis\\testBatch.bat";
            string pathToBatch = Path.Combine(getToUser, getToBatch);

            // Generate and copy over ssh keys in a windows platform

            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = @"C:\windows\system32\cmd.exe";
            proc.Arguments = @"/c testBatch.bat";
            Process.Start(proc);

        }
    }
}
