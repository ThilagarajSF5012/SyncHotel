using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SyncHotel
{
    public class Operation
    {
        CustomList<UserRegistration> userDetails = new CustomList<UserRegistration>();
        CustomList<RoomDetails> roomDetails = new CustomList<RoomDetails>();
        CustomList<RoomSelection> selectionRoom = new CustomList<RoomSelection>();
        CustomList<WishList> wishList = new CustomList<WishList>();
        CustomList<BookingDetails> bookingDetails = new CustomList<BookingDetails>();

        UserRegistration currentUser;

        public void DefaultValues()
        {

            //adding the default valus of the user details
            userDetails.Add(new UserRegistration("Ravichandran", "995875777", "347777378383", "ravi@gmail.com", "Chennai", FoodType.Veg, GenderType.Male, 5000));
            userDetails.Add(new UserRegistration("Baskaran", "448844848", "474777477477", "baskar@gmail.com", "Chennai", FoodType.NonVeg, GenderType.Male, 6000));

            //adding the default values of the Foom details
            roomDetails.Add(new RoomDetails(RoomTypes.Standard, 2, 500));
            roomDetails.Add(new RoomDetails(RoomTypes.Standard, 4, 700));
            roomDetails.Add(new RoomDetails(RoomTypes.Standard, 2, 500));
            roomDetails.Add(new RoomDetails(RoomTypes.Standard, 2, 500));
            roomDetails.Add(new RoomDetails(RoomTypes.Standard, 2, 500));
            roomDetails.Add(new RoomDetails(RoomTypes.Delux, 2, 1000));
            roomDetails.Add(new RoomDetails(RoomTypes.Delux, 2, 1000));
            roomDetails.Add(new RoomDetails(RoomTypes.Delux, 4, 1400));
            roomDetails.Add(new RoomDetails(RoomTypes.Delux, 4, 1400));
            roomDetails.Add(new RoomDetails(RoomTypes.Suit, 2, 2000));
            roomDetails.Add(new RoomDetails(RoomTypes.Suit, 2, 2000));
            roomDetails.Add(new RoomDetails(RoomTypes.Suit, 2, 2000));
            roomDetails.Add(new RoomDetails(RoomTypes.Suit, 4, 2500));

            //Adding the default valuse of the Room Selection
            selectionRoom.Add(new RoomSelection("WSID3001", "BID4001", "RID2001", new DateTime(2024, 11, 11, 06, 0, 00), new DateTime(2024, 11, 12, 14, 0, 00), 750, 1.5, BookingStatus.Booked));
            selectionRoom.Add(new RoomSelection("WSID3002", "BID4001", "RID2002", new DateTime(2024, 11, 11, 10, 0, 00), new DateTime(2024, 11, 12, 9, 0, 00), 700, 1, BookingStatus.Booked));
            selectionRoom.Add(new RoomSelection("WSID3003", "BID4002", "RID2003", new DateTime(2024, 11, 12, 09, 0, 00, DateTimeKind.Utc), new DateTime(2024, 11, 12, 14, 0, 00), 500, 1, BookingStatus.Cancelled));
            selectionRoom.Add(new RoomSelection("WSID3004", "BID4002", "RID2006", new DateTime(2024, 11, 12, 06, 0, 00), new DateTime(2024, 11, 13, 12, 30, 00), 150, 1.5, BookingStatus.Cancelled));

            //Adding the default values of the Wishlist
            wishList.Add(new WishList("SF1001", "RID2001", 750, new DateTime(2024, 11, 12, 9, 0, 0), new DateTime(2024, 11, 13, 9, 0, 0)));
            wishList.Add(new WishList("SF1001", "RID2002", 700, new DateTime(2024, 11, 12, 6, 0, 0), new DateTime(2024, 11, 13, 12, 30, 0)));
            wishList.Add(new WishList("SF1002", "RID2001", 750, new DateTime(2025, 02, 25, 9, 0, 0), new DateTime(2024, 02, 26, 10, 0, 0)));
            wishList.Add(new WishList("SF1001", "RID2001", 750, new DateTime(2025, 03, 03, 10, 0, 0), new DateTime(2025, 03, 04, 11, 0, 0)));

            //Adding the default values of the booking details
            bookingDetails.Add(new BookingDetails("SF1001", 1450, DateTime.ParseExact("10/11/2024", "dd/MM/yyyy", null), BookingStatus.Booked));
            bookingDetails.Add(new BookingDetails("SF1002", 2000, DateTime.ParseExact("10/11/2024", "dd/MM/yyyy", null), BookingStatus.Cancelled));
        }
        public void ReadCSVFile()
        {

            //calling the ReadCsv file static method to read the datas from the csv file
            FileHandler<UserRegistration>.ReadCSVFile(userDetails);
            FileHandler<RoomDetails>.ReadCSVFile(roomDetails);
            FileHandler<RoomSelection>.ReadCSVFile(selectionRoom);
            FileHandler<WishList>.ReadCSVFile(wishList);
            FileHandler<BookingDetails>.ReadCSVFile(bookingDetails);
        }
        public void WriteCSVFile()
        {

            //calling the WriteCsv file static method to write the datas to the csv file
            FileHandler<UserRegistration>.WriteCSVFile(userDetails);
            FileHandler<RoomDetails>.WriteCSVFile(roomDetails);
            FileHandler<RoomSelection>.WriteCSVFile(selectionRoom);
            FileHandler<WishList>.WriteCSVFile(wishList);
            FileHandler<BookingDetails>.WriteCSVFile(bookingDetails);
        }
        public void UserRegistration()
        {
            try
            {
                // Need to get the details below from the user for the user registration.
                Console.WriteLine("Enter the User Name :");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the Mobile Number :");
                string mobile = Console.ReadLine();

                Console.WriteLine("Enter the Aadhar Number :");
                string aadhar = Console.ReadLine();

                Console.WriteLine("Enter the Email :");
                string email = Console.ReadLine();

                Console.WriteLine("Enter the Address :");
                string address = Console.ReadLine();

                Console.WriteLine("Enter the Food Type (Veg,Nonveg)");
                FoodType food = Enum.Parse<FoodType>(Console.ReadLine(), true);

                Console.WriteLine("Enter the Gender ( Male, Female, Transgender)");
                GenderType gender = Enum.Parse<GenderType>(Console.ReadLine(), true);

                Console.WriteLine("Enter the Wallat balance :");
                double amount = Convert.ToDouble(Console.ReadLine());

                //Creating the object of the User Registration class with the above details
                UserRegistration user = new UserRegistration(name, mobile, aadhar, email, address, food, gender, amount);

                //adding the user to the user details list
                userDetails.Add(user);
                Console.WriteLine("User Registered Succesfully. User id is " + user.UserID);
            }
            //catch block to catch the Format exception if any value not match with the type
            catch (FormatException e)
            {
                Console.WriteLine("Format Exception Occured " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e);
            }
        }
        public void MainMenu()
        {
            try
            {
                int choice;
                do
                {
                    //showing choices and geting the choice from the user
                    System.Console.WriteLine("Welcome");
                    System.Console.WriteLine("Main Menu\n     1. User Registration\n     2. User Login\n     3. Exit\nEnter Your choice....");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        //Calls the User REgistration Method
                        case 1:
                            {
                                Console.WriteLine("Welcome New User");
                                UserRegistration();
                                break;
                            }
                        case 2:
                            {
                                //calls the UserLogin Method
                                UserLogin();
                                break;
                            }
                        case 3:
                            {
                                break;
                            }
                        //if choice not match with the above cases
                        default:
                            {
                                Console.WriteLine("Invalid Choice");
                                break;
                            }
                    }

                } while (choice != 3);
                Console.WriteLine("Thank You");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Ocured " + e.Message);
            }
        }
        public void UserLogin()
        {
            //Ask and get the “UserID” from the user. Check the “UserID” in the users list.
            System.Console.WriteLine("Enter the UserId to Login: ");
            string userId = Console.ReadLine().Trim().ToUpper();

            //using Binary search we search the user id
            int isValidID = CustomList<UserRegistration>.BinarySearch(userDetails, userId, "UserID", out currentUser);

            //if the User Login succese
            if (isValidID >= 0)
            {
                Console.WriteLine("User LogIn Succesfully");
                SubMenu();
            }
            else
            {
                Console.WriteLine("Invalid ID");
            }


        }
        public void SubMenu()
        {
            try
            {
                int choice;
                do
                {
                    //shoing the choices and geting the choice from the user
                    Console.WriteLine("Sub Menu \n1.	ViewCustomerProfile\n2.	AddToWishList\n3.	BookRoom\n4.	CancelBooking\n5.	BookingHistory\n6.	WalletRecharge\n7.	ShowWalletBalance\n8.	Exit \nEnter your Choice:");
                    choice = Convert.ToInt32(Console.ReadLine().Trim());
                    switch (choice)
                    {
                        case 1:
                            {
                                //to call the ViewUserProfile
                                ViewUserProfile();
                                break;
                            }
                        case 2:
                            {
                                //to call teh AddtowishList
                                AddToWishList();
                                break;
                            }
                        case 3:
                            {
                                BookRoom();
                                break;
                            }
                        case 4:
                            {
                                CancelBooking();
                                break;
                            }
                        case 5:
                            {
                                BookingHistory();
                                break;
                            }
                        case 6:
                            {
                                WalletRecharge();
                                break;
                            }
                        case 7:
                            {
                                ShowWalletBalance();
                                break;
                            }
                        case 8:
                            {
                                break;
                            }
                        //if no above case valid then default will run
                        default:
                            {
                                Console.WriteLine("Invalid Choice");
                                break;
                            }
                    }
                } while (choice != 8);
            }
            //to catch the format exception 
            catch (FormatException e)
            {
                Console.WriteLine("Format Exception Occured " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e);
            }
        }

        private void BookingHistory()
        {
            CustomList<BookingDetails> bookingHistory = new();
            /// traversing the current customer’s booking details by traversing the bookings list 
            foreach (BookingDetails booking in bookingDetails)
            {
                if (booking.UserID.Equals(currentUser.UserID, StringComparison.OrdinalIgnoreCase))
                {
                    bookingHistory.Add(booking);
                }
            }
            if (bookingHistory.Count == 0)
            {
                Console.WriteLine("No Booking detail to show\n");
            }
            else
            {
                //Printing the Boking History of the Current User
                Grid<BookingDetails>.PrintTable(bookingHistory);
            }
        }

        private void BookRoom()
        {

            try
            {

                int choice = 0;
                do
                {
                    bool hasWishList = false;
                    // Traverse and show the wishList, and check if the room is available or not by comparing wishList RoomID with the room selectionList RoomID. 
                    CustomList<WishList> availableWishList = new();
                    foreach (WishList list in wishList)
                    {
                        bool flag = false;
                        if (list.UserID.Equals(currentUser.UserID))
                        {
                            hasWishList = true;
                            //Traversing the RoomSelection List
                            foreach (RoomSelection selection in selectionRoom)
                            {
                                if (list.RoomID.Equals(selection.RoomID))
                                {
                                    if (selection.StayingDateFrom > list.FromDate && selection.StayingDateTo < list.FromDate && selection.StayingDateFrom > list.ToDate && selection.StayingDateTo < list.ToDate && !selection.Status.Equals(BookingStatus.Booked))
                                    {
                                        flag = true;
                                    }
                                    else
                                    {
                                        flag = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    flag = true;
                                }

                            }
                            //tocheck if it is availabe or not
                            string isAvilable;
                            if (flag)
                            {
                                isAvilable = "Available";
                                availableWishList.Add(list);
                            }
                            else
                            {
                                isAvilable = "Not Available";
                            }
                            Console.WriteLine($"| {list.WishListID,-17} || {list.RoomID,-17} || {list.PriceOfRoom,-17} || {isAvilable}");

                        }
                    }
                    if (hasWishList)
                    {
                        //giveing the choices to the user and geting the option 
                        Console.WriteLine("RoomBooking Options:\n1.	ConfirmBooking\n2.	DeleteWishList\n3.	Exit\nEnter your choice");
                        choice = Convert.ToInt16(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                {
                                    ConfirmBooking(availableWishList);
                                    break;
                                }
                            case 2:
                                {
                                    DeleteWishList();
                                    break;
                                }
                            case 3:
                                {
                                    break;
                                }
                            //if no aboove choice valid then it will run
                            default:
                                {
                                    Console.WriteLine("Invalid Choice");
                                    break;
                                }
                        }

                    }
                    else
                    {
                        Console.WriteLine("No wishList Available to display");
                        break;
                    }
                } while (choice != 3);
            }//catch bloc to catch the all kind of exception
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e);
            }
        }

        private void DeleteWishList()
        {
            // Show all the wishListItems of the current customer.
            CustomList<WishList> userWishList = new();
            foreach (WishList list in wishList)
            {

                if (list.UserID.Equals(currentUser.UserID))
                {
                    userWishList.Add(list);
                }
            }
            if (userWishList.Count > 0)
            {
                Grid<WishList>.PrintTable(userWishList);
                //Ask the customer to select one WishListID, the customer wants to delete.
                Console.WriteLine("Enter WishListID to Detlete");
                string wishListID = Console.ReadLine().ToUpper();
                //Validate if the WishListID is valid or not by traversing the wishList.
                int isValidID = CustomList<WishList>.BinarySearch(userWishList, wishListID, "WishListID", out WishList currentWishList);

                if (isValidID >= 0)
                {
                    // If the WishListID is valid, then remove the chosen wishList from the wishListItems list
                    wishList.Remove(currentWishList);
                    Console.WriteLine("Selection room is deleted from WishList successfully");
                }
                //  If the WishListID is invalid, then show 
                else
                {
                    Console.WriteLine("Invalid WishListID");
                }
            }
            else
            {
                Console.WriteLine("No Wish List found to delete");
            }
        }
        private void ConfirmBooking(CustomList<WishList> list)
        {
            //To Print the available list
            if (list.Count > 0)
            {
                Grid<WishList>.PrintTable(list);
            }
            //travering to calculate the price
            double TotalPrice = 0;
            foreach (WishList data in list)
            {
                TotalPrice += data.PriceOfRoom;
            }
            bool canBook = true;

            //to check the if the User has enough wallet
            if (TotalPrice > currentUser.WalletBalance)
            {
                canBook = false;
                Console.WriteLine("Insufficient balance to make your purchase. Needed amount to make your purchase is " + (TotalPrice - currentUser.WalletBalance));
                //Ask if the customer wish to recharge their wallet, If the customer chooses “No”, then show the RoomBooking Options.
                Console.WriteLine("Do you want to recharge their wallet (yes/no)");
                string isRecharge = Console.ReadLine();

                // If “Yes”, then ask and get the recharge amount and recharge the wallet of the current customer.
                while (isRecharge.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Enter Amount to Recharge");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    currentUser.WalletRecharge(amount);

                    //Again, check if the customer’s wallet balance meets the TotalPrice.
                    if (TotalPrice <= currentUser.WalletBalance)
                    {
                        canBook = true;
                        break;
                    }
                    Console.WriteLine("Insufficent Balance To book room .Do you want to recharge their wallet again (yes/no)");
                    isRecharge = Console.ReadLine();
                }
            }
            //if user has enough wallet 
            if (canBook && list.Count > 0)
            {
                //Creating the bookin objcet
                BookingDetails booking = new BookingDetails(currentUser.UserID, TotalPrice, DateTime.Now, BookingStatus.Booked);
                currentUser.DeductBalance(TotalPrice);
                foreach (WishList wish in list)
                {
                    //Creating teh Reoom Selection object
                    RoomSelection room = new RoomSelection(wish.WishListID, booking.BookingID, wish.RoomID, wish.FromDate, wish.ToDate, TotalPrice, (wish.ToDate - wish.FromDate).TotalDays, BookingStatus.Booked);
                    selectionRoom.Add(room);
                    wishList.Remove(wish);
                }
                //adding the booking details object
                bookingDetails.Add(booking);
                Console.WriteLine("Booking Successful. Your BookingID is " + booking.BookingID);
            }
            else
            {
                Console.WriteLine("\n               No Availabe Wishlist to Confirm Room               \n");
            }
        }
        private void CancelBooking()
        {
            try
            {
                
                CustomList<BookingDetails> list = new();
                /// traversing the current customer’s booking details by traversing the bookings list 
                foreach (BookingDetails booking in bookingDetails)
                {
                    if (booking.UserID.Equals(currentUser.UserID, StringComparison.OrdinalIgnoreCase) && booking.Status.Equals(BookingStatus.Booked))
                    {
                        list.Add(booking);
                    }
                }
                if (list.Count == 0)
                {
                    Console.WriteLine("No Booking detail to show");
                }
                else
                {
                    //Printing the booking id to cancell
                    Grid<BookingDetails>.PrintTable(list);

                    Console.WriteLine("Enter the BookinId to cancel");
                    string bookingId = Console.ReadLine().ToUpper();
                    bool isCanceled = false;
                    int isValidID = CustomList<BookingDetails>.BinarySearch(list, bookingId, "BookingID", out BookingDetails currentbooking);
                    //If the BookingID is valid, then update the current chosen booking’s booking status as “Cancelled”.
                    if (isValidID >= 0)
                    {
                        currentbooking.Status = BookingStatus.Cancelled;

                        //Return the TotalPrice for the booking to customer’s wallet balance.
                        currentUser.WalletRecharge(currentbooking.TotalPrice);

                        //Traverse the roomSelection list and change the status of corresponding roomsSelectionList entries to “Cancelled” by checking the BookingID of selection entrie
                        foreach (RoomSelection room in selectionRoom)
                        {
                            if (currentbooking.BookingID.Equals(room.BookingID))
                            {
                                isCanceled = true;
                                room.Status = BookingStatus.Cancelled;
                            }
                            //Then, show “Booking Cancelled Successfully”
                            if (isCanceled)
                            {
                                Console.WriteLine("Booking Cancelled Successfully");
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid Booking ID");
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occured " + e);
            }
        }
        private void AddToWishList()
        {
            string addCartAgain = "No";
            do
            {
                //ask and geting the from date form user
                Console.WriteLine("Enter The From Date of Booking in (dd/MM/yyyy HH:mm:ss) format");
                DateTime fromDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", null);

                //ask and geting the to date form user
                Console.WriteLine("Enter The to Date of Booking in (dd/MM/yyyy hh:mm:ss) format");
                DateTime toDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", null);

                CustomList<RoomDetails> availableRooms = new();

                //traversin the roomDetails list to check if room is available or not
                foreach (RoomDetails selection in roomDetails)
                {
                    bool flag = false;
                    foreach (RoomSelection room in selectionRoom)
                    {
                        if (room.RoomID.Equals(selection.RoomID, StringComparison.OrdinalIgnoreCase))
                        {
                            //check in the particular date room is available or not
                            if (room.StayingDateFrom > fromDate && room.StayingDateTo < fromDate && room.StayingDateFrom > toDate && room.StayingDateTo < toDate && !room.Status.Equals(BookingStatus.Booked))
                            {
                                flag = true;
                            }
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                    //if room is available then add the room to the available room list
                    if (flag)
                    {
                        availableRooms.Add(selection);
                    }
                }
                if (availableRooms.Count > 0)
                {
                    Grid<RoomDetails>.PrintTable(availableRooms);

                    Console.WriteLine("Enter the Room ID..");
                    string roomId = Console.ReadLine().ToUpper();

                    //to check if the room id is available
                    int isValidRoomID = CustomList<RoomDetails>.BinarySearch(roomDetails, roomId, "RoomID", out RoomDetails currentRoom);
                    if (isValidRoomID >= 0)
                    {
                        //binary serch to check if the id is present in the availabe rooms list
                        int isRoomAvailable = CustomList<RoomDetails>.BinarySearch(availableRooms, roomId, "RoomID", out currentRoom);
                        if (isRoomAvailable >= 0)
                        {
                            //creating the wishlist with the above data adnd ading it to list
                            WishList list = new WishList(currentUser.UserID, currentRoom.RoomID, (toDate - fromDate).TotalDays > 0 ? currentRoom.PricePerDay * (toDate - fromDate).TotalDays : currentRoom.PricePerDay, fromDate, toDate);
                            wishList.Add(list);
                            Console.WriteLine("Booking Successfully added to WishList");

                            //ask and get if the user want to add another room
                            Console.WriteLine("Do you Wish to add another Room");

                            addCartAgain = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Room is already booked");
                        }
                    }//if invalid room id
                    else
                    {
                        Console.WriteLine("Invalid Room Id");
                    }
                }//if no available rooms
                else
                {
                    Console.WriteLine("All room are booked on the particular date. Kindly choose another date");
                }
            } while (addCartAgain.Equals("yes", StringComparison.OrdinalIgnoreCase));


        }

        public void ViewUserProfile()
        {
            //To show the User Detail Profile
            CustomList<UserRegistration> printUser = [currentUser];
            Grid<UserRegistration>.PrintTable(printUser);
        }
        public void WalletRecharge()
        {
            //asking and geting the wish to recharge from the user
            Console.WriteLine("Do you wish to Recharge the wallet? (yes/no)");
            string choice = Console.ReadLine();

            //if the choice is yes then the recharge process start
            if (choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                //getting the recharge amount and call the wallet recharge method
                Console.WriteLine("Enter amount to recharge ");
                double amount = Convert.ToDouble(Console.ReadLine());
                currentUser.WalletRecharge(amount);

                //printing the Current balance of the Current balance after recharge
                ShowWalletBalance();
            }
            //If The user choice is other the yes the it return to sub menu
            else
            {
                Console.WriteLine("Returning to Sub Menu");
            }

        }
        public void ShowWalletBalance()
        {
            //showing the wallet balance of the current user using wallet balance property
            Console.WriteLine($"Current Balance of the {currentUser.UserID} is Rs.{currentUser.WalletBalance}.");
        }
    }

}
