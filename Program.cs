using System;
using System.Linq;

namespace SafariVacation
{
  class Program
  {
    static void CreateData()
    {
      var db = new SafariVacationContext();

      var lion = new Safari
      {
        Species = "lion",
        CountOfTimesSeen = 3,
        LocationOfLastSeen = "Savannah",
      };

      var tiger = new Safari
      {
        Species = "tiger",
        CountOfTimesSeen = 6,
        LocationOfLastSeen = "jungle",
      };
      var bears = new Safari
      {
        Species = "bears",
        CountOfTimesSeen = 9,
        LocationOfLastSeen = "forest",
      };
      var snakes = new Safari
      {
        Species = "snakes",
        CountOfTimesSeen = 12,
        LocationOfLastSeen = "desert",
      };

      db.Safaris.Add(lion);
      db.Safaris.Add(tiger);
      db.Safaris.Add(bears);
      db.Safaris.Add(snakes);
      db.SaveChanges();
    }

    static void ReadData()
    {
      var db = new SafariVacationContext();

      var allJungle = db.Safaris
      .Where(Safari => Safari.LocationOfLastSeen == "jungle")
      .Select(safari => safari.Species);
      foreach (var animal in allJungle)


        Console.WriteLine(animal);
    }

    static void AnimalCount()
    {
      var db = new SafariVacationContext();
      var total = db.Safaris.Sum(Safari => Safari.CountOfTimesSeen);
      Console.WriteLine(total);
    }
    static void OhMy()
    {
      var db = new SafariVacationContext();
      var furrys = db.Safaris.Where(Safari => Safari.Species == "lion" || Safari.Species == "tiger" || Safari.Species == "bears").Sum(Safari => Safari.CountOfTimesSeen);
      Console.WriteLine(furrys);
    }




    static void UpdateData()
    {
      var db = new SafariVacationContext();
      var countToUpdate = db.Safaris.FirstOrDefault(safari => safari.Species == "snakes");
      countToUpdate.CountOfTimesSeen = 13;
      countToUpdate.LocationOfLastSeen = "jungle";
      db.SaveChanges();
    }



    static void DeleteData()
    {
      var db = new SafariVacationContext();

      //   var desertDelete = db.Safaris.FirstOrDefault(safari => safari.LocationOfLastSeen == "desert");
      //   db.Safaris.Remove(desertDelete);

      var oops = db.Safaris.FirstOrDefault(Safari => Safari.Species == "bears");
      db.Safaris.Remove(oops);
      db.SaveChanges();
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      //   CreateData();
      //   UpdateData();
      //   ReadData();
      DeleteData();
      //   OhMy();
    }
  }
}
