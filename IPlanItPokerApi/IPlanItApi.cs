using PlanITpoker;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IPlanItPokerApi.Specs
{
     public interface IPlanItApi
    {
        [Get("/api/rooms")]
        Task<List<Room>> GetRooms();

        [Get("/api/rooms/{room}")]
        Task<Room> GetRoom(string room);

        [Post("/api/games/create")]
        Task<GameData> CreateRoom([Body(BodySerializationMethod.UrlEncoded)] Room room);

        [Post("/api/authentication/login")]
        Task<object> Login([Body(BodySerializationMethod.UrlEncoded)] LoginData room);
    }
}
