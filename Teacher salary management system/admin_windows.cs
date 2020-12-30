using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace Teacher_salay_mangement_system
{
    public struct basic
    {
        public string name;
        public string sex;
        public string organization;
        public string address_province;
        public string address_city;
        public string address_country;
        public string address_detailed;
        public string telephone;
    }
    public struct salary
    {
        public float base_pay;
        public float allowance;
        public float subsistence_allowance;
    }
    public struct aggregate
    {
        public float telephone_bill;
        public float water_electricity;
        public float the_rent;
        public float income_tax;
        public float sanitation_fee;
        public float accumulation_fund;
    }
    public struct total
    {
        public string id;
        public basic basic_inf;
        public salary salary_inf;
        public aggregate aggregate_inf;
    }
    struct Salary
    {
        public float salary;
        public float aggregate;
        public float payroll;
    }
    
    public partial class admin_windows : Form
    {
        private MysqlConnector mysql_database;
        Salary Salary_show = new Salary();
        total data = new total();
        total[] data_all;
        int number_of_teacher = 0;
        int number_loc = 0;
        public admin_windows(USER_INF User_Inf_input)
        {
            mysql_database = new MysqlConnector(User_Inf_input);
            InitializeComponent();
        }
        private void logout_system_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            total total_input = new total();
            if (Input_check(id, id_input,ref total_input.id) == true)
            {
                if(id_input.TextLength!=10)
                {
                    MessageBox.Show("教师号为10位数字字母组合字符串","教师号输入错误！");
                    return;
                }
            }
            else
                return;
            if (Input_check(name, name_input,ref total_input.basic_inf.name) != true)
                return;
            if (Input_check(sex, sex_input,ref total_input.basic_inf.sex) != true)
                return;
            if (Input_check(organization, organization_input,ref total_input.basic_inf.organization) != true)
                return;
            if (Input_check(address, address_province_input,ref total_input.basic_inf.address_province) != true)
                return;
            if (Input_check(address, address_city_input,ref total_input.basic_inf.address_city) != true)
                return;
            if (Input_check(address, address_county_input,ref total_input.basic_inf.address_country) != true)
                return;
            if (Input_check(address, address_detailed_input,ref total_input.basic_inf.address_detailed) != true)
                return;
            if (Input_check(telephone, telephone_input,ref total_input.basic_inf.telephone) == true)
            {
                if (telephone_input.TextLength != 11)
                {
                    MessageBox.Show("电话号码输入错误！");
                    return;
                }
            }
            else
                return;
            if (Input_check(base_pay,base_pay_input,ref total_input.salary_inf.base_pay) != true)
                return;
            if (Input_check(allowance,allowance_input,ref total_input.salary_inf.allowance) != true)
                return;
            if (Input_check(subsistence_allowance,subsistence_allowance_input,ref total_input.salary_inf.subsistence_allowance) != true)
                return;
            if (Input_check(telephone_bill,telephone_bill_input,ref total_input.aggregate_inf.telephone_bill) != true)
                return;
            if (Input_check(water_electricity,water_electricity_input,ref total_input.aggregate_inf.water_electricity) != true)
                return;
            if (Input_check(the_rent,the_rent_input,ref total_input.aggregate_inf.the_rent) != true)
                return;
            if (Input_check(income_tax, income_tax_input,ref total_input.aggregate_inf.income_tax) != true)
                return;
            if (Input_check(sanitation_fee,sanitation_fee_input,ref total_input.aggregate_inf.sanitation_fee) != true)
                return;
            if (Input_check(accumulation_fund,accumulation_fund_input,ref total_input.aggregate_inf.accumulation_fund) != true)
                return;
            Salary_show.salary = total_input.salary_inf.base_pay +
                total_input.salary_inf.allowance +
                total_input.salary_inf.subsistence_allowance;
            salary_show.Text = Salary_show.salary.ToString();
            Salary_show.aggregate = total_input.aggregate_inf.telephone_bill +
                total_input.aggregate_inf.water_electricity +
                total_input.aggregate_inf.the_rent +
                total_input.aggregate_inf.income_tax +
                total_input.aggregate_inf.sanitation_fee +
                total_input.aggregate_inf.accumulation_fund + 0.0f;
            aggregate_show.Text = Salary_show.aggregate.ToString();
            Salary_show.payroll = Salary_show.salary - Salary_show.aggregate + 0.00f;
            payroll_show.Text = Salary_show.payroll.ToString();
            if (MessageBox.Show("确认修改", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                update_inf(total_input, data);
                MessageBox.Show("修改成功！", "提示");
            }
        }
        private void update_inf(total total_input,total total_original)
        {
            bool status = false;
            string command_str = "UPDATE teacher_salary.基本信息 SET ";
            if (total_input.basic_inf.name != total_original.basic_inf.name)
            {
                command_str += "姓名='" + total_input.basic_inf.name + "',";
                status = true;
            }
            if (total_input.basic_inf.sex != total_original.basic_inf.sex)
            {
                command_str += "性别='" + total_input.basic_inf.sex + "',";
                status = true;
            }
            if (total_input.basic_inf.organization != total_original.basic_inf.organization)
            {
                command_str += "单位名称='" + total_input.basic_inf.organization + "',";
                status = true;
            }
            if (total_input.basic_inf.address_province != total_original.basic_inf.address_province)
            {
                command_str += "省='" + total_input.basic_inf.address_province + "',";
                status = true;
            }
            if (total_input.basic_inf.address_city != total_original.basic_inf.address_city)
            {
                command_str += "市='" + total_input.basic_inf.address_city + "',";
                status = true;
            }
            if (total_input.basic_inf.address_country != total_original.basic_inf.address_country)
            {
                command_str += "县='" + total_input.basic_inf.address_country + "',";
                status = true;
            }
            if (total_input.basic_inf.address_detailed != total_original.basic_inf.address_detailed)
            {
                command_str += "详细地址='" + total_input.basic_inf.address_detailed + "',";
                status = true;
            }
            if (total_input.basic_inf.telephone != total_original.basic_inf.telephone)
            {
                command_str += "联系电话='" + total_input.basic_inf.telephone + "',";
                status = true;
            }
            if (status)
            {
                command_str = command_str.Substring(0, command_str.Length - 1);
                command_str += " WHERE 教师号='" + total_original.id + "';";
                mysql_database.ExeUpdate(command_str);
            }
            status = false;
            command_str = "UPDATE teacher_salary.扣款 SET ";
            if (total_input.aggregate_inf.telephone_bill != total_original.aggregate_inf.telephone_bill)
            {
                command_str += "电话费=" + total_input.aggregate_inf.telephone_bill + ",";
                status = true;
            }
            if (total_input.aggregate_inf.water_electricity != total_original.aggregate_inf.water_electricity)
            {
                command_str += "水电费=" + total_input.aggregate_inf.water_electricity + ",";
                status = true;
            }
            if (total_input.aggregate_inf.the_rent != total_original.aggregate_inf.the_rent)
            {
                command_str += "房租=" + total_input.aggregate_inf.the_rent + ",";
                status = true;
            }
            if (total_input.aggregate_inf.income_tax != total_original.aggregate_inf.income_tax)
            {
                command_str += "所得税=" + total_input.aggregate_inf.income_tax + ",";
                status = true;
            }
            if (total_input.aggregate_inf.sanitation_fee != total_original.aggregate_inf.sanitation_fee)
            {
                command_str += "卫生费=" + total_input.aggregate_inf.sanitation_fee + ",";
                status = true;
            }
            if (total_input.aggregate_inf.accumulation_fund != total_original.aggregate_inf.accumulation_fund)
            {
                command_str += "公积金=" + total_input.aggregate_inf.accumulation_fund + ",";
                status = true;
            }
            if (status)
            {
                command_str = command_str.Substring(0, command_str.Length - 1);
                command_str += " WHERE 教师号='" + total_original.id + "';";
                mysql_database.ExeUpdate(command_str);
            }
            status = false;
            command_str = "UPDATE teacher_salary.应发 SET ";
            if (total_input.salary_inf.base_pay != total_original.salary_inf.base_pay)
            {
                command_str += "基本工资=" + total_input.salary_inf.base_pay + ",";
                status = true;
            }
            if (total_input.salary_inf.subsistence_allowance != total_original.salary_inf.subsistence_allowance)
            {
                command_str += "生活补贴=" + total_input.salary_inf.subsistence_allowance + ",";
                status = true;
            }
            if (total_input.salary_inf.allowance != total_original.salary_inf.allowance)
            {
                command_str += "津贴=" + total_input.salary_inf.allowance + ",";
                status = true;
            }
            if (status)
            {
                command_str = command_str.Substring(0, command_str.Length - 1);
                command_str += " WHERE 教师号='" + total_original.id + "';";
                mysql_database.ExeUpdate(command_str);
            }
            if (total_input.id != total_original.id)
            {
                command_str = "UPDATE teacher_salary.基本信息 SET 教师号='" + total_input.id + "' WHERE 教师号='" + total_original.id + "';";
                mysql_database.ExeUpdate(command_str);
                command_str = "UPDATE teacher_salary.用户表 SET 教师号='" + total_input.id + "' WHERE 教师号='" + total_original.id + "';";
                mysql_database.ExeUpdate(command_str);
                command_str = "UPDATE teacher_salary.扣款 SET 教师号='" + total_input.id + "' WHERE 教师号='" + total_original.id + "';";
                mysql_database.ExeUpdate(command_str);
                command_str = "UPDATE teacher_salary.应发 SET 教师号='" + total_input.id + "' WHERE 教师号='" + total_original.id + "';";
                mysql_database.ExeUpdate(command_str);
            }
        }
        private void update_inf(string id_input,string id_original,basic basic_input,basic basic_original)
        {
            bool status=false;
            string command_str="UPDATE teacher_salary.基本信息 SET ";
            if(basic_input.name!= basic_original.name)
            {
                command_str += "姓名='" + basic_input.name + "',";
                status = true;
            }
            if (basic_input.sex != basic_original.sex)
            {
                command_str += "性别='" + basic_input.sex + "',";
                status = true;
            }
            if (basic_input.organization != basic_original.organization)
            {
                command_str += "单位名称='" + basic_input.organization + "',";
                status = true;
            }
            if (basic_input.address_province != basic_original.address_province)
            {
                command_str += "省='" + basic_input.address_province + "',";
                status = true;
            }
            if (basic_input.address_city != basic_original.address_city)
            {
                command_str += "市='" + basic_input.address_city + "',";
                status = true;
            }
            if (basic_input.address_country != basic_original.address_country)
            {
                command_str += "县='" + basic_input.address_country + "',";
                status = true;
            }
            if (basic_input.address_detailed != basic_original.address_detailed)
            {
                command_str += "详细地址='" + basic_input.address_detailed + "',";
                status = true;
            }
            if (basic_input.telephone != basic_original.telephone)
            {
                command_str += "联系电话='" + basic_input.telephone + "',";
                status = true;
            }
            if (status)
            {
                command_str = command_str.Substring(0, command_str.Length - 1);
                command_str += " WHERE 教师号='" + id_original + "';";
                mysql_database.ExeUpdate(command_str);
            }
            if(id_input!=id_original)
            {
                command_str = "UPDATE teacher_salary.基本信息 SET 教师号='" + id_input + "' WHERE 教师号='" + id_original + "';";
                mysql_database.ExeUpdate(command_str);
                command_str = "UPDATE teacher_salary.用户表 SET 教师号='" + id_input + "' WHERE 教师号='" + id_original + "';";
                mysql_database.ExeUpdate(command_str);
                command_str = "UPDATE teacher_salary.扣款 SET 教师号='" + id_input + "' WHERE 教师号='" + id_original + "';";
                mysql_database.ExeUpdate(command_str);
                command_str = "UPDATE teacher_salary.应发 SET 教师号='" + id_input + "' WHERE 教师号='" + id_original + "';";
                mysql_database.ExeUpdate(command_str);
            }
        }
        private void update_inf(string ID,salary salary_input,aggregate aggregate_input,total data_original)
        {
            bool status = false;
            string command_str = "UPDATE teacher_salary.扣款 SET ";
            if(data_original.aggregate_inf.telephone_bill!=aggregate_input.telephone_bill)
            {
                command_str += "电话费=" +aggregate_input.telephone_bill + ",";
                status = true;
            }
            if (data_original.aggregate_inf.water_electricity != aggregate_input.water_electricity)
            {
                command_str += "水电费=" + aggregate_input.water_electricity + ",";
                status = true;
            }
            if (data_original.aggregate_inf.the_rent != aggregate_input.the_rent)
            {
                command_str += "房租=" + aggregate_input.the_rent + ",";
                status = true;
            }
            if (data_original.aggregate_inf.income_tax != aggregate_input.income_tax)
            {
                command_str += "所得税=" + aggregate_input.income_tax+ ",";
                status = true;
            }
            if (data_original.aggregate_inf.sanitation_fee != aggregate_input.sanitation_fee)
            {
                command_str += "卫生费=" + aggregate_input.sanitation_fee + ",";
                status = true;
            }
            if (data_original.aggregate_inf.accumulation_fund != aggregate_input.accumulation_fund)
            {
                command_str += "公积金=" + aggregate_input.accumulation_fund + ",";
                status = true;
            }
            if(status)
            {
                command_str = command_str.Substring(0, command_str.Length - 1);
                command_str += " WHERE 教师号='" + ID + "';";
                mysql_database.ExeUpdate(command_str);
            }
            status = false;
            command_str = "UPDATE teacher_salary.应发 SET ";
            if(data_original.salary_inf.base_pay!=salary_input.base_pay)
            {
                command_str += "基本工资=" + salary_input.base_pay + ",";
                status = true;
            }
            if (data_original.salary_inf.subsistence_allowance != salary_input.subsistence_allowance)
            {
                command_str += "生活补贴=" + salary_input.subsistence_allowance + ",";
                status = true;
            }
            if (data_original.salary_inf.allowance != salary_input.allowance)
            {
                command_str += "津贴=" + salary_input.allowance + ",";
                status = true;
            }
            if(status)
            {
                command_str = command_str.Substring(0, command_str.Length - 1);
                command_str += " WHERE 教师号='" + ID + "';";
                mysql_database.ExeUpdate(command_str);
            }
        }
        
        private bool delete_inf(string User_ID)
        {
            if(mysql_database.ExeUpdate("DELETE FROM teacher_salary.基本信息 WHERE 教师号='" + User_ID + "';")&&
            mysql_database.ExeUpdate("DELETE FROM teacher_salary.应发 WHERE 教师号='" + User_ID + "';")&&
            mysql_database.ExeUpdate("DELETE FROM teacher_salary.扣款 WHERE 教师号='" + User_ID + "';")&&
            mysql_database.ExeUpdate("DELETE FROM teacher_salary.用户表 WHERE 教师号='" + User_ID + "';"))
                return true;
            return false;
        }
        private void clear()
        {
            id_input.Text = "";
            name_input.Text = "";
            organization_input.Text = "";
            telephone_input.Text = "";
            base_pay_input.Text = "";
            allowance_input.Text = "";
            subsistence_allowance_input.Text = "";
            telephone_bill_input.Text = "";
            water_electricity_input.Text = "";
            the_rent_input.Text = "";
            income_tax_input.Text = "";
            sanitation_fee_input.Text = "";
            accumulation_fund_input.Text = "";
            sex_input.Text = "";
            address_province_input.Text = "";
            address_city_input.Text = "";
            address_county_input.Text = "";
            address_detailed_input.Text = "";
        }
        private bool Input_check(Label label,TextBox box,ref float data)
        {
            if (box.Text != "")
            {
                data = float.Parse(box.Text);
                if(data<0)
                {
                    MessageBox.Show("必须非负！！！", "提示");
                    return false;
                }
                return true;
            }
            else
            {
                DialogResult DR = MessageBox.Show(label.Text+"未填写！", "提示", MessageBoxButtons.YesNo);
                if (DR == DialogResult.Yes)
                {
                    box.Text = "0.00";
                    data = 0.0f;
                    return true;
                }
                else
                    return false;
            }
        }
        private bool Input_check(Label label,TextBox box, ref string data)
        {
            if (box.Text != "")
            {
                data = box.Text;
                return true;
            }
            else
            {
                DialogResult DR = MessageBox.Show(label.Text+"未填写！", "提示", MessageBoxButtons.YesNo);
                if (DR == DialogResult.Yes)
                {
                    box.Text = "";
                    data = "";
                    return true;
                }
                else
                    return false;
            }
        }
        private bool Input_check(Label label, ComboBox box, ref string data)
        {
            if (box.Text != "")
            {
                data = box.Text;
                return true;
            }
            else
            {
                DialogResult DR = MessageBox.Show(label.Text + "未填写！", "提示", MessageBoxButtons.YesNo);
                if (DR == DialogResult.Yes)
                {
                    box.Text = "";
                    data = "";
                    return true;
                }
                else
                    return false;
            }
        }
        private void calc_Click(object sender, EventArgs e)
        {
             if (Input_check(base_pay,base_pay_input, ref data.salary_inf.base_pay) != true)
                return;
            if (Input_check(allowance,allowance_input,ref data.salary_inf.allowance) != true)
                return;
            if (Input_check(subsistence_allowance,subsistence_allowance_input,ref  data.salary_inf.subsistence_allowance) != true)
                return;
            if (Input_check(telephone_bill,telephone_bill_input, ref data.aggregate_inf.telephone_bill) != true)
                return;
            if (Input_check(water_electricity,water_electricity_input,ref  data.aggregate_inf.water_electricity) != true)
                return;
            if (Input_check(the_rent,the_rent_input,ref data.aggregate_inf.the_rent) != true)
                return;
            if (Input_check(income_tax, income_tax_input,ref  data.aggregate_inf.income_tax) != true)
                return;
            if (Input_check(sanitation_fee,sanitation_fee_input,ref data.aggregate_inf.sanitation_fee) != true)
                return;
            if (Input_check(accumulation_fund,accumulation_fund_input, ref data.aggregate_inf.accumulation_fund) != true)
                return;
            Salary_show.salary = data.salary_inf.base_pay + data.salary_inf.allowance 
                + data.salary_inf.subsistence_allowance;
            salary_show.Text = Salary_show.salary.ToString();
            Salary_show.aggregate = data.aggregate_inf.telephone_bill +
                data.aggregate_inf.water_electricity +
                data.aggregate_inf.the_rent +
                data.aggregate_inf.income_tax +
                data.aggregate_inf.sanitation_fee +
                data.aggregate_inf.accumulation_fund;
            aggregate_show.Text= Salary_show.aggregate.ToString();
            Salary_show.payroll = Salary_show.salary- Salary_show.aggregate;
            payroll_show.Text= Salary_show.payroll.ToString();
        }
        private void change_submit_Click(object sender, EventArgs e)
        {
            if(id_input.Text!=data.id)
            {
                MessageBox.Show("教师号不允许修改！", "提示");
                id_input.Text = data.id;
            }
            if(name_input.Text!=data.basic_inf.name)
            {
                MessageBox.Show("姓名不允许被修改", "提示");
                name_input.Text = data.basic_inf.name;
            }
            if (Input_check(base_pay, base_pay_input) != true)
                return;
            if (Input_check(allowance, allowance_input) != true)
                return;
            if (Input_check(subsistence_allowance, subsistence_allowance_input) != true)
                return;
            if (Input_check(telephone_bill, telephone_bill_input) != true)
                return;
            if (Input_check(water_electricity, water_electricity_input) != true)
                return;
            if (Input_check(the_rent, the_rent_input) != true)
                return;
            if (Input_check(income_tax, income_tax_input) != true)
                return;
            if (Input_check(sanitation_fee, sanitation_fee_input) != true)
                return;
            if (Input_check(accumulation_fund, accumulation_fund_input) != true)
                return;
            if (MessageBox.Show("确认修改？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                salary salary_input; aggregate aggregate_input;
                aggregate_input.telephone_bill = float.Parse(telephone_bill_input.Text);
                aggregate_input.water_electricity = float.Parse(water_electricity_input.Text);
                aggregate_input.the_rent = float.Parse(the_rent_input.Text);
                aggregate_input.income_tax = float.Parse(income_tax_input.Text);
                aggregate_input.sanitation_fee = float.Parse(sanitation_fee_input.Text);
                aggregate_input.accumulation_fund = float.Parse(accumulation_fund_input.Text);
                salary_input.base_pay = float.Parse(base_pay_input.Text);
                salary_input.subsistence_allowance = float.Parse(subsistence_allowance_input.Text);
                salary_input.allowance = float.Parse(allowance_input.Text);
                Salary_show.salary = data.salary_inf.base_pay + data.salary_inf.allowance
                       + data.salary_inf.subsistence_allowance + 0.00f;
                salary_show.Text = Salary_show.salary.ToString();
                Salary_show.aggregate = data.aggregate_inf.telephone_bill +
                    data.aggregate_inf.water_electricity +
                    data.aggregate_inf.the_rent +
                    data.aggregate_inf.income_tax +
                    data.aggregate_inf.sanitation_fee +
                    data.aggregate_inf.accumulation_fund + 0.0f;
                aggregate_show.Text = Salary_show.aggregate.ToString();
                Salary_show.payroll = Salary_show.salary - Salary_show.aggregate + 0.00f;
                payroll_show.Text = Salary_show.payroll.ToString();
                update_inf(data.id, salary_input, aggregate_input, data);
            }
        }
        public enum Interface_status
        {
            close_all=0,

            open_basic=2,
            open_finance=4,
            open_look=6,
        }
        static bool stats = false;
        void interface_contrl(Interface_status status)
        {
            switch(status)
            {
                case Interface_status.close_all:
                    {
                        this.id.Visible = false;
                        this.name.Visible = false;
                        this.sex.Visible = false;
                        this.organization.Visible = false;
                        this.address.Visible = false;
                        this.telephone.Visible = false;
                        this.base_pay.Visible = false;
                        this.allowance.Visible = false;
                        this.subsistence_allowance.Visible = false;
                        this.telephone_bill.Visible = false;
                        this.water_electricity.Visible = false;
                        this.the_rent.Visible = false;
                        this.income_tax.Visible = false;
                        this.sanitation_fee.Visible = false;
                        this.accumulation_fund.Visible = false;

                        this.id_input.Visible = false;
                        this.name_input.Visible = false;
                        this.sex_input.Visible = false;
                        this.organization_input.Visible = false;
                        this.address_province_input.Visible = false;
                        this.address_city_input.Visible = false;
                        this.address_county_input.Visible = false;
                        this.address_detailed_input.Visible = false;
                        this.telephone_input.Visible = false;
                        this.base_pay_input.Visible = false;
                        this.allowance_input.Visible = false;
                        this.subsistence_allowance_input.Visible = false;
                        this.telephone_bill_input.Visible = false;
                        this.water_electricity_input.Visible = false;
                        this.the_rent_input.Visible = false;
                        this.income_tax_input.Visible = false;
                        this.sanitation_fee_input.Visible = false;
                        this.accumulation_fund_input.Visible = false;

                        this.salary.Visible = false;
                        this.salary_show.Visible = false;
                        this.aggregate.Visible = false;
                        this.aggregate_show.Visible = false;
                        this.payroll.Visible = false;
                        this.payroll_show.Visible = false;

                        this.calc.Visible = false;
                        this.submit.Visible = false;
                        this.change_submit.Visible = false;
                        this.modif_inf.Visible = false;
                        this.del_inf.Visible = false;
                        this.submit_new.Visible = false;
                        this.inquire_finance.Visible = false;
                        this.inquire_look.Visible = false;
                        this.inquire_basic.Visible = false;
                        this.up_inf.Visible = false;
                        this.bot_inf.Visible = false;
                        if(stats)
                        {
                            this.base_pay_input.Location = new Point(this.base_pay_input.Location.X, this.base_pay_input.Location.Y + 138);
                            this.allowance_input.Location = new Point(this.allowance_input.Location.X, this.allowance_input.Location.Y + 138);
                            this.subsistence_allowance_input.Location = new Point(this.subsistence_allowance_input.Location.X, this.subsistence_allowance_input.Location.Y + 138);
                            this.telephone_bill_input.Location = new Point(this.telephone_bill_input.Location.X, this.telephone_bill_input.Location.Y + 138);
                            this.water_electricity_input.Location = new Point(this.water_electricity_input.Location.X, this.water_electricity_input.Location.Y + 138);
                            this.the_rent_input.Location = new Point(this.the_rent_input.Location.X, this.the_rent_input.Location.Y + 138);
                            this.income_tax_input.Location = new Point(this.income_tax_input.Location.X, this.income_tax_input.Location.Y + 138);
                            this.sanitation_fee_input.Location = new Point(this.sanitation_fee_input.Location.X, this.sanitation_fee_input.Location.Y + 138);
                            this.accumulation_fund_input.Location = new Point(this.accumulation_fund_input.Location.X, this.accumulation_fund_input.Location.Y + 138);
                            this.salary.Location = new Point(this.salary.Location.X, this.salary.Location.Y + 138);
                            this.salary_show.Location = new Point(this.salary_show.Location.X, this.salary_show.Location.Y + 138);
                            this.aggregate.Location = new Point(this.aggregate.Location.X, this.aggregate.Location.Y + 138);
                            this.aggregate_show.Location = new Point(this.aggregate_show.Location.X, this.aggregate_show.Location.Y + 138);
                            this.payroll.Location = new Point(this.payroll.Location.X, this.payroll.Location.Y + 138);
                            this.payroll_show.Location = new Point(this.payroll_show.Location.X, this.payroll_show.Location.Y + 138);
                            this.base_pay.Location = new Point(this.base_pay.Location.X, this.base_pay.Location.Y + 138);
                            this.allowance.Location = new Point(this.allowance.Location.X, this.allowance.Location.Y + 138);
                            this.subsistence_allowance.Location = new Point(this.subsistence_allowance.Location.X, this.subsistence_allowance.Location.Y + 138);
                            this.telephone_bill.Location = new Point(this.telephone_bill.Location.X, this.telephone_bill.Location.Y + 138);
                            this.water_electricity.Location = new Point(this.water_electricity.Location.X, this.water_electricity.Location.Y + 138);
                            this.the_rent.Location = new Point(this.the_rent.Location.X, this.the_rent.Location.Y + 138);
                            this.income_tax.Location = new Point(this.income_tax.Location.X, this.income_tax.Location.Y + 138);
                            this.sanitation_fee.Location = new Point(this.sanitation_fee.Location.X, this.sanitation_fee.Location.Y + 138);
                            this.accumulation_fund.Location = new Point(this.accumulation_fund.Location.X, this.accumulation_fund.Location.Y + 138);
                            this.calc.Location = new Point(this.calc.Location.X, this.calc.Location.Y + 138);
                            stats = false;
                        }
                        break;
                    }
                case Interface_status.open_basic:
                    {
                        this.id.Visible = true;
                        this.name.Visible = true;
                        this.sex.Visible = true;
                        this.organization.Visible = true;
                        this.address.Visible = true;
                        this.telephone.Visible = true;

                        this.id_input.Visible = true;
                        this.name_input.Visible = true;
                        this.sex_input.Visible = true;
                        this.organization_input.Visible = true;
                        this.address_province_input.Visible = true;
                        this.address_city_input.Visible = true;
                        this.address_county_input.Visible = true;
                        this.address_detailed_input.Visible = true;
                        this.telephone_input.Visible = true;
                        break;
                    }
                case Interface_status.open_finance:
                    {
                        this.id.Visible = true;
                        this.name.Visible = true;
                        this.base_pay.Visible = true;
                        this.allowance.Visible = true;
                        this.subsistence_allowance.Visible = true;
                        this.telephone_bill.Visible = true;
                        this.water_electricity.Visible = true;
                        this.the_rent.Visible = true;
                        this.income_tax.Visible = true;
                        this.sanitation_fee.Visible = true;
                        this.accumulation_fund.Visible = true;

                        this.id_input.Visible = true;
                        this.name_input.Visible = true;
                        this.base_pay_input.Visible = true;
                        this.allowance_input.Visible = true;
                        this.subsistence_allowance_input.Visible = true;
                        this.telephone_bill_input.Visible = true;
                        this.water_electricity_input.Visible = true;
                        this.the_rent_input.Visible = true;
                        this.income_tax_input.Visible = true;
                        this.sanitation_fee_input.Visible = true;
                        this.accumulation_fund_input.Visible = true;

                        this.salary.Visible = true;
                        this.salary_show.Visible = true;
                        this.aggregate.Visible = true;
                        this.aggregate_show.Visible = true;
                        this.payroll.Visible = true;
                        this.payroll_show.Visible = true;
                        this.change_submit.Visible = true;
                        this.calc.Visible = true;
                        if (!stats)
                        {
                            this.base_pay_input.Location = new Point(this.base_pay_input.Location.X, this.base_pay_input.Location.Y - 138);
                            this.allowance_input.Location = new Point(this.allowance_input.Location.X, this.allowance_input.Location.Y - 138);
                            this.subsistence_allowance_input.Location = new Point(this.subsistence_allowance_input.Location.X, this.subsistence_allowance_input.Location.Y - 138);
                            this.telephone_bill_input.Location = new Point(this.telephone_bill_input.Location.X, this.telephone_bill_input.Location.Y - 138);
                            this.water_electricity_input.Location = new Point(this.water_electricity_input.Location.X, this.water_electricity_input.Location.Y - 138);
                            this.the_rent_input.Location = new Point(this.the_rent_input.Location.X, this.the_rent_input.Location.Y - 138);
                            this.income_tax_input.Location = new Point(this.income_tax_input.Location.X, this.income_tax_input.Location.Y - 138);
                            this.sanitation_fee_input.Location = new Point(this.sanitation_fee_input.Location.X, this.sanitation_fee_input.Location.Y - 138);
                            this.accumulation_fund_input.Location = new Point(this.accumulation_fund_input.Location.X, this.accumulation_fund_input.Location.Y - 138);
                            this.salary.Location = new Point(this.salary.Location.X, this.salary.Location.Y - 138);
                            this.salary_show.Location = new Point(this.salary_show.Location.X, this.salary_show.Location.Y - 138);
                            this.aggregate.Location = new Point(this.aggregate.Location.X, this.aggregate.Location.Y - 138);
                            this.aggregate_show.Location = new Point(this.aggregate_show.Location.X, this.aggregate_show.Location.Y - 138);
                            this.payroll.Location = new Point(this.payroll.Location.X, this.payroll.Location.Y - 138);
                            this.payroll_show.Location = new Point(this.payroll_show.Location.X, this.payroll_show.Location.Y - 138);
                            this.base_pay.Location = new Point(this.base_pay.Location.X, this.base_pay.Location.Y - 138);
                            this.allowance.Location = new Point(this.allowance.Location.X, this.allowance.Location.Y - 138);
                            this.subsistence_allowance.Location = new Point(this.subsistence_allowance.Location.X, this.subsistence_allowance.Location.Y - 138);
                            this.telephone_bill.Location = new Point(this.telephone_bill.Location.X, this.telephone_bill.Location.Y - 138);
                            this.water_electricity.Location = new Point(this.water_electricity.Location.X, this.water_electricity.Location.Y - 138);
                            this.the_rent.Location = new Point(this.the_rent.Location.X, this.the_rent.Location.Y - 138);
                            this.income_tax.Location = new Point(this.income_tax.Location.X, this.income_tax.Location.Y - 138);
                            this.sanitation_fee.Location = new Point(this.sanitation_fee.Location.X, this.sanitation_fee.Location.Y - 138);
                            this.accumulation_fund.Location = new Point(this.accumulation_fund.Location.X, this.accumulation_fund.Location.Y - 138);
                            this.calc.Location = new Point(this.calc.Location.X, this.calc.Location.Y - 138);
                            stats = true;
                        }
                        break;
                    }
                case Interface_status.open_look:
                    {
                        this.id.Visible = true;
                        this.name.Visible = true;
                        this.sex.Visible = true;
                        this.organization.Visible = true;
                        this.address.Visible = true;
                        this.telephone.Visible = true;
                        this.base_pay.Visible = true;
                        this.allowance.Visible = true;
                        this.subsistence_allowance.Visible = true;
                        this.telephone_bill.Visible = true;
                        this.water_electricity.Visible = true;
                        this.the_rent.Visible = true;
                        this.income_tax.Visible = true;
                        this.sanitation_fee.Visible = true;
                        this.accumulation_fund.Visible = true;

                        this.id_input.Visible = true;
                        this.name_input.Visible = true;
                        this.sex_input.Visible = true;
                        this.organization_input.Visible = true;
                        this.address_province_input.Visible = true;
                        this.address_city_input.Visible = true;
                        this.address_county_input.Visible = true;
                        this.address_detailed_input.Visible = true;
                        this.telephone_input.Visible = true;
                        this.base_pay_input.Visible = true;
                        this.allowance_input.Visible = true;
                        this.subsistence_allowance_input.Visible = true;
                        this.telephone_bill_input.Visible = true;
                        this.water_electricity_input.Visible = true;
                        this.the_rent_input.Visible = true;
                        this.income_tax_input.Visible = true;
                        this.sanitation_fee_input.Visible = true;
                        this.accumulation_fund_input.Visible = true;

                        this.salary.Visible = true;
                        this.salary_show.Visible = true;
                        this.aggregate.Visible = true;
                        this.aggregate_show.Visible = true;
                        this.payroll.Visible = true;
                        this.payroll_show.Visible = true;

                        this.calc.Visible = true;
                        this.submit.Visible = true;
                        break;
                    }
            }
        }
        private void new_basic_inf_entry_Click(object sender, EventArgs e)
        {
            clear();
            interface_contrl(Interface_status.close_all);
            interface_contrl(Interface_status.open_basic);
            this.submit_new.Visible = true;
        }
        private void modif_basic_inf_Click(object sender, EventArgs e)
        {
            clear();
            interface_contrl(Interface_status.close_all);
            interface_contrl(Interface_status.open_basic);
            this.inquire_basic.Visible = true;
        }
        private void batch_basic_inf_entry_Click(object sender, EventArgs e)
        {
            clear();
            interface_contrl(Interface_status.close_all);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dr = openFileDialog.ShowDialog();
            openFileDialog.InitialDirectory = "c:\\Users\\sjzmd\\Documents\\";
            openFileDialog.Filter = "Excel|*.xls;*.xlsx";
            openFileDialog.RestoreDirectory = false;
            openFileDialog.FilterIndex = 1;
            string filename = openFileDialog.FileName;//获取所打开文件的文件名
            if (dr == System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(filename))
            {
                FileStream fsRead = null;
                IWorkbook wkBook = null;
                int number = 0;
                try
                { fsRead = new FileStream(filename, FileMode.Open, FileAccess.Read); }
                catch (IOException)
                {
                    MessageBox.Show("文件打开失败！", "提示");
                    return;
                }
                if (filename.IndexOf(".xlsx") > 0)
                {
                    wkBook = new XSSFWorkbook(fsRead);  //xlsx数据读入workbook
                }
                else if (filename.IndexOf(".xls") > 0)
                {
                    wkBook = new HSSFWorkbook(fsRead);  //xls数据读入workbook
                }
                ISheet sheet = wkBook.GetSheetAt(0); //第一个工作表
                IRow row;          //新建当前工作表行数据
                for (int i = 1; i <=sheet.LastRowNum; i++)  //对工作表每一行
                {
                    row = sheet.GetRow(i);   //row读入第i行数据
                    if (row != null)
                    {
                        data.id = row.GetCell(0).ToString();
                        data.basic_inf.name = row.GetCell(1).ToString();
                        data.basic_inf.sex = row.GetCell(2).ToString();
                        data.basic_inf.organization = row.GetCell(3).ToString();
                        data.basic_inf.address_province = row.GetCell(4).ToString();
                        data.basic_inf.address_city = row.GetCell(5).ToString();
                        data.basic_inf.address_country = row.GetCell(6).ToString();
                        data.basic_inf.address_detailed = row.GetCell(7).ToString();
                        data.basic_inf.telephone = row.GetCell(8).ToString();
                        if (!mysql_database.inquire_inf(data.id))
                        {
                            mysql_database.ExeUpdate("INSERT INTO teacher_salary.基本信息 VALUES('"
                                    + data.id + "','"
                                    + data.basic_inf.name + "','"
                                    + data.basic_inf.sex + "','"
                                    + data.basic_inf.organization + "','"
                                    + data.basic_inf.address_province+ "','"
                                    + data.basic_inf.address_city + "','"
                                    + data.basic_inf.address_country + "','"
                                    + data.basic_inf.address_detailed + "','"
                                    + data.basic_inf.telephone+ "');");
                            mysql_database.ExeUpdate("INSERT INTO teacher_salary.应发 VALUES('" + data.id + "',0.00,0.00,0.00);");
                            mysql_database.ExeUpdate("INSERT INTO teacher_salary.扣款 VALUES('" + data.id+ "',0.00,0.00,0.00,0.00,0.00,0.00);");
                            mysql_database.ExeUpdate("INSERT INTO teacher_salary.用户表 VALUES('" + data.id+ "'," + "'123456');"); //初始密码为123456
                        }
                        else
                            number++;
                    }
                }
                if(number!=0)
                    MessageBox.Show(sheet.LastRowNum.ToString()+"个导入成功！"+number.ToString()+"个导入失败！", "提示");
                else
                    MessageBox.Show(sheet.LastRowNum.ToString() + "个导入成功！", "提示");
                fsRead.Close(); 
                wkBook.Close();
            }
        }
        private void finance_single_entry_Click(object sender, EventArgs e)
        {
            clear();
            interface_contrl(Interface_status.close_all);
            interface_contrl(Interface_status.open_finance);
            this.inquire_finance.Visible = true;
        }
        private void finance_batch_entry_Click(object sender, EventArgs e)
        {
            clear();
            interface_contrl(Interface_status.close_all);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dr = openFileDialog.ShowDialog();
            openFileDialog.InitialDirectory = "c:\\Users\\sjzmd\\Documents\\";
            openFileDialog.Filter = "Excel|*.xls;*.xlsx";
            openFileDialog.RestoreDirectory = false;
            openFileDialog.FilterIndex = 1;
            string filename = openFileDialog.FileName;//获取所打开文件的文件名
            if (dr == System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(filename))
            {
                FileStream fsRead = null;
                IWorkbook wkBook = null;
                int number = 0; 
                try
                { fsRead = new FileStream(filename, FileMode.Open, FileAccess.Read); }
                catch (IOException)
                {
                    MessageBox.Show("文件打开失败！", "提示");
                    return;
                }
                if (filename.IndexOf(".xlsx") > 0)
                    wkBook = new XSSFWorkbook(fsRead);  //xlsx数据读入workbook
                else if (filename.IndexOf(".xls") > 0)
                    wkBook = new HSSFWorkbook(fsRead);  //xls数据读入workbook
                ISheet sheet = wkBook.GetSheetAt(1); //第一个工作表
                IRow row;          //新建当前工作表行数据
                for (int i = 1; i <= sheet.LastRowNum; i++)  //对工作表每一行
                {
                    row = sheet.GetRow(i);   //row读入第i行数据
                    if (row != null)
                    {
                        data.id = row.GetCell(0).ToString();
                        data.aggregate_inf.telephone_bill = float.Parse(row.GetCell(1).ToString());
                        data.aggregate_inf.water_electricity = float.Parse(row.GetCell(2).ToString());
                        data.aggregate_inf.the_rent = float.Parse(row.GetCell(3).ToString());
                        data.aggregate_inf.income_tax = float.Parse(row.GetCell(4).ToString());
                        data.aggregate_inf.sanitation_fee = float.Parse(row.GetCell(5).ToString());
                        data.aggregate_inf.accumulation_fund = float.Parse(row.GetCell(6).ToString());
                        if (mysql_database.inquire_inf(data.id))
                        {
                            string command_str = "UPDATE teacher_salary.扣款 SET "+
                                "电话费=" + data.aggregate_inf.telephone_bill + ","+
                                "水电费=" + data.aggregate_inf.water_electricity + ","+
                                "房租=" + data.aggregate_inf.the_rent + ","+
                                "所得税=" + data.aggregate_inf.income_tax + ","+
                                "卫生费=" + data.aggregate_inf.sanitation_fee + ","+
                                "公积金=" + data.aggregate_inf.accumulation_fund +
                                " WHERE 教师号='" + data.id + "';";
                                mysql_database.ExeUpdate(command_str);
                        }
                        else
                            number++;
                    }
                }
                if (number != 0)
                    MessageBox.Show("扣款"+sheet.LastRowNum.ToString() + "个更新成功！" + number.ToString() + "个更新失败！", "提示");
                else
                    MessageBox.Show("扣款" + sheet.LastRowNum.ToString() + "个更新成功！", "提示");
                number = 0;
                sheet = wkBook.GetSheetAt(2);
                for (int i = 1; i <= sheet.LastRowNum; i++)  //对工作表每一行
                {
                    row = sheet.GetRow(i);   //row读入第i行数据
                    if (row != null)
                    {
                        data.id = row.GetCell(0).ToString();
                        data.salary_inf.allowance = float.Parse(row.GetCell(1).ToString());
                        data.salary_inf.base_pay = float.Parse(row.GetCell(2).ToString());
                        data.salary_inf.subsistence_allowance = float.Parse(row.GetCell(3).ToString());
                        if (mysql_database.inquire_inf(data.id))
                        {
                            string command_str = "UPDATE teacher_salary.扣款 SET " +
                                "电话费=" + data.salary_inf.base_pay + "," +
                                "生活补贴=" + data.salary_inf.subsistence_allowance + "," +
                                "津贴=" + data.salary_inf.allowance + "," +
                                " WHERE 教师号='" + data.id + "';";
                            mysql_database.ExeUpdate(command_str);
                        }
                        else
                            number++;
                    }
                }
                if (number != 0)
                    MessageBox.Show("应发"+sheet.LastRowNum.ToString() + "个更新成功！" + number.ToString() + "个更新失败！", "提示");
                else
                    MessageBox.Show("应发" + sheet.LastRowNum.ToString() + "个更新成功！", "提示");
                fsRead.Close();
                wkBook.Close();
            }
        }
        private void look_uo_id_Click(object sender, EventArgs e)
        {
            clear();
            interface_contrl(Interface_status.close_all);
            interface_contrl(Interface_status.open_look);
            this.inquire_look.Visible = true;
        }
        private void look_up_all_Click(object sender, EventArgs e)
        {
            clear();
            interface_contrl(Interface_status.close_all);
            interface_contrl(Interface_status.open_look);
            this.submit.Visible = false;
            this.bot_inf.Visible = true;
            this.calc.Visible = false;
            number_of_teacher = mysql_database.length_inf();
            data_all = new total[number_of_teacher];
            mysql_database.inquire_inf(ref  data_all);
            show_data_look(data_all[0]);
        }
        private void inquire_basic_Click(object sender, EventArgs e)
        {
            if (this.id_input.Text == "")
            {
                MessageBox.Show("输入为空！", "提示");
                return;
            }
            else if (this.id_input.Text.Length != 10)
            {
                MessageBox.Show("输入错误！", "提示");
                return;
            }
            if (mysql_database.inquire_inf(this.id_input.Text, ref data.basic_inf))
            {
                data.id = this.id_input.Text;
                this.name_input.Text = data.basic_inf.name;
                this.sex_input.Text = data.basic_inf.sex;
                this.organization_input.Text = data.basic_inf.organization;
                this.address_province_input.Text = data.basic_inf.address_province;
                this.address_city_input.Text = data.basic_inf.address_city;
                this.address_county_input.Text = data.basic_inf.address_country;
                this.address_detailed_input.Text = data.basic_inf.address_detailed;
                this.telephone_input.Text = data.basic_inf.telephone;
                this.modif_inf.Visible = true;
                this.del_inf.Visible = true;
            }

        }
        private void inquire_finance_Click(object sender, EventArgs e)
        {
            if (this.id_input.Text == "")
            {
                MessageBox.Show("输入为空！", "提示");
                return;
            }
            else if (this.id_input.Text.Length != 10)
            {
                MessageBox.Show("输入错误！", "提示");
                return;
            }
            if (mysql_database.inquire_inf(this.id_input.Text, ref data))
            {
                this.name_input.Text = data.basic_inf.name;
                this.base_pay_input.Text = data.salary_inf.base_pay.ToString();
                this.allowance_input.Text = data.salary_inf.allowance.ToString();
                this.subsistence_allowance_input.Text = data.salary_inf.subsistence_allowance.ToString();
                this.telephone_bill_input.Text = data.aggregate_inf.telephone_bill.ToString();
                this.water_electricity_input.Text = data.aggregate_inf.water_electricity.ToString();
                this.the_rent_input.Text = data.aggregate_inf.the_rent.ToString();
                this.income_tax_input.Text = data.aggregate_inf.income_tax.ToString();
                this.sanitation_fee_input.Text = data.aggregate_inf.sanitation_fee.ToString();
                this.accumulation_fund_input.Text = data.aggregate_inf.accumulation_fund.ToString();
                Salary_show.salary = data.salary_inf.base_pay +
                    data.salary_inf.allowance +
                    data.salary_inf.subsistence_allowance + 0.00f;
                salary_show.Text = Salary_show.salary.ToString();
                Salary_show.aggregate = data.aggregate_inf.telephone_bill +
                    data.aggregate_inf.water_electricity +
                    data.aggregate_inf.the_rent +
                    data.aggregate_inf.income_tax +
                    data.aggregate_inf.sanitation_fee +
                    data.aggregate_inf.accumulation_fund + 0.0f;
                aggregate_show.Text = Salary_show.aggregate.ToString();
                Salary_show.payroll = Salary_show.salary - Salary_show.aggregate + 0.00f;
                payroll_show.Text = Salary_show.payroll.ToString();
            }
        }
        private void inquire_look_Click(object sender, EventArgs e)
        {
            if (this.id_input.Text == "")
            {
                MessageBox.Show("输入为空！", "提示");
                return;
            }
            else if (this.id_input.Text.Length != 10)
            {
                MessageBox.Show("输入错误！", "提示");
                return;
            }
            mysql_database.inquire_inf(this.id_input.Text, ref data);
            clear();
            show_data_look(data);
        }
        void show_data_look(total data_inf_all)
        {
            this.id_input.Text = data_inf_all.id;
            this.name_input.Text = data_inf_all.basic_inf.name;
            this.sex_input.Text = data_inf_all.basic_inf.sex;
            this.organization_input.Text = data_inf_all.basic_inf.organization;
            this.address_province_input.Text = data_inf_all.basic_inf.address_province;
            this.address_city_input.Text = data_inf_all.basic_inf.address_city;
            this.address_county_input.Text = data_inf_all.basic_inf.address_country;
            this.address_detailed_input.Text = data_inf_all.basic_inf.address_detailed;
            this.telephone_input.Text = data_inf_all.basic_inf.telephone;
            this.base_pay_input.Text = data_inf_all.salary_inf.base_pay.ToString();
            this.allowance_input.Text = data_inf_all.salary_inf.allowance.ToString();
            this.subsistence_allowance_input.Text = data_inf_all.salary_inf.subsistence_allowance.ToString();
            this.telephone_bill_input.Text = data_inf_all.aggregate_inf.telephone_bill.ToString();
            this.water_electricity_input.Text = data_inf_all.aggregate_inf.water_electricity.ToString();
            this.the_rent_input.Text = data_inf_all.aggregate_inf.the_rent.ToString();
            this.income_tax_input.Text = data_inf_all.aggregate_inf.income_tax.ToString();
            this.sanitation_fee_input.Text = data_inf_all.aggregate_inf.sanitation_fee.ToString();
            this.accumulation_fund_input.Text = data_inf_all.aggregate_inf.accumulation_fund.ToString();
            Salary_show.salary = data_inf_all.salary_inf.base_pay + data_inf_all.salary_inf.allowance
                + data_inf_all.salary_inf.subsistence_allowance + 0.00f;
            salary_show.Text = Salary_show.salary.ToString();
            Salary_show.aggregate = data_inf_all.aggregate_inf.telephone_bill +
                data_inf_all.aggregate_inf.water_electricity +
                data_inf_all.aggregate_inf.the_rent +
                data_inf_all.aggregate_inf.income_tax +
                data_inf_all.aggregate_inf.sanitation_fee +
                data_inf_all.aggregate_inf.accumulation_fund + 0.0f;
            aggregate_show.Text = Salary_show.aggregate.ToString();
            Salary_show.payroll = Salary_show.salary - Salary_show.aggregate + 0.00f;
            payroll_show.Text = Salary_show.payroll.ToString();
        }
        private bool Input_check(Label label,TextBox textBox)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(label.Text + "未填写！", "提示");
                return false;
            }
            return true;
        }
        private bool Input_check(Label label, ComboBox textBox)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(label.Text + "未填写！", "提示");
                return false;
            }
            return true;
        }
        private void modif_inf_Click(object sender, EventArgs e)
        {
            basic basic_input=new basic();
            basic_input.name = name_input.Text;
            basic_input.sex = sex_input.Text;
            basic_input.organization = organization_input.Text;
            basic_input.address_province = address_province_input.Text;
            basic_input.address_city = address_city_input.Text;
            basic_input.address_country = address_county_input.Text;
            basic_input.address_detailed = address_detailed_input.Text;
            basic_input.telephone = telephone_input.Text;

            if (Input_check(id, id_input) == true)
            {
                if (id_input.Text.Length != 10)
                {
                    MessageBox.Show("教师号为10位数字字母组合字符串", "教师号输入错误！");
                    return;
                }
            }
            else
                return;
            if (Input_check(name, name_input) != true)
                return;
            if (Input_check(sex, sex_input) != true)
                return;
            if (Input_check(organization, organization_input) != true)
                return;
            if (Input_check(address, address_province_input) != true)
                return;
            if (Input_check(address, address_city_input) != true)
                return;
            if (Input_check(address, address_county_input) != true)
                return;
            if (Input_check(address, address_detailed_input) != true)
                return;
            if (Input_check(telephone, telephone_input) == true)
            {
                if (telephone_input.Text.Length != 11)
                {
                    MessageBox.Show("电话号码输入错误！");
                    return;
                }
            }
            else
                return;
            if (MessageBox.Show("是否提交？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                update_inf(id_input.Text, data.id, basic_input, data.basic_inf);
                clear();
                MessageBox.Show("修改成功！", "提示");
            }
        }

        private void del_inf_Click(object sender, EventArgs e)
        {
            if(this.id_input.Text=="")
            {
                MessageBox.Show("教师号为空！", "提示");
            }
            else
            {
                if(MessageBox.Show("请确认删除"+name_input.Text+"的信息","提示",MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    if (delete_inf(id_input.Text))
                    {
                        clear();
                        MessageBox.Show("删除成功！", "提示");
                    }
                    else
                        MessageBox.Show("删除失败！", "提示");
                }
            }
        }
        private void submit_new_Click(object sender, EventArgs e)
        {
            if (Input_check(id, id_input) == true)
            {
                if (id_input.Text.Length != 10)
                {
                    MessageBox.Show("教师号为10位数字字母组合字符串", "教师号输入错误！");
                    return;
                }
            }
            else
                return;
            if (Input_check(name, name_input) != true)
                return;
            if (Input_check(sex, sex_input) != true)
                return;
            if (Input_check(organization, organization_input) != true)
                return;
            if (Input_check(address, address_province_input) != true)
                return;
            if (Input_check(address, address_city_input) != true)
                return;
            if (Input_check(address, address_county_input) != true)
                return;
            if (Input_check(address, address_detailed_input) != true)
                return;
            if (Input_check(telephone, telephone_input) == true)
            {
                if (telephone_input.Text.Length != 11)
                {
                    MessageBox.Show("电话号码输入错误！");
                    return;
                }
            }
            else
                return;
            if (MessageBox.Show("是否提交？", "提示", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                mysql_database.ExeUpdate("INSERT INTO teacher_salary.基本信息 VALUES('"
                    + id_input.Text + "','"
                    + name_input.Text + "','"
                    + sex_input.Text + "','"
                    + organization_input.Text + "','"
                    + address_province_input.Text + "','"
                    + address_city_input.Text + "','"
                    + address_county_input.Text + "','"
                    + address_detailed_input.Text + "','"
                    + telephone_input.Text + "');");
                mysql_database.ExeUpdate("INSERT INTO teacher_salary.应发 VALUES('" + id_input.Text + "',0.00,0.00,0.00);");
                mysql_database.ExeUpdate("INSERT INTO teacher_salary.扣款 VALUES('" + id_input.Text + "',0.00,0.00,0.00,0.00,0.00,0.00);");
                mysql_database.ExeUpdate("INSERT INTO teacher_salary.用户表 VALUES('" + id_input.Text + "'," + "'123456');"); //初始密码为123456
                clear();
                if (MessageBox.Show("继续录入？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    interface_contrl(Interface_status.close_all);
                }
            }

        }

        private void bot_inf_Click(object sender, EventArgs e)
        {
            clear();
            number_loc++;
            mysql_database.inquire_inf(ref data_all);
            show_data_look(data_all[number_loc]);
            if (number_loc == number_of_teacher-1)
            {
                this.bot_inf.Visible = false;
            }
            else
                this.up_inf.Visible = true;
            
        }

        private void up_inf_Click(object sender, EventArgs e)
        {
            clear();
            number_loc--;
            mysql_database.inquire_inf(ref data_all);
            show_data_look(data_all[number_loc]);
            if (number_loc == 0)
                this.up_inf.Visible = false;
            else
                this.bot_inf.Visible = true;
        }
    }
}

