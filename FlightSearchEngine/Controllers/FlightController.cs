using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FlightSearchEngine.Models;

public class FlightController : Controller
{
    private readonly string connectionString;

    public FlightController(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public IActionResult Index()
    {
        var model = new SearchViewModel
        {
            SourceList = new SelectList(GetCities("Source")),
            DestinationList = new SelectList(GetCities("Destination"))
        };

        return View(model);
    }

    private List<string> GetCities(string column)
    {
        List<string> list = new List<string>();

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT DISTINCT {column} FROM Flights", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(reader[0].ToString());
            }
        }

        return list;
    }
}