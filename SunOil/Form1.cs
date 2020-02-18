using MaterialSkin.Controls;
using Newtonsoft.Json;
using SunOil.Extension;
using SunOil.Model;
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



namespace SunOil
{
    public partial class SunOil : MaterialForm
    {
        GasStation gasStation = new GasStation();
        List<Report> reports = new List<Report>();

        bool petrolTypeIsSelected = false;


        double _amount = 0.0;
        public SunOil()
        {
            InitializeComponent();
        }

        private void petroltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = petroltype.SelectedIndex;
            TotalPetrolPrice.Text = gasStation.Petrol[index].Price.ToString();
            petrolpricetxtbox.Text = gasStation.Petrol[index].Price.ToString();


            _amount = gasStation.Petrol[index].Price;



            if (hotdogcheck.Checked)
            {
                _amount += (Convert.ToDouble(hotdogprice.Text) * Convert.ToDouble(hotdogcount.Text));
            }
            if (hamburgercheck.Checked)
            {
                _amount += (Convert.ToDouble(hamprice.Text) * Convert.ToDouble(hamcount.Text));
            }
            if (potatofricheck.Checked)
            {
                _amount += (Convert.ToDouble(potatoprice.Text) * Convert.ToDouble(fricount.Text));
            }
            if (colacheck.Checked)
            {
                _amount += (Convert.ToDouble(colaprice.Text) * Convert.ToDouble(colacount.Text));
            }


            moneyr.Enabled = true;
            unitr.Enabled = true;
            petrolTypeIsSelected = true;
            TotalGSPrice.Text = _amount.ToString();


        }

        private void SunOil_Load(object sender, EventArgs e)
        {
            TotalGSPrice.Text = "0.0";

            hotdogprice.Text = gasStation.miniCafe.Food[0].Price.ToString();
            hamprice.Text = gasStation.miniCafe.Food[1].Price.ToString();
            potatoprice.Text = gasStation.miniCafe.Food[2].Price.ToString();
            colaprice.Text = gasStation.miniCafe.Food[3].Price.ToString();

        //    var str = File.ReadAllText("Reports.json");
         //   reports = JsonConvert.DeserializeObject<List<Report>>(str);

        }

        private void BuyingType_CheckedChanged(object sender, EventArgs e)
        {
            var type = sender as RadioButton;

            switch (type.Name)
            {
                case "moneyr":
                    {
                        if (moneyr.Checked)
                        {
                            mtextbox.Enabled = true;
                            unitbox.Enabled = false;
                            unitbox.Text = "0";
                        }

                        break;
                    }
                case "unitr":
                    {
                        if (unitr.Checked)
                        {
                            unitbox.Enabled = true;
                            mtextbox.Enabled = false;
                            mtextbox.Text = "0";
                        }
                        break;

                    }
            }

        }

        private void BuyingTypeTextBox_TextChanged(object sender, EventArgs e)
        {
            var type = sender as TextBox;

            switch (type.Name)
            {
                case "mtextbox":
                    {
                        if (!unitr.Checked)
                        {
                            _amount = Convert.ToDouble(mtextbox.Text);
                        }
                        else
                        {
                            _amount = Convert.ToDouble(unitbox.Text) * Convert.ToDouble(petrolpricetxtbox.Text);
                            mtextbox.Text = "0";
                        }
                        break;
                    }
                case "unitbox":
                    {
                        if (!moneyr.Checked)
                        {
                            TotalPetrolPrice.Text = (_amount = Convert.ToDouble(unitbox.Text) * Convert.ToDouble(petrolpricetxtbox.Text)).ToString();

                        }
                        else
                        {
                            _amount = Convert.ToDouble(mtextbox.Text);
                            unitbox.Text = "0";
                        }

                        break;
                    }

            }

            TotalPetrolPrice.Text = _amount.ToString();

            if (hotdogcheck.Checked)
            {
                _amount += (Convert.ToDouble(hotdogprice.Text) * Convert.ToDouble(hotdogcount.Text));
            }
            if (hamburgercheck.Checked)
            {
                _amount += (Convert.ToDouble(hamprice.Text) * Convert.ToDouble(hamcount.Text));
            }
            if (potatofricheck.Checked)
            {
                _amount += (Convert.ToDouble(potatoprice.Text) * Convert.ToDouble(fricount.Text));
            }
            if (colacheck.Checked)
            {
                _amount += (Convert.ToDouble(colaprice.Text) * Convert.ToDouble(colacount.Text));
            }
            TotalGSPrice.Text = _amount.ToString();
        }

        private void itemcheck_CheckedChanged(object sender, EventArgs e)
        {
            var item = sender as CheckBox;

            switch (item.Name)
            {
                case "hotdogcheck":
                    {
                        if (hotdogcheck.Checked)
                        {
                            hotdogcount.Text = "1";
                            _amount = gasStation.miniCafe.Food[0].Price;
                            if (hamburgercheck.Checked)
                            {
                                _amount += (Convert.ToDouble(hamprice.Text) * Convert.ToDouble(hamcount.Text));
                            }
                            if (potatofricheck.Checked)
                            {
                                _amount += (Convert.ToDouble(potatoprice.Text) * Convert.ToDouble(fricount.Text));
                            }
                            if (colacheck.Checked)
                            {
                                _amount += (Convert.ToDouble(colaprice.Text) * Convert.ToDouble(colacount.Text));
                            }
                            decreaseHotDog.Enabled = true;
                            increaseHotdog.Enabled = true;
                            hotdogcount.Enabled = true;
                        }
                        else
                        {
                            _amount = 0;
                            if (hamburgercheck.Checked)
                            {
                                _amount += (Convert.ToDouble(hamprice.Text) * Convert.ToDouble(hamcount.Text));
                            }
                            if (potatofricheck.Checked)
                            {
                                _amount += (Convert.ToDouble(potatoprice.Text) * Convert.ToDouble(fricount.Text));
                            }
                            if (colacheck.Checked)
                            {
                                _amount += (Convert.ToDouble(colaprice.Text) * Convert.ToDouble(colacount.Text));
                            }
                            hotdogcount.Text = "1";
                            gasStation.miniCafe.Food[0].Count = 1;
                            decreaseHotDog.Enabled = false;
                            increaseHotdog.Enabled = false;
                            hotdogcount.Enabled = false;
                        }
                        TotalCafePrice.Text = _amount.ToString();

                        break;
                    }
                case "hamburgercheck":
                    {
                        if (hamburgercheck.Checked)
                        {
                            hamcount.Text = "1";
                            _amount = gasStation.miniCafe.Food[1].Price;
                            if (hotdogcheck.Checked)
                            {
                                _amount += (Convert.ToDouble(hotdogprice.Text) * Convert.ToDouble(hotdogcount.Text));
                            }
                            if (potatofricheck.Checked)
                            {
                                _amount += (Convert.ToDouble(potatoprice.Text) * Convert.ToDouble(fricount.Text));
                            }
                            if (colacheck.Checked)
                            {
                                _amount += (Convert.ToDouble(colaprice.Text) * Convert.ToDouble(colacount.Text));
                            }
                            decreaseHamburger.Enabled = true;
                            increaseHamburger.Enabled = true;
                            hamcount.Enabled = true;
                        }
                        else
                        {
                            _amount = 0;
                            if (hotdogcheck.Checked)
                            {
                                _amount += (Convert.ToDouble(hotdogprice.Text) * Convert.ToDouble(hotdogcount.Text));
                            }
                            if (potatofricheck.Checked)
                            {
                                _amount += (Convert.ToDouble(potatoprice.Text) * Convert.ToDouble(fricount.Text));
                            }
                            if (colacheck.Checked)
                            {
                                _amount += (Convert.ToDouble(colaprice.Text) * Convert.ToDouble(colacount.Text));
                            }
                            hamcount.Text = "1";
                            gasStation.miniCafe.Food[1].Count = 1;
                            decreaseHamburger.Enabled = false;
                            increaseHamburger.Enabled = false;
                            hamcount.Enabled = false;
                        }
                        TotalCafePrice.Text = _amount.ToString();
                        break;
                    }
                case "potatofricheck":
                    {
                        if (potatofricheck.Checked)
                        {
                            fricount.Text = "1";
                            _amount = gasStation.miniCafe.Food[2].Price;
                            if (hotdogcheck.Checked)
                            {
                                _amount += (Convert.ToDouble(hotdogprice.Text) * Convert.ToDouble(hotdogcount.Text));
                            }
                            if (hamburgercheck.Checked)
                            {
                                _amount += (Convert.ToDouble(hamprice.Text) * Convert.ToDouble(hamcount.Text));
                            }
                            if (colacheck.Checked)
                            {
                                _amount += (Convert.ToDouble(colaprice.Text) * Convert.ToDouble(colacount.Text));
                            }
                            decreaseFri.Enabled = true;
                            increaseFri.Enabled = true;
                            fricount.Enabled = true;
                        }
                        else
                        {
                            _amount = 0;
                            if (hotdogcheck.Checked)
                            {
                                _amount += (Convert.ToDouble(hotdogprice.Text) * Convert.ToDouble(hotdogcount.Text));
                            }
                            if (hamburgercheck.Checked)
                            {
                                _amount += (Convert.ToDouble(hamprice.Text) * Convert.ToDouble(hamcount.Text));
                            }
                            if (colacheck.Checked)
                            {
                                _amount += (Convert.ToDouble(colaprice.Text) * Convert.ToDouble(colacount.Text));
                            }
                            fricount.Text = "1";
                            gasStation.miniCafe.Food[3].Count = 1;
                            decreaseFri.Enabled = false;
                            increaseFri.Enabled = false;
                            fricount.Enabled = false;
                        }
                        TotalCafePrice.Text = _amount.ToString();

                        break;
                    }
                case "colacheck":
                    {
                        if (colacheck.Checked)
                        {
                            colacount.Text = "1";
                            _amount = gasStation.miniCafe.Food[3].Price;
                            if (hotdogcheck.Checked)
                            {
                                _amount += (Convert.ToDouble(hotdogprice.Text) * Convert.ToDouble(hotdogcount.Text));
                            }
                            if (hamburgercheck.Checked)
                            {
                                _amount += (Convert.ToDouble(hamprice.Text) * Convert.ToDouble(hamcount.Text));
                            }
                            if (potatofricheck.Checked)
                            {
                                _amount += (Convert.ToDouble(potatoprice.Text) * Convert.ToDouble(fricount.Text));
                            }

                            decreaseCola.Enabled = true;
                            increaseCola.Enabled = true;
                            colacount.Enabled = true;
                        }
                        else
                        {
                            _amount = 0;
                            if (hotdogcheck.Checked)
                            {
                                _amount += (Convert.ToDouble(hotdogprice.Text) * Convert.ToDouble(hotdogcount.Text));
                            }
                            if (hamburgercheck.Checked)
                            {
                                _amount += (Convert.ToDouble(hamprice.Text) * Convert.ToDouble(hamcount.Text));
                            }
                            if (potatofricheck.Checked)
                            {
                                _amount += (Convert.ToDouble(potatoprice.Text) * Convert.ToDouble(fricount.Text));
                            }

                            fricount.Text = "1";
                            gasStation.miniCafe.Food[3].Count = 1;
                            decreaseCola.Enabled = false;
                            increaseCola.Enabled = false;
                            colacount.Enabled = false;
                        }
                        TotalCafePrice.Text = _amount.ToString();

                        break;
                    }

            }
            //   if (hotdogcheck.Checked)
            // {
            if (TotalPetrolPrice.Text != "0,0" || TotalPetrolPrice.Text != "0")
            {
                _amount += Convert.ToDouble(TotalPetrolPrice.Text);
            }
            // }



            TotalGSPrice.Text = _amount.ToString();
        }

        private void increaseItemPrice_Click(object sender, EventArgs e)
        {
            var inc = sender as Button;


            switch (inc.Name)
            {
                case "increaseHotdog":
                    {
                        hotdogcount.Text = (++gasStation.miniCafe.Food[0].Count).ToString();


                        _amount = (Convert.ToDouble(hotdogprice.Text) * Convert.ToInt32(hotdogcount.Text));
                        if (hamburgercheck.Checked)
                        {
                            _amount += (Convert.ToDouble(hamprice.Text) * Convert.ToDouble(hamcount.Text));
                        }
                        if (potatofricheck.Checked)
                        {
                            _amount += (Convert.ToDouble(potatoprice.Text) * Convert.ToDouble(fricount.Text));
                        }
                        if (colacheck.Checked)
                        {
                            _amount += (Convert.ToDouble(colaprice.Text) * Convert.ToDouble(colacount.Text));
                        }

                        break;
                    }
                case "increaseHamburger":
                    {
                        hamcount.Text = (++gasStation.miniCafe.Food[1].Count).ToString();

                        _amount = (Convert.ToDouble(hamprice.Text) * Convert.ToInt32(hamcount.Text));

                        if (hotdogcheck.Checked)
                        {
                            _amount += (Convert.ToDouble(hotdogprice.Text) * Convert.ToDouble(hotdogcount.Text));
                        }
                        if (potatofricheck.Checked)
                        {
                            _amount += (Convert.ToDouble(potatoprice.Text) * Convert.ToDouble(fricount.Text));
                        }
                        if (colacheck.Checked)
                        {
                            _amount += (Convert.ToDouble(colaprice.Text) * Convert.ToDouble(colacount.Text));
                        }
                        break;
                    }
                case "increaseFri":
                    {
                        fricount.Text = (++gasStation.miniCafe.Food[2].Count).ToString();

                        _amount = (Convert.ToDouble(potatoprice.Text) * Convert.ToInt32(fricount.Text));

                        if (hotdogcheck.Checked)
                        {
                            _amount += (Convert.ToDouble(hotdogprice.Text) * Convert.ToDouble(hotdogcount.Text));
                        }
                        if (hamburgercheck.Checked)
                        {
                            _amount += (Convert.ToDouble(hamprice.Text) * Convert.ToDouble(hamcount.Text));
                        }
                        if (colacheck.Checked)
                        {
                            _amount += (Convert.ToDouble(colaprice.Text) * Convert.ToDouble(colacount.Text));
                        }
                        break;
                    }
                case "increaseCola":
                    {
                        colacount.Text = (++gasStation.miniCafe.Food[3].Count).ToString();

                        _amount = (Convert.ToDouble(colaprice.Text) * Convert.ToInt32(colacount.Text));

                        if (hotdogcheck.Checked)
                        {
                            _amount += (Convert.ToDouble(hotdogprice.Text) * Convert.ToDouble(hotdogcount.Text));
                        }
                        if (hamburgercheck.Checked)
                        {
                            _amount += (Convert.ToDouble(hamprice.Text) * Convert.ToDouble(hamcount.Text));
                        }
                        if (potatofricheck.Checked)
                        {
                            _amount += (Convert.ToDouble(potatoprice.Text) * Convert.ToDouble(fricount.Text));
                        }
                        break;
                    }
            }
            TotalCafePrice.Text = _amount.ToString();
            if (TotalPetrolPrice.Text != "0,0" || TotalPetrolPrice.Text != "0")
            {
                _amount += Convert.ToDouble(TotalPetrolPrice.Text);
            }

            TotalGSPrice.Text = _amount.ToString();

        }

        private void DecreaseItemPrice_Click(object sender, EventArgs e)
        {
            var dec = sender as Button;


            switch (dec.Name)
            {
                case "decreaseHotDog":
                    {
                        if (gasStation.miniCafe.Food[0].Count - 1 > 0)
                        {
                            hotdogcount.Text = (--gasStation.miniCafe.Food[0].Count).ToString();
                        }

                        _amount = (Convert.ToDouble(hotdogprice.Text) * Convert.ToDouble(hotdogcount.Text));

                        if (hamburgercheck.Checked)
                        {
                            _amount += (Convert.ToDouble(hamprice.Text) * Convert.ToDouble(hamcount.Text));
                        }
                        if (potatofricheck.Checked)
                        {
                            _amount += (Convert.ToDouble(potatoprice.Text) * Convert.ToDouble(fricount.Text));
                        }
                        if (colacheck.Checked)
                        {
                            _amount += (Convert.ToDouble(colaprice.Text) * Convert.ToDouble(colacount.Text));
                        }

                        break;
                    }
                case "decreaseHamburger":
                    {
                        if (gasStation.miniCafe.Food[1].Count - 1 > 0)
                        {
                            hamcount.Text = (--gasStation.miniCafe.Food[1].Count).ToString();
                        }

                        _amount = (Convert.ToDouble(hamprice.Text) * Convert.ToDouble(hamcount.Text));

                        if (hotdogcheck.Checked)
                        {
                            _amount += (Convert.ToDouble(hotdogprice.Text) * Convert.ToDouble(hotdogcount.Text));
                        }
                        if (potatofricheck.Checked)
                        {
                            _amount += (Convert.ToDouble(potatoprice.Text) * Convert.ToDouble(fricount.Text));
                        }
                        if (colacheck.Checked)
                        {
                            _amount += (Convert.ToDouble(colaprice.Text) * Convert.ToDouble(colacount.Text));
                        }
                        break;
                    }
                case "decreaseFri":
                    {
                        if (gasStation.miniCafe.Food[2].Count - 1 > 0)
                        {
                            fricount.Text = (--gasStation.miniCafe.Food[2].Count).ToString();
                        }

                        _amount = (Convert.ToDouble(potatoprice.Text) * Convert.ToDouble(fricount.Text));

                        if (hotdogcheck.Checked)
                        {
                            _amount += (Convert.ToDouble(hotdogprice.Text) * Convert.ToDouble(hotdogcount.Text));
                        }
                        if (hamburgercheck.Checked)
                        {
                            _amount += (Convert.ToDouble(hamprice.Text) * Convert.ToDouble(hamcount.Text));
                        }
                        if (colacheck.Checked)
                        {
                            _amount += (Convert.ToDouble(colaprice.Text) * Convert.ToDouble(colacount.Text));
                        }
                        break;
                    }
                case "decreaseCola":
                    {
                        if (gasStation.miniCafe.Food[3].Count - 1 > 0)
                        {
                            colacount.Text = (--gasStation.miniCafe.Food[3].Count).ToString();
                        }

                        _amount = (Convert.ToDouble(colaprice.Text) * Convert.ToDouble(colacount.Text));

                        if (hotdogcheck.Checked)
                        {
                            _amount += (Convert.ToDouble(hotdogprice.Text) * Convert.ToDouble(hotdogcount.Text));
                        }
                        if (hamburgercheck.Checked)
                        {
                            _amount += (Convert.ToDouble(hamprice.Text) * Convert.ToDouble(hamcount.Text));
                        }
                        if (potatofricheck.Checked)
                        {
                            _amount += (Convert.ToDouble(potatoprice.Text) * Convert.ToDouble(fricount.Text));
                        }

                        break;
                    }
            }
            TotalCafePrice.Text = _amount.ToString();
            if (TotalPetrolPrice.Text != "0,0" || TotalPetrolPrice.Text != "0")
            {
                _amount += Convert.ToDouble(TotalPetrolPrice.Text);
            }

            TotalGSPrice.Text = _amount.ToString();

        }

        private void payBtn_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.foodWithTotalPrice = new Dictionary<Food, double>();
            if (petroltype.SelectedIndex > -1)
            {

                if (petroltype.SelectedItem.ToString() == "BioDiesel")
                {

                    report.petrolType = PetrolType.BioDiesel;
                }
                else if (petroltype.SelectedItem.ToString() == "Diesel")
                {
                    report.petrolType = PetrolType.Diesel;
                }
                else if (petroltype.SelectedItem.ToString() == "LPG")
                {
                    report.petrolType = PetrolType.LPG;
                }

                report.Price = Convert.ToDouble(petrolpricetxtbox.Text);

                if (moneyr.Checked)
                {
                    report.Unit = $"${mtextbox.Text}";
                }
                if (unitr.Checked)
                {
                    report.Unit = $"{unitbox.Text}L";
                }

                report.TotalPetrolPrice = Convert.ToDouble(TotalPetrolPrice.Text);
            }



            if (hotdogcheck.Checked)
            {
                report.foodWithTotalPrice.Add(new Food { Name = "HotDog", Count = Convert.ToInt32(hotdogcount.Text), Price = gasStation.miniCafe.Food[0].Price }, Convert.ToDouble(hotdogprice.Text) * Convert.ToInt32(hotdogcount.Text));
            }
            if (hamburgercheck.Checked)
            {
                report.foodWithTotalPrice.Add(new Food { Name = "Hamburger", Count = Convert.ToInt32(hamcount.Text), Price = gasStation.miniCafe.Food[1].Price }, Convert.ToDouble(hamprice.Text) * Convert.ToInt32(hamcount.Text));
            }
            if (potatofricheck.Checked)
            {
                report.foodWithTotalPrice.Add(new Food { Name = "PotatoFri", Count = Convert.ToInt32(fricount.Text), Price = gasStation.miniCafe.Food[2].Price }, Convert.ToDouble(potatoprice.Text) * Convert.ToInt32(fricount.Text));
            }
            if (colacheck.Checked)
            {
                report.foodWithTotalPrice.Add(new Food { Name = "Cola", Count = Convert.ToInt32(colacount.Text), Price = gasStation.miniCafe.Food[3].Price }, Convert.ToDouble(colaprice.Text) * Convert.ToInt32(colacount.Text));
            }

            report.TotalCafePrice = TotalCafePrice.Text;
            report.BuyingDate = DateTime.Now;
            report.TotalGSPrice = TotalGSPrice.Text;

            reports.Add(report);

            var json = JsonConvert.SerializeObject(reports, Formatting.Indented);
            File.WriteAllText("Reports.json", json);


        }
    }
}




