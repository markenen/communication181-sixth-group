
namespace Teacher_salay_mangement_system
{
    partial class admin_windows
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admin_windows));
            this.menu_admin = new System.Windows.Forms.MenuStrip();
            this.mange_basic_inf = new System.Windows.Forms.ToolStripMenuItem();
            this.new_basic_inf_entry = new System.Windows.Forms.ToolStripMenuItem();
            this.modif_basic_inf = new System.Windows.Forms.ToolStripMenuItem();
            this.batch_basic_inf_entry = new System.Windows.Forms.ToolStripMenuItem();
            this.finance_inf = new System.Windows.Forms.ToolStripMenuItem();
            this.finance_single_entry = new System.Windows.Forms.ToolStripMenuItem();
            this.finance_batch_entry = new System.Windows.Forms.ToolStripMenuItem();
            this.look_up_data = new System.Windows.Forms.ToolStripMenuItem();
            this.look_uo_id = new System.Windows.Forms.ToolStripMenuItem();
            this.look_up_all = new System.Windows.Forms.ToolStripMenuItem();
            this.logout_system = new System.Windows.Forms.ToolStripMenuItem();
            this.id = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.sex = new System.Windows.Forms.Label();
            this.organization = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.Label();
            this.telephone = new System.Windows.Forms.Label();
            this.base_pay = new System.Windows.Forms.Label();
            this.allowance = new System.Windows.Forms.Label();
            this.subsistence_allowance = new System.Windows.Forms.Label();
            this.telephone_bill = new System.Windows.Forms.Label();
            this.water_electricity = new System.Windows.Forms.Label();
            this.the_rent = new System.Windows.Forms.Label();
            this.income_tax = new System.Windows.Forms.Label();
            this.sanitation_fee = new System.Windows.Forms.Label();
            this.accumulation_fund = new System.Windows.Forms.Label();
            this.id_input = new System.Windows.Forms.TextBox();
            this.name_input = new System.Windows.Forms.TextBox();
            this.organization_input = new System.Windows.Forms.TextBox();
            this.telephone_input = new System.Windows.Forms.TextBox();
            this.base_pay_input = new System.Windows.Forms.TextBox();
            this.allowance_input = new System.Windows.Forms.TextBox();
            this.subsistence_allowance_input = new System.Windows.Forms.TextBox();
            this.telephone_bill_input = new System.Windows.Forms.TextBox();
            this.water_electricity_input = new System.Windows.Forms.TextBox();
            this.the_rent_input = new System.Windows.Forms.TextBox();
            this.income_tax_input = new System.Windows.Forms.TextBox();
            this.sanitation_fee_input = new System.Windows.Forms.TextBox();
            this.accumulation_fund_input = new System.Windows.Forms.TextBox();
            this.salary = new System.Windows.Forms.Label();
            this.salary_show = new System.Windows.Forms.Label();
            this.aggregate = new System.Windows.Forms.Label();
            this.aggregate_show = new System.Windows.Forms.Label();
            this.payroll = new System.Windows.Forms.Label();
            this.payroll_show = new System.Windows.Forms.Label();
            this.calc = new System.Windows.Forms.Button();
            this.submit = new System.Windows.Forms.Button();
            this.sex_input = new System.Windows.Forms.ComboBox();
            this.address_province_input = new System.Windows.Forms.ComboBox();
            this.address_city_input = new System.Windows.Forms.ComboBox();
            this.address_county_input = new System.Windows.Forms.ComboBox();
            this.address_detailed_input = new System.Windows.Forms.TextBox();
            this.inquire_basic = new System.Windows.Forms.Button();
            this.change_submit = new System.Windows.Forms.Button();
            this.submit_new = new System.Windows.Forms.Button();
            this.modif_inf = new System.Windows.Forms.Button();
            this.del_inf = new System.Windows.Forms.Button();
            this.inquire_finance = new System.Windows.Forms.Button();
            this.inquire_look = new System.Windows.Forms.Button();
            this.up_inf = new System.Windows.Forms.Button();
            this.bot_inf = new System.Windows.Forms.Button();
            this.menu_admin.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_admin
            // 
            this.menu_admin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mange_basic_inf,
            this.finance_inf,
            this.look_up_data,
            this.logout_system});
            resources.ApplyResources(this.menu_admin, "menu_admin");
            this.menu_admin.Name = "menu_admin";
            // 
            // mange_basic_inf
            // 
            this.mange_basic_inf.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.new_basic_inf_entry,
            this.modif_basic_inf,
            this.batch_basic_inf_entry});
            this.mange_basic_inf.Name = "mange_basic_inf";
            resources.ApplyResources(this.mange_basic_inf, "mange_basic_inf");
            // 
            // new_basic_inf_entry
            // 
            this.new_basic_inf_entry.Name = "new_basic_inf_entry";
            resources.ApplyResources(this.new_basic_inf_entry, "new_basic_inf_entry");
            this.new_basic_inf_entry.Click += new System.EventHandler(this.new_basic_inf_entry_Click);
            // 
            // modif_basic_inf
            // 
            this.modif_basic_inf.Name = "modif_basic_inf";
            resources.ApplyResources(this.modif_basic_inf, "modif_basic_inf");
            this.modif_basic_inf.Click += new System.EventHandler(this.modif_basic_inf_Click);
            // 
            // batch_basic_inf_entry
            // 
            this.batch_basic_inf_entry.Name = "batch_basic_inf_entry";
            resources.ApplyResources(this.batch_basic_inf_entry, "batch_basic_inf_entry");
            this.batch_basic_inf_entry.Click += new System.EventHandler(this.batch_basic_inf_entry_Click);
            // 
            // finance_inf
            // 
            this.finance_inf.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.finance_single_entry,
            this.finance_batch_entry});
            this.finance_inf.Name = "finance_inf";
            resources.ApplyResources(this.finance_inf, "finance_inf");
            // 
            // finance_single_entry
            // 
            this.finance_single_entry.Name = "finance_single_entry";
            resources.ApplyResources(this.finance_single_entry, "finance_single_entry");
            this.finance_single_entry.Click += new System.EventHandler(this.finance_single_entry_Click);
            // 
            // finance_batch_entry
            // 
            this.finance_batch_entry.Name = "finance_batch_entry";
            resources.ApplyResources(this.finance_batch_entry, "finance_batch_entry");
            this.finance_batch_entry.Click += new System.EventHandler(this.finance_batch_entry_Click);
            // 
            // look_up_data
            // 
            this.look_up_data.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.look_uo_id,
            this.look_up_all});
            this.look_up_data.Name = "look_up_data";
            resources.ApplyResources(this.look_up_data, "look_up_data");
            // 
            // look_uo_id
            // 
            this.look_uo_id.Name = "look_uo_id";
            resources.ApplyResources(this.look_uo_id, "look_uo_id");
            this.look_uo_id.Click += new System.EventHandler(this.look_uo_id_Click);
            // 
            // look_up_all
            // 
            this.look_up_all.Name = "look_up_all";
            resources.ApplyResources(this.look_up_all, "look_up_all");
            this.look_up_all.Click += new System.EventHandler(this.look_up_all_Click);
            // 
            // logout_system
            // 
            this.logout_system.Name = "logout_system";
            resources.ApplyResources(this.logout_system, "logout_system");
            this.logout_system.Click += new System.EventHandler(this.logout_system_Click);
            // 
            // id
            // 
            resources.ApplyResources(this.id, "id");
            this.id.Name = "id";
            // 
            // name
            // 
            resources.ApplyResources(this.name, "name");
            this.name.Name = "name";
            // 
            // sex
            // 
            resources.ApplyResources(this.sex, "sex");
            this.sex.Name = "sex";
            // 
            // organization
            // 
            resources.ApplyResources(this.organization, "organization");
            this.organization.Name = "organization";
            // 
            // address
            // 
            resources.ApplyResources(this.address, "address");
            this.address.Name = "address";
            // 
            // telephone
            // 
            resources.ApplyResources(this.telephone, "telephone");
            this.telephone.Name = "telephone";
            // 
            // base_pay
            // 
            resources.ApplyResources(this.base_pay, "base_pay");
            this.base_pay.Name = "base_pay";
            // 
            // allowance
            // 
            resources.ApplyResources(this.allowance, "allowance");
            this.allowance.Name = "allowance";
            // 
            // subsistence_allowance
            // 
            resources.ApplyResources(this.subsistence_allowance, "subsistence_allowance");
            this.subsistence_allowance.Name = "subsistence_allowance";
            // 
            // telephone_bill
            // 
            resources.ApplyResources(this.telephone_bill, "telephone_bill");
            this.telephone_bill.Name = "telephone_bill";
            // 
            // water_electricity
            // 
            resources.ApplyResources(this.water_electricity, "water_electricity");
            this.water_electricity.Name = "water_electricity";
            // 
            // the_rent
            // 
            resources.ApplyResources(this.the_rent, "the_rent");
            this.the_rent.Name = "the_rent";
            // 
            // income_tax
            // 
            resources.ApplyResources(this.income_tax, "income_tax");
            this.income_tax.Name = "income_tax";
            // 
            // sanitation_fee
            // 
            resources.ApplyResources(this.sanitation_fee, "sanitation_fee");
            this.sanitation_fee.Name = "sanitation_fee";
            // 
            // accumulation_fund
            // 
            resources.ApplyResources(this.accumulation_fund, "accumulation_fund");
            this.accumulation_fund.Name = "accumulation_fund";
            // 
            // id_input
            // 
            resources.ApplyResources(this.id_input, "id_input");
            this.id_input.Name = "id_input";
            // 
            // name_input
            // 
            resources.ApplyResources(this.name_input, "name_input");
            this.name_input.Name = "name_input";
            // 
            // organization_input
            // 
            resources.ApplyResources(this.organization_input, "organization_input");
            this.organization_input.Name = "organization_input";
            // 
            // telephone_input
            // 
            resources.ApplyResources(this.telephone_input, "telephone_input");
            this.telephone_input.Name = "telephone_input";
            // 
            // base_pay_input
            // 
            resources.ApplyResources(this.base_pay_input, "base_pay_input");
            this.base_pay_input.Name = "base_pay_input";
            // 
            // allowance_input
            // 
            resources.ApplyResources(this.allowance_input, "allowance_input");
            this.allowance_input.Name = "allowance_input";
            // 
            // subsistence_allowance_input
            // 
            resources.ApplyResources(this.subsistence_allowance_input, "subsistence_allowance_input");
            this.subsistence_allowance_input.Name = "subsistence_allowance_input";
            // 
            // telephone_bill_input
            // 
            resources.ApplyResources(this.telephone_bill_input, "telephone_bill_input");
            this.telephone_bill_input.Name = "telephone_bill_input";
            // 
            // water_electricity_input
            // 
            resources.ApplyResources(this.water_electricity_input, "water_electricity_input");
            this.water_electricity_input.Name = "water_electricity_input";
            // 
            // the_rent_input
            // 
            resources.ApplyResources(this.the_rent_input, "the_rent_input");
            this.the_rent_input.Name = "the_rent_input";
            // 
            // income_tax_input
            // 
            resources.ApplyResources(this.income_tax_input, "income_tax_input");
            this.income_tax_input.Name = "income_tax_input";
            // 
            // sanitation_fee_input
            // 
            resources.ApplyResources(this.sanitation_fee_input, "sanitation_fee_input");
            this.sanitation_fee_input.Name = "sanitation_fee_input";
            // 
            // accumulation_fund_input
            // 
            resources.ApplyResources(this.accumulation_fund_input, "accumulation_fund_input");
            this.accumulation_fund_input.Name = "accumulation_fund_input";
            // 
            // salary
            // 
            resources.ApplyResources(this.salary, "salary");
            this.salary.Name = "salary";
            // 
            // salary_show
            // 
            resources.ApplyResources(this.salary_show, "salary_show");
            this.salary_show.Name = "salary_show";
            // 
            // aggregate
            // 
            resources.ApplyResources(this.aggregate, "aggregate");
            this.aggregate.Name = "aggregate";
            // 
            // aggregate_show
            // 
            resources.ApplyResources(this.aggregate_show, "aggregate_show");
            this.aggregate_show.Name = "aggregate_show";
            // 
            // payroll
            // 
            this.payroll.AutoEllipsis = true;
            resources.ApplyResources(this.payroll, "payroll");
            this.payroll.Name = "payroll";
            // 
            // payroll_show
            // 
            resources.ApplyResources(this.payroll_show, "payroll_show");
            this.payroll_show.Name = "payroll_show";
            // 
            // calc
            // 
            resources.ApplyResources(this.calc, "calc");
            this.calc.Name = "calc";
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.calc_Click);
            // 
            // submit
            // 
            resources.ApplyResources(this.submit, "submit");
            this.submit.Name = "submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // sex_input
            // 
            this.sex_input.FormattingEnabled = true;
            resources.ApplyResources(this.sex_input, "sex_input");
            this.sex_input.Name = "sex_input";
            // 
            // address_province_input
            // 
            this.address_province_input.FormattingEnabled = true;
            resources.ApplyResources(this.address_province_input, "address_province_input");
            this.address_province_input.Name = "address_province_input";
            // 
            // address_city_input
            // 
            this.address_city_input.FormattingEnabled = true;
            resources.ApplyResources(this.address_city_input, "address_city_input");
            this.address_city_input.Name = "address_city_input";
            // 
            // address_county_input
            // 
            this.address_county_input.FormattingEnabled = true;
            resources.ApplyResources(this.address_county_input, "address_county_input");
            this.address_county_input.Name = "address_county_input";
            // 
            // address_detailed_input
            // 
            resources.ApplyResources(this.address_detailed_input, "address_detailed_input");
            this.address_detailed_input.Name = "address_detailed_input";
            // 
            // inquire_basic
            // 
            resources.ApplyResources(this.inquire_basic, "inquire_basic");
            this.inquire_basic.Name = "inquire_basic";
            this.inquire_basic.UseVisualStyleBackColor = true;
            this.inquire_basic.Click += new System.EventHandler(this.inquire_basic_Click);
            // 
            // change_submit
            // 
            resources.ApplyResources(this.change_submit, "change_submit");
            this.change_submit.Name = "change_submit";
            this.change_submit.UseVisualStyleBackColor = true;
            this.change_submit.Click += new System.EventHandler(this.change_submit_Click);
            // 
            // submit_new
            // 
            resources.ApplyResources(this.submit_new, "submit_new");
            this.submit_new.Name = "submit_new";
            this.submit_new.UseVisualStyleBackColor = true;
            this.submit_new.Click += new System.EventHandler(this.submit_new_Click);
            // 
            // modif_inf
            // 
            this.modif_inf.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.modif_inf, "modif_inf");
            this.modif_inf.Name = "modif_inf";
            this.modif_inf.UseVisualStyleBackColor = true;
            this.modif_inf.Click += new System.EventHandler(this.modif_inf_Click);
            // 
            // del_inf
            // 
            this.del_inf.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.del_inf, "del_inf");
            this.del_inf.Name = "del_inf";
            this.del_inf.UseVisualStyleBackColor = true;
            this.del_inf.Click += new System.EventHandler(this.del_inf_Click);
            // 
            // inquire_finance
            // 
            resources.ApplyResources(this.inquire_finance, "inquire_finance");
            this.inquire_finance.Name = "inquire_finance";
            this.inquire_finance.UseVisualStyleBackColor = true;
            this.inquire_finance.Click += new System.EventHandler(this.inquire_finance_Click);
            // 
            // inquire_look
            // 
            resources.ApplyResources(this.inquire_look, "inquire_look");
            this.inquire_look.Name = "inquire_look";
            this.inquire_look.UseVisualStyleBackColor = true;
            this.inquire_look.Click += new System.EventHandler(this.inquire_look_Click);
            // 
            // up_inf
            // 
            resources.ApplyResources(this.up_inf, "up_inf");
            this.up_inf.Name = "up_inf";
            this.up_inf.UseVisualStyleBackColor = true;
            this.up_inf.Click += new System.EventHandler(this.up_inf_Click);
            // 
            // bot_inf
            // 
            resources.ApplyResources(this.bot_inf, "bot_inf");
            this.bot_inf.Name = "bot_inf";
            this.bot_inf.UseVisualStyleBackColor = true;
            this.bot_inf.Click += new System.EventHandler(this.bot_inf_Click);
            // 
            // admin_windows
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bot_inf);
            this.Controls.Add(this.up_inf);
            this.Controls.Add(this.inquire_look);
            this.Controls.Add(this.inquire_finance);
            this.Controls.Add(this.del_inf);
            this.Controls.Add(this.modif_inf);
            this.Controls.Add(this.submit_new);
            this.Controls.Add(this.change_submit);
            this.Controls.Add(this.inquire_basic);
            this.Controls.Add(this.address_detailed_input);
            this.Controls.Add(this.address_county_input);
            this.Controls.Add(this.address_city_input);
            this.Controls.Add(this.address_province_input);
            this.Controls.Add(this.sex_input);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.calc);
            this.Controls.Add(this.payroll_show);
            this.Controls.Add(this.payroll);
            this.Controls.Add(this.aggregate_show);
            this.Controls.Add(this.aggregate);
            this.Controls.Add(this.salary_show);
            this.Controls.Add(this.salary);
            this.Controls.Add(this.accumulation_fund_input);
            this.Controls.Add(this.sanitation_fee_input);
            this.Controls.Add(this.income_tax_input);
            this.Controls.Add(this.the_rent_input);
            this.Controls.Add(this.water_electricity_input);
            this.Controls.Add(this.telephone_bill_input);
            this.Controls.Add(this.subsistence_allowance_input);
            this.Controls.Add(this.allowance_input);
            this.Controls.Add(this.base_pay_input);
            this.Controls.Add(this.telephone_input);
            this.Controls.Add(this.organization_input);
            this.Controls.Add(this.name_input);
            this.Controls.Add(this.id_input);
            this.Controls.Add(this.water_electricity);
            this.Controls.Add(this.the_rent);
            this.Controls.Add(this.income_tax);
            this.Controls.Add(this.sanitation_fee);
            this.Controls.Add(this.accumulation_fund);
            this.Controls.Add(this.telephone);
            this.Controls.Add(this.base_pay);
            this.Controls.Add(this.allowance);
            this.Controls.Add(this.subsistence_allowance);
            this.Controls.Add(this.telephone_bill);
            this.Controls.Add(this.address);
            this.Controls.Add(this.organization);
            this.Controls.Add(this.sex);
            this.Controls.Add(this.name);
            this.Controls.Add(this.id);
            this.Controls.Add(this.menu_admin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menu_admin;
            this.Name = "admin_windows";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menu_admin.ResumeLayout(false);
            this.menu_admin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu_admin;
        private System.Windows.Forms.ToolStripMenuItem mange_basic_inf;
        private System.Windows.Forms.ToolStripMenuItem new_basic_inf_entry;
        private System.Windows.Forms.ToolStripMenuItem modif_basic_inf;
        private System.Windows.Forms.ToolStripMenuItem finance_inf;
        private System.Windows.Forms.ToolStripMenuItem look_up_data;
        private System.Windows.Forms.ToolStripMenuItem look_uo_id;
        private System.Windows.Forms.ToolStripMenuItem look_up_all;
        private System.Windows.Forms.ToolStripMenuItem logout_system;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label sex;
        private System.Windows.Forms.Label organization;
        private System.Windows.Forms.Label address;
        private System.Windows.Forms.Label telephone;
        private System.Windows.Forms.Label base_pay;
        private System.Windows.Forms.Label allowance;
        private System.Windows.Forms.Label subsistence_allowance;
        private System.Windows.Forms.Label telephone_bill;
        private System.Windows.Forms.Label water_electricity;
        private System.Windows.Forms.Label the_rent;
        private System.Windows.Forms.Label income_tax;
        private System.Windows.Forms.Label sanitation_fee;
        private System.Windows.Forms.Label accumulation_fund;
        private System.Windows.Forms.TextBox id_input;
        private System.Windows.Forms.TextBox name_input;
        private System.Windows.Forms.TextBox organization_input;
        private System.Windows.Forms.TextBox telephone_input;
        private System.Windows.Forms.TextBox base_pay_input;
        private System.Windows.Forms.TextBox allowance_input;
        private System.Windows.Forms.TextBox subsistence_allowance_input;
        private System.Windows.Forms.TextBox telephone_bill_input;
        private System.Windows.Forms.TextBox water_electricity_input;
        private System.Windows.Forms.TextBox the_rent_input;
        private System.Windows.Forms.TextBox income_tax_input;
        private System.Windows.Forms.TextBox sanitation_fee_input;
        private System.Windows.Forms.TextBox accumulation_fund_input;
        private System.Windows.Forms.Label salary;
        private System.Windows.Forms.Label salary_show;
        private System.Windows.Forms.Label aggregate;
        private System.Windows.Forms.Label aggregate_show;
        private System.Windows.Forms.Label payroll;
        private System.Windows.Forms.Label payroll_show;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.ComboBox sex_input;
        private System.Windows.Forms.ComboBox address_province_input;
        private System.Windows.Forms.ComboBox address_city_input;
        private System.Windows.Forms.ComboBox address_county_input;
        private System.Windows.Forms.TextBox address_detailed_input;
        private System.Windows.Forms.Button inquire_basic;
        private System.Windows.Forms.Button change_submit;
        private System.Windows.Forms.ToolStripMenuItem batch_basic_inf_entry;
        private System.Windows.Forms.ToolStripMenuItem finance_single_entry;
        private System.Windows.Forms.ToolStripMenuItem finance_batch_entry;
        private System.Windows.Forms.Button submit_new;
        private System.Windows.Forms.Button modif_inf;
        private System.Windows.Forms.Button del_inf;
        private System.Windows.Forms.Button calc;
        private System.Windows.Forms.Button inquire_finance;
        private System.Windows.Forms.Button inquire_look;
        private System.Windows.Forms.Button up_inf;
        private System.Windows.Forms.Button bot_inf;
    }
}