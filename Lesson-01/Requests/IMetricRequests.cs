using System;

namespace Lesson_01.Requests
{
	public interface IMetricGetByIntervalRequestByClient
	{
		int AgentId { get; set; }
		DateTimeOffset FromTime { get; set; }
		DateTimeOffset ToTime { get; set; }
	}
}
