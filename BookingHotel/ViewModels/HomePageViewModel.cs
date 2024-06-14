using BookingHotel.Models;

namespace BookingHotel.ViewModels
{
    public class HomePageViewModel
    {
        public Request Request { get; set; }
        public IEnumerable<RoomTypeViewModel> RoomTypeViewModels { get; set; }
    }
}
