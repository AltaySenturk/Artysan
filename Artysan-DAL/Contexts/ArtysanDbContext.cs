using Artysan_Entities.Entites;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_DAL.Contexts
{
    public class ArtysanDbContext : DbContext
    {
        public ArtysanDbContext(DbContextOptions options) : base(options) { }

        DbSet<Event> events { get; set; }
        DbSet<Artist> artists { get; set; }
        DbSet<Ticket> tickets { get; set; }
        DbSet<Category> categories { get; set; }
        DbSet<Customer> customers { get; set; }
        DbSet<EventArtist> eventArtists { get; set; }
        DbSet<Location> locations { get; set; }
        DbSet<EventSale> eventSales { get; set; }
        DbSet<EventSale> eventSaleDetails { get; set; }





        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            var (events, artists, tickets, categories, customers, eventartist, locations, eventSales, eventSaleDetails) = GetSeedData();

            builder.Entity<Event>().HasData(events);
            builder.Entity<Artist>().HasData(artists);
            builder.Entity<Ticket>().HasData(tickets);
            builder.Entity<Category>().HasData(categories);
            builder.Entity<Customer>().HasData(customers);
            builder.Entity<EventArtist>().HasData(eventartist);
            builder.Entity<Location>().HasData(locations);
            builder.Entity<EventSale>().HasData(eventSales);
            builder.Entity<EventSaleDetail>().HasData(eventSaleDetails);


        }

        private (IEnumerable<Event>, IEnumerable<Artist>, IEnumerable<Ticket>, IEnumerable<Category>,
        IEnumerable<Customer>, IEnumerable<EventArtist>, IEnumerable<Location>,
        IEnumerable<EventSale>, IEnumerable<EventSaleDetail>) GetSeedData()
        {
            var filePath = "../extensions/c.json";
            var jsonContent = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<List<Event>>(jsonContent).ToArray();
            var data2 = JsonConvert.DeserializeObject<List<Artist>>(jsonContent).ToArray();
            var data3 = JsonConvert.DeserializeObject<List<Ticket>>(jsonContent).ToArray();
            var data4 = JsonConvert.DeserializeObject<List<Category>>(jsonContent).ToArray();
            var data5 = JsonConvert.DeserializeObject<List<Customer>>(jsonContent).ToArray();
            var data6 = JsonConvert.DeserializeObject<List<EventArtist>>(jsonContent).ToArray();
            var data7 = JsonConvert.DeserializeObject<List<Location>>(jsonContent).ToArray();
            var data8 = JsonConvert.DeserializeObject<List<EventSale>>(jsonContent).ToArray();
            var data9 = JsonConvert.DeserializeObject<List<EventSaleDetail>>(jsonContent).ToArray();
            return (data, data2, data3, data4, data5, data6, data7, data8, data9);
        }
    }
}
