using Lesson_01.Requests;
using Lesson_01.Responses.FromManager;

namespace Lesson_01.Client
{
	public interface IMetricsClient
	{
		AllAgentsInfoResponse GetAllAgentsInfo();

		AllMetricsResponse<T> GetMetrics<T>(IMetricGetByIntervalRequestByClient request, ApiNames apiName);

	}
}
