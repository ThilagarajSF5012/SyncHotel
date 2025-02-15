using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncHotel
{
    /// <summary>
    /// The class BookingDetails <see cref="BookingDetails"/> is used to create the object of the Room bookings
    /// </summary>
    public class BookingDetails
    {
        /// <summary>
        /// feild s_bookingID is used to store the id value for the incementing purpose
        /// </summary>
        private static int s_bookingID = 4000;
        /// <summary>
        /// feild _bookin ID is private and it is used to store booking ID
        /// </summary>
        private string _bookingId;
        /// <summary>
        /// property BookingId is public property and it is used to return the booking id and assign the value to _bookingID and s_bookingId feild
        /// </summary>
        /// <returns>It return the _bookingID</returns>
        public string BookingID { get{return _bookingId;} set{_bookingId=value;s_bookingID=int.Parse(value.Remove(0,3));} }

        /// <summary>
        /// property UserID is used to store the UserId of the User Registration object
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// property TotalPrice is used to store the TotalPrice of the total bookin objects
        /// </summary>
        public double TotalPrice { get; set; }
        /// <summary>
        /// property DateOfBooking is to store the booking date of the object
        /// </summary>
        /// <value></value>
        public DateTime DateOfBooking { get; set; }
        /// <summary>
        /// property Status is an Enum type <see cref="BookingStatus"/> to give the status of the object
        /// </summary>
        /// <value></value>
        public BookingStatus Status { get; set; }

        /// <summary>
        /// Constructor is used to initialize the properties of the object of BookingDetails
        /// </summary>
        public BookingDetails()
        {

        }
        /// <summary>
        /// The parametrized constructor is used to intialize the object with the argumert values
        /// </summary>
        /// <param name="userId">userID is type of string it is used to give the value to property USerID</param>
        /// <param name="price">Price is type of double it is used to give the value to property TotalPrice</param>
        /// <param name="date">date perameter is used to tive the booking date to the object</param>
        /// <param name="status">status is to give the status of the booking to the Status property</param>
        public BookingDetails(string userId, double price, DateTime date, BookingStatus status)
        {
            BookingID = $"BID{++s_bookingID}";
            UserID = userId;
            TotalPrice = price;
            DateOfBooking = date;
            Status = status;
        }
    }
}