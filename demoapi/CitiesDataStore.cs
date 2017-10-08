using System;
using System.Collections.Generic;
using demoapi.Models;

namespace demoapi
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDto> Cities { get; set;  }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Leander",
                    Description = "Our awesome home in Leander Texas!!!",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest() {
                            Id = 1,
                            Name = "H E B",
                            Description = "Most visited point in Leander!!"
                        },
                        new PointOfInterest(){
                            Id = 2,
                            Name = "Lowes",
                            Description = "Frequently visited to construct awesome things!"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Sacramento",
                    Description = "Where Auntie Sheilah lives!"
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "London",
                    Description = "Nana and Opa live here in London Ontario Canada!"
                }

            };
        }
    }
}
