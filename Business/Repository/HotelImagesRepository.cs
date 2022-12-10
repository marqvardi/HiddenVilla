using AutoMapper;
using Business.Repository.IRepository;
using DataLayerAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class HotelImagesRepository : IHotelImageRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public HotelImagesRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<int> CreateHotelRoomImage(HotelRoomImageDto hotelRoomImageDto)
        {
            var image = mapper.Map<HotelRoomImageDto, HotelRoomImage>(hotelRoomImageDto);
            await dbContext.HotelRoomImages.AddAsync(image);
            return await dbContext.SaveChangesAsync();

        }

        public async Task<int> DeleteHotelImageByImageUrl(string imageUrl)
        {
            var image = await dbContext.HotelRoomImages.FirstOrDefaultAsync(c => c.RoomImageUrl.ToLower() == imageUrl.ToLower());

            if (image != null)
            {
                dbContext.HotelRoomImages.Remove(image);
                return await dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> DeleteHotelRoomImageById(int imageId)
        {
            var image = await dbContext.HotelRoomImages.FindAsync(imageId);
            if (image is not null)
            {
                dbContext.HotelRoomImages.Remove(image);
                return await dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> DeleteHotelRoomImageByRoomId(int roomId)
        {
            var images = await dbContext.HotelRoomImages.Where(c => c.RoomId == roomId).ToListAsync();
            if (images is not null)
            {
                dbContext.HotelRoomImages.RemoveRange(images);
                return await dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<HotelRoomImageDto>> GetHotelRoomImages(int roomId)
        {
            return mapper.Map<IEnumerable<HotelRoomImage>, IEnumerable<HotelRoomImageDto>>(
                 await dbContext.HotelRoomImages.Where(c => c.RoomId == roomId).ToListAsync());
        }
    }
}
