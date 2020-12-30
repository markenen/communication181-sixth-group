using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teacher_salay_mangement_system
{
    public partial class teacher_windows : Form
    {
        private MysqlConnector mysql_database;
        USER_INF user_inf=new USER_INF();
        total data;
        public teacher_windows(USER_INF User_Inf_input)
        {
            user_inf = User_Inf_input;
            mysql_database = new MysqlConnector();
            InitializeComponent();
            show_inf();
        }
        private void teacher_logout_Click(object sender, EventArgs e)
        {
            DialogResult dr=MessageBox.Show("退出？", "提示", MessageBoxButtons.YesNo);
            if(dr== DialogResult.Yes)
                this.Close();
        }
        void show_inf()
        {
            Salary Salary_show = new Salary();
            mysql_database.inquire_inf(user_inf.id,ref data);
            this.id_input.Text = data.id;
            this.name_input.Text = data.basic_inf.name;
            this.sex_input.Text = data.basic_inf.sex;
            this.organization_input.Text = data.basic_inf.organization;
            this.address_province_input.Text = data.basic_inf.address_province;
            this.address_city_input.Text = data.basic_inf.address_city;
            this.address_county_input.Text = data.basic_inf.address_country;
            this.address_detailed_input.Text = data.basic_inf.address_detailed;
            this.telephone_input.Text = data.basic_inf.telephone;
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

        private void reflash_Click(object sender, EventArgs e)
        {
            show_inf();
        }
    }
}
