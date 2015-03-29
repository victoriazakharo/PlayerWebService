using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PlayerWebService
{
    /// <summary>
    /// Сводное описание для PlayerWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class PlayerWebService : System.Web.Services.WebService
    {
        private string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\CRITTERS.MDB;Persist Security Info=True";

        [WebMethod]
        public List<PlayerViewModel> GetPlayers(PlayerFilter filter)
        {
            List<PlayerViewModel> playerList = new List<PlayerViewModel>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(CreateQuery(filter), connection);
                OleDbDataReader dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        var player = new PlayerViewModel
                        {
                            PlayerId = dataReader.GetString(0),
                            Jersey = dataReader.GetInt32(1),
                            FirstName = dataReader.GetString(2),
                            Surname = dataReader.GetString(3),
                            Position = dataReader.GetString(4),
                            Birthday = dataReader.GetDateTime(5),
                            Height = dataReader.GetInt32(6),
                            Weight = dataReader.GetInt32(7),
                            Birthcity = dataReader.GetString(8),
                            Birthstate = dataReader.GetString(9)
                        };
                        playerList.Add(player);
                    }
                }
            }
            return playerList;
        }
        private String CreateQuery(PlayerFilter filter)
        {
            String query = @"SELECT playerid, 
                                    jersey, 
                                    fname, 
                                    sname,
                                    `position`,
                                    birthday,
                                    height,
                                    weight,
                                    birthcity,
                                    birthstate FROM roster";
            List<string> parameters = new List<string>();
            if (filter.Position != null && !filter.Position.Equals("Any"))
            {
                parameters.Add("`position` = '" + filter.Position + "'");
            }
            if (filter.WeightFrom != null)
            {
                parameters.Add("weight >= " + filter.WeightFrom);
            }
            if (filter.WeightTo != null)
            {
                parameters.Add("weight <= " + filter.WeightTo);
            }
            if (filter.HeightFrom != null)
            {
                parameters.Add("height >= " + filter.HeightFrom);
            }
            if (filter.HeightTo != null)
            {
                parameters.Add("height <= " + filter.HeightTo);
            }
            if (filter.YearFrom != null)
            {
                parameters.Add("YEAR(birthday) >= " + filter.YearFrom);
            }
            if (parameters.Count > 0)
            {
                String parameterString = String.Join(" AND ", parameters);
                query = String.Format("{0} WHERE {1}", query, parameterString);
            }
            return query;
        }
    }
}
