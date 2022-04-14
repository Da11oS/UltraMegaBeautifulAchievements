using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achievements.Database;
using Achievements.Domain.Models.Achievements;
using Microsoft.EntityFrameworkCore;

namespace Achievements.WebApplication.Repositories.AchievementTypes
{
    public class AchievementInstanceRepository : BaseRepository<AchievementInstance>, IAchievementInstanceRepository
    {
        private readonly BaseRepository<AchievementValue> _valuesRepository;

        public AchievementInstanceRepository(ApplicationDbContext context, BaseRepository<AchievementValue> _valuesRepository) 
            : base(context)
        {
            this._valuesRepository = _valuesRepository;
        }

        public IEnumerable<AchievementInstance> GetForType(int typeId, int userId)
        {
            var instances = Context.AchievementInstances
                .Where(f => f.AchievementType.Id == typeId && f.User.Id == userId).AsEnumerable();
            foreach (var instance in instances)
            {
                var values = _valuesRepository.GetAll().Where(w => w.AchievementInstance.Id == instance.Id);
                instance.Values = values.ToList();
            }

            return instances;
        }
        public AchievementInstance GetEmptyInstance(int typeId)
        {
            var achievementType = Context.AchievementTypes.FirstOrDefault(f => f.Id == typeId);
            
            var instance = new AchievementInstance
            {
                AchievementType = achievementType,
            };
            
            var values = Context.Columns.Where(w => w.AchievementType.Id == achievementType.Id).Select(s => new AchievementValue()
            {
                Column = s,
                AchievementInstance = instance,
            });
            
            instance.Values = values.ToList();
            return instance;
        }

        public async Task<int> CreateWithNewColumns(AchievementInstance instance)
        {
            var values = new List<AchievementValue>(instance.Values);
            instance.Values = new List<AchievementValue>();
            
            instance.AchievementType =
                await Context.AchievementTypes
                    .FirstOrDefaultAsync(f => f.Id == instance.AchievementType.Id);
            
            instance.User = await Context.Users.FirstOrDefaultAsync(f => f.Id == instance.User.Id);
            
            var newInstance = await Context.AchievementInstances.AddAsync(instance);
            await Context.SaveChangesAsync();
            values.ForEach(f =>
            {
                f.AchievementInstance = newInstance.Entity;
            });
            
            foreach (var value in values)
            {
                value.Column = await Context.Columns.FirstOrDefaultAsync(f => f.Id == value.Column.Id);
                var valueResult = await Context.AchievementValues.AddAsync(value);
                await Context.SaveChangesAsync();
            }
            
            var result = await Context.AchievementInstances.
                FirstOrDefaultAsync(f => f.Id == newInstance.Entity.Id);
            
            return result.Id;
        }
    }
}