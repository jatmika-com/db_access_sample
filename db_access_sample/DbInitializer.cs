using System;
using System.Collections.Generic;
using System.Linq;
using app_global;
using Microsoft.EntityFrameworkCore;


public static class DbInitializer
{
  public static void Initialize()
  {

    using (var context = new Model())
    {

      context.Database.Migrate(); //init migration

      if (context.enumerators.Any())
      { // Look for any user.
        return;   // DB has been seeded
      }

      //m_feature_group
      List<enumerator> enumerators_list = new List<enumerator>
      {
        new enumerator{enumerator_value=3.20 },
        new enumerator{enumerator_value=4.80 },
        new enumerator{enumerator_value=6.20 },
        new enumerator{enumerator_value=1.80 },
        new enumerator{enumerator_value=4.50 },
        new enumerator{enumerator_value=3.50 },
      };
      foreach (enumerator enumerator_data in enumerators_list)
      {
        context.enumerators.Add(enumerator_data);
      }
      context.SaveChanges();
    }
  }

  public static string GetAllData()
  {
    string return_data = "";
    Model _context = new Model();

    var all_data = _context.enumerators.ToList();
    return_data = Newtonsoft.Json.JsonConvert.SerializeObject(all_data);

    return return_data;
  }
  public static string GetAverageData()
  {
    string return_data = "";
    Model _context = new Model();

    double average = _context.enumerators.Average(e => e.enumerator_value);
    return_data = "average value = " + average;

    return return_data;
  }
}
