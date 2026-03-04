using SA_lab_3.DAL;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System;
namespace SA_lab_3.DAL
{
    public class Data
    {
        private List<Location> _locations = new List<Location>();
        public List<User> allUsers = new List<User>();
        private float width = 960f;
        private float height = 872f;
        private string dataFilePath = "app_data.json";
        public Data()
        {
            if (File.Exists(dataFilePath))
            {
                LoadData();
            }
            else
            {
                SeedHardcodedData(); // Hardcode backup
                SaveData(); 
            }
        }
        public void SaveData()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true, // for saving { get; set; }
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            };

            var wrapper = new DataWrapper { Locations = _locations, Users = allUsers };
            string json = JsonSerializer.Serialize(wrapper, options);
            File.WriteAllText(dataFilePath, json);
        }
        private void LoadData()
        {
            string json = File.ReadAllText(dataFilePath);
            var options = new JsonSerializerOptions { IncludeFields = true };
            var wrapper = JsonSerializer.Deserialize<DataWrapper>(json, options);
            if (wrapper != null)
            {
                _locations = wrapper.Locations ?? new List<Location>();
                allUsers = wrapper.Users ?? new List<User>();
            }
        }
        private class DataWrapper
        {
            public List<Location> Locations { get; set; }
            public List<User> Users { get; set; }
        }
        private void SeedHardcodedData()
        {
            allUsers.Add(new User//strawberry
            {
                Id = -1,
                name = "John Marston(Beecher's Hope )",

                IsManager = false
            });
            _locations.Add(new Location
            {
                Id = -1,
                name = "Beecher's Hope ",
                description = "Beecher's Hope is a safehouse and a ranch in the Great Plains region of the West Elizabeth territory. ",
                X = 218/width,
                Y = 565/height,
                //ImagePaths = new List<string> { @"C:" },
               // Manager = allUsers[0]
            });
            // Hardcode
            _locations.Add(new Location
            {
                Id = 1,
                name = "Valentine",
                description = $"Valentine is a livestock town, a short ride away from the Horseshoe Overlook camp\n" +
                $" the first camp the gang makes after their exodus from the frigid mountains. ",
                X = 0.45f,
                Y = 0.35f, 
                //ImagePaths = new List<string> { @"C:\Images\valentine1.jpg", @"C:\Images\valentine2.jpg" }
            });
            allUsers.Add(new User// Governor of New Hanover
            {
                Id = 1,
                name = "John James Peterson(New Hanover)",

            });
            _locations.Add(new Location
            {
                Id = 2,
                name = "Saint Denis",
                description = "\"Jewel of Lemoyne,\" is a major city and the state capital of Lemoyne\n" +
                "Saint Denis is a heavily industrialized city at the turn of the 20th century, with large factories with towering chimneys.",
                X = 777/width,
                Y = 548/height,

            });
            allUsers.Add(new User// Saint Denis
            {
                Id = 2,
                name = "Henri Lemieux (Saint Denis)",
            });

            allUsers.Add(new User//strawberry
            {
                Id = 0,
                name = "Nicholas Timmins(strawberry)",
                //Visited.add()
                IsManager = true
            });
            _locations.Add(new Location
            {
                Id = 0,
                name = "Strawberry",
                description = "It serves as the capital of the Big Valley region. It is found roughly south-central in the region, southeast of Mount Shann.\n" +
                " Although the city was founded as a small logging town, it has grown in recent years and displays sluices and other equipment often associated with small gold mining operations.\n" +
                " Nonetheless, its mayor wishes to transform it into a resort town. ",
                X = 205/width,
                Y = 431/height,

                Manager = allUsers[0]
            });
            allUsers.Add(new User
            {
                Id = 5,
                name = "Josiah Blackwater",
            });
            _locations.Add(new Location
            {
                Id = 5,
                name = "Blackwater",
                description = " is a growing city and the state capital of the commonwealth of West Elizabeth\n" +
                "Blackwater is an industrialized settlement and is the largest and most modern city in Red Dead Redemption, serving the area as a thriving port on Flat Iron Lake. ",
                X = 0.340625f,
                Y = 0.6227064220183486f,

                // Manager = allUsers[0]
            });
            allUsers.Add(new User
            {
                Id = 6,
                name = "Leigh Gray (Rhoades)",
            });
            _locations.Add(new Location
            {
                Id = 6,
                name = "Rhoades",
                description = "a small town  located in the Scarlett Meadows region of the state of Lemoyne.\n" +
                "Rhodes was primarily founded by Sherman M. Rhodes, a Brigadier General in the army. The town plays host to a busy railway station on the west side of town. ",
                X = 597/width,
                Y = 547/height,

            });
            allUsers.Add(new User
            {
                Id = 7,
                name = "Archibald Jameson and Leviticus Cornwall (Annesburg)",
            });
            _locations.Add(new Location
            {
                Id = 7,
                name = "Annesburg",
                description = "Annesburg is a mining town located in the Roanoke Ridge region of the state of New Hanover, on the banks of the Lannahechee River.  ",
                X = 899 / width,
                Y = 143 / height,

            });
            _locations.Add(new Location
            {
                Id = 8,
                name = "Colter",
                description = "Ex miner's city and an abandoned settlement, a gang hideout and a camp hideout\n" +
                "It serves as the location of the Van der Linde gang’s camp",
                X = 342 / width,
                Y = 140 / height,

            });
        }

        public List<Location> GetAll() => _locations;
        public  List<User> GetUsers() => allUsers;
    }
}

