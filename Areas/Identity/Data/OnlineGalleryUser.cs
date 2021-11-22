using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OnlineGallery.Areas.Identity.Data;

// Add profile data for application users by adding properties to the OnlineGalleryUser class
public class OnlineGalleryUser : IdentityUser
{
    //create database
    [PersonalData]//private field
    [Column(TypeName = "nvarchar(30)")]//datatipe
    public string FirstName { get; set; }//field

    [PersonalData]//private field
    [Column(TypeName = "nvarchar(30)")]//datatipe
    public string LastName { get; set; }//field
}