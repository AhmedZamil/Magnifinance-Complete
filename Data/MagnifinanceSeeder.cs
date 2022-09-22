using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DutchTreat.Data.Entities;
using Magnifinance.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace DutchTreat.Data
{
  public class MagnifinanceSeeder
  {
    private readonly MagnifinanceContext _ctx;
    private readonly IWebHostEnvironment _hosting;
    private readonly UserManager<StoreUser> _userManager;

    public MagnifinanceSeeder(MagnifinanceContext ctx,
      IWebHostEnvironment hosting,
      UserManager<StoreUser> userManager)
    {
      _ctx = ctx;
      _hosting = hosting;
      _userManager = userManager;
    }

    public async Task SeedAsync()
    {
      _ctx.Database.EnsureCreated();

      StoreUser user = await _userManager.FindByEmailAsync("ahmedlutfulzamil@gmail.com");

      if (user == null)
      {
        user = new StoreUser()
        {
          FirstName = "ahmed",
          LastName = "zamil",
          Email = "ahmedlutfulzamil@gmail.com",
          UserName = "ahmedlutfulzamil@gmail.com"
        };

        var result = await _userManager.CreateAsync(user, "Ahmed@12345");
        if (result != IdentityResult.Success)
        {
          throw new InvalidOperationException("Could not create new user in Seeder");
        }
      }
    }
  }
}
