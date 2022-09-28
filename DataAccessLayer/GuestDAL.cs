using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Exception1;

namespace DataAccessLayer
{
    public class GuestDAL
    {
        public static List<Guest> guestList = new List<Guest>();


        public bool AddGuest(Guest g)
        {
            bool isAdded = false;
            try
            {
                guestList.Add(g);
                isAdded = true;
                return isAdded;

            }
            catch(GuestPhoneBookException e)
            {
                
                throw e;
            }

           

        }

        public List<Guest> ListAllGuest()
        {
            return guestList;


        }


        public Guest SearchGuestByID(int GuestID)
        {
            Guest guest1 = null;
            foreach (Guest guest in guestList)
            {
                if( guest.Id== GuestID)
                {
                    guest1= guest;
                  
                } 
            }

            if(guest1 == null)
            {
                throw new GuestPhoneBookException("ID is Invalid");
            }
            else
            {
                return guest1;
            }
            

        }
        public List<Guest> SearchGuestByRelationShip(Relation relationShip)
        {
            List<Guest> guestRelatives = new List<Guest>();
            foreach (Guest guest in guestList)
            {
                if (guest.Relationship == relationShip)
                {
                    guestRelatives.Add(guest);
                    
                  
                }
            }
            return guestRelatives;

        }

        public bool UpdateGuest( Guest guestDetails)
        {
            for( int i =0; i< guestList.Count; i++ )
            {
                if(guestList[i].Id== guestDetails.Id)
                {
                    guestList.RemoveAt(i);
                    guestList.Insert(i, guestDetails);
                    return true;

                }
            }
            return false; 


        }

        public bool DeletGuest(int guestID)
        {
            for (int i = 0; i < guestList.Count; i++)
            {
                if (guestList[i].Id == guestID)
                {
                    guestList.RemoveAt(i);
                    
                    return true;

                }
            }
            return false;

        }


    }
}
