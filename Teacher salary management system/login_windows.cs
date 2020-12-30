using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Drawing.Drawing2D;
using MySql.Data.MySqlClient;
namespace Teacher_salay_mangement_system
{
    public struct USER_INF
    {
        public string ip_address;
        public string id;
        public string password;
    }
    public partial class login : Form
    {
        public USER_INF User_Inf;
        MysqlConnector mysql_database = new MysqlConnector();
        public login()
        {
            InitializeComponent();
        }
        private void login_ip_ping_Click(object sender, EventArgs e)
        {
            if (mysql_database.PingIp(login_ip_input.Text))
            {
                login_ip_ping.BackColor = Color.Green;
                MessageBox.Show("成功", "提示");
            }
            else
            {
                login_ip_ping.BackColor = Color.Red;
                MessageBox.Show("失败", "提示");
            }
        }

        private void login_confirm_Click(object sender, EventArgs e)
        {
            switch (mysql_database.login_user(login_user_input.Text.Replace("\r\n", ""), login_passward_input.Text.Replace("\r\n", "")))
            {
                case 'A':
                    MessageBox.Show("欢迎管理员登录！", "提示");
                    User_Inf.id = login_user_input.Text;
                    User_Inf.password = login_passward_input.Text;
                    User_Inf.ip_address = login_ip_input.Text;
                    this.DialogResult = DialogResult.OK; //系统管理员账户
                    break;
                case 'U':
                    MessageBox.Show("欢迎登录！", "提示");
                    User_Inf.id = login_user_input.Text;
                    User_Inf.password = login_passward_input.Text;
                    User_Inf.ip_address = login_ip_input.Text;
                    this.DialogResult = DialogResult.Yes; //用户账户
                    break;
                case 'F':
                    MessageBox.Show("账号或者用户名错误！", "提示");
                    break;
                case 'E':
                    MessageBox.Show("网络连接失败", "提示");
                    break;
            }
        }

        /// <summary>
        /// ping ip,测试能否ping通
        /// </summary>
        /// <param name="strIP">IP地址</param>
        /// <returns></returns>

    }
    public class MysqlConnector
    {
        private struct connection_inf
        {
            internal static string server;
            internal static string userid;
            internal static string password;
            internal static string database;
            internal static string port;
            internal static string charset;
        }
        public MysqlConnector()
        {
            connection_inf.server = "rm-bp130m31cpbdbq7p2125010nm.mysql.rds.aliyuncs.com";
            connection_inf.userid = "guest_teacher";
            connection_inf.password = "qazqwer123@@";
            connection_inf.database = "teacher_salary";
            connection_inf.port = "3306";
            connection_inf.charset = null;
        }
        public MysqlConnector(USER_INF inf)
        {
            connection_inf.server = inf.ip_address;
            connection_inf.userid = inf.id;
            connection_inf.password = inf.password;
            connection_inf.database = "teacher_salary";
            connection_inf.port = "3306";
            connection_inf.charset = null;
        }

        #region  建立MySql数据库连接
        /// <summary>
        /// 建立数据库连接.
        /// </summary>
        /// <returns>返回MySqlConnection对象</returns>
        private MySqlConnection GetMysqlConnection()
        {
            string M_str_sqlcon = string.Format("server={0};user id={1};password={2};database={3};port={4};Charset={5}", 
                connection_inf.server, connection_inf.userid, connection_inf.password,
                connection_inf.database, connection_inf.port, connection_inf.charset);
            MySqlConnection myCon = new MySqlConnection(M_str_sqlcon);
            return myCon;
        }
        public bool PingIp(string strIP)
        {
            bool bRet = false;
            try
            {
                Ping pingSend = new Ping();
                PingReply reply = pingSend.Send(strIP, 1000);
                if (reply.Status == IPStatus.Success)
                    bRet = true;
            }
            catch (Exception)
            {
                bRet = false;
            }
            return bRet;
        }
        #endregion

        #region  执行MySqlCommand命令
        /// <summary>
        /// 执行MySqlCommand
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        public bool ExeUpdate(string M_str_sqlstr)
        {
            MySqlConnection mysqlcon = this.GetMysqlConnection();
            MySqlDataReader reader;
            try
            {
                mysqlcon.Open();
                MySqlCommand mysqlcom = new MySqlCommand(M_str_sqlstr, mysqlcon);
                reader = mysqlcom.ExecuteReader();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
                mysqlcon.Close();
                return false;
            }
            finally
            {
                mysqlcon.Close();
            }
            return true;
        }
        public char login_user(string user_id,string passward)
        {
            connection_inf.userid = "guest_teacher";
            connection_inf.password = "qazqwer123@@";
            MySqlConnection mysqlcon = this.GetMysqlConnection();
            MySqlDataReader reader;
            if(!PingIp(connection_inf.server))
            {
                return 'E';
            }
            mysqlcon.Open();
            MySqlCommand mysqlcom = new MySqlCommand(
                "SELECT * from teacher_salary.用户表 where 用户表.教师号='" +
                user_id + "'&& 用户表.密码='" + passward + "';", mysqlcon);
            reader = mysqlcom.ExecuteReader();
            if (!reader.Read())
            {
                mysqlcon.Close();
                mysqlcon.Dispose();
                connection_inf.userid = user_id;
                connection_inf.password = passward;
                MySqlConnection mysqlcon_admin = this.GetMysqlConnection();
                try
                {
                    mysqlcon_admin.Open();
                    MySqlCommand mysqlcom_admin = new MySqlCommand("SELECT 教师号 from teacher_salary.用户表  where 用户表.教师号='admin';", mysqlcon_admin);
                    reader = mysqlcom_admin.ExecuteReader();
                    if (!reader.Read())
                    {
                        mysqlcon_admin.Close();
                        mysqlcon_admin.Dispose();
                        return 'F';
                    }
                }
                catch(MySqlException)
                {
                    mysqlcon_admin.Close();
                    mysqlcon_admin.Dispose();
                    return 'F';
                }
                finally
                {
                    mysqlcon_admin.Close();
                    mysqlcon_admin.Dispose();
                }
                return 'A';
            }
            else
            {
                return 'U';
            }
        }
        public bool inquire_inf(string User_ID, ref basic data)
        {
            MySqlConnection mysqlcon = this.GetMysqlConnection();
            MySqlDataReader reader;
            mysqlcon.Open();
            MySqlCommand mysqlcom = new MySqlCommand(
                "SELECT * FROM teacher_salary.基本信息 where 教师号 = '" +
                User_ID + "';", mysqlcon);
            reader = mysqlcom.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                data.name = reader["姓名"].ToString();
                data.sex = reader["性别"].ToString();
                data.organization = reader["单位名称"].ToString();
                data.address_province = reader["省"].ToString();
                data.address_city = reader["市"].ToString();
                data.address_country = reader["县"].ToString();
                data.address_detailed = reader["详细地址"].ToString();
                data.telephone = reader["联系电话"].ToString();
                mysqlcon.Close();
                mysqlcon.Dispose();
                reader.Close();
                reader.Dispose();
                return true;
            }
            else
            {
                mysqlcon.Close();
                mysqlcon.Dispose();
                reader.Close();
                reader.Dispose();
                MessageBox.Show("没有查询到与" + User_ID + "的有关信息", "提示");
                return false;
            }
        }
        public bool inquire_inf(string User_ID,ref total data)
        {
            MySqlConnection mysqlcon = this.GetMysqlConnection();
            MySqlDataReader reader;
            mysqlcon.Open();
            MySqlCommand mysqlcom = new MySqlCommand(
                "SELECT * FROM teacher_salary.基本信息 where 教师号 = '" + 
                User_ID + "';", mysqlcon);
            reader = mysqlcom.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                data.id = reader["教师号"].ToString();
                data.basic_inf.name = reader["姓名"].ToString();
                data.basic_inf.sex = reader["性别"].ToString();
                data.basic_inf.organization = reader["单位名称"].ToString();
                data.basic_inf.address_province = reader["省"].ToString();
                data.basic_inf.address_city = reader["市"].ToString();
                data.basic_inf.address_country = reader["县"].ToString();
                data.basic_inf.address_detailed = reader["详细地址"].ToString();
                data.basic_inf.telephone = reader["联系电话"].ToString();
                mysqlcon.Close();
                mysqlcon.Open();
                mysqlcom = new MySqlCommand(
                "SELECT * FROM teacher_salary.应发 where 教师号 = '" +
                User_ID + "';", mysqlcon);
                reader = mysqlcom.ExecuteReader(CommandBehavior.SingleRow);
                reader.Read();
                data.salary_inf.base_pay = float.Parse(reader["基本工资"].ToString());
                data.salary_inf.allowance = float.Parse(reader["津贴"].ToString());
                data.salary_inf.subsistence_allowance = float.Parse(reader["生活补贴"].ToString());
                mysqlcon.Close();
                mysqlcon.Open();
                mysqlcom = new MySqlCommand(
                    "SELECT * FROM teacher_salary.扣款 where 教师号 = '" +
                    User_ID + "';", mysqlcon);
                reader = mysqlcom.ExecuteReader(CommandBehavior.SingleRow);
                reader.Read();
                data.aggregate_inf.telephone_bill = float.Parse(reader["电话费"].ToString());
                data.aggregate_inf.water_electricity = float.Parse(reader["水电费"].ToString());
                data.aggregate_inf.the_rent = float.Parse(reader["房租"].ToString());
                data.aggregate_inf.income_tax = float.Parse(reader["所得税"].ToString());
                data.aggregate_inf.sanitation_fee = float.Parse(reader["卫生费"].ToString());
                data.aggregate_inf.accumulation_fund = float.Parse(reader["公积金"].ToString());
                mysqlcon.Close();
                mysqlcon.Dispose();
                reader.Close();
                reader.Dispose();
                return true;
            }
            else
            {
                mysqlcon.Close();
                mysqlcon.Dispose();
                reader.Close();
                reader.Dispose();
                MessageBox.Show("没有查询到与" + User_ID + "的有关信息", "提示");
                return false;
            }
        }
        public int length_inf()
        {
            int return_value=0;
            MySqlConnection mysqlcon = this.GetMysqlConnection();
            MySqlDataReader reader;
            mysqlcon.Open();
            MySqlCommand mysqlcom = new MySqlCommand(
                "SELECT * FROM teacher_salary.基本信息;", mysqlcon);
            reader = mysqlcom.ExecuteReader();
            while (reader.Read())
                return_value++;
            mysqlcon.Close();
            mysqlcon.Dispose();
            return return_value;
        }
        public void inquire_inf( ref total [] data)
        {
            MySqlConnection mysqlcon = this.GetMysqlConnection();
            MySqlDataReader reader;
            mysqlcon.Open();
            MySqlCommand mysqlcom = new MySqlCommand(
                "SELECT * FROM teacher_salary.基本信息;", mysqlcon);
            reader = mysqlcom.ExecuteReader();
            for (int i = 0;reader.Read(); i++)
            {
                data[i].id = reader["教师号"].ToString();
                data[i].basic_inf.name = reader["姓名"].ToString();
                data[i].basic_inf.sex = reader["性别"].ToString();
                data[i].basic_inf.organization = reader["单位名称"].ToString();
                data[i].basic_inf.address_province = reader["省"].ToString();
                data[i].basic_inf.address_city = reader["市"].ToString();
                data[i].basic_inf.address_country = reader["县"].ToString();
                data[i].basic_inf.address_detailed = reader["详细地址"].ToString();
                data[i].basic_inf.telephone = reader["联系电话"].ToString();
            }
            mysqlcon.Close();
            mysqlcon.Open();
            mysqlcom = new MySqlCommand("SELECT * FROM teacher_salary.应发;", mysqlcon);
            reader = mysqlcom.ExecuteReader();
            for (int i = 0;reader.Read(); i++)
            {
                data[i].salary_inf.base_pay = float.Parse(reader["基本工资"].ToString());
                data[i].salary_inf.allowance = float.Parse(reader["津贴"].ToString());
                data[i].salary_inf.subsistence_allowance = float.Parse(reader["生活补贴"].ToString());
            }
            mysqlcon.Close();
            mysqlcon.Open();
            mysqlcom = new MySqlCommand("SELECT * FROM teacher_salary.扣款;", mysqlcon);
            reader = mysqlcom.ExecuteReader();
            for (int i = 0;reader.Read(); i++)
            {
                data[i].aggregate_inf.telephone_bill = float.Parse(reader["电话费"].ToString());
                data[i].aggregate_inf.water_electricity = float.Parse(reader["水电费"].ToString());
                data[i].aggregate_inf.the_rent = float.Parse(reader["房租"].ToString());
                data[i].aggregate_inf.income_tax = float.Parse(reader["所得税"].ToString());
                data[i].aggregate_inf.sanitation_fee = float.Parse(reader["卫生费"].ToString());
                data[i].aggregate_inf.accumulation_fund = float.Parse(reader["公积金"].ToString());
            }
            mysqlcon.Close();
            mysqlcon.Dispose();
            reader.Close();
            reader.Dispose();
        }
        public bool inquire_inf(string User_ID)
        {
            MySqlConnection mysqlcon = this.GetMysqlConnection();
            MySqlDataReader reader;
            mysqlcon.Open();
            MySqlCommand mysqlcom = new MySqlCommand(
                "SELECT * FROM teacher_salary.基本信息 where 教师号 = '" +
                User_ID + "';", mysqlcon);
            reader = mysqlcom.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
                return true;
            return false;
        }
        #endregion

        #region  创建MySqlDataReader对象
        /// <summary>
        /// 创建一个MySqlDataReader对象
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        /// <returns>返回MySqlDataReader对象</returns>
        public MySqlDataReader ExeQuery(string M_str_sqlstr)
        {
            Console.WriteLine(M_str_sqlstr);
            MySqlConnection mysqlcon = this.GetMysqlConnection();
            MySqlCommand mysqlcom = new MySqlCommand(M_str_sqlstr, mysqlcon);
            mysqlcon.Open();
            MySqlDataReader mysqlread = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            return mysqlread;

        }
        #endregion
    }
}