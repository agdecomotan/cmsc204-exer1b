using System;

// Anelie Decomotan
// 2017 - 30211
// March 10, 2019

namespace Exercise1B
{
    class Program
    {
        static LinkedList linkedList = new LinkedList();
        static void Main(string[] args)
        {
            mainMenu();
        }

        static void mainMenu()
        {
            // Show main menu
            string instruction = "[1] Sign up for doctor’s consultation \n" +
                "[2] Enter room \n" +
                "[3] Begin consultation \n" +
                "[4] Closing time \n" +
                "[5] Exit";
            Console.WriteLine(instruction);
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    insertPatient();
                    break;
                case "2":
                    enterRoom();
                    break;
                case "3":
                    beginConsultation();
                    break;
                case "4":
                    closingTime();
                    break;
                case "5":
                    exitApplication();
                    break;
                default:
                    mainMenu();
                    Console.WriteLine("Invalid input.");
                    break;
            }

            //Back to main menu
            mainMenu();
        }

        static void insertPatient()
        {
            // Get patient name and concern as user input
            Console.WriteLine("Enter patient name:");
            string patientName = Console.ReadLine();

            Console.WriteLine("Enter nature of concern:");
            string concern = Console.ReadLine();

            // Create patient object and assign data to a node
            Patient patient = new Patient(patientName, concern);
            Node node = new Node(patient);

            if (linkedList.Header == null)
            {
                // Set new node as header and tail
                linkedList.Header = node;
                linkedList.Tail = node;
            }
            else
            {
                // Set new node as current tail node's next node
                linkedList.Tail.Next = node;
                // Set current node as tail node
                linkedList.Tail = node;
            }           
        }

        static void enterRoom()
        {
            Node header = linkedList.Header;
            if(header != null)
            {
                // Get data of header
                Patient patient = header.Data;
                Console.WriteLine("Current patient " + patient.Name);
            }
            else
            {
                Console.WriteLine("No patient in queue.");
            }      
        }

        static void beginConsultation()
        {
            Node header = linkedList.Header;
            if (header != null)
            {
                // Get data of header
                Patient patient = header.Data;
                Console.WriteLine("Current patient " + patient.Name);
                Console.WriteLine("Nature of concern " + patient.Concern);

                // Set next node of header as the new header
                Node nextNode = header.Next;
                linkedList.Header = null;
                linkedList.Header = nextNode;
            }
            else
            {
                Console.WriteLine("No patient in queue.");
            }
        }

        static void closingTime()
        {
            // Remove header and tail
            linkedList.Header = null;
            linkedList.Tail = null;
            Console.WriteLine("Clear patient queue.");
        }

        static void exitApplication()
        {
            Environment.Exit(1);
        }
    }
}
