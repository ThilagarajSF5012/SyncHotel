using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncHotel
{
    public class RoomSelection
    {
       /// <summary>
       /// static s_Selection feild is used to give the value to the selectionID
       /// </summary>
        private static int s_selectionID = 5000;
        /// <summary>
       /// private _Selection feild is used to give the value to the selectionID
       /// </summary
        private string _selectionID;
        /// <summary>
       /// Selection property is used to get and set the value to the selectionID 
       /// </summary
        public string SelectionID { get { return _selectionID; } set { _selectionID = value; s_selectionID = int.Parse(value.Remove(0, 3)); } }
       
       /// <summary>
       /// WishListID property is used to give the value to the WishListID
       /// </summary
        public string WishListID { get; set; }
        /// <summary>
       /// BookingID property is used to give the value to the BookingID
       /// </summary
        public string BookingID { get; set; }

        /// <summary>
       /// RoomId property is used to give the value to the RoomID
       /// </summary
        public string RoomID { get; set; }

        /// <summary>
        /// property StayingDatefrom from is used to give the when you need room
        /// </summary>
        public DateTime StayingDateFrom { get; set; }
        /// <summary>
        /// property Stayingdateto from is used to give the when you vecate room 
        /// </summary>
        public DateTime StayingDateTo { get; set; }

        /// <summary>
        /// property Price is to give the total price of the booking
        /// </summary>
        /// <value></value>
        public double Price { get; set; }

        /// <summary>
        /// Property Number of Days is used to give the number of days your are staying
        /// </summary>
        /// <value></value>
        public double NumberOfDays { get; set; }

        /// <summary>
        /// property Booking Status is used to give the status of the booking 
        /// </summary>
        /// <value></value>
        public BookingStatus Status { get; set; }

        /// <summary>
        /// Constructor RoomSelection is used to initialize the object of RoomSelection
        /// </summary>
        public RoomSelection(){

        }
        /// <summary>
        /// Constructor RoomSelection is used to initialize the object of RoomSelection with the below parameter
        /// </summary>
        /// <param name="wishListID">WishListID parameteris used to give the value to the WishListID</param>
        /// <param name="bookingID">bookingID parameter is used to give the value to the bookingD</param>
        /// <param name="roomID">roomgID parameter is used to give the value to the RoomD</param>
        /// <param name="stayfrom">stayFrom parameter is used to give the value to the StartingDate</param>
        /// <param name="stayto">stayto parameter is used to give the value to the last date</param>
        /// <param name="price">price parameter is used to give the value to the Price</param>
        /// <param name="noOfDays">noOfDaysparameter is used to give the value to the noOfDAys</param>
        /// <param name="status">status parameter is used to give the value to the Status</param>
        public RoomSelection(string wishListID, string bookingID, string roomID, DateTime stayfrom, DateTime stayto, double price, double noOfDays, BookingStatus status)
        {
            SelectionID = $"SID{++s_selectionID}";
            WishListID = wishListID;
            BookingID = bookingID;
            RoomID = roomID;
            StayingDateFrom = stayfrom;
            StayingDateTo = stayto;
            Price = price;
            NumberOfDays = noOfDays;
            Status = status;
        }
    }
}