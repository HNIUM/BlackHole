using MachineInfo.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MachineInfo
{
    public class DBManager
    {
        const String connectString = "Server=127.0.0.1;Database=webdv;Uid =webmaster;pwd=12345";
        public static List<MachineCensor> selectDB(String query)

        {
            List<MachineCensor> machineCensorList = new List<MachineCensor>();

            DataTable dataTable = new DataTable();

            MySqlConnection connection = new MySqlConnection(connectString);

            try //select
            {
                
                connection.Open();
                Console.WriteLine("DB연결이 성공하였습니다.");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine("DB접속이 실패했습니다.");
            }
                MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                dataTable.Load(mySqlDataReader);


                foreach (DataRow row in dataTable.Rows)
                {
                machineCensorList.Add(new MachineCensor


                {
                    machineName = (String)row["machineName"],
                    managerName = (String)row["managerName"],
                    temperature = Convert.ToInt32(row["temperature"]),
                        power = Convert.ToInt32(row["power"]),
                        runTime = Convert.ToInt32(row["runTime"])
                });
                        


                }
                mySqlDataReader.Close();
                connection.Close();

            return machineCensorList;

        }
        //END of selectDB method

    }
}
