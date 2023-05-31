using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Windows.Forms.DataVisualization.Charting;



namespace Faculty_Evaluation_System
{
        class ConnectAPI
        {

            public static void dgvViewing(string displayData, DataGridView dgv)
            {
                try
                {
                    RestClient client = new RestClient("http://localhost:3000");
                    var request = new RestRequest("evaluation", Method.Get);
                    request.AddHeader("authorization", InfoStorage.infoset.token);
                    request.AddParameter("displayData", displayData);

                    var response = client.Execute(request);

                    if (response.IsSuccessful)
                    {

                        DataTable dt = JsonConvert.DeserializeObject<DataTable>(response.Content);
                        dgv.DataSource = dt;
                        dgv.Columns[0].Visible = true;


                    }
                    else
                    {
                        MessageBox.Show("Error fetching data");
                    }
                }
                catch
                {

                }
            }
            public static void dgvViewing(string displayData, string searchData, DataGridView dgv)
            {
                try
                {
                    RestClient client = new RestClient("http://localhost:3000");
                    var request = new RestRequest("Search", Method.Get);
                    request.AddHeader("authorization", InfoStorage.infoset.token);
                    request.AddParameter("displayData", displayData);
                    request.AddParameter("searchData", searchData);

                    var response = client.Execute(request);

                    if (response.IsSuccessful)
                    {
                        DataTable dt = JsonConvert.DeserializeObject<DataTable>(response.Content);
                        dgv.DataSource = dt;
                        dgv.Columns[0].Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Error fetching data");
                    }
                }
                catch
                {

                }
            }

        public static void createAccount(string[] columnName, string[] data)
        {
            try
            {
                RestClient client = new RestClient("http://localhost:3000");
                var request = new RestRequest("createaccount", Method.Post);
                for (int i = 0; i < data.Length; i++)
                {
                    request.AddQueryParameter(columnName[i], data[i]);
                }
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {

                }
                else
                {
                    MessageBox.Show("Fill up incomplete" + response.ErrorMessage);
                }
            }
            catch
            {
            }
        }
        public static void saveData(string tableName, string[] columnName, string[] data)
            {
                try
                {
                    RestClient client = new RestClient("http://localhost:3000");
                    var request = new RestRequest("evaluation", Method.Post);
                    request.AddHeader("authorization", InfoStorage.infoset.token);

                    request.AddQueryParameter("tableName", tableName);
                    for (int i = 0; i < data.Length; i++)
                    {
                        request.AddQueryParameter(columnName[i], data[i]);
                    }
                    var response = client.Execute(request);
                    if (response.IsSuccessful)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Fill up incomplete" + response.ErrorMessage);
                    }
                }
                catch
                {
                }
            }

       
        
        public static void updateData(string tableName, string[] columnName, string[] data, int id)
            {
                try
                {
                    RestClient client = new RestClient("http://localhost:3000");
                    var request = new RestRequest("evaluation", Method.Put);
                    request.AddHeader("authorization", InfoStorage.infoset.token);

                    request.AddQueryParameter("tableName", tableName);
                    request.AddQueryParameter("id", id);
                    for (int i = 0; i < columnName.Length; i++)
                    {
                        request.AddQueryParameter(columnName[i], data[i]);
                    }
                    var response = client.Execute(request);
                    if (response.IsSuccessful)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Fill up incomplete!!" + response.ErrorMessage);
                    }
                }
                catch
                {
                }
            }
            public static void deleteData(string tableName, int id)
            {
                try
                {
                    RestClient client = new RestClient("http://localhost:3000");
                    var request = new RestRequest("evaluation", Method.Delete);
                    request.AddHeader("authorization", InfoStorage.infoset.token);
                    request.AddQueryParameter("tableName", tableName);
                    request.AddQueryParameter("id", id);
                    var response = client.Execute(request);
                    if (response.IsSuccessful)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Error: mmm" + response.ErrorMessage);
                    }
                }
                catch
                {
                }
            }
      
            public static Boolean AccountVerification(TextBox username, TextBox password)
            {
                bool verify = false;
                try
                {
                    RestClient client = new RestClient("http://localhost:3000");
                    var request = new RestRequest("login", Method.Post);
                    request.AddQueryParameter("username", username.Text);
                    request.AddQueryParameter("password", password.Text);

                    var response = client.Execute(request);
                    if (response.ContentLength > 2)
                    {
                        JArray jsonArray = JArray.Parse(response.Content);
                        DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());
                        verify = true;
                        InfoStorage.infoset.first_name = (dt.Rows[0]["first_name"]).ToString();
                        InfoStorage.infoset.role = (dt.Rows[0]["account_role"]).ToString();
                        InfoStorage.infoset.token = (dt.Rows[0]["token"]).ToString();
                        InfoStorage.infoset.users_id = int.Parse((dt.Rows[0]["users_id"]).ToString());
                        InfoStorage.infoset.last_name = (dt.Rows[0]["last_name"]).ToString();
                        InfoStorage.infoset.birthdate = Convert.ToDateTime((dt.Rows[0]["birth_date"]).ToString());
                        InfoStorage.infoset.username = (dt.Rows[0]["username"]).ToString();
                        InfoStorage.infoset.password = (dt.Rows[0]["password"]).ToString();
            }
                }
                catch
                {
                }
                return verify;
            }
            public static void cbxView(string displayData, string displayMember, string valueMember, ComboBox cbxName)
            {
                try
                {
                    RestClient client = new RestClient("http://localhost:3000");
                    var request = new RestRequest("search", Method.Get);
                    request.AddHeader("authorization", InfoStorage.infoset.token);
                    request.AddParameter("displayData", displayData);
                    request.AddParameter("searchData", "Admin");
                    var response = client.Execute(request);
                    JArray jsonArray = JArray.Parse(response.Content);
                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());
                    cbxName.DataSource = dt;
                    cbxName.DisplayMember = displayMember;
                    cbxName.ValueMember = valueMember;
                }
                catch
                {

                }
            }

            public static string getDetail(string displayData, int id, string column)
            {
                JToken detail = null;
                try
                {
                    RestClient client = new RestClient("http://localhost:3000");
                    var request = new RestRequest("search", Method.Get);
                    request.AddHeader("authorization", InfoStorage.infoset.token);
                    request.AddParameter("displayData", displayData);
                    request.AddParameter("searchData", id);
                    var response = client.Execute(request);
                    JArray jsonArray = JArray.Parse(response.Content);
                    JObject jsonObject = jsonArray.FirstOrDefault() as JObject;
                    if (jsonObject != null)
                    {
                        detail = jsonObject.GetValue(column);
                        if (detail != null)
                        {
                            return detail.ToString();
                        }
                    }
                }
                catch
                {

                }
                return detail.ToString();
            }
            public static void autoUpdate()
            {
                RestClient client = new RestClient("http://localhost:3000");
                var request = new RestRequest("executeUpdate", Method.Get);
                request.AddHeader("authorization", InfoStorage.infoset.token);
                var response = client.Execute(request);
            }
            public static void getEvaluationReport(Chart chart1)
            {
                try
                {
                    RestClient client = new RestClient("http://localhost:3000");
                    var request = new RestRequest("search", Method.Get);
                    request.AddHeader("authorization", InfoStorage.infoset.token);
                    request.AddParameter("displayData", "Report");
                    request.AddParameter("searchData", InfoStorage.infoset.users_id);
                    var response = client.Execute(request);

                    if (response.IsSuccessful)
                    {
                        DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(response.Content);
                        

                    chart1.DataSource = dataTable;

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        if (column.ColumnName != "name")
                        {
                            Series series = new Series(column.ColumnName);
                            series.ChartType = SeriesChartType.Column;
                            series.XValueMember = "name";
                            series.YValueMembers = column.ColumnName;
                            chart1.Series.Add(series);
                        }
                    }

                    chart1.DataBind();
                }
                    else
                    {
                        MessageBox.Show("Error fetching data");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }
    }


