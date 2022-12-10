using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IHotelImageRepository
    {
        public Task<int> CreateHotelRoomImage(HotelRoomImageDto hotelRoomImageDto);
        public Task<int> DeleteHotelRoomImageById(int imageId);
        public Task<int> DeleteHotelRoomImageByRoomId(int roomId);
        public Task<int> DeleteHotelImageByImageUrl(string imageUrl);
        public Task<IEnumerable<HotelRoomImageDto>> GetHotelRoomImages(int roomId);
    }
}
