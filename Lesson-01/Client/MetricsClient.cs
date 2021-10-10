﻿using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Lesson_01.Requests;
using Lesson_01.Responses.FromManager;

namespace Lesson_01.Client
{
	public enum ApiNames
	{
		Cpu,
		DotNet,
		Hdd,
		Network,
		Ram,
	}

	public class MetricsClient : IMetricsClient
	{
		private readonly string ManagerUri = "http://metricsmanager.verm-v.ru";

		private readonly HttpClient _httpClient;

		private readonly Dictionary<ApiNames, string> apiNames = new Dictionary<ApiNames, string>()
		{
			{ApiNames.Cpu, "cpu" },
			{ApiNames.DotNet, "dotnet" },
			{ApiNames.Hdd, "hdd" },
			{ApiNames.Network, "network" },
			{ApiNames.Ram, "ram" },
		};


		public MetricsClient()
		{
			_httpClient = new HttpClient();
		}

		public AllAgentsInfoResponse GetAllAgentsInfo()
		{
			var httpRequest = new HttpRequestMessage(
				HttpMethod.Get,
				$"{ManagerUri}/api/agents/read");

			var response = new AllAgentsInfoResponse();

			try
			{
				HttpResponseMessage managerResponse = _httpClient.SendAsync(httpRequest).Result;

				var responseStream = managerResponse.Content.ReadAsStreamAsync().Result;
				var streamReader = new StreamReader(responseStream);
				var content = streamReader.ReadToEnd();

				var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
				response = JsonSerializer.Deserialize<AllAgentsInfoResponse>(content, options);
			}
			catch (Exception ex)
			{
				//Обработка ошибки
			}

			return response;
		}

		public AllMetricsResponse<T> GetMetrics<T>(IMetricGetByIntervalRequestByClient request, ApiNames apiName)
		{
			var fromParameter = request.FromTime.UtcDateTime.ToString("O");
			var toParameter = request.ToTime.UtcDateTime.ToString("O");
			var agentId = request.AgentId.ToString();
			var httpRequest = new HttpRequestMessage(
				HttpMethod.Get,
				$"{ManagerUri}/api/metrics/{apiNames[apiName]}/agent/{agentId}/from/{fromParameter}/to/{toParameter}");

			var response = new AllMetricsResponse<T>();

			try
			{
				HttpResponseMessage managerResponse = _httpClient.SendAsync(httpRequest).Result;

				var responseStream = managerResponse.Content.ReadAsStreamAsync().Result;
				var streamReader = new StreamReader(responseStream);
				var content = streamReader.ReadToEnd();

				var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
				response = JsonSerializer.Deserialize<AllMetricsResponse<T>>(content, options);
			}
			catch (Exception ex)
			{
				//Обработка ошибки
			}

			return response;
		}

	}
}
