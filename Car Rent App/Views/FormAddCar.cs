﻿using Car_Rent_App.Entities;
using ApplicationContext = Car_Rent_App.Entities.ApplicationContext;

namespace Car_Rent_App.Views
{
    public partial class FormAddCar : Form
    {
        public FormAddCar()
        {
            InitializeComponent();
        }

        private void lb_AddCar_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string brand = tb_brand.Text;
            string model = tb_Model.Text;
            string year = dateTimePicker.Value.ToUniversalTime().ToString("yyyy-MM-dd");
            string color = tbColor.Text;
            int price = Convert.ToInt32(tbPrice.Text);
            bool availability = true;

            using (ApplicationContext db = new ApplicationContext())
            {
                Car car = new Car
                {
                    Brand= brand,
                    Model= model,
                    Year= Convert.ToDateTime(year).ToUniversalTime(),
                    Color= color,
                    Price= price,
                    isAvailable= availability
                };
                await db.Cars.AddAsync(car);
                await db.SaveChangesAsync();
                MessageBox.Show("The car has added");
            }
            this.Refresh();
        }
    }
}