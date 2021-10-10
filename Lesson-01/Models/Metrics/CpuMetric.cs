using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_01.Models.Metrics
{
	public class CpuMetric
	{
		public DateTimeOffset Time { get; set; }
		public int Value { get; set; }
	}
}
