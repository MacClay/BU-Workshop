using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetRPG.Models;

namespace dotnetRPG.Repository
{
    public interface IPlayer
    {
        Task<List<Player>> GetPlayers();
        Task<Player> GetPlayer(Guid id);
        Task CreatePlayer(Player player);
        Task UpdatePlayer(Guid id, Player player);
        Task DeletePlayer(Guid id);
    }
}