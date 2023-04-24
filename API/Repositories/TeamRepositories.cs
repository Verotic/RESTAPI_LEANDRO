using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using API.Repositories;
using Dapper;
using MySql.Data.MySqlClient;

namespace API
{
    public class TeamRepository : ITeamRepository
    {

        private MysqlConfiguration _connectionString;

        public TeamRepository(MysqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<Team> CreateTeam(Team team)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO team(name) VALUES (@name); SELECT LAST_INSERT_ID()";

            team.Id = await db.QuerySingleAsync<int>(sql, new { team.Name });

            return team;
        }

        public async Task<bool> DeleteTeam(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE team WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new { id });

            return result > 0;
        }

        public async Task<IEnumerable<Team>> GetTeams()
        {
            var db = dbConnection();

            var sql = @"SELECT id, name FROM team";

            return await db.QueryAsync<Team>(sql, new { });
        }

        public async Task<Team> GetTeam(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM team WHERE id = @id";

            return await db.QueryFirstAsync<Team>(sql, new { id });

        }

        public async Task<bool> UpdateTeam(Team team, int id)
        {
            var db = dbConnection();

            var sql = @"UPDATE team SET name = @name WHERE id =@id";

            var result = await db.ExecuteAsync(sql, new { team.Name, id });

            return result > 0;
        

       
        }
    }
}

