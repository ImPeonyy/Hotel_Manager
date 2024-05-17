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
                new RoomType{roomTypeName="Luxury", roomLeft=10},
                new RoomType{roomTypeName="Vip", roomLeft=10},
                new RoomType{roomTypeName="Lite", roomLeft=10}
            };
            hotelContext.RoomTypes.AddRange(roomTypes);
            hotelContext.SaveChanges();

            var rooms = new Room[]
            {
                new Room{roomName="101", roomTypeID=roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, accountID=1},
                new Room{roomName="102", roomTypeID=roomTypes.Single(s => s.roomTypeID == 2).roomTypeID, accountID=2},
                new Room{roomName="103", roomTypeID=roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, accountID=3}
            };
            hotelContext.Rooms.AddRange(rooms);
            hotelContext.SaveChanges();

            var roomTypeDetails = new RoomTypeDetail[]
            {
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 1).roomTypeID, description="Phong dep lam nha 1", maxPeople=1, view="Beach", size="44,1", bed=2},
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 2).roomTypeID, description="Phong dep lam nha 2", maxPeople=2, view="Beach", size="44,1", bed=2},
                new RoomTypeDetail{roomTypeID = roomTypes.Single(s => s.roomTypeID == 3).roomTypeID, description="Phong dep lam nha 3", maxPeople=3, view="Beach", size="44,1", bed=2},
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
                new Request {accountID= accounts.Single(s =>s.accountID ==1).accountID, dateCheckIn=DateTime.Parse("2024-05-15"),dateCheckOut=DateTime.Parse("2024-05-17"),roomType="Luxury",message="Không biết nói gì hết", status="Chưa duyệt" },
                new Request {accountID= accounts.Single(s =>s.accountID ==2).accountID, dateCheckIn=DateTime.Parse("2024-03-12"),dateCheckOut=DateTime.Parse("2024-03-17"),roomType="Lite",message="Không biết nói gì hết", status="Chưa duyệt" },
                new Request {accountID= accounts.Single(s =>s.accountID ==3).accountID, dateCheckIn=DateTime.Parse("2024-04-14"),dateCheckOut=DateTime.Parse("2024-04-17"),roomType="Lite",message="Không biết nói gì hết", status="Chưa duyệt" },
            };
            hotelContext.Requests.AddRange(requests);
            hotelContext.SaveChanges();

            var bookings = new Booking[]
            {
                new Booking {accountID= accounts.Single(s =>s.accountID ==1).accountID, dateCheckIn=DateTime.Parse("2024-05-15"),dateCheckOut=DateTime.Parse("2024-05-17"),roomType="Luxury",message="Không biết nói gì hết", status="Trống" },
                new Booking {accountID= accounts.Single(s =>s.accountID ==2).accountID, dateCheckIn=DateTime.Parse("2024-03-12"),dateCheckOut=DateTime.Parse("2024-03-17"),roomType="Lite",message="Không biết nói gì hết", status="Có khách"},
                new Booking {accountID= accounts.Single(s =>s.accountID ==3).accountID, dateCheckIn=DateTime.Parse("2024-04-14"),dateCheckOut=DateTime.Parse("2024-04-17"),roomType="Lite",message="Không biết nói gì hết", status="Trống" },
            };
            hotelContext.Bookings.AddRange(bookings);
            hotelContext.SaveChanges();

            var enrolllments = new Enrollment[]
            {
                new Enrollment {roomID = rooms.Single(s => s.roomID== 1).roomID, accountID = accounts.Single(a => a.accountID ==1).accountID, dateOfReceipt=DateTime.Parse("2024-05-15")},
                new Enrollment {roomID = rooms.Single(s => s.roomID== 3).roomID, accountID = accounts.Single(a => a.accountID ==2).accountID, dateOfReceipt=DateTime.Parse("2024-03-12")},new Enrollment {roomID = rooms.Single(s => s.roomID== 3).roomID, accountID = accounts.Single(a => a.accountID ==3).accountID, dateOfReceipt=DateTime.Parse("2024-04-04")}
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
