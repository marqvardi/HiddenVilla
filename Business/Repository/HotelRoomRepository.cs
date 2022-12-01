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
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public HotelRoomRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<HotelRoomDto> CreateHotelRoom(HotelRoomDto hotelRoomDto)
        {
            var hotelRoom = mapper.Map<HotelRoom>(hotelRoomDto);
            hotelRoom.CreatedDate = DateTime.Now;
            hotelRoom.CreatedBy = "";

            var addedHotelRoom = await dbContext.HotelRooms.AddAsync(hotelRoom);
            await dbContext.SaveChangesAsync();

            return mapper.Map<HotelRoomDto>(addedHotelRoom.Entity);
        }

        public async Task<int> DeleteHotelRoom(int roomId)
        {
            var roomDetails = await dbContext.HotelRooms.FindAsync(roomId);

            if(roomDetails != null)
            {
                dbContext.HotelRooms.Remove(roomDetails);
                return await dbContext.SaveChangesAsync();
            }
            else
            {
                return 0;
            }

        }

        public async Task<IEnumerable<HotelRoomDto>> GetAllHotelRoom()
        {
            try
            {
                return mapper.Map<IEnumerable<HotelRoomDto>>(dbContext.HotelRooms);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDto> GetHotelRoom(int roomId)
        {
            try
            {
                var hotelRoomDto = mapper.Map<HotelRoomDto>(await dbContext.HotelRooms.FirstOrDefaultAsync(c => c.Id == roomId));

                return hotelRoomDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDto> IsRoomUnique(string name)
        {
            try
            {
                var hotelRoomDto = mapper.Map<HotelRoomDto>(await dbContext.HotelRooms.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower()));

                return hotelRoomDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDto> UpdateHotelRoom(int roomId, HotelRoomDto hotelRoomDto)
        {
            try
            {
                if (roomId == hotelRoomDto.Id)
                {
                    var roomDetails = await dbContext.HotelRooms.FindAsync(roomId);
                    var room = mapper.Map<HotelRoom>(roomDetails);
                    room.UpdateDate = DateTime.Now;
                    room.UpdatedBy = "";

                    var updatedRoom = dbContext.HotelRooms.Update(room);
                    await dbContext.SaveChangesAsync();

                    return mapper.Map<HotelRoomDto>(updatedRoom.Entity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
