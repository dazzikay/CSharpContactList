
using contacts;
using Microsoft.VisualBasic;
using System.IO;

class Program
{
    static List<Contact> contactList = new List<Contact>();

    //adds new contacts
    public static void addContact()
    {
        Console.WriteLine("Enter name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter phone:");
        string phone = Console.ReadLine();
        Console.WriteLine("Enter email:");
        string email = Console.ReadLine();

        var newContact = new Contact(name, phone, email);
        contactList.Add(newContact);

    }

    //removes contact by looking at name
    public static void removeContact()
    {
        Console.WriteLine("Enter name to remove:");
        string removeName = Console.ReadLine();

        var tempContact = new Contact("", "", "");

        foreach (Contact c in contactList)
        {
            if (removeName.Equals(c.Name))
            {
                tempContact = c;

            }
        }

        contactList.Remove(tempContact);
    }

    //Prints out everyone in contacts
    public static void printList()
    {
        Console.WriteLine("--------CONTACTS--------");

        //sorts into alphabetical order when shown using sort method and delegate
        contactList.Sort(delegate (Contact c1, Contact c2) { return c1.Name.CompareTo(c2.Name); });

        foreach (Contact c in contactList)
        {
            Console.WriteLine(c);
           
        }
        Console.WriteLine("-------------------------");
    }

    //Looks for name in contact list
    public static void searchName()
    {
        Console.WriteLine("Enter name to search:");
        string searchName = Console.ReadLine();

        Console.WriteLine("--------CONTACTS--------");
        foreach (Contact c in contactList)
        {
            if (searchName.Equals(c.Name))
            {
                Console.WriteLine(c);

            }
        }
        Console.WriteLine("-------------------------");
    }

    //save to file called saved.txt
    public static void saveFile()
    {

        try
        {
            StreamWriter sw = new StreamWriter("saved.txt");


            foreach (Contact c in contactList)
            {
                sw.WriteLine(c);

            }

            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }



    public static void Main(string[] args)
        {

        //reads from file called contacts.txt and initially loads to the list of contacts
        String line;
        try
        {

            StreamReader sr = new StreamReader("contacts.txt");

            line = sr.ReadLine();


            while (line != null)
            {
           
                string[] words = line.Split(' ');

                string name = words[0];
                string phone = words[1];
                string email = words[2];

                contactList.Add(new Contact(name, phone, email));

                line = sr.ReadLine();
            }
            sr.Close();
       
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
      
    
        //shows the options of command
        while (true)
        {
            Console.WriteLine("Command: show, add, remove, search, save, exit");
            Console.WriteLine("Enter command:");
            string command = Console.ReadLine();


            if (command.Equals("show"))
            {
                printList();
          
            }

            else if (command.Equals("add"))
            {
                addContact();
            }

            else if (command.Equals("remove"))
            {
                removeContact();

            }

            else if (command.Equals("search"))
            {
                searchName();

            }

            else if (command.Equals("save"))
            {

                saveFile();
            }

            else if (command.Equals("exit"))
            {
                break;

            }

            else
            {
                Console.WriteLine("Command not understood: " + command);
            }


        }
       
        Console.ReadLine();


        }

    }

