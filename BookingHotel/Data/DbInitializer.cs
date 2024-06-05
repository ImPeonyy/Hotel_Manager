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
                new RoomType{roomTypeName="King Room", roomLeft=5},
                new RoomType{roomTypeName="Suite Room", roomLeft=5},
                new RoomType{roomTypeName="Family Room", roomLeft=5},
                new RoomType{roomTypeName="Deluxe Room", roomLeft=5},
                new RoomType{roomTypeName="Luxury Room", roomLeft=5},
                new RoomType{roomTypeName="Superior Room", roomLeft=5}
            };
            hotelContext.RoomTypes.AddRange(roomTypes);
            hotelContext.SaveChanges();

            var rooms = new Room[]
            {
                new Room{roomName="101", roomTypeID=roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, status = "Empty"},
                new Room{roomName="102", roomTypeID=roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, status = "Empty"},
                new Room{roomName="103", roomTypeID=roomTypes.Single(s => s.roomTypeID == 2).roomTypeID, status = "Empty"},
                new Room{roomName="104", roomTypeID=roomTypes.Single(s => s.roomTypeID == 2).roomTypeID, status = "Empty"},
                new Room{roomName="105", roomTypeID=roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, status = "Empty"},

                new Room{roomName="201", roomTypeID=roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, status = "Empty"},
                new Room{roomName="202", roomTypeID=roomTypes.Single(s => s.roomTypeID == 2).roomTypeID, status = "Empty"},
                new Room{roomName="203", roomTypeID=roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, status = "Empty"},
                new Room{roomName="204", roomTypeID=roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, status = "Empty"},
                new Room{roomName="205", roomTypeID=roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, status = "Empty"},

                new Room{roomName="301", roomTypeID=roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, status = "Empty"},
                new Room{roomName="302", roomTypeID=roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, status = "Empty"},
                new Room{roomName="303", roomTypeID=roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, status = "Empty"},
                new Room{roomName="304", roomTypeID=roomTypes.Single(s => s.roomTypeID == 2).roomTypeID, status = "Empty"},
                new Room{roomName="305", roomTypeID=roomTypes.Single(s => s.roomTypeID == 2).roomTypeID, status = "Empty"},

                new Room{roomName="401", roomTypeID=roomTypes.Single(s => s.roomTypeID == 4).roomTypeID, status = "Empty"},
                new Room{roomName="402", roomTypeID=roomTypes.Single(s => s.roomTypeID == 4).roomTypeID, status = "Empty"},
                new Room{roomName="403", roomTypeID=roomTypes.Single(s => s.roomTypeID == 4).roomTypeID, status = "Empty"},
                new Room{roomName="404", roomTypeID=roomTypes.Single(s => s.roomTypeID == 5).roomTypeID, status = "Empty"},
                new Room{roomName="405", roomTypeID=roomTypes.Single(s => s.roomTypeID == 6).roomTypeID, status = "Empty"},

                new Room{roomName="501", roomTypeID=roomTypes.Single(s => s.roomTypeID == 5).roomTypeID, status = "Empty"},
                new Room{roomName="502", roomTypeID=roomTypes.Single(s => s.roomTypeID == 5).roomTypeID, status = "Empty"},
                new Room{roomName="503", roomTypeID=roomTypes.Single(s => s.roomTypeID == 5).roomTypeID, status = "Empty"},
                new Room{roomName="504", roomTypeID=roomTypes.Single(s => s.roomTypeID == 4).roomTypeID, status = "Empty"},
                new Room{roomName="505", roomTypeID=roomTypes.Single(s => s.roomTypeID == 6).roomTypeID, status = "Empty"},

                new Room{roomName="601", roomTypeID=roomTypes.Single(s => s.roomTypeID == 4).roomTypeID, status = "Empty"},
                new Room{roomName="602", roomTypeID=roomTypes.Single(s => s.roomTypeID == 5).roomTypeID, status = "Empty"},
                new Room{roomName="603", roomTypeID=roomTypes.Single(s => s.roomTypeID == 6).roomTypeID, status = "Empty"},
                new Room{roomName="604", roomTypeID=roomTypes.Single(s => s.roomTypeID == 6).roomTypeID, status = "Empty"},
                new Room{roomName="605", roomTypeID=roomTypes.Single(s => s.roomTypeID == 6).roomTypeID, status = "Empty"},

            };
            hotelContext.Rooms.AddRange(rooms);
            hotelContext.SaveChanges();

            var roomTypeDetails = new RoomTypeDetail[]
            {
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, description="With views of the city, this luxurious room has been designed with a refreshing palette of nature-inspired green tones infused with subtle local touches.", 
                    maxPeople=2, view="City View", size="32", bed=1},
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 2).roomTypeID, description="With views spanning over the cityscape, this spacious room features two double beds and an elegant bathroom with a rain shower and luxurious bath.", 
                    maxPeople=2, view="City View", size="32", bed=2},
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, description="Phong dep lam nha 3", maxPeople=4, view="Garden View", size="32", bed=2},
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 4).roomTypeID, description="Floor-to-ceiling windows overlooking the city, this spacious room comes complete with a private balcony and an elegant bathroom, featuring a rain shower and luxurious bath.",
                    maxPeople=3, view="Beach View", size="64", bed=1},
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 5).roomTypeID, description="Phong dep lam nha 2", maxPeople=3, view="Beach View", size="96", bed=1},
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 6).roomTypeID, description="Boasting panoramic vistas of Marina Bay and Singapore's skyline through its floor-to-ceiling windows, this beautifully appointed room features a cool blue colour palette and includes exclusive lounge access.", 
                    maxPeople=2, view="Beach View", size="128", bed=1},
            };
            hotelContext.RoomTypeDetails.AddRange(roomTypeDetails);
            hotelContext.SaveChanges();

            var services = new Service[]
            {
                new Service{general="dich vu 1", bathroom="phong tam dep 1", other="may cai khac cx oke 1", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 1).roomTypeDetailID},
                new Service{general="dich vu 2", bathroom="phong tam dep 2", other="may cai khac cx oke 2", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 2).roomTypeDetailID},
                new Service{general="dich vu 3", bathroom="phong tam dep 3", other="may cai khac cx oke 3", roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 3).roomTypeDetailID},
            };
            hotelContext.Services.AddRange(services);
            hotelContext.SaveChanges();

            var roomTypeDetailImages = new RoomTypeDetailImage[]
            {
                new RoomTypeDetailImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 1).roomTypeDetailID, imagePath="path 1"},
                new RoomTypeDetailImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 2).roomTypeDetailID, imagePath="path 2"},
                new RoomTypeDetailImage{roomTypeDetailID= roomTypeDetails.Single(s => s.roomTypeDetailID == 3).roomTypeDetailID, imagePath="path 3"},
            };
            hotelContext.roomTypeDetailImages.AddRange(roomTypeDetailImages);
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
