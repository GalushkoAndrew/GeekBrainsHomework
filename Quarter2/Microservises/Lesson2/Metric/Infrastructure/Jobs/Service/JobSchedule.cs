using System;

namespace GeekBrains.Learn.Core.Infrastructure.Jobs
{
    /// <inheritdoc/>
    public class JobSchedule
    {
        /// <summary>
        /// ctor
        /// </summary>
        public JobSchedule(Type jobType, string cronExpression)
        {
            JobType = jobType;
            CronExpression = cronExpression;
        }

        /// <inheritdoc/>
        public Type JobType { get; }

        /// <inheritdoc/>
        public string CronExpression { get; }
    }
}
