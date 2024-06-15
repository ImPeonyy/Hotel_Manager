using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel.Models
{
    public class COMBOGenreViewModel
    {
        public List<ComboSale> ComboSales { get; set; }
        public SelectList Genres { get; set; }
        public string CombosaleGenre { get; set; }
        public string SearchString { get; set; }
    }
    public class ComboSale
    {
        public int comboSaleID { get; set; }

        // [Required(ErrorMessage = "Price is required.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Title must be over 10 and under 100 characters")]
        public string title { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(30, ErrorMessage = "Content cannot be longer than 500 characters.")]
        public string genre { get; set; }
        [StringLength(100, ErrorMessage = "ShortContent cannot be longer than 100 characters.")]
        public string ShortContent { get; set; }

        [StringLength(2000, ErrorMessage = "Content cannot be longer than 2000 characters.")]
        public string content { get; set; }

        public string image { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid price.")]
        //0: Giá trị tối thiểu được phép đối với price.
        //double.MaxValue: Giá trị tối đa được phép cho price, là giá trị kép lớn nhất có thể.
        public double? price { get; set; }

        [NotMapped]
        public List<string> GenreList { get; } = new List<string> { "Friendly Service", "Get Breakfast", "Transfer Services", "Suits & SPA", "Cozy Rooms" };


    }
}
