using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BusinessLayer;
using Exception1;
using System.Threading;

namespace PresentationLayer1
{
    internal class GuestApplicatonTest
    {
        static void Main(string[] args)
        {
            int choice = 0;
            while (choice != 7)
            {



                Console.Clear();
                Console.WriteLine($"================Guest Aplication============");
                Console.WriteLine($"Enter what you want to perform\n1.Add Guest \n2.ListAllGuest \n3.SearchGuestByID \n4.SearchGuestByRelationship \n5.UpdateGuest \n6.DeletGuest \n7.Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddGuest();
                        break;
                    case 2:
                        ListAllGuest();
                        break;
                    case 3:
                        SearchGuestByID();
                        break;
                    case 4:
                        SearchGuestByRelationShip();
                        break;
                    case 5:
                        UpdateGuest();
                        break;
                    case 6:
                        DeletGuest();
                        break;
                    case 7:
                        break;


                }
                int milliseconds = 2500;
                Thread.Sleep(milliseconds);

            }
        }

        private static void DeletGuest()
        {
            GuestBL guestBL = new GuestBL();
            Console.WriteLine("\n\nenter Id of Guest to delet..");
            int ID =Convert.ToInt32( Console.ReadLine());
            if (guestBL.DeletGuest(ID))
            {
                Console.WriteLine($"\nGuest with ID: {ID} is Deleted..");

            }
            else
            {
                Console.WriteLine($"\nGuest with ID: {ID} is NOT FOUND..");

            }

        }

        private static void UpdateGuest()
        {
            Guest g = new Guest();
            Console.WriteLine($"\n\nenter guest Id to Update");
            g.Id = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine($"enter guest name:");
            g.Name = Console.ReadLine();


            Console.WriteLine($"enter guest contact number:");
            g.ContactNumber = Console.ReadLine();

            Console.WriteLine($"enter guest relation(Capital Letters):");
            g.Relationship = (Relation)Enum.Parse(typeof(Relation), Console.ReadLine());


            GuestBL guestBL = new GuestBL();
            if (guestBL.UpdateGuest(g))
            {
                Console.WriteLine("\n\nguest is updated...");
            }
            else
            {
                Console.WriteLine($"\n\nguest with ID {g.Id} is NOT FOUND...");

            }
            

        }

        private static void SearchGuestByRelationShip()
        {
            Console.WriteLine("\n\nenter relation of Guest to search..");
            string relation = Console.ReadLine();
            Relation r = (Relation)Enum.Parse(typeof(Relation), relation);

            GuestBL guestBL = new GuestBL();
            List<Guest> guestList = guestBL.SearchGuestByRelationShip(r);
            for( int i = 0; i < guestList.Count; i++){
                Console.WriteLine($"\nthese are guest how are {relation} by relation...\n\n");
                Console.WriteLine($"Id of Guest: {guestList[i].Id}, Name of Guest: {guestList[i].Name}, Contact Number: {guestList[i].ContactNumber}");
            }
            
        }

        private static void SearchGuestByID()
        {
            Console.WriteLine("\n\nenter id of Guest to search..");
            
            try
            {
                int Id = Convert.ToInt32(Console.ReadLine());
                GuestBL guestBL = new GuestBL();
                Guest g = guestBL.SearchGuestByID(Id);
                Console.WriteLine($"\nDetails of Guest with ID :{Id} is as follows: \n\n");
                Console.WriteLine($"Name of Guest: {g.Name}, Relation: {g.Relationship}");
            }
            catch( GuestPhoneBookException e)
            {
                Console.WriteLine("\n"+e.Message);
            }
           



        }

        private static void ListAllGuest()
        {
            GuestBL guestBL = new GuestBL();
            List<Guest> guestList= guestBL.ListAllGuest();
            Console.WriteLine("\n\nLIST of Guest:");

            foreach ( Guest guest in guestList)
            {
                
                Console.WriteLine($"\nId of Guest: {guest.Id}, Name: {guest.Name}, ContactNumber: {guest.ContactNumber}, Relation: {guest.Relationship}");
            }
        }

        private static void AddGuest()
        {
            Guest g = new Guest();
            try
            {

                
                Console.WriteLine($"enter guest details");

                Console.WriteLine($"enter guest name:");
                g.Name = Console.ReadLine();

                Console.WriteLine($"enter guest Id");
                g.Id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"enter guest contact number:");
                g.ContactNumber = Console.ReadLine();

                Console.WriteLine($"enter guest relation(Capital Letters):");
                g.Relationship = (Relation)Enum.Parse(typeof(Relation), Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


            GuestBL guestBL = new GuestBL();

            try
            {
                if (guestBL.AddGuest(g))
                {
                    Console.WriteLine($"\nguest is added!!!");

                }
                else
                {
                    Console.WriteLine($"\nenter valid data..");
                }


            }
            catch( GuestPhoneBookException e)
            {
                Console.WriteLine(e.Message);
            }

            
            
        }
    }
}
