using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achievements.Database;
using Achievements.Domain.Models.Achievements;
using Microsoft.EntityFrameworkCore;

namespace Achievements.WebApplication.Repositories.AchievementTypes
{
    public class AchievementTypesRepository : BaseRepository<AchievementType>, IAchievementTypesRepository
    {
        public AchievementTypesRepository(ApplicationDbContext context) 
            : base(context) { }

        public IEnumerable<AchievementType> GetTypesByGroup(AchievementGroup group)
        {
            return Context.Set<AchievementType>().Where(type => type.AchievementGroup == group);
        }
        public async Task Create(AchievementType type, Column[] columns)
        {
            await using var transaction = await Context.Database.BeginTransactionAsync();
            var nextId = Context.AchievementTypes.Max(x => x.Id);
            var result = await Context.AchievementTypes.AddAsync(type.Id == 0 ? new AchievementType()
            {
                Name = type.Name,
                AchievementGroup = await Context.AchievementGroups.FirstOrDefaultAsync(f => f.Equals(type.AchievementGroup)) 
            } : type);
            
            await Context.SaveChangesAsync();
            foreach (var column in columns)
            {
                await Context.Columns.AddAsync(column.Id == 0
                    ? new Column()
                    {
                        Label = column.Label,
                        DataType = column.DataType,
                        AchievementType = result.Entity,
                    }
                    : column);
            }
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
    }
}