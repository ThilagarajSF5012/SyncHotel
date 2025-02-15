using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncHotel
{
  /// <summary>
  /// Class PersonalDetails <see cref="PersonalDetails"/> is used to create and give the personal Detail of the user
  /// </summary>
  public class PersonalDetails
  {

    /// <summary>
    /// property User name is user to give the name to the user
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Property MobileNumber is used to give the Mobile Number to the user
    /// </summary>
    /// <value></value>
    public string MobileNumber { get; set; }
     /// Property AadharNumber is used to give the Aadhar Number to the user
    /// </summary>
    /// <value></value>
    public string AadharNumber { get; set; }

     /// Property Email is used to give email to the user
    /// </summary>
    /// <value></value>
    public string Email { get; set; }

     /// Property Address is used to give the Address to the user
    /// </summary>
    /// <value></value>
    public string Address { get; set; }

     /// Property Food is used to give the FoodType to the user
    /// </summary>
    /// <value></value>
    public FoodType Food { get; set; }

     /// Property Gender is used to give Gender Type to the user
    /// </summary>
    /// <value></value>
    public GenderType Gender { get; set; }

    /// <summary>
    /// constructor Personal Details is used to initialize object without parameters
    /// </summary>
    public PersonalDetails()
    {

    }
/// <summary>
/// it is the Parameterized constructor which is used to intialize the personalDetails with the argument
/// </summary>
/// <param name="name">parameter name isused to assign the value to the Property Name</param>
/// <param name="mobile">parmaeter mobile is used to assign the value to the property MobileNumber</param>
/// <param name="aadhar">parmaeter aadhar is used to assign the value to the property aadharNumber</param>
/// <param name="email">parmaeter email is used to assign the value to the property Email</param>
/// <param name="address">parmaeter Address is used to assign the value to the property addres</param>
/// <param name="food">parmaeter food is used to assign the value to the property Food</param>
/// <param name="gender">parmaeter gender is used to assign the value to the property Gender</param>
    public PersonalDetails(string name, string mobile, string aadhar, string email, string address, FoodType food, GenderType gender)
    {
      UserName = name;
      MobileNumber = mobile;
      AadharNumber = aadhar;
      Email = email;
      Address = address;
      Food = food;
      Gender = gender;
    }

  }
}