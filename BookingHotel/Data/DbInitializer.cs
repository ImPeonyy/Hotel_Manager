using BookingHotel.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace BookingHotel.Data

{
    public class DbInitializer
    {
        public static void Initialize(HotelContext hotelContext)
        {
            // Room Context
            hotelContext.Database.EnsureCreated();

            if (hotelContext.Rooms.Any())
            {
                return;   // DB has been seeded
            }

            var roomTypes = new RoomType[]
            {
                new RoomType{roomTypeName="OceanFront Room", roomLeft=8},
                new RoomType{roomTypeName="City View Room", roomLeft=3},
                new RoomType{roomTypeName="Surf Club Room", roomLeft=8},
                new RoomType{roomTypeName="Bay-View Room", roomLeft=5},
                new RoomType{roomTypeName="Ocean Bungalow", roomLeft=3},
                new RoomType{roomTypeName="Ocean-View Corner Studio", roomLeft=8},
                new RoomType{roomTypeName="Bay-View Corner Studio", roomLeft=8},
                new RoomType{roomTypeName="OceanFront Four Bedroom Suite", roomLeft=6},
                new RoomType{roomTypeName="Marybelle Penthouse Suite", roomLeft=1},
                new RoomType{roomTypeName="Bay-View One Bedroom Suite", roomLeft=7},
                new RoomType{roomTypeName="OceanFront One Bedroom Suite", roomLeft=6},
                new RoomType{roomTypeName="OceanFront Two Bedroom Suite", roomLeft=4},
                new RoomType{roomTypeName="Bay-View Two Bedroom Suite", roomLeft=6},
                new RoomType{roomTypeName="Surf Club One Bedroom Suite", roomLeft=3},
                new RoomType{roomTypeName="City-View Two Bedroom Suite", roomLeft=2},
                new RoomType{roomTypeName="OceanFront Accessible Room", roomLeft=2},
            };
            hotelContext.RoomTypes.AddRange(roomTypes);
            hotelContext.SaveChanges();

            var rooms = new Room[]
            {
                new Room{roomName="501", roomTypeID=roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, status = "Empty"},
                new Room{roomName="601", roomTypeID=roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, status = "Empty"},
                new Room{roomName="701", roomTypeID=roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, status = "Empty"},
                new Room{roomName="801", roomTypeID=roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, status = "Empty"},
                new Room{roomName="901", roomTypeID=roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, status = "Empty"},
                new Room{roomName="1001", roomTypeID=roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, status = "Empty"},
                new Room{roomName="1101", roomTypeID=roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, status = "Empty"},
                new Room{roomName="1201", roomTypeID=roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, status = "Empty"},

                new Room{roomName="503", roomTypeID=roomTypes.Single(s => s.roomTypeID == 2).roomTypeID, status = "Empty"},
                new Room{roomName="603", roomTypeID=roomTypes.Single(s => s.roomTypeID == 2).roomTypeID, status = "Empty"},
                new Room{roomName="703", roomTypeID=roomTypes.Single(s => s.roomTypeID == 2).roomTypeID, status = "Empty"},

                new Room{roomName="502", roomTypeID=roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, status = "Empty"},
                new Room{roomName="602", roomTypeID=roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, status = "Empty"},
                new Room{roomName="702", roomTypeID=roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, status = "Empty"},
                new Room{roomName="802", roomTypeID=roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, status = "Empty"},
                new Room{roomName="902", roomTypeID=roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, status = "Empty"},
                new Room{roomName="1002", roomTypeID=roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, status = "Empty"},
                new Room{roomName="1102", roomTypeID=roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, status = "Empty"},
                new Room{roomName="1202", roomTypeID=roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, status = "Empty"},

                new Room{roomName="803", roomTypeID=roomTypes.Single(s => s.roomTypeID == 4).roomTypeID, status = "Empty"},
                new Room{roomName="903", roomTypeID=roomTypes.Single(s => s.roomTypeID == 4).roomTypeID, status = "Empty"},
                new Room{roomName="1003", roomTypeID=roomTypes.Single(s => s.roomTypeID == 4).roomTypeID, status = "Empty"},
                new Room{roomName="1103", roomTypeID=roomTypes.Single(s => s.roomTypeID == 4).roomTypeID, status = "Empty"},
                new Room{roomName="1203", roomTypeID=roomTypes.Single(s => s.roomTypeID == 4).roomTypeID, status = "Empty"},

                new Room{roomName="201", roomTypeID=roomTypes.Single(s => s.roomTypeID == 5).roomTypeID, status = "Empty"},
                new Room{roomName="202", roomTypeID=roomTypes.Single(s => s.roomTypeID == 5).roomTypeID, status = "Empty"},
                new Room{roomName="203", roomTypeID=roomTypes.Single(s => s.roomTypeID == 5).roomTypeID, status = "Empty"},

                new Room{roomName="504", roomTypeID=roomTypes.Single(s => s.roomTypeID == 6).roomTypeID, status = "Empty"},
                new Room{roomName="604", roomTypeID=roomTypes.Single(s => s.roomTypeID == 6).roomTypeID, status = "Empty"},
                new Room{roomName="704", roomTypeID=roomTypes.Single(s => s.roomTypeID == 6).roomTypeID, status = "Empty"},
                new Room{roomName="804", roomTypeID=roomTypes.Single(s => s.roomTypeID == 6).roomTypeID, status = "Empty"},
                new Room{roomName="904", roomTypeID=roomTypes.Single(s => s.roomTypeID == 6).roomTypeID, status = "Empty"},
                new Room{roomName="1004", roomTypeID=roomTypes.Single(s => s.roomTypeID == 6).roomTypeID, status = "Empty"},
                new Room{roomName="1104", roomTypeID=roomTypes.Single(s => s.roomTypeID == 6).roomTypeID, status = "Empty"},
                new Room{roomName="1204", roomTypeID=roomTypes.Single(s => s.roomTypeID == 6).roomTypeID, status = "Empty"},

                new Room{roomName="505", roomTypeID=roomTypes.Single(s => s.roomTypeID == 7).roomTypeID, status = "Empty"},
                new Room{roomName="605", roomTypeID=roomTypes.Single(s => s.roomTypeID == 7).roomTypeID, status = "Empty"},
                new Room{roomName="705", roomTypeID=roomTypes.Single(s => s.roomTypeID == 7).roomTypeID, status = "Empty"},
                new Room{roomName="805", roomTypeID=roomTypes.Single(s => s.roomTypeID == 7).roomTypeID, status = "Empty"},
                new Room{roomName="905", roomTypeID=roomTypes.Single(s => s.roomTypeID == 7).roomTypeID, status = "Empty"},
                new Room{roomName="1005", roomTypeID=roomTypes.Single(s => s.roomTypeID == 7).roomTypeID, status = "Empty"},
                new Room{roomName="1105", roomTypeID=roomTypes.Single(s => s.roomTypeID == 7).roomTypeID, status = "Empty"},
                new Room{roomName="1205", roomTypeID=roomTypes.Single(s => s.roomTypeID == 7).roomTypeID, status = "Empty"},

                new Room{roomName="301", roomTypeID=roomTypes.Single(s => s.roomTypeID == 8).roomTypeID, status = "Empty"},
                new Room{roomName="302", roomTypeID=roomTypes.Single(s => s.roomTypeID == 8).roomTypeID, status = "Empty"},
                new Room{roomName="303", roomTypeID=roomTypes.Single(s => s.roomTypeID == 8).roomTypeID, status = "Empty"},
                new Room{roomName="401", roomTypeID=roomTypes.Single(s => s.roomTypeID == 8).roomTypeID, status = "Empty"},
                new Room{roomName="402", roomTypeID=roomTypes.Single(s => s.roomTypeID == 8).roomTypeID, status = "Empty"},
                new Room{roomName="403", roomTypeID=roomTypes.Single(s => s.roomTypeID == 8).roomTypeID, status = "Empty"},

                new Room{roomName="Penthouse", roomTypeID=roomTypes.Single(s => s.roomTypeID == 9).roomTypeID, status = "Empty"},

                new Room{roomName="406", roomTypeID=roomTypes.Single(s => s.roomTypeID == 10).roomTypeID, status = "Empty"},
                new Room{roomName="506", roomTypeID=roomTypes.Single(s => s.roomTypeID == 10).roomTypeID, status = "Empty"},
                new Room{roomName="606", roomTypeID=roomTypes.Single(s => s.roomTypeID == 10).roomTypeID, status = "Empty"},
                new Room{roomName="706", roomTypeID=roomTypes.Single(s => s.roomTypeID == 10).roomTypeID, status = "Empty"},
                new Room{roomName="806", roomTypeID=roomTypes.Single(s => s.roomTypeID == 10).roomTypeID, status = "Empty"},
                new Room{roomName="906", roomTypeID=roomTypes.Single(s => s.roomTypeID == 10).roomTypeID, status = "Empty"},
                new Room{roomName="1006", roomTypeID=roomTypes.Single(s => s.roomTypeID == 10).roomTypeID, status = "Empty"},

                new Room{roomName="507", roomTypeID=roomTypes.Single(s => s.roomTypeID == 11).roomTypeID, status = "Empty"},
                new Room{roomName="607", roomTypeID=roomTypes.Single(s => s.roomTypeID == 11).roomTypeID, status = "Empty"},
                new Room{roomName="707", roomTypeID=roomTypes.Single(s => s.roomTypeID == 11).roomTypeID, status = "Empty"},
                new Room{roomName="807", roomTypeID=roomTypes.Single(s => s.roomTypeID == 11).roomTypeID, status = "Empty"},
                new Room{roomName="907", roomTypeID=roomTypes.Single(s => s.roomTypeID == 11).roomTypeID, status = "Empty"},
                new Room{roomName="1007", roomTypeID=roomTypes.Single(s => s.roomTypeID == 11).roomTypeID, status = "Empty"},

                new Room{roomName="708", roomTypeID=roomTypes.Single(s => s.roomTypeID == 12).roomTypeID, status = "Empty"},
                new Room{roomName="808", roomTypeID=roomTypes.Single(s => s.roomTypeID == 12).roomTypeID, status = "Empty"},
                new Room{roomName="908", roomTypeID=roomTypes.Single(s => s.roomTypeID == 12).roomTypeID, status = "Empty"},
                new Room{roomName="1008", roomTypeID=roomTypes.Single(s => s.roomTypeID == 12).roomTypeID, status = "Empty"},

                new Room{roomName="409", roomTypeID=roomTypes.Single(s => s.roomTypeID == 13).roomTypeID, status = "Empty"},
                new Room{roomName="509", roomTypeID=roomTypes.Single(s => s.roomTypeID == 13).roomTypeID, status = "Empty"},
                new Room{roomName="609", roomTypeID=roomTypes.Single(s => s.roomTypeID == 13).roomTypeID, status = "Empty"},
                new Room{roomName="709", roomTypeID=roomTypes.Single(s => s.roomTypeID == 13).roomTypeID, status = "Empty"},
                new Room{roomName="809", roomTypeID=roomTypes.Single(s => s.roomTypeID == 13).roomTypeID, status = "Empty"},
                new Room{roomName="909", roomTypeID=roomTypes.Single(s => s.roomTypeID == 13).roomTypeID, status = "Empty"},
                new Room{roomName="1009", roomTypeID=roomTypes.Single(s => s.roomTypeID == 13).roomTypeID, status = "Empty"},

                new Room{roomName="404", roomTypeID=roomTypes.Single(s => s.roomTypeID == 14).roomTypeID, status = "Empty"},
                new Room{roomName="405", roomTypeID=roomTypes.Single(s => s.roomTypeID == 14).roomTypeID, status = "Empty"},
                new Room{roomName="407", roomTypeID=roomTypes.Single(s => s.roomTypeID == 14).roomTypeID, status = "Empty"},

                new Room{roomName="408", roomTypeID=roomTypes.Single(s => s.roomTypeID == 15).roomTypeID, status = "Empty"},
                new Room{roomName="508", roomTypeID=roomTypes.Single(s => s.roomTypeID == 15).roomTypeID, status = "Empty"},

                new Room{roomName="608", roomTypeID=roomTypes.Single(s => s.roomTypeID == 16).roomTypeID, status = "Empty"},
                new Room{roomName="710", roomTypeID=roomTypes.Single(s => s.roomTypeID == 16).roomTypeID, status = "Empty"},
            };
            hotelContext.Rooms.AddRange(rooms);
            hotelContext.SaveChanges();

            var roomTypeDetails = new RoomTypeDetail[]
            {
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, 
                    description="With a focus on the shimmering Surfside beach and Atlantic Ocean through a full wall of windows, our oceanfront hotel and " +
                    "rooms let you enjoy the panoramic coastline not only from your furnished balcony, but also from the luxurious, spacious interior for " +
                    "true indoor-outdoor living.", 
                    maxPeople=3, view="Ocean view", size="645 to 735 sq. ft. (60 to 68 m2). 5th to 12th floors", bed= "One king or two double beds, One crib"},
               
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 2).roomTypeID, 
                    description="Perched above iconic Collins Avenue, our City-View Rooms allow you to enjoy streetscape views from the quiet comfort of a " +
                    "luxurious guest room filled with natural light through a full wall of windows.", 
                    maxPeople=3, view="City view", size="600 sq. ft. (56 m2). 5th to 7th floors", bed="One king bed, One Rollaway or One Crib"},
                
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, 
                    description="If you expect to be spending most of your time exploring Surfside’s beautiful beach and Miami’s vibrant culture, our Surf " +
                    "Club Room is the ideal option for experiencing the luxury of Four Seasons Hotel at The Surf Club, Surfside, at maximum value.", 
                    maxPeople=2, view="Surrounding grounds and courtyard", size="435 sq. ft. (40 m2). 5th to 12th floors", bed="One king bed, One crib"},
                
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 4).roomTypeID, 
                    description="Located on the upper floors of the Hotel, offering a panoramic view of the city skyline through a full wall of windows, " +
                    "spacious Bay-View Rooms are a calming oasis during your stay at Surfside.", 
                    maxPeople=3, view="Biscayne Bay and Downtown Miami", size="600 sq. ft. (56 m2). Hotel Tower, Floors 8–12", bed="One king bed, One crib or rollaway"},
               
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 5).roomTypeID, 
                    description="With privileged beach and pool views, our Ocean Bungalows are luxurious hideaways located on the second floor of The Surf " +
                    "Club’s legendary Cabana Row. From the earliest years, original architect Russell Pancost instinctively understood that these sun sanctuaries " +
                    "would always remain the true soul of The Surf Club.", 
                    maxPeople=2, view="Ocean view", size="415 sq. ft. (39 m2). 2nd floor", bed="One king bed, One crib"},
               
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 6).roomTypeID, 
                    description="Take in the most stunning sights from our Ocean-View Corner Studios. Wake up to a breathtaking panoramic vista of the shimmering " +
                    "Atlantic Ocean through a full wall of windows, and in the evenings, enjoy a glass of wine on the wraparound corner balcony that looks " +
                    "out over the city skyline.", 
                    maxPeople=3, view="Ocean view", size="700 sq. ft. (65 m2). 5th to 12th floors", bed="One king bed, One rollaway or one crib"},
               
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 7).roomTypeID, 
                    description="Offering a panoramic view of the city skyline through a full wall of windows, spacious Bay-View Corner Studios are a calming " +
                    "oasis during your stay in Surfside.", 
                    maxPeople=3, view="City view", size="735 sq. ft. (68 m2). 5th to 12th floors", bed="One king bed, One rollaway or one crib"},
              
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 8).roomTypeID, 
                    description="Step out of a dedicated elevator and walk into your Oceanfront Four Bedroom Suite to enjoy indoor-outdoor living as it’s " +
                    "meant to be lived.", 
                    maxPeople=9, view="Ocean and city", size="4328 sq. ft. (402 m2). 3rd and 4th floors, Hotel Residence Tower", bed="Two king beds and two queen beds, " +
                    "One rollaway or one crib upon request"},
               
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 9).roomTypeID, 
                    description="Named after the yacht where Harvey Firestone and his peers discovered the land on which to build The Surf Club, the Marybelle " +
                    "is our largest, most exclusive suite. Soak in unimpeded sunset views from four bedrooms, your private rooftop pool and terrace or the " +
                    "expansive living spaces designed by Joseph Dirand.", 
                    maxPeople=8, view="Ocean and city", size="7,200 sq. ft. (668 m2). Hotel Residence Tower", bed="Two king beds, one queen bed and one twin bed, " +
                    "One rollaway"},
            
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 10).roomTypeID, 
                    description="Unwind in South Florida style in our Bay-View One-Bedroom Suites, where spacious accommodations and Joseph Dirand signature " +
                    "kitchens and bathrooms make it easy to feel at home during your stay in Miami.", 
                    maxPeople=3, view="Bay view", size="1400 sq. ft. (130 m2). 4th to 10th floors", bed="One king bed, One rollaway or crib"},  
              
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 11).roomTypeID, 
                    description="For home-away-from-home comforts and stunning views of the Atlantic Ocean, our Oceanfront One Bedroom Suites are your ideal " +
                    "accommodations.", 
                    maxPeople=4, view="Ocean view", size="1800 sq. ft. (167 m2). 5th to 10th floors", bed="King bed, Sofabed and crib upon request"},
               
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 12).roomTypeID, 
                    description="Step out from your dedicated elevator and walk into our oceanfront two bedroom suites to enjoy indoor outdoor living as its " +
                    "meant to be lived.", 
                    maxPeople=5, view="Ocean view", size="2000 sq. ft. (186 m2). 7th to 10th floors", bed="Two king beds, One rollaway or crib"},
              
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 13).roomTypeID, 
                    description="Feel at home in the Miami Beaches in our spacious Bay-View Two-Bedroom suites, from the full designer kitchen to the furnished " +
                    "balcony, perfect for taking in sunset views over the bay.", 
                    maxPeople=5, view="Bay view", size="1800 sq. ft. (167 m2). 4th to 10th floors", bed="One King Bed and One Queen Bed, One rollaway or crib"},
             
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 14).roomTypeID, 
                    description="Enjoy the comforts of home in South Florida style with custom accommodations by Joseph Dirand, including a white marble bathroom " +
                    "and gourmet kitchenette.", 
                    maxPeople=3, view="Local Town of Surfside", size="965 sq. ft. (89.65 m2). Hotel Residence Tower 4th floor", bed="One king bed, One rollaway or crib"},
                
              
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 15).roomTypeID, 
                    description="Feel at home in these spacious two-bedroom suites overlooking the city.", 
                    maxPeople=5, view="City view", size="1800 sq. ft. (167 m2). Floors 4 and 5", bed="One King Bed and One Queen Bed, One rollaway or crib"},
             
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 16).roomTypeID, 
                    description="With a focus on the shimmering Atlantic Ocean through a full wall of windows, our Oceanfront Accessible Rooms let you enjoy the " +
                    "panoramic coastline not only from your furnished balcony, but also from the luxurious, spacious interior for true indoor-outdoor living.", 
                    maxPeople=3, view="Ocean view", size="645 to 735 sq. ft. (60 to 68 m2) 6th to 7th floors", bed="Two double beds, One crib"},
            };
            hotelContext.RoomTypeDetails.AddRange(roomTypeDetails);
            hotelContext.SaveChanges();

            var services = new Service[]
            {
                new Service{roomHighlights="Refrigerated private bar.In-room safe.Tea/coffee maker", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 1).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 2).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 3).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 4).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 5).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 6).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 7).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 8).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 9).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 10).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 11).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 12).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 12).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 14).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 14).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 15).roomTypeDetailID},
                new Service{roomHighlights="", bedAndBath="", servicesAndAmenities="", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 16).roomTypeDetailID},
            };
            hotelContext.Services.AddRange(services);
            hotelContext.SaveChanges();

            var roomTypeImages = new RoomTypeImage[]
            {
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 1).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront room/1.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 1).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront room/2.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 1).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront room/3.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 1).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront room/4.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 1).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront room/5.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 1).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront room/6.jpg"},

                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 2).roomTypeDetailID, imagePath="/img/roomtypeimages/city view room/1.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 2).roomTypeDetailID, imagePath="/img/roomtypeimages/city view room/2.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 2).roomTypeDetailID, imagePath="/img/roomtypeimages/city view room/3.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 2).roomTypeDetailID, imagePath="/img/roomtypeimages/city view room/4.jpg"},

                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 3).roomTypeDetailID, imagePath="/img/roomtypeimages/surf club room/1.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 3).roomTypeDetailID, imagePath="/img/roomtypeimages/surf club room/2.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 3).roomTypeDetailID, imagePath="/img/roomtypeimages/surf club room/3.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 3).roomTypeDetailID, imagePath="/img/roomtypeimages/surf club room/4.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 3).roomTypeDetailID, imagePath="/img/roomtypeimages/surf club room/5.jpg"},

                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 4).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view room/1.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 4).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view room/2.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 4).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view room/3.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 4).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view room/4.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 4).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view room/5.jpg"},

                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 5).roomTypeDetailID, imagePath="/img/roomtypeimages/ocean bungalow/1.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 5).roomTypeDetailID, imagePath="/img/roomtypeimages/ocean bungalow/2.jpg"},

                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 6).roomTypeDetailID, imagePath="/img/roomtypeimages/ocean-view corner studio/1.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 6).roomTypeDetailID, imagePath="/img/roomtypeimages/ocean-view corner studio/2.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 6).roomTypeDetailID, imagePath="/img/roomtypeimages/ocean-view corner studio/3.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 6).roomTypeDetailID, imagePath="/img/roomtypeimages/ocean-view corner studio/4.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 6).roomTypeDetailID, imagePath="/img/roomtypeimages/ocean-view corner studio/5.jpg"},

                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 7).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view corner studio/1.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 7).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view corner studio/2.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 7).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view corner studio/3.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 7).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view corner studio/4.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 7).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view corner studio/5.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 7).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view corner studio/6.jpg"},

                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 8).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront four bedroom suite/1.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 8).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront four bedroom suite/2.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 8).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront four bedroom suite/3.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 8).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront four bedroom suite/4.jpg"},

                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 9).roomTypeDetailID, imagePath="/img/roomtypeimages/marybelle penthouse suite/1.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 9).roomTypeDetailID, imagePath="/img/roomtypeimages/marybelle penthouse suite/2.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 9).roomTypeDetailID, imagePath="/img/roomtypeimages/marybelle penthouse suite/3.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 9).roomTypeDetailID, imagePath="/img/roomtypeimages/marybelle penthouse suite/4.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 9).roomTypeDetailID, imagePath="/img/roomtypeimages/marybelle penthouse suite/5.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 9).roomTypeDetailID, imagePath="/img/roomtypeimages/marybelle penthouse suite/6.jpg"},

                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 10).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view one bedroom suite/1.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 10).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view one bedroom suite/2.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 10).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view one bedroom suite/3.jpg"},

                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 11).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront one bedroom suite/1.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 11).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront one bedroom suite/2.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 11).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront one bedroom suite/3.jpg"},

                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 12).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront two bedroom suite/1.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 12).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront two bedroom suite/2.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 12).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront two bedroom suite/3.jpg"},

                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 13).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view two bedroom suite/1.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 13).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view two bedroom suite/2.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 13).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view two bedroom suite/3.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 13).roomTypeDetailID, imagePath="/img/roomtypeimages/bay-view two bedroom suite/4.jpg"},

                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 14).roomTypeDetailID, imagePath="/img/roomtypeimages/surf club one bedroom suite/1.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 14).roomTypeDetailID, imagePath="/img/roomtypeimages/surf club one bedroom suite/2.jpg"},

                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 15).roomTypeDetailID, imagePath="/img/roomtypeimages/city-view two bedroom suite/1.jpg"},

                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 16).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront accessible room/1.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 16).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront accessible room/2.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 16).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront accessible room/3.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 16).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront accessible room/4.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 16).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront accessible room/5.jpg"},
                new RoomTypeImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 16).roomTypeDetailID, imagePath="/img/roomtypeimages/oceanfront accessible room/6.jpg"},

            };
            hotelContext.roomTypeImages.AddRange(roomTypeImages);
            hotelContext.SaveChanges();

            // Booking Context

            var accounts = new Account[]
            {
                new Account{username = "pmq0511", password ="123", name = "Phạm Minh Quang", phoneNumber= "0346991600", role="user" },
                new Account { username = "user1", password = "1234", name = "Phạm User", phoneNumber = "0346991600", role="admin" },
                new Account{username = "user2", password ="12345", name= "Minh User", phoneNumber= "0346991600", role="user" }
            };
            hotelContext.Accounts.AddRange(accounts);
            hotelContext.SaveChanges();
            var requests = new Request[]
            {

                new Request {accountID= accounts.Single(s =>s.accountID ==1).accountID, dateCheckIn=DateTime.Parse("2024-05-15"),dateCheckOut=DateTime.Parse("2024-05-17"),roomTypeID=1, message="Không biết nói gì hết", status="Waiting" },
                new Request {accountID= accounts.Single(s =>s.accountID ==2).accountID, dateCheckIn=DateTime.Parse("2024-03-12"),dateCheckOut=DateTime.Parse("2024-03-17"),roomTypeID=2, message="Không biết nói gì hết", status="Waiting" },
                new Request {accountID= accounts.Single(s =>s.accountID ==3).accountID, dateCheckIn=DateTime.Parse("2024-04-14"),dateCheckOut=DateTime.Parse("2024-04-17"),roomTypeID=3, message="Không biết nói gì hết", status="Waiting" },

            };
            hotelContext.Requests.AddRange(requests);
            hotelContext.SaveChanges();

            var enrolllments = new Enrollment[]
            {
                new Enrollment {roomID = rooms.Single(s => s.roomID== 1).roomID, accountID = accounts.Single(a => a.accountID ==1).accountID, dateOfReceipt=DateTime.Parse("2024-05-15")},
                new Enrollment {roomID = rooms.Single(s => s.roomID== 2).roomID, accountID = accounts.Single(a => a.accountID ==2).accountID, dateOfReceipt=DateTime.Parse("2024-03-12")},
                new Enrollment {roomID = rooms.Single(s => s.roomID== 3).roomID, accountID = accounts.Single(a => a.accountID ==3).accountID, dateOfReceipt=DateTime.Parse("2024-04-04")}
            };
            hotelContext.Enrollments.AddRange(enrolllments);
            hotelContext.SaveChanges();

            // ComboSale Context

            var comboSales = new ComboSale[]
            {
                new ComboSale{title="Combo Sale 1", genre="genre 1", content="content 1", image="path 1", price=100},
                new ComboSale{title="Combo Sale 2", genre="genre 2", content="content 2", image="path 2", price=200},
                new ComboSale{title="Combo Sale 3", genre="genre 3", content="content 3", image="path 3", price=300},
            };
            hotelContext.ComboSales.AddRange(comboSales);
            hotelContext.SaveChanges();
        }
    }
}
