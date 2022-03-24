using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetRPG.Models;
using dotnetRPG.Context;
using Microsoft.EntityFrameworkCore;

namespace dotnetRPG.Repository
{
    public class SqlitePlayer : IPlayer
    {
        private PlayerDBContext db;

        public SqlitePlayer(PlayerDBContext db)
        {
            this.db = db;
        }

        public async Task CreatePlayer(Player player)
        {
            Player newplayer = new (){
                id = Guid.NewGuid(),
                Name = player.Name,
                Balance = player.Balance,
                CreatedDate = DateTimeOffset.UtcNow
            };
            await db.players.AddAsync(newplayer);
            await db.SaveChangesAsync();
        }

        public async Task DeletePlayer(Guid id)
        {
            var existedPlayer = await db.players.Where(p => p.id == id).FirstOrDefaultAsync();
            if (existedPlayer is null)
            {
                throw new Exception("Player not found");
            }
            db.players.Remove(existedPlayer);
            await db.SaveChangesAsync();
        }

        public async Task<Player> GetPlayer(Guid id)
        {
            var player = await db.players.Where(p => p.id == id).FirstOrDefaultAsync();
            if (player is null)
            {
                throw new Exception("Player not found");
            }
            return player;
        }

        public async Task<List<Player>> GetPlayers()
        {
            var players = await db.players.ToListAsync();
            if (players is null)
            {
                throw new Exception("Player not found");
            }
            return players;
        }

        public async Task UpdatePlayer(Guid id, Player player)
        {
            var existedPlayer = await db.players.Where(p => p.id == id).AsNoTracking().FirstOrDefaultAsync();
            if (existedPlayer is null)
            {
                throw new Exception("Player not found");
            }
            existedPlayer = existedPlayer with {
                Name = player.Name,
                Balance = player.Balance
            };
            db.players.Update(existedPlayer);
            await db.SaveChangesAsync();
        }
    }
}