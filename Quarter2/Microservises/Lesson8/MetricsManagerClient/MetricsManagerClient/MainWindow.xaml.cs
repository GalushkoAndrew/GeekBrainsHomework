using System.Collections.Generic;
using System;
using System.Windows;
using System.Net.Http;
using System.Text.Json;
using MetricsManagerClient.DTO;
using System.Windows.Controls;
using System.Linq;
using System.Globalization;

namespace MetricsManagerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string uriBase = "http://localhost:5001/";

        public MainWindow()
        {
            InitializeComponent();

            FillMetricsListCombobox(CurrentMetric);

            SetDatesNow(DateFrom, DateTo);

            LoadAgents(CurrentAgent);
        }

        public List<AgentDto> Agents { get; set; }

        private DateTime GetDateFrom
        {
            get
            {
                return DateFrom.SelectedDate ?? DateTime.Now;
            }
        }

        private DateTime GetDateTo
        {
            get
            {
                return DateTo.SelectedDate ?? DateTime.Now;
            }
        }

        private string CurrentMetricName
        {
            get
            {
                return CurrentMetric.Text;
            }
        }

        private int CurrentAgentId
        {
            get
            {
                var agentName = CurrentAgent.Text;
                return Agents
                    .Where(x => x.Uri.Equals(agentName))
                    .Select(x => x.Id)
                    .FirstOrDefault();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadMetricsData<MetricDto>(CurrentAgentId, GetDateFrom, GetDateTo);
        }

        private void FillMetricsListCombobox(ComboBox metrics)
        {
            metrics.Items.Add("Cpu");
            metrics.Items.Add("Hdd");
            metrics.Items.Add("Dotnet");
            metrics.Items.Add("Ram");
            metrics.SelectedIndex = 0;
        }

        private void SetDatesNow(DatePicker dateFrom, DatePicker dateTo)
        {
            dateFrom.SelectedDate = DateTime.Now;
            dateTo.SelectedDate = DateTime.Now.AddDays(1);
        }

        private void LoadMetricsData<T>(int agentId, DateTime fromTime, DateTime toTime)
            where T : IMetricDto
        {
            MetricsChart.ColumnSeriesValues[0].Values.Clear();

            string fromString = DateToHttpFormat(fromTime);
            string toString = DateToHttpFormat(toTime);
            string metricName = CurrentMetricName.ToLower();


            var uri = uriBase + $"MetricsManager/{metricName}/agent/{agentId}/from/{fromString}/to/{toString}";

            List<T> list = GetDtoFromHttp<List<T>>(uri);

            if (list == null)
            {
                MetricsChart.ColumnSeriesValues[0].Values.Clear();
                return;
            }

            var dataList = list.OrderBy(x => x.Date).Select(x => (object)(double)x.Value).ToList();

            MetricsChart.ColumnSeriesValues[0].Values.AddRange(dataList);
        }

        private string DateToHttpFormat(DateTime date)
        {
            return date.ToString("s", DateTimeFormatInfo.InvariantInfo);
        }

        private void LoadAgents(ComboBox agents)
        {
            GetAgents();

            agents.Items.Clear();

            foreach (var agent in Agents)
            {
                agents.Items.Add(agent.Uri);
            }

            if (Agents.Count() > 0)
            {
                agents.SelectedIndex = 0;
            }
        }


        private void GetAgents()
        {
            var uri = uriBase + "MetricsManager";

            List<AgentDto> list = GetDtoFromHttp<List<AgentDto>>(uri);

            Agents = list ?? new List<AgentDto>();
        }

        private T GetDtoFromHttp<T>(string uri)
            where T : class
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response;

            try
            {
                response = client.GetAsync(uri).Result;
            }
            catch (Exception)
            {
                return null;
            }

            if (response.IsSuccessStatusCode)
            {
                var responseStream = response.Content.ReadAsStreamAsync().Result;

                T result = null;

                try
                {
                    result = JsonSerializer.DeserializeAsync<T>(responseStream, new JsonSerializerOptions(JsonSerializerDefaults.Web)).Result;
                }
                catch (Exception)
                {
                }

                return result;
            }

            return null;
        }
    }
}
