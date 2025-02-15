using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncHotel
{
    /// <summary>
    /// class RoomDetail <see cref="RoomDetails"/> is used to create the object of the Room Details
    /// </summary>
    public class RoomDetails
    {
        /// <summary>
        /// static feild s_roomId is used to assign the number to the Room ID
        /// </summary>
         private static int s_roomID = 2000;

         /// <summary>
         /// privat _roomId is used to give the value to the RoomID
         /// </summary>
        private string _roomID;
        /// <summary>
        /// property RoomID is used to give the return the roomId and set the value to the RoomId
        /// </summary>
        public string RoomID { get { return _roomID; } set { _roomID = value; s_roomID = int.Parse(value.Remove(0, 3)); } }

        /// <summary>
        /// property RoomType is used to give the What are the types of room are in there
        /// </summary>
        public RoomTypes RoomType { get; set; }

        /// <summary>
        /// property NumberOfBeds is used to give the Number of Beds 
        /// </summary>
        /// <value></value>
        public int NumberOfBeds { get; set; }

        /// <summary>
        /// property PricePerDay is used to give the price to the objcet
        /// </summary>
        /// <value></value>
        public double PricePerDay { get; set; }
        /// <summary>
        /// Default constructor to initialize the object of the RoomDetails class
        /// </summary>
        public RoomDetails(){
            
        }
        /// <summary>
        /// parameterized constructor is to initialize the object with the arguments
        /// </summary>
        /// <param name="type">type parameter is used to give the Type of room to the Property RoomType</param>
        /// <param name="noOfBeds">noOfBeds perametr is used to give the how many beds are in room</param>
        /// <param name="price">price parameter is used to give the price of the room</param>
        public RoomDetails(RoomTypes type, int noOfBeds, double price)
        {
            RoomID=$"RID{++s_roomID}";
            RoomType = type;
            NumberOfBeds = noOfBeds;
            PricePerDay = price;
        }
    }
}