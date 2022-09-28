using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;
using Exception1;


namespace BusinessLayer
{
    public class GuestBL
    {

        public bool AddGuest(Guest newGuest)
        {
            try
            {
                if (!ValidateGuest(newGuest))
                {
                    return false;
                }
                else
                {
                    GuestDAL guestDAL = new GuestDAL();
                    guestDAL.AddGuest(newGuest);
                   
                    return true;
                }
            }
            catch(GuestPhoneBookException e)
            {
                throw e;
            }

        }

        public List<Guest> ListAllGuest()
        {
            GuestDAL guestDAL = new GuestDAL();
            return guestDAL.ListAllGuest();


        }
        public Guest SearchGuestByID(int GuestID)
        {
            try
            {
                if (GuestID.ToString().Length == 3)
                {
                    GuestDAL guestDAL = new GuestDAL();
                    return guestDAL.SearchGuestByID(GuestID);

                }
                else
                {
                    throw new Exception();
                }
            }
            catch( GuestPhoneBookException e)
            {
                throw e;
            }



        }

        public List<Guest> SearchGuestByRelationShip(Relation relationShip)
        {
            GuestDAL guestDAL = new GuestDAL();

            return guestDAL.SearchGuestByRelationShip(relationShip);

        }

        public bool UpdateGuest(Guest guestDetails)
        {
            
            try
            {
                if (!ValidateGuest(guestDetails))
                {
                    return false;
                }
                else
                {
                    GuestDAL guestDAL = new GuestDAL();
                    return guestDAL.UpdateGuest(guestDetails);
                   
                    
                }
            }
            catch (GuestPhoneBookException e)
            {
                throw e;
            }

        }

        public bool DeletGuest(int guestID)
        {
            GuestDAL guestDAL = new GuestDAL();
            if (guestID < 0)
            {
                throw new Exception();

            }

            return guestDAL.DeletGuest(guestID);


        }

        public bool ValidateGuest( Guest guestDetails)
        {
            string input1 = guestDetails.Name;
            string pattern1 = "^[A-Z]{1}[A-Za-z]{2,}$";
            bool result1 = Regex.IsMatch(input1, pattern1);

            string pattern2 = @"^[6789]\d{9}$";
            string input2 = guestDetails.ContactNumber;
            bool result2 = Regex.IsMatch(input2, pattern2);



            if (guestDetails == null || guestDetails.Id == 0 || ! (Enum.IsDefined(typeof(Entities.Relation), guestDetails.Relationship)) || guestDetails.ContactNumber == null || guestDetails.Name == null)
            {
                
                return false;
            }
            else if (guestDetails.Id.ToString().Length != 3)
            {
            
                return false;
            }
            else if (! result1)
            {
                
                return false;

            }
            else if( !result2)
            {
              
                return false;
            }
            else
            {
                return true;
            }

            

        }




    }
}
