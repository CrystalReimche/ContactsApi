using ContactsApi.Models;

namespace ContactsApi.Data
{
    public class Seed
    {
        // Seeding InMemoryDatabase
        public static void SeedAsync(ContactsAPIDbContext dbContext)
        {
            if (!dbContext.Contacts.Any())
            {
                var contacts = new List<Contact>
                {
                    new Contact
                    {
                        FullName = "Fermin A. Nussbaum",
                        Email = "FerminANussbaum@armyspy.com",
                        Phone = 5852475561,
                        Address = "2560 Caldwell Road, Rochester, NY 14624"
                    },
                    new Contact
                    {
                        FullName = "Hayden J. Reiss",
                        Email = "HaydenJReiss@rhyta.com",
                        Phone = 3183738123,
                        Address = "1636 August Lane, Alexandria, LA 71301"
                    },
                    new Contact
                    {
                        FullName = "Darryl D. Griegoss",
                        Email = "DarrylDGriego@dayrep.com",
                        Phone = 7249459064,
                        Address = "1158 Spruce Drive, Scenery Hill, PA 15360"
                    }
                };

                dbContext.Contacts.AddRange(contacts);
                dbContext.SaveChanges();
            }
        }
    }
}
